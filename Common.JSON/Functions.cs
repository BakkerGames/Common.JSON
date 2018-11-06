// Functions.cs - 11/06/2018

// 06/06/2018 - SBakker
//            - Added function NormalizeDecimal() to return deterministic string values
//              for decimal inputs.
// 05/31/2018 - SBakker
//            - Skip non-standard comments as whitespace. Only used for reading,
//              so can comment out lines in config.json files or whatever. Ignores
//              any text in // to eol and /* to */. If end of file is found, that
//              is fine and just ends the comment. This breaks the implementation
//              by not throwing an error if the comments are found, but that seems
//              a reasonable trade-off.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Common.JSON
{
    static internal class Functions
    {
        internal static int IndentSize = 2;
        internal static CultureInfo decimalCulture = CultureInfo.CreateSpecificCulture("en-US");

        internal static Stack<char> _charStack = new Stack<char>();

        internal static char PeekNextChar(object input, ref int pos)
        {
            if (_charStack.Count > 0)
            {
                return _charStack.Peek();
            }
            if (input.GetType() == typeof(string))
            {
                return ((string)input)[pos];
            }
            else if (input.GetType() == typeof(TextReader))
            {
                int result = ((TextReader)input).Peek();
                if (result < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return (char)result;
            }
            else
            {
                throw new SystemException($"Unknown type: {input.GetType()}");
            }
        }

        internal static char ReadNextChar(object input, ref int pos)
        {
            if (_charStack.Count > 0)
            {
                return _charStack.Pop();
            }
            if (input.GetType() == typeof(string))
            {
                return ((string)input)[pos++];
            }
            else if (input.GetType() == typeof(TextReader))
            {
                int result = ((TextReader)input).Read();
                if (result < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                pos++; // use as a counter
                return (char)result;
            }
            else
            {
                throw new SystemException($"Unknown type: {input.GetType()}");
            }
        }

        internal static void PushLastChar(char c)
        {
            _charStack.Push(c);
        }

        internal static bool IsEOL(object input, ref int pos)
        {
            if (_charStack.Count > 0)
            {
                return false;
            }
            if (input.GetType() == typeof(string))
            {
                return ((string)input).Length >= pos;
            }
            else if (input.GetType() == typeof(TextReader))
            {
                int result = ((TextReader)input).Peek();
                return (result < 0);
            }
            else
            {
                throw new SystemException($"Unknown type: {input.GetType()}");
            }
        }

        internal static void SkipWhitespace(object input, ref int pos)
        {
            char currChar;
            while (true)
            {
                if (IsEOL(input, ref pos))
                {
                    break;
                }
                try
                {
                    currChar = PeekNextChar(input, ref pos);
                }
                catch (Exception)
                {
                    break;
                }
                // use c# definition of whitespace
                if (char.IsWhiteSpace(currChar))
                {
                    pos++;
                    continue;
                }
                // check for comments
                if (currChar == '/')
                {
                    char nextChar = ReadNextChar(input, ref pos);
                    if (nextChar == '/') // to eol
                    {

                    }
                    else if (nextChar == '*') // to */
                    {

                    }
                    else
                    {

                    }
                }
                if (pos + 1 < input.Length && input[pos] == '/' && input[pos + 1] == '/')
                {
                    pos = pos + 2;
                    while (pos < input.Length)
                    {
                        if (input[pos] == '\r' || input[pos] == '\n')
                        {
                            pos++;
                            break;
                        }
                        pos++;
                    }
                    continue;
                }
                // allow non-standard comment, /* to */
                if (pos + 1 < input.Length && input[pos] == '/' && input[pos + 1] == '*')
                {
                    pos = pos + 2;
                    while (pos < input.Length)
                    {
                        if (input[pos - 1] == '*' && input[pos] == '/')
                        {
                            pos++;
                            break;
                        }
                        pos++;
                    }
                    continue;
                }
                break;
            }
        }

        /// <summary>
        /// Expects "pos" to be first char of string after initial quote
        /// </summary>
        internal static string GetStringValue(string input, ref int pos)
        {
            StringBuilder value = new StringBuilder();
            char c;
            bool lastWasSlash = false;
            while (pos < input.Length)
            {
                // get next char
                c = input[pos];
                pos++;
                // handle string value
                if (!lastWasSlash && c == '\\') // slashed char
                {
                    lastWasSlash = true;
                    continue;
                }
                if (lastWasSlash) // here is the slashed char
                {
                    lastWasSlash = false;
                    string escapedChar;
                    if (c == 'u')
                    {
                        if (pos + 4 > input.Length)
                        {
                            // doesn't have four hex chars after "u"
                            throw new SystemException("Invalid escaped char sequence");
                        }
                        escapedChar = FromUnicodeChar("\\u" + input[pos] + input[pos + 1] + input[pos + 2] + input[pos + 3]);
                        pos = pos + 4;
                    }
                    else
                    {
                        escapedChar = FromEscapedChar(c);
                    }
                    value.Append(escapedChar);
                    continue;
                }
                if (c == '\"') // end of string
                {
                    return value.ToString();
                }
                // any other char in a string
                value.Append(c);
                continue;
            }
            // incorrect syntax!
            throw new SystemException("Incorrect syntax");
        }

        internal static string ToJsonString(string input)
        {
            // handle escaping of special chars here
            StringBuilder result = new StringBuilder();
            int pos = 0;
            char c;
            while (pos < input.Length)
            {
                c = input[pos];
                pos++;
                if (c == '\\')
                {
                    result.Append("\\\\");
                }
                else if (c == '\"')
                {
                    result.Append("\\\"");
                }
                else if (c == '\r')
                {
                    result.Append("\\r");
                }
                else if (c == '\n')
                {
                    result.Append("\\n");
                }
                else if (c == '\t')
                {
                    result.Append("\\t");
                }
                else if (c == '\b')
                {
                    result.Append("\\b");
                }
                else if (c == '\f')
                {
                    result.Append("\\f");
                }
                else if (c < 32 || c == 127 || c == 129 || c == 141 || c == 143 ||
                         c == 144 || c == 157 || c == 160 || c == 173 || c > 255)
                {
                    // ascii control chars, unused chars, or unicode chars
                    result.Append(string.Format("\\u{0:x4}", (int)c));
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        internal static bool IsNumericType(object value)
        {
            if (value == null)
            {
                return false;
            }
            Type t = value.GetType();
            switch (Type.GetTypeCode(t))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return true;
                case TypeCode.Object:
                    if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return IsNumericType(Nullable.GetUnderlyingType(t));
                    }
                    return false;
            }
            return false;
        }

        internal static bool IsDecimalType(object value)
        {
            if (value == null)
            {
                return false;
            }
            Type t = value.GetType();
            switch (Type.GetTypeCode(t))
            {
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return true;
                case TypeCode.Object:
                    if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return IsDecimalType(Nullable.GetUnderlyingType(t));
                    }
                    return false;
            }
            return false;
        }

        internal static string FromEscapedChar(char c)
        {
            string result;
            switch (c)
            {
                case '"':
                    result = "\"";
                    break;
                case '\\':
                    result = "\\";
                    break;
                case '/':
                    result = "/";
                    break;
                case 'b':
                    result = "\b";
                    break;
                case 'f':
                    result = "\f";
                    break;
                case 'n':
                    result = "\n";
                    break;
                case 'r':
                    result = "\r";
                    break;
                case 't':
                    result = "\t";
                    break;
                default:
                    // escaped unicode (\uXXXX) is handled in FromUnicodeChar()
                    throw new System.Exception($"Unknown escaped char: \"\\{c}\"");
            }
            return result;
        }

        internal static string FromUnicodeChar(string value)
        {
            string result;
            // value should be in the exact format "\u####", where # is a hex digit
            if (string.IsNullOrEmpty(value) || value.Length != 6)
            {
                throw new System.Exception($"Unknown unicode char: \"{value}\"");
            }
            result = Convert.ToChar(Convert.ToUInt16(value.Substring(2, 4), 16)).ToString();
            return result;
        }

        internal static string NormalizeDecimal(string value)
        {
            decimal tempValue;
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            if (!decimal.TryParse(value, out tempValue))
            {
                throw new SystemException($"Cannot parse as decimal: \"{value}\"");
            }
            return NormalizeDecimal(tempValue);
        }

        internal static string NormalizeDecimal(decimal value)
        {
            string result;
            result = value.ToString(decimalCulture);
            if (result.IndexOf('.') >= 0)
            {
                while (result.Length > 0)
                {
                    if (result.EndsWith(".")) // remove trailing decimal point
                    {
                        result = result.Substring(0, result.Length - 1);
                        break; // done
                    }
                    if (result.EndsWith("0")) // remove trailing zero decimal digits
                    {
                        result = result.Substring(0, result.Length - 1);
                        continue;
                    }
                    break;
                }
            }
            return result;
        }
    }
}
