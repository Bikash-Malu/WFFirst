using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

namespace WFFirst
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                lblmessage.Text = "";
                lblmessage.Visible = false;
                lblErrorMessage.Text = "";
                lblErrorMessage.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "admin" && password == "password")
            {
                Session["Username"] = username;
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Invalid username or password.";
                lblErrorMessage.Visible = true;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (FileUpload1.HasFile)
            {
                try
                {
                    string uploadFolder = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }
                    string filePath = Path.Combine(uploadFolder, Path.GetFileName(FileUpload1.FileName));
                    FileUpload1.SaveAs(filePath);
                    sb.AppendFormat("File uploaded successfully!<br/>");
                    //sb.AppendFormat("Save Path: {0}<br/>", filePath);
                    //sb.AppendFormat("File Type: {0}<br/>", FileUpload1.PostedFile.ContentType);
                    //sb.AppendFormat("File Size: {0} bytes<br/>", FileUpload1.PostedFile.ContentLength);
                    //sb.AppendFormat("File Name: {0}<br/>", FileUpload1.FileName);
                }
                catch (Exception ex)
                {
                    sb.Append("<br/> Error: Unable to save file.<br/>");
                    sb.AppendFormat("Error Message: {0}", ex.Message);
                }
            }
            else
            {
                sb.Append("No file selected for upload.");
            }
 


        lblmessage.Text = sb.ToString();
            lblmessage.Visible = true;
        }
        protected void ddlOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected value from DropDownList
            string selectedValue = ddlOptions.SelectedItem.Text;

            // Display the selected value in Label
            lblSelectedValue.Text = "Selected Value: " + selectedValue;
        }
    }
}
