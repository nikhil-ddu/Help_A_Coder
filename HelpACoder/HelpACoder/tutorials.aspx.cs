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
    public partial class tutorials : System.Web.UI.Page
    {
        List<String> tutoriallist;
        static HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTutorialList();
            }
        }
        class Tutorial
        {
            public string name { get; set; }
            public string content { get; set; }
        }
        private async void GetTutorial()
        {
            try
            {
                var response = await client.GetAsync("https://web-crawler-java.herokuapp.com/webapi/tutorials/" + DropDownList1.SelectedItem.Text);
                if (response.IsSuccessStatusCode)
                {
                    string responsestr = await response.Content.ReadAsStringAsync();
                    Tutorial tr = JsonConvert.DeserializeObject<Tutorial>(responsestr);
                    Label1.Text = tr.content;

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Something Went Wrong!Try again');", true);
                }
            }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Something Went Wrong!Try again');", true);
            }
        }
        private async void GetTutorialList()
        {
            try
            {
                var response = await client.GetAsync("https://web-crawler-java.herokuapp.com/webapi/tutorials");
                if (response.IsSuccessStatusCode)
                {
                    string responsestr = await response.Content.ReadAsStringAsync();
                    tutoriallist= JsonConvert.DeserializeObject<List<String>>(responsestr).ToList();
                    DropDownList1.DataSource = tutoriallist;
                    DropDownList1.DataBind();
                    
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Enter Valid Information');", true);
                }
            }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Something Went Wrong!Try again');", true);
            }
       }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTutorial();
            
        }
    }
}