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
          //  try
           // {
                var response = await client.GetAsync("https://web-crawler-java.herokuapp.com/webapi/contests");
                if (response.IsSuccessStatusCode)
                {
                    string responsestr = await response.Content.ReadAsStringAsync();
                    var arr = JsonConvert.DeserializeObject<Contest[]>(responsestr).ToList();

                    foreach (var i in arr)
                    {
                    if(i.startDate != null)
                    {
                        DateTime d2 = DateTime.Parse(i.startDate, null, System.Globalization.DateTimeStyles.RoundtripKind);
                        i.startDate = d2.ToString();

                    }

                    if (i.platform == "Codeforces")
                        {
                            i.imageUrl = "~/Content/images/codeforces_logo.png";
                        }
                        else if (i.platform == "CodeChef")
                        {
                            i.imageUrl = "~/Content/images/codechef_logo.png";
                        }
                        else if (i.platform == "Spoj")
                        {
                            i.imageUrl = "~/Content/images/spoj_logo.png";
                        }
                        else if (i.platform == "Topcoder")
                        {
                            i.imageUrl = "~/Content/images/topcoder_logo.png";
                        }
                        else if (i.platform == "HackerEarth")
                        {
                            i.imageUrl = "~/Content/images/hackerearth_logo.png";
                        }
                        else if (i.platform == "HackerRank")
                        {
                            i.imageUrl = "~/Content/images/hackerrank_logo.jpg";
                        }

                    }
                    GridView1.DataSource = arr;
                    GridView1.DataBind();
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Something Went Wrong');", true);
                }
          //  }
            /*
#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Something Went Wrong!Try again');", true);
            }*/
        } 

    }
}