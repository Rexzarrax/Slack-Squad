using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Slack_Squad
{
    class sql_access
    {

		MySqlConnection SQLConn;

		public readonly List<slack_status> slack_status_list;

		public sql_access(string cs)
		{
			slack_status_list = new List<slack_status>();

			SQLConn = new MySqlConnection(cs);
			try
			{
				SQLConn.Open();
				Console.WriteLine(SQLConn.ServerVersion.ToString());
			}
			catch
			{
				throw new Exception("Database Connection Error");
			}

		}
		public void ReopenConnections()
		{
			try
			{
				SQLConn.Close();
				SQLConn.Open();
			}
			catch
			{
				throw new Exception("Database Connection Error");
			}
		}
		//update the status of the user on the database.
		public void GetStatusAll()
		{
			string sqlstatement = "SELECT status_name, status_emoji, status_text FROM status ORDER BY status_name ASC;";
			ReopenConnections();
			MySqlCommand cmd = new MySqlCommand(sqlstatement, SQLConn);
			MySqlDataReader rdr = cmd.ExecuteReader();

			while (rdr.Read())
			{
				slack_status_list.Add(new slack_status(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2)));
			}

			// Call Close when done reading.
			rdr.Close();
		}
	}
	struct slack_status
	{
		public string status_text;
		public string status_emoji;
		public string status_title;
		
		public slack_status (string title, string emoji, string text)
        {
			status_text = text;
			status_emoji = emoji;
			status_title = title;
        }

	}
}
