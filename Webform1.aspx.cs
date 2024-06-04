using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tesseract;
namespace SearchTextIntoImage
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            


        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            GridView2.DataBind();

        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                String filePath1 = Path.Combine(Server.MapPath("~/UploadImage"), FileUpload1.FileName);

                string filepath = Convert.ToString(System.IO.Directory.GetParent(FileUpload1.PostedFile.FileName));
                FileUpload1.SaveAs(Server.MapPath("~/UploadImage/") + Path.GetFileName(FileUpload1.FileName));
              
                string link = "UploadImage/" + Path.GetFileName(FileUpload1.FileName);
                using (Stream fs = postedFile.InputStream)
                {
                    string query = "insert into FileInfo5(Name1,fpath1,UploadImage5) values (@FileName, @FileParh,@uploadim )";
                    SqlCommand cmd = new SqlCommand(query);
                    cmd.Parameters.AddWithValue("@FileName", filename);
                    cmd.Parameters.AddWithValue("@FileParh", filePath1);
                    cmd.Parameters.AddWithValue("@uploadim", link);
                    string mycon = "your program sql connection enter here"";Integrated Security=True";
                    SqlConnection con = new SqlConnection(mycon);
                    con.Open();
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                   
                    string result = PerformOCR(filePath1);
                  
                    con.Close();






                }

            }
        }
        private string PerformOCR(string imagePath)
        {

            using (var engine = new TesseractEngine(Server.MapPath(@"~/tessdata"), "eng", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    using (var page = engine.Process(img))
                    {
                        return page.GetText();
                    }
                }
            }
        }





       
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try {
                if (e.CommandName == "FetchText1")
                {
                    
                    int rowIndex2 = Convert.ToInt32(e.CommandArgument);
                    Label lblFetchedText1 = (Label)GridView2.Rows[rowIndex2].FindControl("lblFetchedText1");
                  
                    string imagePath2 = GridView2.DataKeys[rowIndex2]["fpath1"].ToString();
                   string imageText1 = FetchTextFromImage2(imagePath2);
                   
                    lblFetchedText1.Text = imageText1;
                    UpdateDatabase1(rowIndex2,imageText1);
                   
                }

            }
            catch(Exception ex)
            {
                
            }

        }
        private string FetchTextFromImage2(string imagePath2)
        {
            try
            {
                string tessdataPath1 = Server.MapPath("~/tessdata");
                using (var engine = new TesseractEngine(tessdataPath1, "eng", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(imagePath2))
                    {
                        using (var page = engine.Process(img))
                        {
                            return page.GetText();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

       
        private void UpdateDatabase1(int index, string imageText1)
        {
            
            string connectionString = "Your project connection Enter Here";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query1 = "UPDATE FileInfo5 SET Showtext2 = @ImageText1 WHERE imgId = @ImageID1";
                using (SqlCommand command = new SqlCommand(query1, connection))
                {

                    command.Parameters.AddWithValue("@ImageText1", imageText1);
                    command.Parameters.AddWithValue("@ImageID1", index + 1); // Assuming ImageID is 1-based

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Assuming the image column is the second column (index 1)
                ImageField imageField = (ImageField)GridView2.Columns[3];

                // Set the desired width and height
                imageField.ControlStyle.Width = Unit.Pixel(100); // replace 100 with your desired width
                imageField.ControlStyle.Height = Unit.Pixel(100); // replace 100 with your desired height
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Assuming the label is in the second column (index 1)
                Label label1 = (Label)e.Row.Cells[1].FindControl("lblFetchedText1");

                // Set the desired width and height
                label1.Style["width"] = "400px"; // replace 100 with your desired width
                label1.Style["height"] = "50px"; // replace 50 with your desired height
            }
        }
    }
}
