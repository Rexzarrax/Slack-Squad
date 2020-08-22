using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace Slack_Squad
{
    class httprequest
    {
        //UAK4YQ1TP
        public httprequest()
        {

        }

        public async System.Threading.Tasks.Task sendAsync(string json, string token)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://slack.com/api/users.profile.set"))
                    {
                        string value = "Bearer " + token;
                        
                        request.Headers.TryAddWithoutValidation("Authorization", value);
                        request.Content = new StringContent(json);
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }

        }
    }
}