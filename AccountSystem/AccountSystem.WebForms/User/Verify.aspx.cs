namespace AccountSystem.WebForms.User
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Microsoft.AspNet.Identity;

    using AccountSystem.Data;
    using AccountSystem.Models;

    public partial class Verify : System.Web.UI.Page
    {
        private IAccountSystemData appData;
        private string currentUserId;

        public Verify()
        {
            this.appData = new AccountSystemData(new AccountSystemDbContext());
            this.currentUserId = this.User.Identity.GetUserId();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            var user = this.appData.Users.All().FirstOrDefault(u => u.Id == this.currentUserId);
            if (FileUploadControl.HasFile && user.Documents.Count > 10)
            {
                ShowError("Upload status: Documents limit reached!");
            }
            else if (FileUploadControl.HasFile)
            {
                try
                {
                    if (IsDocumentTypeAllowed(FileUploadControl.PostedFile.ContentType))
                    {
                        if (FileUploadControl.PostedFile.ContentLength < 5120000)
                        {
                            string filename = Path.GetFileName(FileUploadControl.FileName);
                            var fileExt = Path.GetExtension(FileUploadControl.FileName);
                            CreateDirIfNotExists("/Uploaded_Documents/" + user.UserName);
                            var uploadPath = Server.MapPath("~/Uploaded_Documents/") + user.UserName + "/";
                            var newFileName = Path.GetRandomFileName() + fileExt;
                            FileUploadControl.SaveAs(uploadPath + newFileName);
                            user.Documents.Add(new FileUploadData()
                            {
                                FileName = newFileName,
                                FileType = FileUploadControl.PostedFile.ContentType,
                                UploadDate = DateTime.Now,
                                User = user
                            });
                            this.appData.SaveChanges();
                            this.ShowSuccess("Upload status: File uploaded!");
                        }
                        else
                            ShowError("Upload status: The file has to be less than 5 mb!");
                    }
                    else
                        ShowError("Upload status: Only JPEG files are accepted!");
                }
                catch (Exception ex)
                {
                    ShowError("Upload status: The file could not be uploaded. The following error occured: " + ex.Message);
                }
            }
            else
            {
                ShowError("No file selected!");
            }
        }

        private bool IsDocumentTypeAllowed(string miteType)
        {
            switch (miteType)
            {
                case "image/jpeg":
                case "image/jpg":
                case "image/gif":
                case "image/bmp":
                case "image/png":
                case "image/pdf":
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
        }

        private void CreateDirIfNotExists(string subPath)
        {
            bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
        }

        private void ShowError(string message)
        {
            this.FormError.Visible = true;
            this.StatusLabel.Text = message;
        }

        private void ShowSuccess(string message)
        {
            this.FormSuccess.Visible = true;
            this.SuccessLabel.Text = message;
        }

        protected void DocumentDownload_Command(object sender, CommandEventArgs e)
        {
            var fileParam = e.CommandArgument as string;
            if (string.IsNullOrEmpty(fileParam))
            {
                return;
            }

            int fileId;
            if (!int.TryParse(fileParam, out fileId))
            {
                return;
            }

            var currentUser = this.appData.Users.All().FirstOrDefault(u => u.UserName == this.User.Identity.Name);
            var requestedFile = currentUser.Documents.FirstOrDefault(d => d.Id == fileId);
            if (requestedFile == null)
            {
                return;
            }

            Response.AddHeader("Content-Type", "application/octet-stream");
            Response.AddHeader("Content-Transfer-Encoding", "Binary");
            Response.AddHeader("Content-disposition", "attachment; filename=\"" + requestedFile.FileName + "\"");
            Response.WriteFile(HttpRuntime.AppDomainAppPath + @"Uploaded_Documents\\" + currentUser.UserName + "\\" + requestedFile.FileName);
            Response.End();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<AccountSystem.Models.FileUploadData> GridViewCards_GetData()
        {
            var currentUser = this.appData.Users.All().FirstOrDefault(u => u.UserName == this.User.Identity.Name);
            return currentUser.Documents.AsQueryable();
        }
    }
}