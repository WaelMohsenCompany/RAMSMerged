// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 01-29-2018
// ***********************************************************************
// <copyright file="MOL_RAMS_RunAwayTransactionsLog_Repository.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using MOL.EFDAL.Models;

namespace MOL.EFDAL.Repository
{
    /// <summary>
    /// Class MOL_RAMS_RunAwayTransactionsLog_Repository.
    /// </summary>
    /// <seealso cref="MOL.EFDAL.Repository.EFRepository{MOL.EFDAL.Models.MOL_RAMS_RunAwayTransactionsLog}" />
    public partial class MOL_RAMS_RunAwayTransactionsLog_Repository : EFRepository<MOL_RAMS_RunAwayTransactionsLog>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_RAMS_RunAwayTransactionsLog_Repository"/> class.
        /// </summary>
        public MOL_RAMS_RunAwayTransactionsLog_Repository()
        {
            Context = new MOLEFEntities();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MOL_RAMS_RunAwayTransactionsLog_Repository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MOL_RAMS_RunAwayTransactionsLog_Repository(MOLEFEntities context) : base(context)
        {

        }
    }
}
