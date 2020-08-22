using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;

namespace Slack_Squad
{
    public partial class ui : Form
    {
        public string Host;
        public ui()
        {
            InitializeComponent();
            ReadHost RH = new ReadHost();
            Host = RH.Get();
            string cs = @"server=" + Host + ";userid=NS_USER;password=;database=notification_squad";
            sql_access sql = new sql_access(cs);


            json json = new json();

            List<Button> buttons = new List<Button>();

            sql.GetStatusAll();

            if (sql.slack_status_list.Count == 0)
            {
                MessageBox.Show("No Status Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Size = new Size(175, LoadButtons() + 40);

            async void newButton_Click(object sender, EventArgs e)
            {
                string jsonstring;
                Button btnSender = (Button)sender;
                string status_text = btnSender.Text;
                jsonstring = json.builder(sql.slack_status_list, ref status_text);

                httprequest request = new httprequest();
                await request.sendAsync(jsonstring);

            }

            int LoadButtons()
            {
                int buttonjump = 10;

                foreach (slack_status status in sql.slack_status_list)
                {
                    Button newButton = new Button();
                    newButton.Name = status.status_title;
                    newButton.Location = new Point(5, buttonjump);
                    newButton.Text = status.status_title;

                    newButton.BackColor = Color.DarkGray;
                    newButton.Click += newButton_Click;

                    buttons.Add(newButton);
                    this.Controls.Add(newButton);
                    buttonjump = buttonjump + 30;
                }
                return buttonjump;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Host, "INFO");
        }
    }
}
