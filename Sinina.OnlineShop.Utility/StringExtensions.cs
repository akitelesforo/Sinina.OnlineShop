using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace Sinina.OnlineShop.Utility
{
    /// <summary>
    /// Extension methods for String class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Formats string with specified parameters.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string Set(this string format, params object[] parameters)
        {
            return string.Format(format, parameters);
        }

        /// <summary>
        /// Checks if string is a valid URL.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsUrl(this string url)
        {
            string strRegex = "^(https?://)"
            + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //user@
            + @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184
            + "|" // allows either IP or domain
            + @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www.
            + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // second level domain
            + "[a-z]{2,6})" // first level domain- .com or .museum
            + "(:[0-9]{1,4})?" // port number- :80
            + "((/?)|" // a slash isn't required if there is no file name
            + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
            Regex regex = new Regex(strRegex);

            return regex.IsMatch(url);

        }

        /// <summary>
        /// Checks if string is a valid e-mail address.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsEmail(this string email)
        {
            Regex regex = new Regex(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                  + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                            [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                  + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                            [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                  + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$");

            return regex.IsMatch(email);
        }

        /// <summary>
        /// Checks if string is a valid IP address.
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <returns></returns>
        public static bool IsIPAddress(this string ipaddress)
        {
            Regex regex = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");

            if (regex.IsMatch(ipaddress))
            {
                var values = ipaddress.Split('.');

                foreach (var value in values)
                {
                    try
                    {
                        if (int.Parse(value) > 255)
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if string is null, empty, or blank spaces.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNullOrEmptyOrBlank(this string input)
        {
            //return string.IsNullOrEmpty(input) || string.IsNullOrEmpty(input.Trim());
            return string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// Checks if the string is valid integer.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsInteger(this string s)
        {
            Regex regExp = new Regex("^-[0-9]+$|^[0-9]+$");
            return regExp.Match(s).Success;
        }


        /// <summary>
        /// Converts string to integer.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int ToInt(this string input)
        {
            try
            {
                return int.Parse(input);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Converts string to decimal.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string input)
        {
            try
            {
                return decimal.Parse(input);
            }
            catch
            {
                return 0m;
            }
        }

        /// <summary>
        /// Converts string to decimal.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double ToDouble(this string input)
        {
            try
            {
                return double.Parse(input);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets a substring of a string for max length of characters
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns>string</returns>
        public static string SubStr(this string input, int length)
        {
            int ilength = input.Length;
            if (length > ilength) length = ilength;
            return input.Substring(0, length);
        }

        /// <summary>
        /// Converts string to DateTime.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string input)
        {
            try
            {
                return DateTime.Parse(input);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Extract numeric characters only
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string NumbersOnly(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            else
                return Regex.Replace(input, @"[^0-9]", string.Empty);
        }

        /// <summary>
        /// Converts string to boolean.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ToBoolean(this string input)
        {
            try
            {
                return bool.Parse(input);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Converts JSON string to object type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        //public static T FromJson<T>(this string json)
        //{
        //    JavaScriptSerializer ser = new JavaScriptSerializer();
        //    T result = ser.Deserialize<T>(json.Replace("__type", "type"));

        //    return result;
        //}

        /// <summary>
        /// Converts string array to JSON string.
        /// </summary>
        /// <param name="stringArray"></param>
        /// <returns></returns>
        //public static string ToJson(this string[] stringArray)
        //{
        //    #region -- Custom Implementation --
        //    var sb = new StringBuilder();

        //    sb.Append("[");

        //    foreach (var item in stringArray)
        //    {
        //        if (sb.Length > 1)
        //        {
        //            sb.Append(",");
        //        }

        //        sb.Append("\"{0}\"".Set(item));
        //    }

        //    sb.Append("]");

        //    return sb.ToString();
        //    #endregion
        //}

        public static bool IsEqual(this string input1, string input2, bool ignoreCase)
        {
            if (input1 != null && input2 != null)
            {
                return string.Compare(input1.Trim(), input2.Trim(), ignoreCase) == 0;
            }
            else
            {
                return false;
            }
        }

        public static string ToShortDateString(this object input)
        {
            return ToShortDateString(input, string.Empty);
        }

        public static string ToShortDateString(this object input, string format)
        {
            try
            {
                if (string.IsNullOrEmpty(format))
                    return Convert.ToDateTime(input).ToShortDateString();
                else
                    return Convert.ToDateTime(input).ToString(format);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string ToDecimalFormattedString(this object input)
        {
            return ToDecimalFormattedString(input, null);
        }

        public static string ToDecimalFormattedString(this object input, string format)
        {
            try
            {
                string fs = (!string.IsNullOrEmpty(format)) ? format : "n";
                return Convert.ToDecimal(input).ToString(fs);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static DateTime MakeDate(this string date)
        {
            var dtDate = date.ToDateTime();
            return dtDate.HasValue ? dtDate.Value : DateTime.Now;
        }

        public static string MakeShortDate(this string date)
        {
            var dt = DateTime.Now;

            try
            {
                DateTime.TryParse(date, out dt);
            }
            catch
            {
                return string.Empty;
            }

            return dt.ToString("MM/dd/yy");
        }

        public static List<string> ConvertStringToListofString(this string data, char delimeter)
        {
            string[] strMessageProp = data.Split(delimeter);
            return strMessageProp.ToList();
        }

        public static int[] GetCompoundKeyValues(this string input)
        {
            return GetCompoundKeyValues(input, 0);
        }

        public static int[] GetCompoundKeyValues(this string input, int numberOfKeys)
        {
            var values = new List<int>();

            for (var i = 0; i < numberOfKeys; i++)
            {
                values.Add(0);
            }

            var idValues = input.IsNullOrEmptyOrBlank() ? new string[] { } : input.Split('-');

            for (var i = 0; i < idValues.Length; i++)
            {
                if (values.Count() > i)
                {
                    values[i] = idValues[i].ToInt();
                }
                else
                {
                    values.Add(idValues[i].ToInt());
                }

            }
            return values.ToArray();
        }

        public static bool IsXml(this string input)
        {
            var valid = true;

            try
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(input);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

        // string extension method ToUpperFirstLetter
        public static string ToUpperFirstLetter(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            // convert first all characters to small letter
            var toLower = source.ToLower();
            // convert to char array of the string
            char[] letters = toLower.ToCharArray();
            // upper case the first char
            letters[0] = char.ToUpper(letters[0]);
            // return the array made of the new char array
            return new string(letters);
        }

        public static string ReplaceApostrophe(this string value)
        {
            if (value.Contains("'"))
            {
                value = value.Replace("'", "''");
            }

            return value;
        }

        public static bool IsAlphaNumeric(this string s)
        {
            Regex regExp = new Regex("^[a-zA-Z0-9]*$");
            return regExp.Match(s).Success;
        }

        public static string ToShortMonthString(this int value)
        {
            DateTime date = new DateTime(2000, value, 1);
            return date.ToString("MMM");
        }

        public static string ToLongMonthString(this int value)
        {
            DateTime date = new DateTime(2000, value, 1);
            return date.ToString("MMMM");
        }

        public static string ToPercentString(this int value, int totalValue)
        {
            return (((float)value / (float)totalValue) * 100).ToString("n") + "%";
        }
    }
}
