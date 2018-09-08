// ***********************************************************************
// Assembly         : RAMS.WebApp
// Author           : WaelMohsen
// Created          : 08-15-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 07-29-2018
// ***********************************************************************
// <copyright file="FileUtility.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RAMS.BusinessServices.Post;
using RAMS.WebApp.Services.RAMS.Base;
using RAMS.WebApp.Services.RAMS.Models;
using RAMSInfrastructure = RAMS.InfrastructureService.FileTransfer;

namespace RAMS.WebApp.Services.RAMS.Utility
{
    /// <inheritdoc />
    /// <summary>
    /// Class FileUtility.
    /// </summary>
    /// <seealso cref="!:RAMS.WebApp.Services.RAMS.Base.RamsBasePage" />
    public class FileUtility : RamsBasePage
    {
        #region Fields and Properties 

        /// <summary>
        /// post business service
        /// </summary>
        private readonly PostBusinessService _postBusinessService = new PostBusinessService();

        #endregion

        #region Methods 

        #region Upload files 

        /// <summary>
        /// upload file
        /// </summary>
        /// <param name="neededDocumentFileUpload">The needed document file upload.</param>
        /// <param name="fileUploadCustomError">The file upload custom error.</param>
        /// <param name="maxFileSize">Maximum size of the file.</param>
        /// <param name="files">The files.</param>
        public void UploadFile(FileUpload neededDocumentFileUpload, HtmlGenericControl fileUploadCustomError,
            int maxFileSize, List<FileModel> files)
        {
            if (!ValidateUploadedFile(neededDocumentFileUpload, fileUploadCustomError, maxFileSize)) return;
            FileModel fileMode = null;
            if (files != null && files.Any())
            {
                fileMode = files.FirstOrDefault(f => f.Name == neededDocumentFileUpload.FileName);
            }
            if (fileMode != null) return;
            var user = GetCurrentUser();
            if (user?.IdNumber == null) return;
            var requestInfo = _postBusinessService.UploadFile(new RAMSInfrastructure.RemoteFileInfo
            {
                FileName = Path.GetFileName(neededDocumentFileUpload.FileName),
                Length = neededDocumentFileUpload.PostedFile.ContentLength,
                FileByteStream = neededDocumentFileUpload.PostedFile.InputStream
            }, user.IdNumber.Value);
            if (string.IsNullOrEmpty(requestInfo.FileName)) return;
            if (files == null)
            {
                files = new List<FileModel>();
            }
            files.Add(new FileModel { Name = neededDocumentFileUpload.FileName, Path = requestInfo.FileName });
        }

        /// <summary>
        /// Validate uploaded file against
        /// </summary>
        /// <param name="neededDocumentFileUpload">The needed document file upload.</param>
        /// <param name="fileUploadCustomError">The file upload custom error.</param>
        /// <param name="systemFileSize">Size of the system file.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected static bool ValidateUploadedFile(FileUpload neededDocumentFileUpload,
            HtmlGenericControl fileUploadCustomError,
            int systemFileSize)
        {
            var allowedExtensions = new List<string>
            {
                ".pdf",
                ".doc",
                ".docx",
                ".ppt",
                ".pptx",
                ".txt",
                ".xls",
                ".xlsx",
                ".png",
                ".jpg",
                ".jpeg",
                ".pdf"
            };
            if (!neededDocumentFileUpload.HasFile)
            {
                fileUploadCustomError.InnerText = "عفوا، يجب إرفاق نسخة إلكترونية من المستندات المطلوبة.";
                fileUploadCustomError.Style.Add("display", "block");
                return false;
            }
            var extension = Path.GetExtension(neededDocumentFileUpload.FileName);
            if (extension != null && !allowedExtensions.Contains(extension.ToLower()))
            {
                fileUploadCustomError.InnerText =
                    "صيغة ملف الأوراق الثبوتية الذي تم رفعه غير سليمة، برجاء إعادة رفع الملف بصيغ قياسية.";
                fileUploadCustomError.Style.Add("display", "block");
                return false;
            }
            var iFileSize = neededDocumentFileUpload.FileBytes.Length;
            var systemFileSizeByte = systemFileSize * 1024 * 1024;
            if (iFileSize > systemFileSizeByte || iFileSize <= 102400) // 5MB Or 100KB
            {
                var minimumFileSize = ConfigurationManager.AppSettings["MinFileSize"];
                fileUploadCustomError.InnerText = "يجب ان يكون حجم الملف بين (" + systemFileSize + "MB - +" +
                                                  minimumFileSize + "KB).";
                fileUploadCustomError.Style.Add("display", "block");
                return false;
            }
            fileUploadCustomError.Style.Add("display", "none");
            return true;
        }

        #endregion

        #endregion

    }
}
