using System;

namespace EAPP.WebApp.MasterPages
{
    public partial class Individual : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var user = (MolMembershipUser)Session["MembershipUser"];
            //masterUserId.Value = user.IdNumber.ToString();
            //userImage.Src = user.GenderId == 2 ? "/Services/Eapp/images/female.png" : "/Services/Eapp/images/male.jpg";
            //userNameLabel.InnerText = user.FirstName + " ";
            //userNameLabel.InnerText += user.FourthName;

            masterUserId.Value = "1076462256";

            //if (UserHasEstablishment(user.IdNumber))
            //    establishmentLink.Visible = true;
            //else
            //    establishmentLink.Visible = false;
            //masterUserId.Value = "1";
        }

        //private bool UserHasEstablishment(long ? userId)
        //{
        //    return new EstablishmentMailBoxController(new Repository<TWSLContext>()).GetEstablishments(userId.ToString()).Count>0;
        //}

    }
}