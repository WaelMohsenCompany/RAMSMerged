using System;
using System.Web.Security;
using Mol.Integration.Authintication;

namespace RAMS.WebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RedirectButton_Click(object sender, EventArgs e)
        {

            LoadCurrentUser();

            Response.Redirect(RedirectDropDownList.SelectedValue);

        }

        private void LoadCurrentUser()
        {
            Session["CurrentLoggedInSessionID"] = Session.SessionID;

            MolMembershipUser user = new MolMembershipUser()
            {
                FirstName = UserNameTextBox.Text,
                IdNumber = long.Parse(UserIdTextBox.Text)
                ,UserTypeId = 3
            };


            Session["MembershipUser"] = user;

            FormsAuthentication.SetAuthCookie(UserNameTextBox.Text, true);
            //FormsAuthentication.RedirectFromLoginPage(UserNameTextBox.Text, true);
      
        }


    }
}