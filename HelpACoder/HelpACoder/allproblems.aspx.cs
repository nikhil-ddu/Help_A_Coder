using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelpACoder
{
    class Problem
    {
        public int id { get; set; }
        public string title { get; set; }
        public string platform { get; set; }
        public string problemUrl { get; set; }
        public string imageUrl { get; set; }
    }
    public partial class allproblems : System.Web.UI.Page
    {
        static HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetProblemsDetails();
            }
            
        }
        private async void GetProblemsDetails()
        {
            try
            {


                var response = await client.GetAsync("http://webservices-dhavalmehta.rhcloud.com/webapi/problems");
                if (response.IsSuccessStatusCode)
                {
                    string responsestr = await response.Content.ReadAsStringAsync();
                    var arr = JsonConvert.DeserializeObject<Problem[]>(responsestr).ToList();

                    foreach (var i in arr)
                    {
                        if (i.platform == "Codeforces")
                        {
                            i.imageUrl = "~/images/codeforces_logo.png";
                        }
                        else if (i.platform == "HackerEarth")
                        {
                            i.imageUrl = "~/images/hackerearth_logo.png";
                        }
                        else if (i.platform == "Spoj")
                        {
                            i.imageUrl = "~/images/spoj_logo.png";
                        }
                    }
                    GridView1.DataSource = arr;
                    GridView1.DataBind();
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Something Went Wrong!Try again');", true);
                }
            }
            catch(Exception e)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Something Went Wrong!Try again');", true);
            }
        }
        protected void gridMembersList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "More")
            {
                
                int id =int.Parse( e.CommandArgument.ToString());
                Response.Redirect("displayprobleminfo.aspx?id="+id);
            }
        }

    }
}