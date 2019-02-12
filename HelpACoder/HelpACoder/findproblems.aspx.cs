using Newtonsoft.Json;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
#pragma warning disable CS0105 // The using directive for 'System.Web' appeared previously in this namespace
using System.Web;
#pragma warning restore CS0105 // The using directive for 'System.Web' appeared previously in this namespace
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

                var response = await client.GetAsync(url);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + url + "');", true);
                if (response.IsSuccessStatusCode)
                {
                    GridView1.Visible = true;
                    string responsestr = await response.Content.ReadAsStringAsync();
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + responsestr + "');", true);
                    var arr = JsonConvert.DeserializeObject<Problem[]>(responsestr).ToList();
                    foreach (var i in arr)
                    {
                        string platform = "";
                        if (i.platform != null)
                        {
                            platform = i.platform.ToLower();
                        }
                        i.imageUrl = "~/Content/images/" + platform + "_logo.png";
                    }
                    GridView1.DataSource = arr;
                    GridView1.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Enter Valid Information');", true);
                }
            }
            catch (Exception e)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + e.Message + "');", true);
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
            String url = "https://web-crawler-java.herokuapp.com/webapi/problems?";
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
            if (url.Equals("https://web-crawler-java.herokuapp.com/webapi/problems?"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Enter Some Information');", true);
            }
            else
            {
                GetProblemsDetails(url);
            }
        }
    }

}