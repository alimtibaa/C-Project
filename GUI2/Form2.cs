using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace GUI2
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			

		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			SqlDataReader rdr = null;
			SqlConnection connexion = null;

			string connectionString = null;

			try
			{
				// connexion 
				connectionString =
						ConfigurationManager.ConnectionStrings["dbSqlServer"].ConnectionString;

				connexion = new SqlConnection(connectionString);
				connexion.Open();

				if (comboBox1.SelectedIndex == 0)
				{
					string stm = "SELECT * FROM Automobile WHERE AutoMoto = 0 ";
					SqlCommand cmd2 = new SqlCommand(stm, connexion);
					rdr = cmd2.ExecuteReader();
					while (rdr.Read())
					{
						Object a = rdr.GetString(2) + " " + rdr.GetString(3) + " " + rdr.GetString(4);
						listBox1.Items.Add(a);
					}
				}

				if (comboBox1.SelectedIndex == 1)
				{
					string stm = "SELECT * FROM Automobile WHERE AutoMoto = 1 ";
					SqlCommand cmd2 = new SqlCommand(stm, connexion);
					rdr = cmd2.ExecuteReader();
					while (rdr.Read())
					{
						Object a = rdr.GetString(2) + " " + rdr.GetString(3) + " " + rdr.GetString(4);
						listBox1.Items.Add(a);
					}
				}
			}
			catch (Exception exp)
			{
				Console.WriteLine("Erreur de configuration : {0}", exp.Message);

			}
			finally
			{
				if (rdr != null)
				{
					rdr.Close();
				}
				if (connexion != null)
				{
					connexion.Close();
				}
			}
		}
	}
}
