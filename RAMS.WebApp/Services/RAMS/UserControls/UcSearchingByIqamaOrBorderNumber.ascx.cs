// ***********************************************************************
// Assembly         : RAMS.WebApp
// Author           : WaelMohsen
// Created          : 08-15-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 08-15-2018
// ***********************************************************************
// <copyright file="UcSearchingByIqamaOrBorderNumber.ascx.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Mol.Common;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoggingUtilities;

namespace RAMS.WebApp.Services.RAMS.UserControls
{
    /// <inheritdoc />
    /// <summary>
    /// Class UcSearchingByIqamaOrBorderNumber.
    /// </summary>
    /// <seealso cref="T:System.Web.UI.UserControl" />
    public partial class UcSearchingByIqamaOrBorderNumber : UserControl
    {
        #region Fields and properties 

        /// <summary>
        /// Gets or sets a value indicating whether this instance is iqama number valid.
        /// </summary>
        /// <value><c>true</c> if this instance is iqama number valid; otherwise, <c>false</c>.</value>
        public bool IsIqamaNumberValid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is Boundary Number valid.
        /// </summary>
        /// <value><c>true</c> if this instance is Boundary Number valid; otherwise, <c>false</c>.</value>
        public bool IsBoundaryNumberValid { get; set; }

        /// <summary>
        /// return Iqama number
        /// </summary>
        /// <value>The iqama number.</value>
        public string IqamaNumber => iqamaNumberTextBox.Text;

        /// <summary>
        /// return border number
        /// </summary>
        /// <value>The border number.</value>
        public string BorderNumber => bounderyNumberTextBox.Text;

        /// <summary>
        /// reset user control to default values
        /// </summary>
        /// <value><c>true</c> if [reset user control]; otherwise, <c>false</c>.</value>
        public bool ResetUserControl
        {
            set
            {
                if (!value) return;
                iqamaNumberTextBox.Text = string.Empty;
                bounderyNumberTextBox.Text = string.Empty;
                laborerRadioButtonList.SelectedIndex = 0;
                if (laborerRadioButtonList.SelectedValue == "IqamaNumber")
                {
                    iqamaNumberDiv.Visible = true;
                    borderNumberDiv.Visible = false;
                }
                else
                {
                    iqamaNumberDiv.Visible = false;
                    borderNumberDiv.Visible = true;
                }
            }
        }

        /// <summary>
        /// Delegate SearchFinished
        /// </summary>
        protected delegate void SearchFinished();

        /// <summary>
        /// Occurs when [on search finished].
        /// </summary>
        protected event SearchFinished OnSearchFinished;

        /// <summary>
        /// Gets or sets a value indicating whether [change RadioButton value].
        /// </summary>
        /// <value><c>true</c> if [change RadioButton value]; otherwise, <c>false</c>.</value>
        protected bool ChangeRadioButtonValue { get; set; }

        /// <summary>
        /// Gets or sets the array messages.
        /// </summary>
        /// <value>The array messages.</value>
        protected string[] ErrorMessages { get; set; }

        /// <summary>
        /// Arr Messages
        /// </summary>
        /// <value>The arr messages.</value>
        protected string[] ArrMessages { get; set; }

        /// <summary>
        /// Show Error Message
        /// </summary>
        protected void ShowErrorMsg()
        {
            //ClearPage();
            ScriptManager.RegisterStartupScript(Page, GetType(), "ShowErrorMsg", "ShowErrorMsg();", true);
        }

        #endregion

        #region Events

        /// <summary>
        /// load Page
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    laborerRadioButtonList.SelectedIndex = 0;
                    iqamaNumberDiv.Visible = true;
                    borderNumberDiv.Visible = false;
                    iqamaNumberTextBox.Text = string.Empty;
                    bounderyNumberTextBox.Text = string.Empty;
                    ChangeRadioButtonValue = false;
                }
                if (laborerRadioButtonList.SelectedValue == "IqamaNumber")
                {
                    iqamaNumberDiv.Visible = true;
                    borderNumberDiv.Visible = false;
                }
                else
                {
                    iqamaNumberDiv.Visible = false;
                    borderNumberDiv.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                LoggingHelper.Error(ex.Message, ex);
                ShowErrorMsg();
            }
        }

        /// <summary>
        /// search  action
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void SearchRunAwayButton_Click(object sender, EventArgs e)
        {
            try
            {
                OnSearchFinished?.Invoke();
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                LoggingHelper.Error(ex.Message, ex);
                ShowErrorMsg();
            }
        }

        #region Server validations 

        /// <summary>
        /// ValidateIqamaNumber
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="args">The <see cref="ServerValidateEventArgs" /> instance containing the event data.</param>
        protected void ValidateIqamaNumber_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                args.IsValid = true;
                if (CommonUtilities.IsIDNumberValid(args.Value))
                {
                    IsIqamaNumberValid = true;
                    return;
                }
                args.IsValid = false;
                IsIqamaNumberValid = false;
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                LoggingHelper.Error(ex.Message, ex);
                ShowErrorMsg();
                args.IsValid = false;
                IsBoundaryNumberValid = false;
            }
        }

        /// <summary>
        /// ValidateBoundaryNumber
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="args">The <see cref="ServerValidateEventArgs" /> instance containing the event data.</param>
        protected void validateBoundaryNumber_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                args.IsValid = true;
                if (CommonUtilities.IsIDNumberValid(args.Value))
                {
                    IsIqamaNumberValid = true;
                    return;
                }
                args.IsValid = false;
                IsBoundaryNumberValid = false;
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                LoggingHelper.Error(ex.Message, ex);
                ShowErrorMsg();
                args.IsValid = false;
                IsBoundaryNumberValid = false;
            }
        }

        #endregion

        /// <summary>
        /// radio button select  items
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void LaborerRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedValue = laborerRadioButtonList.SelectedValue;
                ChangeRadioButtonValue = true;
                //تحديد موعد
                if (selectedValue == "IqamaNumber")
                {
                    iqamaNumberDiv.Visible = true;
                    borderNumberDiv.Visible = false;
                    iqamaNumberTextBox.Text = string.Empty;
                    bounderyNumberTextBox.Text = string.Empty;
                }
                else
                {
                    iqamaNumberDiv.Visible = false;
                    borderNumberDiv.Visible = true;
                    iqamaNumberTextBox.Text = string.Empty;
                    bounderyNumberTextBox.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                LoggingHelper.Error(ex.Message, ex);
                ShowErrorMsg();
            }
        }

        #endregion
    }
}