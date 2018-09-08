
using System.Text.RegularExpressions;
using System.Threading;

namespace RAMS.Web.CrossCutting
{
    public class TypedObjects
    {

        #region General

        public const string EstalishmentHomePage = "~/CIW/Services.aspx";
        public const string RejectionReason = "عفوا عزيزي المستخدم،سبب الرفض حقل إلزامى ";

        #endregion

        #region Constant Key

        public const string GeneralSystemError =
            "عفوا عزيزي المستخدم، فقد تعرض النظام لخطأ تقني أثناء تنفيذ طلبك، برجاء إعادة المحاولة.";

        public const string NoDocumentMessage = "عفوا عزيزي المستخدم ، لابد من رفع المستندات المطلوبة";

        public const string EmptyMessage = "عفوا عزيزي المستخدم، لابد من ادخال محددات البحث";

        public const string SelectSearchCriteria = "عفوا عزيزي المستخدم، لابد من ادخال إحدى محددات البحث";

        public const string AppointmentDatetMessage =
            "عفوا عزيزي المستخدم، لابد من تحديد موعد للعامل أو المؤسسة أو كليهما";

        public const string LaborOfficeResponseMessage = "عفوا عزيزي المستخدم، إفادة مكتب العمل حقل إلزامى";

        public const string EstablishmentNumberMessage = "عفوا عزيزي المستخدم، رقم المنشأة غير صحيح";

        public const string RAMSMSG15 = "RAMSMSG15";

        public const string NoFilesFiles = "عفوا عزيزي المستخدم،لابد من رفع الملفات الثبوتية  ";

        public const string MandatoryFieldMessage =
            "عفوا عزيزي المستخدم،يلزم الاجابة على كافة الاسئلة لاستكمال طلبكم   ";

        public const string AgreementFieldMessage = "عفوا عزيزي المستخدم،برجاء مراجعة النص القانونى لإقرار المسؤولية" +
                                                    " و الموافقة عليه لاستكمال حفظ طلبكم  ";

        public const string MessageSize = "عفوا عزيزي المستخدم ، النص المدخل يجب الا  يتعدى 500 حرف   ";

        public const string MobileNumberFormat = "عفوا عزيزي المستخدم ، برجاء التحقق من رقم الجوال المدخل ";

        public const string LaborerStartWorkDateCalendarError =
            " عفوا عزيزي المستخدم ، برجاء التحقق من تاريخ بدأ العمل حيث لا يمكن ان يكون تاريخ بداية العمل بعد تاريخ اليوم     ";

        public const string LaborerEndWorkDateDualSmartCalendarNextDateError =
            "عفوا عزيزي المستخدم ، برجاء التحقق من تاريخ نهاية العمل حيث لا يمكن ان يكون تاريخ نهاية العمل بعد تاريخ اليوم ";

        public const string LaborerEndWorkDateDualSmartCalendarCompareError =
            " عفوا عزيزي المستخدم ، برجاء  التحقق من تاريخ نهاية العمل حيث لا يمكن ان يكون قبل تاريخ بداية العمل  ";

        public const string LaborerEndWorkDateDualSmartCalendarNextError =
            " عفوا عزيزي المستخدم ، برجاء  التحقق من تاريخ اخر راتب حيث لا يمكن ان يكون تاريخ اخر راتب بعد تاريخ اليوم  ";

        public const string LaborerReturnDateToWorkCalendarError = " عفوا عزيزي المستخدم ، برجاءالتحقق من تاريخ عودة العامل الى العمل حيث انه لا يمكن ان يكون بعد تاريخ اليوم   ";

        #endregion

        #region Methods 

        /// <summary>
        /// Encoding Methods 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Decoding method 
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// check if  string base 64 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsBase64String(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return false;
            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        /// <summary>
        /// return Current Culture
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.ToString();
        }

        #endregion
    }
}
