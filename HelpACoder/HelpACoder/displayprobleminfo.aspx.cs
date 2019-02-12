using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using System.Web.UI;

namespace HelpACoder
{
    public class SampleInputOutput
    {
        public string input { get; set; }
        public string output { get; set; }
    }

    public class RootObject
    {
        public int id { get; set; }
        public string problemUrl { get; set; }
        public string title { get; set; }
        public string platform { get; set; }
        public string problemStatement { get; set; }
        public string inputFormat { get; set; }
        public string outputFormat { get; set; }
        public string constraints { get; set; }
        public double timeLimit { get; set; }
        public List<SampleInputOutput> sampleInputOutputs { get; set; }
        public List<string> tags { get; set; }
        public string explanation { get; set; }

    }
    public partial class displayprobleminfo : System.Web.UI.Page
    {
        static HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string v = Request.QueryString["id"];
                if (v != null)
                {
                    GetProblemInfo(int.Parse(v));
                }
            }
        }
        private async void GetProblemInfo(int id)
        {
            try
            {
                var response = await client.GetAsync("https://web-crawler-java.herokuapp.com/webapi/problems/" + id);
                if (response.IsSuccessStatusCode)
                {
                    Image1.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;
                    HyperLink1.Visible = true;
                    Label3.Visible = true;
                    Label4.Visible = true;
                    string responsestr = await response.Content.ReadAsStringAsync();
                    var arr = JsonConvert.DeserializeObject<RootObject>(responsestr);

                    Image1.ImageUrl = "~/Content/images/" + arr.platform.ToLower() + "_logo.png";
                    Label1.Text = "ID :" + arr.id.ToString();
                    Label2.Text = "TITLE :" + arr.title;
                    HyperLink1.NavigateUrl = arr.problemUrl;
                    Label3.Text = "PLATFORM :" + arr.platform;
                    Label4.Text = "Problem Statement :\n" + arr.problemStatement;
                    if (arr.inputFormat != null)
                    {
                        Label5.Visible = true;
                        Label5.Text = "InputFormat :" + arr.inputFormat;
                    }
                    if (arr.outputFormat != null)
                    {
                        Label6.Visible = true;
                        Label6.Text = "OutputFormat :" + arr.outputFormat;
                    }

                    if (arr.constraints != null)
                    {
                        Label7.Visible = true;
                        Label7.Text = "Constarints : " + arr.constraints;
                    }
                    if (arr.sampleInputOutputs != null)
                    {
                        Label8.Visible = true;
                        GridView1.Visible = true;
                        GridView1.DataSource = arr.sampleInputOutputs;
                        GridView1.DataBind();
                    }

                    Label9.Text = "TimeLimit :" + arr.timeLimit.ToString() + "(sec)";

                    if (arr.tags != null && arr.tags.Count != 0)
                    {
                        Label10.Visible = true;
                        GridView2.Visible = true;
                        GridView2.DataSource = arr.tags;
                        GridView2.DataBind();
                    }
                    if (arr.explanation != null)
                    {
                        Label11.Text = arr.explanation;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Enter Valid Id');", true);
                }

            }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Something Went Wrong please try again later!');", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            string s = TextBox1.Text;
            try
            {
                id = int.Parse(s);
            }
#pragma warning disable CS0168 // The variable 'ee' is declared but never used
            catch (Exception ee)
#pragma warning restore CS0168 // The variable 'ee' is declared but never used
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Enter Valid Id');", true);
            }



            GetProblemInfo(id);
        }
    }
}