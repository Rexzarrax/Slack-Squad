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

        public async System.Threading.Tasks.Task sendAsync(string json)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://slack.com/api/users.profile.set"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer xoxp-137162627015-359168817941-1308259865542-20c35a7a191f44cbdde7428265bc6b5d");

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