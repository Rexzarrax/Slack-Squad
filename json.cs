using Newtonsoft.Json;
using System.Collections.Generic;

namespace Slack_Squad
{
    class json
    {
        public json()
        {

        }

        public string builder(List<slack_status> status_, ref string button_title)
        {
            string stringjson = "{\"profile\":";
            foreach (slack_status status in status_)
            {
                if (status.status_title == button_title)
                {

                    stringjson += JsonConvert.SerializeObject(status);

                    stringjson += "}";

                    //MessageBox.Show(stringjson);
                    break;
                }
            }
            return stringjson;
        }
    }
}
