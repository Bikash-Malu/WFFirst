using System;
using System.Web.UI;

namespace WFFirst
{
    public partial class MyUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ViewState["Message"] != null)
                {
                    lblMessage.Text = ViewState["Message"].ToString();
                }
            }
        }

        protected void btnShowMessage_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "You entered: " + txtInput.Text;
            ViewState["Message"] = lblMessage.Text;
        }
    }
}
