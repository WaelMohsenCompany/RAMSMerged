// ***********************************************************************
// Assembly         : RAMS.EnterpriseServices
// Author           : WaelMohsen
// Created          : 04-05-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-05-2018
// ***********************************************************************
// <copyright file="PostCommon.svc.cs" company="Tasleem IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using RAMS.CrossCutting;
using RAMS.InfrastructureService.FileTransfer;

namespace RAMS.EnterpriseServices.Common.Post
{
    /// <inheritdoc />
    /// <summary>
    /// Class PostCommon.
    /// </summary>
    public class PostCommon : BaseDisposeClass
    {
        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <param name="requestFileInfo">The request file information.</param>
        /// <returns>DownloadRequest.</returns>
        public DownloadRequest UploadFile(RemoteFileInfo requestFileInfo)
        {
            using (var fileTransfer = new FileTransferService())
            {
                return fileTransfer.UploadFile(requestFileInfo);
            }
        }
    }
}
