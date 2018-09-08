// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 02-05-2018
// ***********************************************************************
// <copyright file="MOL_RAMS_CancelRunAway_Files_Repository.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************

using MOL.EFDAL.Models;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    /// <summary>
    /// Class MOL_RAMS_CancelRunAway_Files_Repository.
    /// </summary>
    /// <seealso cref="MOL.EFDAL.Repository.EFRepository{MOL.EFDAL.Models.MOL_RAMS_CancelRunAway_Files}" />
    public partial class MOL_RAMS_CancelRunAway_Files_Repository : EFRepository<MOL_RAMS_CancelRunAway_Files>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_RAMS_CancelRunAway_Files_Repository"/> class.
        /// </summary>
        public MOL_RAMS_CancelRunAway_Files_Repository()
        {
            Context = new MOLEFEntities();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_RAMS_CancelRunAway_Files_Repository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MOL_RAMS_CancelRunAway_Files_Repository(MOLEFEntities context) : base(context)
        {

        }

        /// <summary>
        /// Function saves files to DB
        /// </summary>
        /// <param name="requestId">Target Runaway request Id</param>
        /// <param name="filesPaths">Files paths</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddFiles(int requestId, string[] filesPaths)
        {
            foreach (var newFile in filesPaths.Select(currentFilePath => new MOL_RAMS_CancelRunAway_Files
            {
                FileName = System.IO.Path.GetFileName(currentFilePath),
                FilePath = currentFilePath,
                RunAwayId = requestId,

            }))
            {
                //Bulk insert files to DB
                Context.MOL_RAMS_CancelRunAway_Files.Add(newFile);
            }

            return Context.SaveChanges() > 0;
        }
    }
}
