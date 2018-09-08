// ***********************************************************************
// Assembly         : RAMS.CrossCutting
// Author           : WaelMohsen
// Created          : 03-07-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 03-07-2018
// ***********************************************************************
// <copyright file="BaseDisposeClass.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace RAMS.CrossCutting
{
    /// <inheritdoc />
    /// <summary>
    /// Class BaseDisposeClass.
    /// Public implementation of Dispose pattern callable by consumers.
    /// </summary>
    /// <seealso cref="T:System.IDisposable" />
    public class BaseDisposeClass : IDisposable
    {
        /// <summary>
        ///  Flag: Has Dispose already been called?
        /// </summary>
        private bool Disposed { get; set; } = false;

        /// <summary>
        /// Instantiate a SafeHandle instance.
        /// </summary>
        private SafeHandle Handle { get; } = new SafeFileHandle(IntPtr.Zero, true);

        /// <inheritdoc />
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing)
            {
                Handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            Disposed = true;
        }
    }
}