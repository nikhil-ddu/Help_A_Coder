using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelpACoder
{
    class Contest
    {
        public string name { get; set; }
       public  string contestUrl { get; set; }
        public string platform { get; set; }
        public string startDate { get; set; }
        public string imageUrl { get; set; }
    }
    public partial class Contests : System.Web.UI.Page
    {
        static HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetContestsDetails();
        }
        private async void GetContestsDetails()
        {
            try
            {
                var response = await client.GetAsync("http://webservices-dhavalmehta.rhcloud.com/webapi/contests");
                if (response.IsSuccessStatusCode)
                {
                    string responsestr = await response.Content.ReadAsStringAsync();
                    var arr = JsonConvert.DeserializeObject<Contest[]>(responsestr).ToList();

                    foreach (var i in arr)
                    {
                        //DateTime dt = new DateTime();
                        //dt.AddMilliseconds(Double.Parse(i.startDate));

                        DateTime startTime = new DateTime(1970, 1, 1);

                        TimeSpan time = TimeSpan.FromMilliseconds(Double.Parse(i.startDate) + 19800000);
                        i.startDate = startTime.Add(time).ToString();
                        if (i.platform == "Codeforces")
                        {
                            i.imageUrl = "~/images/codeforces_logo.png";
                        }
                        else if (i.platform == "CodeChef")
                        {
                            i.imageUrl = "~/images/codechef_logo.png";
                        }
                        else if (i.platform == "Spoj")
                        {
                            i.imageUrl = "~/images/spoj_logo.png";
                        }
                        else if (i.platform == "Topcoder")
                        {
                            i.imageUrl = "~/images/topcoder_logo.png";
                        }
                        else if (i.platform == "HackerEarth")
                        {
                            i.imageUrl = "~/images/hackerearth_logo.png";
                        }
                        else if (i.platform == "HackerRank")
                        {
                            i.imageUrl = "~/images/hackerrank_logo.png";
                        }

                    }
                    GridView1.DataSource = arr;
                    GridView1.DataBind();
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Something Went Wrong!try agian');", true);
                }
            }
            catch (Exception e)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Something Went Wrong!Try again');", true);
            }
        } 

    }
}