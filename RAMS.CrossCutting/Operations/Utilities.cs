// ***********************************************************************
// Assembly         : RAMS.CrossCutting
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="CommonUtilities.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Xml.Serialization;

namespace RAMS.CrossCutting
{
    /// <summary>
    /// Class CommonUtilities.
    /// </summary>
    public class Utilities
    {
        /// <summary>Gets information describing the NIC name.</summary>
        /// <value>Information describing the NIC name.</value>
        public static SecureString NICNameInfo =>
             StringToSecureString(ConfigurationManager.AppSettings["NICServiceUserName"]);

        /// <summary>Gets information describing the NIC cico.</summary>
        /// <value>Information describing the NIC cico.</value>
        public static SecureString NICCicoCicoInfo =>
             StringToSecureString(ConfigurationManager.AppSettings["NICServicePassword"]);

        #region " Private Functions "

        /// <summary>
        /// Function checks if check sum of border number or Id number is valid
        /// Auto generated from Java script
        /// </summary>
        /// <param name="targetBorderOrIdNumber">The target border or identifier number.</param>
        /// <returns><c>true</c> if [is check sum valid] [the specified target border or identifier number]; otherwise, <c>false</c>.</returns>
        private static bool IsCheckSumValid(string targetBorderOrIdNumber)
        {
            var num1 = 0;
            if (string.IsNullOrEmpty(targetBorderOrIdNumber) || targetBorderOrIdNumber.Length < 10)
                return false;
            var charArray = targetBorderOrIdNumber.ToCharArray();
            for (var index = 0; index < 9; ++index)
            {
                if ((int)charArray[index] < 48 || (int)charArray[index] > 57)
                    return false;
                if (index == 0 || index == 2 || (index == 4 || index == 6) || index == 8)
                {
                    var str = (int.Parse(charArray[index].ToString()) * 2).ToString();
                    num1 += str.Select((t, startIndex) => int.Parse(str.Substring(startIndex, 1))).Sum();
                }
                else
                    num1 += int.Parse(charArray[index].ToString());
            }
            var str1 = num1.ToString();
            var num2 = int.Parse(str1.Substring(str1.Length - 1));
            var num3 = int.Parse(charArray[9].ToString());
            return num2 == num3 || num3 == 10 - num2;
        }

        #endregion

        #region " Public Functions"

        /// <summary>
        /// Function checks if Border Number or ID Number is valid
        /// </summary>
        /// <param name="targetBorderOrIdNumber">The target border or identifier number.</param>
        /// <returns><c>true</c> if [is laborer border or identifier number valid] [the specified target border or identifier number]; otherwise, <c>false</c>.</returns>
        public static bool IsLaborerBorderOrIdNumberValid(string targetBorderOrIdNumber)
        {
            return
                targetBorderOrIdNumber.Length > 0 &&
                targetBorderOrIdNumber.Length == 10 &&
                IsCheckSumValid(targetBorderOrIdNumber);
        }

        /// <summary>
        /// Function checks if Saudi Id Number is valid one
        /// </summary>
        /// <param name="saudiIdNumber">The Saudi identifier number.</param>
        /// <returns><c>true</c> if [is Saudi identifier number valid] [the specified Saudi identifier number]; otherwise, <c>false</c>.</returns>
        public static bool IsSaudiIdNumberValid(string saudiIdNumber)
        {
            return saudiIdNumber.Length == 10 &&
                   saudiIdNumber.StartsWith("1") &&
                   IsCheckSumValid(saudiIdNumber) &&
                   (
                       (int)saudiIdNumber[0] == 49 ||
                       (int)saudiIdNumber[0] == 50 ||
                       ((int)saudiIdNumber[0] == 51 || (int)saudiIdNumber[0] == 52) ||
                       (int)saudiIdNumber[0] == 53
                       );
        }

        /// <summary>  
        /// Format log values. 
        /// </summary>
        /// <param name="prefixStrings">The prefix strings. </param>
        /// <param name="targetMethod">Target method. </param>
        /// <param name="parametersValue"> A variable-length parameters list containing parameters value. </param>
        /// <returns>The formatted log values. </returns>
        public static string FormatLogValues(dynamic[] prefixStrings, MethodBase targetMethod, params dynamic[] parametersValue)
        {
            //========================================================================================
            //Check input values
            if (targetMethod == null)
                return string.Empty;

            var paramsString = new StringBuilder();
            var inputParameters = targetMethod.GetParameters();

            //========================================================================================
            //Append Prefix Strings
            if (prefixStrings?.Length > 0)
                foreach (var currentPrefix in prefixStrings)
                    paramsString.Append(currentPrefix).Append("|");

            //========================================================================================
            //Append Input Parameters
            for (var index = 0; index < inputParameters.Length; index++)
                paramsString
                    .Append(inputParameters[index].Name)
                    .Append("=")
                    .Append(parametersValue[index] ?? "Nullable")
                    .Append(",");

            return paramsString.ToString();
        }

        /// <summary>  
        /// Format log values. 
        /// </summary>
        /// <param name="prefixStrings">The prefix strings. </param>
        /// <param name="targetObject"></param>
        /// <returns>The formatted log values. </returns>
        public static string FormatComplexLogValues(dynamic[] prefixStrings, dynamic targetObject)
        {
            //========================================================================================
            //Check input values
            if (targetObject == null)
                return string.Empty;

            //========================================================================================
            //Append Prefix Strings
            var paramsString = new StringBuilder();
            if (prefixStrings?.Length > 0)
                foreach (var currentPrefix in prefixStrings)
                    paramsString.Append(currentPrefix).Append("|");

            //========================================================================================
            // Convert object to XML string
            var stringWriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(targetObject.GetType());
            serializer.Serialize(stringWriter, targetObject);

            return paramsString.Append(stringWriter.ToString()).ToString();
        }

        /// <summary>A string extension method that convert string to secure string.</summary>
        /// <remarks>Wael Mohsen, 2018-05-08.</remarks>
        /// <param name="data">The data to act on.</param>
        /// <returns>The string converted to secure string.</returns>
        public static SecureString StringToSecureString(string data)
        {
            var secure = new SecureString();
            foreach (var character in data.ToCharArray())
                secure.AppendChar(character);

            secure.MakeReadOnly();
            return secure;
        }

        /// <summary>A SecureString extension method that convert secure string to string.</summary>
        /// <remarks>Wael Mohsen, 2018-05-08.</remarks>
        /// <param name="data">The data to act on.</param>
        /// <returns>The secure converted string to string.</returns>
        public static string SecureStringToString(SecureString data)
        {
            var pointer = IntPtr.Zero;
            try
            {
                pointer = Marshal.SecureStringToGlobalAllocUnicode(data);
                return Marshal.PtrToStringUni(pointer);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(pointer);
            }
        }

        /// <summary>
        /// Function Converts Gregorian to NIC Hijri Format (yyyyMMdd)
        /// </summary>
        /// <param name="targetGregorian">Target Gregorian Date</param>
        /// <returns>System.Int32.</returns>
        public static int ConvertToNICHijriFormate(DateTime targetGregorian)
        {
            string[] allFormats =
                {
                        "yyyy/MM/dd","yyyy/M/d","dd/MM/yyyy",
                        "d/M/yyyy","dd/M/yyyy","d/MM/yyyy",
                        "yyyy-MM-dd","yyyy-M-d","dd-MM-yyyy",
                        "d-M-yyyy","dd-M-yyyy","d-MM-yyyy",
                        "yyyy MM dd","yyyy M d","dd MM yyyy",
                        "d M yyyy","dd M yyyy","d MM yyyy"
                };

            var englishCulture = new CultureInfo("en-US");
            var arabicCulture = new CultureInfo("ar-SA");
            var arabicCalender = new UmAlQuraCalendar();
            arabicCulture.DateTimeFormat.Calendar = arabicCalender;

            var hijriFormateDate = DateTime.ParseExact(
                targetGregorian.ToString("yyyy/MM/dd"), allFormats, englishCulture.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);

            return int.Parse(hijriFormateDate.ToString("yyyyMMdd", arabicCulture.DateTimeFormat));
        }

        /// <summary>
        /// Function Converts Gregorian to Hijri Format (yyyy/MM/dd)
        /// </summary>
        /// <param name="targetGregorian">Target Gregorian Date</param>
        /// <returns>System.Int32.</returns>
        public static string ConvertToHijriFormate(DateTime targetGregorian)
        {
            string[] allFormats =
                {
                        "yyyy/MM/dd","yyyy/M/d","dd/MM/yyyy",
                        "d/M/yyyy","dd/M/yyyy","d/MM/yyyy",
                        "yyyy-MM-dd","yyyy-M-d","dd-MM-yyyy",
                        "d-M-yyyy","dd-M-yyyy","d-MM-yyyy",
                        "yyyy MM dd","yyyy M d","dd MM yyyy",
                        "d M yyyy","dd M yyyy","d MM yyyy"
                };

            var englishCulture = new CultureInfo("en-US");
            var arabicCulture = new CultureInfo("ar-SA");
            var arabicCalender = new UmAlQuraCalendar();
            arabicCulture.DateTimeFormat.Calendar = arabicCalender;

            var hijriFormateDate = DateTime.ParseExact(
                targetGregorian.ToString("yyyy/MM/dd"), allFormats, englishCulture.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);

            return hijriFormateDate.ToString("yyyy/MM/dd", arabicCulture.DateTimeFormat);
        }

        #endregion
    }
}
