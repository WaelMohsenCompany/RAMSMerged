// ***********************************************************************
// Assembly         : RAMS.CrossCutting
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 02-28-2018
// ***********************************************************************
// <copyright file="TypedObjects.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace RAMS.CrossCutting
{
    /// <summary>
    /// Class TypedObjects.
    /// </summary>
    public class TypedObjects
    {
        #region "Constant Messages Members"

        /// <summary>
        /// Formating string to prevent flipping Case Number when merged to Arabic Message Text         
        /// </summary>
        public static readonly string LEFTTORIGHTFLIPPING = ((char)0x200E).ToString();
        /// <summary>
        /// عفوا عزيزي العميل، فقد تعرض النظام لخطأ تقني أثناء تنفيذ طلبك برجاء إعادة المحاولة.
        /// </summary>
        public const string RAMSMSG00 = "RAMSMSG00";
        /// <summary>
        /// لا يوجد لديك بلاغات تغيب مقدمة تخص هذه المنشأة في الفترة المحددة بالنظام.
        /// </summary>
        public const string RAMSMSG01 = "RAMSMSG01";
        /// <summary>
        /// لا يوجد أي بلاغات/طلبات توافق معايير البحث.
        /// </summary>
        public const string RAMSMSG02 = "RAMSMSG02";
        /// <summary>
        /// عزيزي العميل، تم قبول طلب تسجيل بلاغ التغيب بنجاح برقم (رقم البلاغ) وحالته (حالة الطلب)
        /// </summary>
        public const string RAMSMSG03 = "RAMSMSG03";
        /// <summary>
        /// عفوا عزيزي العميل، لا يمكن تقديم بلاغ تغيب عن عامل لا يتبع منشأتك
        /// </summary>
        public const string RAMSMSG04 = "RAMSMSG04";
        /// <summary>
        /// عفوا عزيزي العميل، لا يمكن تقديم بلاغ تغيب عن العامل (اسم العامل) حيث إنه ليس على رأس العمل أو مشمول بطلب نقل خدمة تم الموافقة عليه من صاحب العمل.
        /// </summary>
        public const string RAMSMSG05 = "RAMSMSG05";
        /// <summary>
        /// عفوا عزيزي العميل، هذا البلاغ لا يمكن إلغاؤه لانتهاء المدة المحددة لذلك.
        /// </summary>
        public const string RAMSMSG07 = "RAMSMSG07";
        /// <summary>
        /// عفوا عزيزي العميل، لا يمكن تقديم بلاغ تغيب لقيود النشاط الاقتصادي التابع له المنشأة.
        /// </summary>
        public const string RAMSMSG08 = "RAMSMSG08";
        /// <summary>
        /// عفوا عزيزي العميل، لا يوجد يوجد لديك بلاغات تغيب خلال المدة المحددة بالنظام.
        /// </summary>
        public const string RAMSMSG09 = "RAMSMSG09";
        /// <summary>
        /// عزيزي العميل، تم تسجيل طلبك بنجاح وحالته (حالة الطلب).
        /// </summary>
        public const string RAMSMSG10 = "RAMSMSG10";
        /// <summary>
        /// عفوا عزيزي العميل، حالة المنشأة يجب أن تكون قائمة.
        /// </summary>
        public const string RAMSMSG11 = "RAMSMSG11";
        /// <summary>
        /// عفوا عزيزي العميل، يجب أن يكون اشتراك المنشأة في خدمة واصل ساري.
        /// </summary>
        public const string RAMSMSG12 = "RAMSMSG12";
        /// <summary>
        /// عفوا عزيزي العميل، لا يمكن تقديم بلاغ تغيب ضد العامل المذكور حيث إن لديه دعوى مرفوعة ضد المنشأة في نظام القضايا.
        /// </summary>
        public const string RAMSMSG13 = "RAMSMSG13";
        /// <summary>
        /// عفوا عزيزي العميل، يجب أن تكون "رخصة العمل أو الإقامة الخاصة بالعامل سارية المفعول" أو "رخصة العمل والإقامة منتهية ولم يمضي على انتهاء الإقامة 30 يوما أو لم يمضي على 30 يوما على انتهاء فترة ال 90 يوما لوصول العامل للمملكة"
        /// </summary>
        public const string RAMSMSG14 = "RAMSMSG14";
        /// <summary>
        /// عفوا عزيزي العميل، لا يمكن تقديم طلب إثبات كيدية بلاغ تغيب تم رفضه سابقاً من قبل إدارة بلاغات التغيب
        /// </summary>
        public const string RAMSMSG15 = "RAMSMSG15";
        /// <summary>
        /// عفوا عزيزي العميل، لا يمكن تقديم أكثر من طلب إثبات كيدية لنفس البلاغ
        /// </summary>
        public const string RAMSMSG16 = "RAMSMSG16";
        /// <summary>
        /// عزيزي المستخدم، تم تسجيل طلب إفادة العامل والمنشأة من مكتب العمل التابع له المنشأة بنجاح
        /// </summary>
        public const string RAMSMSG17 = "RAMSMSG17";
        /// <summary>
        /// عزيزي المستخدم، تم تعديل حالة طلب حالة طلب إثبات كيدية البلاغ إلى (مرفوض) و حفظ حالة البلاغ المناظر إلى (مقبول)
        /// </summary>
        public const string RAMSMSG18 = "RAMSMSG18";
        /// <summary>
        /// عزيزي المستخدم، تم تعديل حالة طلب حالة طلب إثبات كيدية البلاغ إلى (مقبول) و حفظ حالة البلاغ المناظر إلى (مرفوض)
        /// </summary>
        public const string RAMSMSG19 = "RAMSMSG19";
        /// <summary>
        /// عزيزي المستخدم، تم تعديل حالة طلب حالة طلب إثبات كيدية البلاغ إلى (تم تحديد موعد للمراجعة) و تم إرسال الموعد)
        /// </summary>
        public const string RAMSMSG20 = "RAMSMSG20";
        /// <summary>
        /// عزيزي المستخدم، تم تعديل حالة طلب حالة طلب إثبات كيدية البلاغ إلى (تمت الإفادة من مكتب العمل))
        /// </summary>
        public const string RAMSMSG21 = "RAMSMSG21";
        /// <summary>
        /// عفوا عزيزي العميل، العامل المطلوب مسجل في بلاغ تغيب أخر
        /// </summary>
        public const string RAMSMSG23 = "RAMSMSG23";
        /// <summary>
        /// عزيزي العميل، تم إلغاء بلاغ التغيب رقم (رقم البلاغ) بنجاح
        /// </summary>
        public const string RAMSMSG24 = "RAMSMSG24";
        /// <summary>
        /// The RAMS internal MSG01
        /// </summary>
        public const string RAMSInternalMSG01 = "عفوا عزيزي العميل، رقم الهوية/الحدود الذي تم إدخاله غير صحيح";
        /// <summary>
        /// عفوا عزيزي العميل، لا يمكنك إنشاء بلاغ تغيب آخر على هذا العامل. نرجوا التوجه إلى مكتب العمل لإنشاء بلاغ التغيب
        /// </summary>
        public const string RAMSMSG25 = "RAMSMSG25";
        /// <summary>
        /// عزيزي المستخدم، نرجوا الإنتباه ان هذه المنشاة قامت بتقديم عدة بلاغات تغيب على هذا العامل مما قد يوحي بالتلاعب في الخدمة
        /// </summary>
        public const string RAMSMSG26 = "RAMSMSG26";
        /// <summary>
        /// عفوا عزيزي العميل، هذا البلاغ لا يمكن إلغاؤه لان حالته لاتسمح بذلك
        /// </summary>
        public const string RAMSMSG27 = "RAMSMSG27";
        /// <summary>
        /// عفوا عزيزي العميل، لا يمكن تقديم طلب إثبات كيدية بلاغ تغيب تم إلغائه سابقاً من قبل ممثل المنشآة
        /// </summary>
        public const string RAMSMSG28 = "RAMSMSG28";
        /// <summary>
        /// عزيزي المستخدم، تم تسجيل إفادتكم على طلب إثبات كيدية البلاغ ولم يتم إرسالها إلى إدارة بلاغات التغيب
        /// </summary>
        public const string RAMSMSG29 = "RAMSMSG29";
        /// <summary>
        /// عزيزي العميل، برجاء مراجعة مكتب العمل بخصوص بلاغ تغيب رقم (123) في موعد أقصاه (20-2-2018).
        /// </summary>
        public const string RAMSMSG22 = "RAMSMSG22";
        /// <summary>
        ///عزيزي العامل ، تم تقديم طلب بلاغ تغيب من المنشآة عليكم برقم ({0}). يمكنكم تقديم شكوى على الطلب من خلال البوابة الإلكترونية للخدمات او من خلال زيارة مكتب العمل
        /// </summary>
        public const string RAMSMSG30 = "RAMSMSG30";
        /// <summary>
        /// عزيزي العامل ، تم إلغاء بلاغ التغيب رقم ({0}) من قبل ممثل المنشآة
        /// </summary>
        public const string RAMSMSG31 = "RAMSMSG31";
        /// <summary>
        /// عزيزي العميل، تم تقديم طلب إثبات كيدية على بلاغ التغيب رقم ({0})
        /// </summary>
        public const string RAMSMSG32 = "RAMSMSG32";
        /// <summary>
        ///عزيزي العميل، تم البت في طلب إثبات الكيدية على بلاغ التغيب رقم ({0}). طلب إثبات الكيدية ({1})
        /// </summary>
        public const string RAMSMSG33 = "RAMSMSG33";
        /// <summary>
        /// عفوا عزيزي العميل، لا يمكنك إلغاء بلاغ التغيب على هذا العامل. نرجوا التوجه إلى مكتب العمل لإغاء بلاغ التغيب
        /// </summary>
        public const string RAMSMSG34 = "RAMSMSG34";
        /// <summary>
        ///  عزيزي المستخدم، نرجوا الإنتباه ان هذه المنشاة قامت بإلغاء بلاغات تغيب على هذا العامل عدة مرات، مما قد يوحي بالتلاعب في الخدمة
        /// </summary>
        public const string RAMSMSG35 = "RAMSMSG35";
        #endregion

        #region "Static String Values used for uploaded files' names"

        /// <summary>
        /// The run away create request file title
        /// </summary>
        public const string RunAwayCreateRequestFileTitle = "بلاغ تغيب";
        /// <summary>
        /// The run away cancel request file title
        /// </summary>
        public const string RunAwayCancelRequestFileTitle = "إلغاء بلاغ تغيب";
        /// <summary>
        /// The complaint create request file title
        /// </summary>
        public const string ComplaintCreateRequestFileTitle = "إثبات كيدية";

        /// <summary>
        /// The has invalid laborer work permit and iqamma rule2
        /// Rule2: "رخصة العمل والإقامة منتهية ولم يمضي على انتهاء الإقامة 30 يوما
        /// </summary>
        public const string HasInvalidLaborerWorkPermitAndIqammaRule2 = "InvalidRule2";
        /// <summary>
        /// Laborer Have Over Number Of RunAway Request
        /// </summary>
        public const string HaveOverNumberOfRunAwayRequest = "HaveOverNumberOfRunAwayRequest";

        /// <summary>
        /// The path traversal vulnerabilities
        /// </summary>
        public const string PathTraversalVulnerabilities = "Path Traversal Vulnerabilities in target File";
        /// <summary>
        /// The no file information
        /// </summary>
        public const string NoFileInfo = "There is no File information.";

        #endregion

        #region "Public Get Status Name"

        /// <summary>
        /// The run away request status names
        /// </summary>
        private static readonly string[] RunAwayRequestStatusNames =
            {
                "مرفوض",
                "مقبول",
                "تحت الدراسة",
                "تم إلغائه"
            };

        /// <summary>
        /// The complaint request status names
        /// </summary>
        private static readonly string[] ComplaintRequestStatusNames =
            {
                "مرفوض",
                "مقبول",
                "تحت الدراسة",
                "تم إلغائه",
                "تحت الدراسة بمكتب العمل",
                "تمت الإفادة من مكتب العمل",
                "تم تحديد موعد للمراجعة"
            };

        /// <summary>
        /// Function returns the status name of target status Array
        /// </summary>
        /// <param name="targetStatusType">Target status Array</param>
        /// <param name="statusIdIndex">Status Id</param>
        /// <returns>System.String.</returns>
        public static string GetStatusName(StatusType targetStatusType, int? statusIdIndex)
        {
            if (!statusIdIndex.HasValue)
                return String.Empty;

            if (statusIdIndex - 1 < 0)
                return String.Empty;

            if (targetStatusType == StatusType.RunAwayRequestStatus &&
                statusIdIndex - 1 <= RunAwayRequestStatusNames.Length)
                return RunAwayRequestStatusNames[statusIdIndex.Value - 1];

            if (targetStatusType == StatusType.ComplaintRequestStatus &&
                statusIdIndex - 1 <= ComplaintRequestStatusNames.Length)
                return ComplaintRequestStatusNames[statusIdIndex.Value - 1];

            return String.Empty;
        }

        #endregion

        #region "Public Enumerations"

        /// <summary>
        /// System Constant Values
        /// </summary>
        public enum StaticValues
        {
            /// <summary>
            /// WASEL active Status
            /// </summary>
            WASELStatus = 1
        }

        /// <summary>
        /// Types of Statuses to return its name
        /// </summary>
        public enum StatusType
        {
            /// <summary>
            /// The run away request status
            /// </summary>
            RunAwayRequestStatus,
            /// <summary>
            /// The complaint request status
            /// </summary>
            ComplaintRequestStatus
        }

        /// <summary>
        /// حالات بلاغ التغيب
        /// </summary>
        public enum RunAwayRequestStatus
        {
            /// <summary>
            /// مرفوض
            /// </summary>
            Rejected = 1,

            /// <summary>
            /// مقبول
            /// </summary>
            Accepted = 2,

            /// <summary>
            /// تحت الدراسة
            /// </summary>
            UnderProcessing = 3,

            /// <summary>
            /// تم إلغائه
            /// </summary>
            Canceled = 4
        }

        /// <summary>
        /// حالات طلب إثبات كيدية بلاغ التغيب
        /// </summary>
        public enum ComplaintRequestStatus
        {
            /// <summary>
            /// مرفوض
            /// </summary>
            Rejected = 1,

            /// <summary>
            /// مقبول
            /// </summary>
            Accepted = 2,

            /// <summary>
            /// تحت الدراسة
            /// </summary>
            UnderProcessing = 3,

            /// <summary>
            /// تم إلغائه
            /// </summary>
            CanceledByEstablishment = 4,

            /// <summary>
            ///تحت الدراسة بمكتب العمل 
            /// </summary>
            UnderLaborOfficeProcessing = 5,

            /// <summary>
            /// تمت الإفادة من مكتب العمل
            /// </summary>
            RepliedByLaborOffice = 6,

            /// <summary>
            /// تم تحديد موعد للمراجعة
            /// </summary>
            ReviewAppointmentTime = 7
        }

        /// <summary>
        /// انواع المواعيد في تدقيق بلاغ تغيب
        /// </summary>
        public enum ReviewAppointmentType
        {
            /// <summary>
            /// Update to schedule an appointment for Laborer
            /// </summary>
            LaborerAppointment,
            /// <summary>
            /// Update to schedule an appointment for Establishment
            /// </summary>
            EstablishmentAppointment,
            /// <summary>
            /// Update to schedule an appointment for both
            /// </summary>
            LaborerAndEstablishmentAppointment
        }

        /// <summary>
        /// نوع إغلاق عملية تدقيق البلاغ
        /// </summary>
        public enum ReviewResultsType
        {
            /// <summary>
            /// The final result of Review results.
            /// </summary>
            FinalResult,
            /// <summary>
            /// Still in progress result and user will update this Review results by additional results in future.
            /// </summary>
            InProgressResult
        }

        /// <summary>
        /// Configurable System Settings
        /// Mentioned Ids is the Primary Keys at ServiceConfiguration table
        /// </summary>
        public enum SystemSettings
        {
            /// <summary>
            /// فترة استعراض البلاغات السابقة = 1 شهر
            /// </summary>
            AllowedBackwardSearchMonths = 256,
            /// <summary>
            /// فترة التقدم بطلب إثبات كيدية بلاغ التغيب = 365 يوم
            /// </summary>
            AllowedDaysToComplaintRequest = 258,
            /// <summary>
            /// أقصى عدد للملفات المرفقة = 10 ملفات
            /// </summary>
            MaximumNumberOfFiles = 259,
            /// <summary>
            /// الحجم الأقصى لملف المستندات والأوراق الثبوتية = 2 ميجا
            /// </summary>
            MaximumFileSizeInMega = 263,
            /// <summary>
            /// الحجم الأدنى لملف المستندات والأوراق الثبوتية = 10 كيلو
            /// </summary>
            MinimumFileSizeInKilo = 405,
            /// <summary>
            /// الفترة الزمنية التي يتم خلالها إلغاء البلاغ   = 15 يوم
            /// </summary>
            AllowedDaysToCancelRunawayRequest = 65,
            /// <summary>
            /// أقصي مدة زمنية لمراجعة مكتب العمل لتدقيق البلاغ = 15 يوم
            /// </summary>
            MaximumDaysToRunAwayAppointment = 392,
            /// <summary>
            /// عدد المرات المسموح بتقديم بلاغ تغيب من خلال بوابة المنشآت = 2
            /// The allowed number of run away request
            /// </summary>
            AllowedNumberOfRunAwayRequest = 379,
            /// <summary>
            /// عدد المرات المسموح بتقديم إلغاء بلاغ تغيب من خلال بوابة المنشآت = 2
            /// The allowed number of Cancel runaway request
            /// </summary>
            AllowedNumberOfCanceledRunAwayRequest = 400,
            /// <summary>
            /// 5 = عدد الأيام الافتراضية لاتخاذ إجراء أولي في طلب إثبات كيدية بلاغ
            /// </summary>
            AllowedNumberOfDaysToTakeInitialAction = 389,
            /// <summary>
            /// رخصة العمل والإقامة منتهية ولم يمضي على انتهاء الإقامة = 30
            /// </summary>
            EServiceAllowedDaysToValidateIqammaAndWorkPermit = 398,
            /// <summary>
            /// رخصة العمل والإقامة منتهية ولم يمضي على انتهاء الإقامة = 60
            /// </summary>
            MyClientsAllowedDaysToValidateIqammaAndWorkPermit = 399
        }

        /// <summary>
        /// أنواع حالات العامل
        /// </summary>
        public enum LaborerStatus
        {
            /// <summary>
            /// علي رأس العمل
            /// </summary>
            Working = 1,
            /// <summary>
            /// على رأس العمل بإنتظار نقل الخدمة
            /// </summary>
            WorkingWaitingSponsorTransfer = 12,
            /// <summary>
            /// متغيب عن العمل في إنتظار نقل الخدمة
            /// </summary>
            RunnerWaitingSponsorTransfer = 13
        }

        /// <summary>
        /// حالات المنشآت
        /// </summary>
        public enum EstablishmentStatusList
        {
            /// <summary>
            /// The existent
            /// </summary>
            Existent = 1
        }

        /// <summary>
        /// نوع العامل
        /// </summary>
        public enum SaudiFlags
        {
            /// <summary>
            /// The is saudi
            /// </summary>
            IsSaudi = 1,
            /// <summary>
            /// The non saudi
            /// </summary>
            NonSaudi = 2
        }

        /// <summary>
        /// Enumeration used to specify the text code
        /// </summary>
        public enum MessageType
        {
            /// <summary>
            ///عند تقديم بلاغ تغيب عن العمل
            /// </summary>
            CreateRunAwayRequest,
            /// <summary>
            /// إلغاء بلاغ تغيب عن العمل
            /// </summary>
            CancelRunAwayRequest,
            /// <summary>
            /// تقديم طلب إثبات كيدية
            /// </summary>
            CreateComplaintRequest,
            /// <summary>
            /// تحديد موعد لتدقيق البلاغ
            /// </summary>
            ReviewAppointment,
            /// <summary>
            /// تم إتخاذ قرار بخصوص إثبات الكيدية
            /// </summary>
            ApproveCompliantRequestResult
        }

        #endregion
    }
}
