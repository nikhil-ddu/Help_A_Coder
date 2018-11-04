using Newtonsoft.Json;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelpACoder
{
    public partial class findproblems : System.Web.UI.Page
    {
        static HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        private async void GetProblemsDetails(string url)
        {
            try
            {
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + url + "');", true);
                var response = await client.GetAsync(url);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + url + "');", true);
                if (response.IsSuccessStatusCode)
                {
                  //  ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + url + "');", true);
                    GridView1.Visible = true;
                    string responsestr = await response.Content.ReadAsStringAsync();
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + responsestr + "');", true);
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

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Enter Valid Information');", true);
                }
            }
            catch(Exception e)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" +e.Message + "');", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Something Went Wrong!Try again');", true);
            }
        }
        protected void gridMembersList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "More")
            {
               
                int id = int.Parse(e.CommandArgument.ToString());
                Response.Redirect("displayprobleminfo.aspx?id=" + id);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String url = "http://webservices-dhavalmehta.rhcloud.com/webapi/problems?";
            String tagstr = TextBox1.Text;
            
            string[] tags = tagstr.Split(',');
            foreach (string word in tags)
            {
                if (word.Length != 0)
                {
                    url += "tag=" + word + "&";
                }
            }

            String platformstr = TextBox2.Text;

            string[] platforms = platformstr.Split(',');
            foreach (string word in platforms)
            {
                if (word.Length != 0)
                {
                    url += "platform=" + word + "&";
                }
            }
            if (url.EndsWith("&"))
            {
                url = url.Substring(0, url.Length - 1);
            }
            if (url.Equals("http://webservices-dhavalmehta.rhcloud.com/webapi/problems?"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Enter Some Information');", true);
            }
            else
            {
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('"+url+"');", true);
                GetProblemsDetails(url);

            }
        }
    }
    
}