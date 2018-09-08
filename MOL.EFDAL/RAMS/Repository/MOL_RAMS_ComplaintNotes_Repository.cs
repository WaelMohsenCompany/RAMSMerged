// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="MOL_RAMS_ComplaintNotes_Repository.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using MOL.EFDAL.Models;
using System.Linq;

namespace MOL.EFDAL.Repository
{
    /// <summary>
    /// Class MOL_RAMS_ComplaintNotes_Repository.
    /// </summary>
    /// <seealso cref="MOL.EFDAL.Repository.EFRepository{MOL.EFDAL.Models.MOL_RAMS_ComplaintNotes}" />
    public partial class MOL_RAMS_ComplaintNotes_Repository : EFRepository<MOL_RAMS_ComplaintNotes>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_RAMS_ComplaintNotes_Repository"/> class.
        /// </summary>
        public MOL_RAMS_ComplaintNotes_Repository()
        {
            Context = new MOLEFEntities();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_RAMS_ComplaintNotes_Repository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MOL_RAMS_ComplaintNotes_Repository(MOLEFEntities context) : base(context)
        {

        }

        /// <summary>
        /// Gets the complaint note by order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>MOL_RAMS_ComplaintNotes.</returns>
        public MOL_RAMS_ComplaintNotes GetComplaintNoteByOrder(int order)
        {
            if (order > 0)
            {
                //===================================================================================
                //Select the final order has to applied
                var complaintTimeId = Context.Lookup_RAMS_ComplaintTimes
                    .OrderBy(ct => ct.ComplaintOrder)
                    .First(ct => ct.ComplaintOrder >= order).Id;

                //====================================================================================
                //Return full complaint note info
                return Context.MOL_RAMS_ComplaintNotes.Single(cn => cn.ComplaintTimeId == complaintTimeId);
            }
            else
                return null;
        }

    }
}
