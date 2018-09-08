// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="Lookup_RAMS_ComplaintTimes_Repository.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using MOL.EFDAL.Models;

namespace MOL.EFDAL.Repository
{
    /// <summary>
    /// Class Lookup_RAMS_ComplaintTimes_Repository.
    /// </summary>
    /// <seealso cref="MOL.EFDAL.Repository.EFRepository{MOL.EFDAL.Models.Lookup_RAMS_ComplaintTimes}" />
    public partial class Lookup_RAMS_ComplaintTimes_Repository : EFRepository<Lookup_RAMS_ComplaintTimes>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lookup_RAMS_ComplaintTimes_Repository"/> class.
        /// </summary>
        public Lookup_RAMS_ComplaintTimes_Repository()
        {
            Context = new MOLEFEntities();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lookup_RAMS_ComplaintTimes_Repository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Lookup_RAMS_ComplaintTimes_Repository(MOLEFEntities context) : base(context)
        {

        }
    }
}
