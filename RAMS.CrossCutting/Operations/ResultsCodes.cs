// ***********************************************************************
// Assembly         : RAMS.CrossCutting
// Author           : WaelMohsen
// Created          : 04-11-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-11-2018
// ***********************************************************************
// <copyright file="ResultsCodes.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RAMS.CrossCutting
{
    /// <summary>
    /// Enumeration of Error Codes
    /// </summary>
    public enum ResultsCodes : uint
    {
        /// <summary>
        /// Business rules violated with error message
        /// </summary>
        BusinessRulesViolationError = 0x00008D07,

        /// <summary>
        /// Business rules violated with Warning message
        /// </summary>
        BusinessRulesViolationWarning = 0x00008D08,

        /// <summary>
        /// Business rules Passed Successfully
        /// </summary>
        BusinessRulesSucceeded = 0x00008D09,

        /// <summary>
        /// The action transaction failed
        /// </summary>
        ActionTransactionError = 0x00008D10,

        /// <summary>
        /// The action transaction succeeded
        /// </summary>
        ActionTransactionSucceeded = 0x00008D11
    }
}
