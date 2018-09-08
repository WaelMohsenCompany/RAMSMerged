// ***********************************************************************
// Assembly         : RAMS.InfrastructureService
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 03-07-2018
// ***********************************************************************
// <copyright file="FileTransferService.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using RAMS.CrossCutting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security;
using System.Security.Permissions;

namespace RAMS.InfrastructureService.FileTransfer
{

    /// <summary>
    /// Class DownloadRequest.
    /// </summary>
    public class DownloadRequest
    {
        /// <summary>
        /// The file name
        /// </summary>
        public string FileName;

        /// <summary>
        /// The Runaway Request number
        /// </summary>
        public string RequestNumber = string.Empty;
    }

    /// <inheritdoc />
    /// <summary>
    /// Class RemoteFileInfo.
    /// </summary>
    /// <seealso cref="T:System.IDisposable" />
    public class RemoteFileInfo : IDisposable
    {

        /// <summary>
        /// The file name
        /// </summary>
        public string FileName;

        /// <summary>
        /// The length
        /// </summary>
        public long Length;

        /// <summary>
        /// The file byte stream
        /// </summary>
        public System.IO.Stream FileByteStream;

        /// <inheritdoc />
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (FileByteStream == null)
                return;
            FileByteStream.Close();
            FileByteStream = null;
        }
    }

    /// <inheritdoc />
    /// <summary>
    ///     Class FileTransferService.
    /// </summary>
    /// <seealso cref="T:RAMS.CrossCutting.BaseDisposeClass" />
    public class FileTransferService : BaseDisposeClass
    {
        #region "Private members"

        /// <summary>
        /// The temporary upload folder
        /// </summary>
        private readonly string tempUploadFolder = ConfigurationManager.AppSettings["UploaderTempFolderPath"];
        /// <summary>
        /// The final folder path
        /// </summary>
        private readonly string finalFolderPath = ConfigurationManager.AppSettings["UploaderFinalFolderPath"];

        #endregion

        /// <summary>
        ///     Function downloads fie to caller machine
        /// </summary>
        /// <param name="requestFileName">Name of the request file.</param>
        /// <returns>RemoteFileInfo.</returns>
        /// <exception cref="System.IO.FileNotFoundException">File not found</exception>
        public RemoteFileInfo DownloadFile(DownloadRequest requestFileName)
        {
            //=====================================================================================
            // Ensure that all path elements are safe path elements.
            if (string.IsNullOrEmpty(requestFileName.FileName))
            {
                throw new ArgumentException(TypedObjects.NoFileInfo);
            }

            if (Path.GetFileName(requestFileName.FileName) != requestFileName.FileName)
            {
                throw new SecurityException($"{"1: "}:{TypedObjects.PathTraversalVulnerabilities}");
            }

            if (requestFileName.FileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                throw new SecurityException($"{"2: "}:{TypedObjects.PathTraversalVulnerabilities}");
            }

            //=====================================================================================
            //Get the file
            var result = new RemoteFileInfo();
            try
            {
                // Get some info about the input file
                var filePath = Path.Combine(finalFolderPath, requestFileName.RequestNumber, requestFileName.FileName);

                //=====================================================================================
                //Check if security Vulnerabilities happened
                if (!filePath.StartsWith(finalFolderPath))
                {
                    throw new SecurityException(
                        $"{System.Reflection.MethodBase.GetCurrentMethod().Name}: {TypedObjects.PathTraversalVulnerabilities}");
                }

                //=====================================================================================
                var fileInfo = new FileInfo(filePath);

                // Check if file exists
                if (!fileInfo.Exists)
                    throw new FileNotFoundException(
                        $"{System.Reflection.MethodBase.GetCurrentMethod().Name}: {TypedObjects.NoFileInfo}",
                        requestFileName.FileName);

                //=====================================================================================
                //Demand Code-Access Security
                var filePermission = new FileIOPermission(FileIOPermissionAccess.Read, filePath);

                // Open stream
                filePermission.Demand();
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                // Return result
                result.FileName = requestFileName.FileName;
                result.Length = fileInfo.Length;
                result.FileByteStream = stream;
            }
            catch (SecurityException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        ///     Function uploads files to Server on Local Drive
        /// </summary>
        /// <param name="requestFileInfo">The request file information.</param>
        /// <returns>DownloadRequest.</returns>
        public DownloadRequest UploadFile(RemoteFileInfo requestFileInfo)
        {
            //=====================================================================================
            // Ensure that all path elements are safe path elements.
            if (string.IsNullOrEmpty(requestFileInfo.FileName))
            {
                throw new ArgumentException(TypedObjects.NoFileInfo);
            }

            if (Path.GetFileName(requestFileInfo.FileName) != requestFileInfo.FileName)
            {
                throw new SecurityException(
                    $"{System.Reflection.MethodBase.GetCurrentMethod().Name}: {TypedObjects.PathTraversalVulnerabilities}");
            }

            if (requestFileInfo.FileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                throw new SecurityException(
                    $"{System.Reflection.MethodBase.GetCurrentMethod().Name}: {TypedObjects.PathTraversalVulnerabilities}");
            }

            //=====================================================================================
            //Create the file
            var sourceStream = requestFileInfo.FileByteStream;

            var filePath = Path.Combine(tempUploadFolder, requestFileInfo.FileName);
            var ext = new FileInfo(requestFileInfo.FileName).Extension;

            using (var targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //read from the input stream in 6K chunks
                //and save to output stream
                const int bufferLen = 65000;
                var buffer = new byte[bufferLen];
                var count = 0;
                while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
                {
                    targetStream.Write(buffer, 0, count);
                }
                targetStream.Close();
                sourceStream.Close();
            }

            var newFile = Path.Combine(tempUploadFolder, Guid.NewGuid() + ext);

            //=====================================================================================
            //Check if security Vulnerabilities happened
            if (!newFile.StartsWith(tempUploadFolder))
            {
                throw new SecurityException(
                    $"{System.Reflection.MethodBase.GetCurrentMethod().Name}: {TypedObjects.PathTraversalVulnerabilities}");
            }

            //=====================================================================================
            //Demand Code-Access Security
            var fromFilePermission = new FileIOPermission(FileIOPermissionAccess.Write, filePath);
            var toFilePermission = new FileIOPermission(FileIOPermissionAccess.Write, newFile);

            //=====================================================================================
            //Move the file to final destination
            try
            {
                fromFilePermission.Demand();
                toFilePermission.Demand();

                File.Move(filePath, newFile);
            }
            catch (SecurityException exp)
            {
                throw new SecurityException(exp.Message);
            }

            return new DownloadRequest
            {
                FileName = newFile
            };
        }

        /// <summary>
        ///     Function moves file from one location to another one
        /// </summary>
        /// <param name="oldFilesNames">The old files names.</param>
        /// <param name="requestNumber">The request number.</param>
        /// <param name="operationTypeName">Name of the operation type.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public List<string> MoveFile(List<string> oldFilesNames, string requestNumber, string operationTypeName)
        {
            if (oldFilesNames.Count <= 0)
                return null;

            //=====================================================================================
            // Ensure that file name elements are safe path elements.
            if (string.IsNullOrEmpty(requestNumber) || string.IsNullOrEmpty(operationTypeName))
            {
                throw new ArgumentException(TypedObjects.NoFileInfo);
            }

            if (Path.GetFileName(requestNumber) != requestNumber ||
                Path.GetFileName(operationTypeName) != operationTypeName)
            {
                throw new SecurityException(
                    $"{System.Reflection.MethodBase.GetCurrentMethod().Name}: {TypedObjects.PathTraversalVulnerabilities}");
            }

            if (requestNumber.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0 ||
                operationTypeName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                throw new SecurityException(
                    $"{System.Reflection.MethodBase.GetCurrentMethod().Name}: {TypedObjects.PathTraversalVulnerabilities}");
            }

            //=====================================================================================
            // Ensure that all path elements are safe path elements.
            foreach (var currentFileName in oldFilesNames)
            {
                if (string.IsNullOrEmpty(currentFileName))
                {
                    throw new ArgumentException(TypedObjects.NoFileInfo);
                }

                if (Path.GetFileName(currentFileName).IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                {
                    throw new SecurityException(
                        $"{System.Reflection.MethodBase.GetCurrentMethod().Name}: {TypedObjects.PathTraversalVulnerabilities}");
                }
            }

            //Create new folder for request
            var newFilePath = Path.Combine(finalFolderPath, requestNumber);
            //=====================================================================================
            //Check if security Vulnerabilities happened
            if (!newFilePath.StartsWith(finalFolderPath))
            {
                throw new SecurityException(
                    $"{System.Reflection.MethodBase.GetCurrentMethod().Name}: {TypedObjects.PathTraversalVulnerabilities}");
            }


            Directory.CreateDirectory(newFilePath);

            // Check that the folder is created
            if (Directory.Exists(newFilePath))
            {
                var newFilesList = new List<string>();

                //Rename and move the folder to final Destination
                var newFileName = requestNumber + "- ملف {0} {1}{2}";
                string movingFilePath;

                for (var index = 0; index < oldFilesNames.Count; index++)
                {
                    movingFilePath =
                        Path.Combine(newFilePath,
                            string.Format(newFileName, operationTypeName, index + 1,
                                Path.GetExtension(oldFilesNames[index])));

                    //Check if file already Exists
                    if (File.Exists(movingFilePath))
                        File.Delete(movingFilePath);

                    File.Move(
                        Path.Combine(tempUploadFolder, oldFilesNames[index]), movingFilePath);

                    newFilesList.Add(Path.Combine(newFilePath,
                        string.Format(newFileName, operationTypeName, index + 1,
                            Path.GetExtension(oldFilesNames[index]))));
                }

                return newFilesList;
            }

            return null;
        }
    }
}