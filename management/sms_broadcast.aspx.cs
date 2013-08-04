using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class management_sms_broadcast : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            lblEncoder.Text = Session["user"].ToString();
            page_request(Request.QueryString["procced"]);

            if (Session["fileupload"] != null)
            {
                lblError.Text = Session["fileupload"].ToString();
                Session["fileupload"] = null; 
                clear_all();
            }
        }
    }

    public void page_request(string input)
    {
        if (input != null)
        {
            switch (input)
            {
                case "true":
                    go(Session["text-file"].ToString());
                    break;
                case "false":
                    clear_all();
                    break;
            }
        }
    }

    private void clear_all()
    {
        Session["text-path"] = null;
        Session["text-file"] = null;
        config.Body_Message1 = string.Empty;
        config.Body_Message2 = string.Empty;
        config.Encoder = string.Empty;
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (this.fuUpload.PostedFile != null)
        {
            try
            {
                string filePath = @"import\excel\";
                string newFile = string.Empty;
                string fileName = fuUpload.PostedFile.FileName;
                string fileExtension = System.IO.Path.GetExtension(fileName).Replace(".", string.Empty).ToLower();
                string[] validFileExtensions = new string[] { "txt", "kpa", "xlsx" };

                foreach (string extension in validFileExtensions)
                {
                    switch (fileExtension)
                    {
                        case "txt":
                        case "kpa":
                            config.Flag = true;
                            break;
                        case "xlsx":
                            config.IsExcel = true;
                            break;
                    }
                }

                if (config.Flag)
                {
                    filePath = @"import\text\";
                }
                string new_file = Guid.NewGuid().ToString() + Path.GetExtension(fuUpload.FileName);
                config.Body_Message1 = txtMsg1.Text;
                config.Body_Message2 = txtMsg2.Text;
                config.Encoder = lblEncoder.Text;
                Session["text-path"] = filePath;
                Session["text-file"] = new_file;
                fuUpload.SaveAs(Server.MapPath(filePath) + new_file);

                if (config.Body_Message1 != string.Empty)
                {
                    linkProceed.Visible = true;
                }
                else
                {
                    lblError.Text = "Oops, no given value in body of message 1";
                }

            }
            catch (Exception ex)
            {
                lblError.Text = "File wasn't uploaded successfully";
            }
        }
    }

    public void go(string fileUploaded)
    {
        if (smsBroadcastController.process(Server.MapPath(Session["text-path"].ToString()) + fileUploaded,
            config.Body_Message1, config.Body_Message2, config.Encoder, config.Flag, config.IsExcel))
        {
            Session["fileupload"] = "SMS Broadcast it's being processed...";
        }
        else
        {
            Session["fileupload"] = "Oops, System has encountered an error!";
        }
        Response.Redirect("sms_broadcast.aspx");
    }
}