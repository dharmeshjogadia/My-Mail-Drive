using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
public partial class DriveHome : System.Web.UI.Page
{
    string path;
    bool flag1 = false;
    bool flag2 = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["username"] == null)
                Response.Redirect("Default.aspx");
            //WalkDirectoryTree(Server.MapPath("Drive") + "Dharmesh");
            if (!IsPostBack)
            {

                CreateTree();
            }
        }
        catch (Exception)
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";
        }

    }
    void CreateTree()
    {
        ltlTree.Text = "";
        string userName = Session["username"].ToString();
        string path = Server.MapPath("Drive")  +"\\"+ userName.Substring(0, userName.LastIndexOf("@"));
        DirectoryInfo d = new DirectoryInfo(path);

        WalkDirectoryTree(d);
    }
    void WalkDirectoryTree(System.IO.DirectoryInfo root)
    {
        path += "\\" + root.Name;
        ltlTree.Text += "<ul>";
        ltlTree.Text += "<li class=\"parent_li\">";
        ltlTree.Text += "<span><i class=\"glyphicon glyphicon-minus-sign\"></i> " + root.Name + "</span>";

        //ltlTree.Text += "<lable xc>" + root.LastAccessTime;
        //ltlTree.Text += "</label>";
        ltlTree.Text += "<div class=\"pull-right\"><label dir=\"" + path + "\" class=\"AddFolder1 right sideBtn\" title=\"Add New Folder\"";
        ltlTree.Text += "data-toggle=\"modal\" data-target=\".bs-example-modal-sm\">";
        ltlTree.Text += "&nbsp; <i class=\"glyphicon glyphicon-plus xs_text\"></i><i class=\"glyphicon glyphicon-folder-open\">";
        ltlTree.Text += "</i>";
        ltlTree.Text += "</label>";

        ltlTree.Text += "&nbsp;<label dir=\"" + path + "\" class=\"AddFile1  right sideBtn\" title=\"Add New File\" ";
        ltlTree.Text += "data-toggle=\"modal\" data-target=\".bs-example-modal-sm\"/>";
        ltlTree.Text += "&nbsp; <i class=\"glyphicon glyphicon-plus xs_text\"></i><i class=\"glyphicon glyphicon-file\">";
        ltlTree.Text += "</i>";
        ltlTree.Text += "</label>";

        ltlTree.Text += "&nbsp;<label dir=\"" + path + "\" class=\"DeleteFile right sideBtn\" title=\"Delete Folder\" id=\"Label1\" ";
        ltlTree.Text += "data-toggle=\"modal\" data-target=\".bs-example-modal-sm\"/>";
        ltlTree.Text += "<i class=\"glyphicon glyphicon-trash\"></i>";
        ltlTree.Text += "</label> </div>";


        //Console.WriteLine(root.Name);

        System.IO.FileInfo[] files = null;
        System.IO.DirectoryInfo[] subDirs = null;

        try
        {
            files = root.GetFiles("*.*");
        }


        catch (System.IO.DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        if (files.Length > 0)
        {

            ltlTree.Text += "<ul>";

            //--<span></span> --%>
            // <i class="glyphicon glyphicon-file"></i> Grand Child<a href="">Goes somewhere</a>

            //  </ul>
            foreach (System.IO.FileInfo fi in files)
            {
                ltlTree.Text += "<li>";
                //Console.WriteLine(fi.Name);
                ltlTree.Text += "<a href=\"./Drive" + path.Replace("\\", "/") + "/" + fi.Name + "\" >";
                ltlTree.Text += "<i class=\"glyphicon glyphicon-file\"></i>" + fi.Name + "</a>";
                ltlTree.Text += "</li>";
            }
            ltlTree.Text += "</ul>";

            
        }
        else
            ltlTree.Text += "<li><lable class=\"text-danger\">No files in this folder</lable></li>";
        subDirs = root.GetDirectories();
        if(subDirs.Length>0)
        foreach (System.IO.DirectoryInfo dirInfo in subDirs)
        {


            WalkDirectoryTree(dirInfo);
            path = path.Substring(0, path.LastIndexOf("\\"));
        }

            
        ltlTree.Text += "</li>";
        ltlTree.Text += "</ul>";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void btnAddFolder_Click(object sender, EventArgs e)
    {
        // Button1.Text = hdPath.Value;

        try
        {
            string path = Server.MapPath("Drive") + hdPath.Value + "\\" + txtFolderName.Text;
            DirectoryInfo ObjSearchDir = new DirectoryInfo(path);
            if (!ObjSearchDir.Exists)
            {
                ObjSearchDir.Create();

                CreateTree();
            }
        }
        catch (Exception)
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";

        }

    }
    protected void btnAddFile_Click(object sender, EventArgs e)
    {
        try
        {

            if ((flpuFile.PostedFile != null) && (flpuFile.PostedFile.ContentLength > 0))
            {
                string fileName = System.IO.Path.GetFileName(flpuFile.PostedFile.FileName);
                string FileLoc = Server.MapPath("Drive") + hdPath.Value + "\\" + fileName;
                try
                {
                    flpuFile.PostedFile.SaveAs(FileLoc);
                    CreateTree();
                }
                catch (Exception ex)
                {

                }
            }
        }
        catch (Exception)
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        try
        {
            string path = Server.MapPath("Drive") + hdPath.Value;
            DirectoryInfo ObjSearchDir = new DirectoryInfo(path);
            if (ObjSearchDir.Exists)
            {
                ObjSearchDir.Delete();

                CreateTree();
            }

        }
        catch (Exception)
        {
            Label lblMsg = (Label)Master.FindControl("Msg");
            lblMsg.Text = utility.ErrorMsg("Error In User Save");
            lblMsg.CssClass += " msg show";
        }
    }

}