using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Web.UI;
using MOL.EFDAL.Repository;
using RAMS.ApplicationServices.RunAwayRequest.Post;
using RAMS.BusinessServices.Get;
using RAMS.BusinessServices.Post;
using RAMS.CrossCutting;
using RAMS.InfrastructureService.FileTransfer;
using RAMS.OracleIntegrationServices.CaseManagement;

namespace RAMS.SOA.Tester
{
    public partial class TestingWebForm : Page
    {
        private readonly string ipAddress = "192.168.56.1";

        protected void CheckCreateRunAwayLaborerBusinessRules_Click(object sender, EventArgs e)
        {
            var objectInstance = new GetBusinessService();

            var results = objectInstance.CheckCreateRunAwayLaborerBusinessRules(
                null, 3352327799, true, 1, 162745, 1027679073);

            foreach (var currentMessage in results.ResultsList)
            {
                if (currentMessage.IsSuccess)
                    continue;

                resultsList.Items.Add(currentMessage.ResponseText);
            }

            resultsList.Items.Add("Done");
        }

        protected void CheckCreateRunAwayEstablishmentBusinessRules_Click(object sender, EventArgs e)
        {
            var objectInstance = new GetBusinessService();

            var results = objectInstance.CheckCreateRunAwayEstablishmentBusinessRules(1, 162745, 1027679073);

            foreach (var currentMessage in results)
            {
                if (currentMessage.IsSuccess)
                    continue;

                resultsList.Items.Add(currentMessage.ResponseText);
            }

            resultsList.Items.Add("Done");
        }

        protected void GetRunAwayRequest_Click(object sender, EventArgs e)
        {
            var objectInstance = new GetBusinessService();
            var results = objectInstance.GetRunAwayRequest(1027679073, 1, 162745, 2251302473, null);
            if (results == null)
            {
                resultsList.Items.Add("NULL");
                return;
            }

            resultsList.Items.Add(results.EstablishmentTitle);
            resultsList.Items.Add(results.LaborerFullName);
            resultsList.Items.Add(results.RequestNumber);
            resultsList.Items.Add(results.CreationQuestion1?.ToShortDateString() ?? "لايوجد");
            resultsList.Items.Add(results.CreationQuestion2?.ToShortDateString() ?? "لايوجد");
            resultsList.Items.Add(results.CreationQuestion3?.ToShortDateString() ?? "لايوجد");
            resultsList.Items.Add(results.CreationQuestion4);
            resultsList.Items.Add(
                results.LaborerIdNumber?.ToString() ?? results.LaborerBorderNumber.Value.ToString());
        }

        protected void GetAllRunAwayRequestsList_Click(object sender, EventArgs e)
        {
            var objectInstance = new GetBusinessService();

            var results = objectInstance.GetAllRunAwayRequestsList(1027679073, 1, 162745, 10, 1);

            foreach (var xx in results)
                resultsList.Items.Add(xx.RequestNumber);
        }

        protected void GetLatestRunAwayOrComplaintRequest_Click(object sender, EventArgs e)
        {
            var objectInstance = new GetBusinessService();
            var sw = new Stopwatch();
            sw.Start();

            var results = objectInstance.GetLatestRunAwayOrComplaintRequest(null, 2288202951);

            sw.Stop();

            resultsList.Items.Clear();
            resultsList.Items.Add("Time: " + sw.ElapsedMilliseconds);
            resultsList.Items.Add("======================");

            if (results == null)
            {
                resultsList.Items.Add("لا يوجد لديك بلاغات مقدمة فى الفترة السابقة فى النظام");
                return;
            }

            resultsList.Items.Add(results.ComplaintRequestStatusName);
            resultsList.Items.Add(results.EstablishmentTitle);
            resultsList.Items.Add(results.RejectReason);
            resultsList.Items.Add(results.RunAwayRequestNumber);
            resultsList.Items.Add(results.RunAwayRequestStatusName);
            resultsList.Items.Add(results.ComplaintRequestId.ToString());
            resultsList.Items.Add(results.ComplaintRequestDate.GetValueOrDefault().ToLongTimeString());
            resultsList.Items.Add(results.ComplaintRequestStatusId.ToString());
            resultsList.Items.Add(results.RunAwayRequestDate.ToLongTimeString());
            resultsList.Items.Add(results.RunAwayRequestStatusId.ToString());

            resultsList.Items.Add(results.ComplaintQuestion1.GetValueOrDefault().ToShortDateString());
            resultsList.Items.Add(results.ComplaintQuestion2.GetValueOrDefault().ToShortDateString());
            resultsList.Items.Add(results.ComplaintQuestion3.GetValueOrDefault().ToShortDateString());
            resultsList.Items.Add(results.ComplaintQuestion4);
        }

        protected void btn_FileUpload_Click(object sender, EventArgs e)
        {
            try
            {
                var objectInstance = new FileTransferService();

                var fileInfo = new RemoteFileInfo
                {
                    FileName = FileUpload1.FileName,
                    Length = FileUpload1.FileBytes.Length,
                    FileByteStream = FileUpload1.FileContent
                };

                var results = objectInstance.UploadFile(fileInfo);

                Label1.Text = "New File Name: " + results.FileName;
            }
            catch (Exception ex)
            {
                Label1.Text = "Error: " + ex.Message;
                ;
            }
        }

        protected void DownloadFile_Click(object sender, EventArgs e)
        {
            var objectInstance = new GetBusinessService();

            var results = objectInstance.DownloadFile(
                new DownloadRequest
                {
                    FileName = "1439-1-1686- ملف بلاغ تغيب 1.pdf",
                    RequestNumber = "1439-1-1686"
                }, 1027679073);

            resultsList.Items.Add(results.FileName);
        }

        protected void ButCreateRunAwayRequest_Click(object sender, EventArgs e)
        {
            var objectInstance = new PostBusinessService();

            var results = objectInstance.CreateRunAwayRequest(new RunAwayCreateRequestInfo
            {
                LaborerOfficeId = 1,
                SequenceNumber = 328673,
                EstablishmentId = 2302056.ToString(),
                EstablishmentTitle = "مؤسسه خبراء التكنولوجيا للتجاره",
                LaborerIdNumber = 2366749758,
                LaborerBorderNumber = null,
                LaborerFullName = "جميل محمود",
                CreationQuestion1 = Convert.ToDateTime("2018-04-01T00:00:00"),
                CreationQuestion2 = Convert.ToDateTime("2018-04-03T00:00:00"),
                CreationQuestion3 = Convert.ToDateTime("2018-04-06T00:00:00"),
                CreationQuestion4 = "Add in Release notes information about he NIC Mockup",
                ApplicantUserIdNumber = 1040243006,
                CreatedByIdNumber = 1040243006,
                IsRequestByEstablishmentAgent = true,
                FilesPaths = new HashSet<string>
                {
                    "c:\\RAMSTempUploadFiles\\1.pdf"
                },
                ClientIPAddress = ipAddress
            });

            resultsList.Items.Add(results.IsSuccess ? results.Description : results.IsSuccess.ToString());

            foreach (var currentMessage in results.ResultsList)
            {
                if (currentMessage.IsSuccess)
                    continue;

                resultsList.Items.Add(currentMessage.ResponseText);
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            //Cancel runaway request
            var objectInstance = new PostBusinessService();

            var results = objectInstance.CancelRunAwayRequest(new RunAwayCancelRequestInfo
            {
                RequestNumber = "1439-1-1762",
                CancelQuestion1 = DateTime.Now,
                CancelReason = "بطيخ البطاطس",

                FilesPaths = new HashSet<string>
                {
                    "c:\\RAMSTempUploadFiles\\1.pdf"
                },
                ApplicantUserIdNumber = 1027679073,
                CreatedByIdNumber = 1027679073,
                ClientIPAddress = ipAddress
            });

            resultsList.Items.Add(results.IsSuccess ? results.Description : results.IsSuccess.ToString());

            foreach (var currentMessage in results.ResultsList)
            {
                if (currentMessage.IsSuccess)
                    continue;

                resultsList.Items.Add(currentMessage.ResponseText);
            }
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            resultsList.Items.Clear();
        }

        protected void ButtonCreateRunAwayComplaintRequest_Click(object sender, EventArgs e)
        {
            var objectInstance = new PostBusinessService();

            var results = objectInstance.CreateRunAwayComplaintRequest(new ComplaintCreateRequestInfo
            {
                LaborerIdNumber = 2288202951,
                BorderNumber = null,
                IsRequestByLaborer = false,
                LaborerMobileNo = "966546053897",

                ComplaintQuestion1 = Convert.ToDateTime("2018-04-01T00:00:00"),
                ComplaintQuestion2 = Convert.ToDateTime("2018-04-03T00:00:00"),
                ComplaintQuestion3 = Convert.ToDateTime("2018-04-06T00:00:00"),
                ComplaintQuestion4 = "Add in Release notes information about he NIC Mockup",

                ApplicantUserIdNumber = 2288202951,
                CreatedByIdNumber = 2344778655,
                FilesPaths = new HashSet<string>
                {
                    "c:\\RAMSTempUploadFiles\\1.pdf"
                },
                RequestNumber = "1439-1-1764",
                RunAwayRequestId = 1764,
                ClientIPAddress = ipAddress
            });


            resultsList.Items.Add(results.IsSuccess ? results.Description : results.IsSuccess.ToString());

            foreach (var currentMessage in results.ResultsList)
            {
                if (currentMessage.IsSuccess)
                    continue;

                resultsList.Items.Add(currentMessage.ResponseText);
            }

            resultsList.Items.Add("Done");
        }

        protected void ButtonGetRegionLaborerOfficeList_Click(object sender, EventArgs e)
        {
            var objectInstance = new GetBusinessService();

            int? value = null;

            if (TextBox1.Text.Trim() != string.Empty)
                value = Convert.ToInt32(TextBox1.Text.Trim());

            var xx = objectInstance.GetRegionLaborerOfficeList(value, 1027679073);
            resultsList.Items.Clear();

            if (xx == null)
            {
                resultsList.Items.Add("Done");
                return;
            }

            foreach (var currentRow in xx) resultsList.Items.Add(currentRow.Name);
        }

        protected void ButtonGetForApprovalRunAwayRequestsList_Click(object sender, EventArgs e)
        {
            var xx = new GetBusinessService();
            var results = xx.GetForApprovalRunAwayRequestsList(
                (TypedObjects.ComplaintRequestStatus)Convert.ToInt32(TextBoxStatus.Text.Trim()),
                null, null, null, 10, 1, 2344778655);

            if (results == null)
            {
                resultsList.Items.Add("Done");
                return;
            }

            foreach (var currentRow in results)
                resultsList.Items.Add(currentRow.LaborerFullName + " - " + currentRow.RunAwayRequestNumber);
        }

        protected void ButtonUpdateRunAwayComplaintStatus_Click(object sender, EventArgs e)
        {
            var xx = new PostBusinessService();
            var results = new ResponseMsg();

            if (RadioButtonReview.Checked)
                results = xx.CreateRunAwayReviewRequest(1746, 2251302473, ipAddress);

            else if (RadioButtonAccept.Checked)
                results = xx.AcceptComplaintRequest(1746, 2251302473, ipAddress);

            else if (RadioButtonReject.Checked)
                results = xx.RejectComplaintRequest(1746, "طظ بلبن فيك", 2251302473, ipAddress);

            resultsList.Items.Add(results.ResponseText == string.Empty ? "Done" : results.ResponseText);
        }

        protected void ButtonGetForReviewRunAwayRequestsList_Click(object sender, EventArgs e)
        {
            var xx = new GetBusinessService();
            var results = xx.GetForReviewRunAwayRequestsList(24,
                (TypedObjects.ComplaintRequestStatus)Convert.ToInt32(TextBoxStatus.Text.Trim()),
                null, null, null, null, null, 10, 1, 2344778655);

            if (results == null)
            {
                resultsList.Items.Add("Done");
                return;
            }

            foreach (var currentRow in results)
                resultsList.Items.Add(currentRow.LaborerFullName + " - " + currentRow.RunAwayRequestNumber);
        }

        protected void ButtonUpdateComplaintRequestByReviewAppointment_Click(object sender, EventArgs e)
        {
            var xx = new PostBusinessService();
            var results = xx.UpdateComplaintRequestByReviewAppointment(
                1651, 2344778655, TypedObjects.ReviewAppointmentType.EstablishmentAppointment, ipAddress);

            if (results == null)
            {
                resultsList.Items.Add("Done");
                return;
            }

            resultsList.Items.Add(results.ResponseText);
        }

        protected void ButtonUpdateComplaintRequestByReviewResults_Click(object sender, EventArgs e)
        {
            var xx = new PostBusinessService();
            var results = new ResponseMsg();

            if (CheckBoxContinue.Checked)
                results = xx.UpdateComplaintRequestByReviewResults(1651, "Toto Mission", 2344778655,
                    TypedObjects.ReviewResultsType.InProgressResult, ipAddress);
            else
                results = xx.UpdateComplaintRequestByReviewResults(1651, "Toto Mission", 2344778655,
                    TypedObjects.ReviewResultsType.FinalResult, ipAddress);

            if (results == null)
            {
                resultsList.Items.Add("Done");
                return;
            }

            resultsList.Items.Add(results.ResponseText);
        }

        protected void ButtonSecureString_Click(object sender, EventArgs e)
        {
            var cmtsUserName = StringToSecureString("TOTOMISSION");

            resultsList.Items.Clear();
            resultsList.Items.Add(SecureStringToString(cmtsUserName));
        }

        /// <summary>A string extension method that convert string to secure string.</summary>
        /// <remarks>Wael Mohsen, 2018-05-08.</remarks>
        /// <param name="data">The data to act on.</param>
        /// <returns>The string converted to secure string.</returns>
        public SecureString StringToSecureString(string data)
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
        public string SecureStringToString(SecureString data)
        {
            var pointer = IntPtr.Zero;
            try
            {
                pointer = Marshal.SecureStringToGlobalAllocUnicode(data);
                var normalString = Marshal.PtrToStringUni(pointer);

                return normalString;
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(pointer);
            }
        }

        protected void ButtonSearchNotes_Click(object sender, EventArgs e)
        {
            var xx = new PostRunAwayRequest();

            resultsList.Items.Add(
                xx.SetRunAwayEstablishmentNote(1018388, 1027679073, "رسالة تست رامز جلال", new UnitOfWork())
                    .ResponseText);
        }

        protected void GetForReviewRunAwayRequestsList_Click(object sender, EventArgs e)
        {
            var xx = new GetBusinessService();

            var results = xx.GetForReviewRunAwayRequestsList(
                1, TypedObjects.ComplaintRequestStatus.UnderLaborOfficeProcessing,
                1, null, null, null, null, 10, 1, 2255917854);

            if (results == null)
            {
                resultsList.Items.Add("Done");
                return;
            }

            foreach (var currentRow in results)
                resultsList.Items.Add(currentRow.LaborerFullName + " - " + currentRow.RunAwayRequestNumber);
        }

        protected void IsLaborerHasCase_Click(object sender, EventArgs e)
        {
            var laborerCase = new GetCase();

            var result = laborerCase.IsLaborerHasCase(1, 162745, 2, 2, 919174);

            resultsList.Items.Add(result.IsSuccess.ToString());
        }
    }
}