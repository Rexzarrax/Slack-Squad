using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace Slack_Squad
{
    class ReadHost
    {
        private string Hostname = "";
        private string Token = "";

        public ReadHost()
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"./host.txt");

                Hostname = lines[0];
                Token = lines[1];
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Error");
                Application.Exit();
            }
        }
        public string HostnameGet()
        {
            return Hostname;
        }
        public string TokenGet()
        {
            return Token;
        }

    }
}
