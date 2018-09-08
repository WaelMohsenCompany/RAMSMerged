// ***********************************************************************
// Assembly         : RAMS.WebApp
// Author           : WaelMohsen
// Created          : 08-15-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 07-29-2018
// ***********************************************************************
// <copyright file="FileModel.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace RAMS.WebApp.Services.RAMS.Models
{
    /// <summary>
    /// Class FileModel.
    /// </summary>
    [Serializable]
    public class FileModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; set; }
    }
}