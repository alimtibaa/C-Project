using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace GUI2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void submit_Click(object sender, EventArgs e)
		{
			// Insertion dans la table Etudiants

			SqlDataReader rdr = null;
			SqlConnection connexion = null;

			string connectionString = null;

			try
			{
				int a;
				// connexion 
				connectionString =
						ConfigurationManager.ConnectionStrings["dbSqlServer"].ConnectionString;

				connexion = new SqlConnection(connectionString);
				connexion.Open();
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = connexion;
				cmd.CommandText = "INSERT INTO Automobile(Annee,Immatriculation,Couleur,Marque,TypeV,Cylindre,VitesseMax,AutoMoto) VALUES(@Annee,@Immatriculation,@Couleur,@Marque,@TypeV,@Cylindre,@VitesseMax,@AutoMoto)";
				cmd.Prepare();

				cmd.Parameters.AddWithValue("@Annee", Int32.Parse(e1.Text));
				cmd.Parameters.AddWithValue("@Immatriculation", e2.Text);
				cmd.Parameters.AddWithValue("@Couleur", e6.Text);
				cmd.Parameters.AddWithValue("@Marque", e7.Text);
				cmd.Parameters.AddWithValue("@TypeV", e8.Text);
				cmd.Parameters.AddWithValue("@Cylindre", Int32.Parse(e4.Text));
				cmd.Parameters.AddWithValue("@VitesseMax", Int32.Parse(e5.Text));
				if (e3.Text == "Auto")
				{ a = 1; }
				else { a = 0; }
				cmd.Parameters.AddWithValue("@AutoMoto", a);
				cmd.ExecuteNonQuery();
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

		private void e3_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (e3.SelectedIndex == 0)
			{
				e6.Enabled = false;
				e7.Enabled = false;
				e8.Enabled = false;
			}
			if (e3.SelectedIndex == 1)
			{
				e6.Enabled = true;
				e7.Enabled = true;
				e8.Enabled = true;
			}
		}

		private void exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form2 f = new Form2();
			f.Show();
		}
	}
}
