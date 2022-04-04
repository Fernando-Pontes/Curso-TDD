using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Agenda.UIDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtContatoNovo.Text;
            string id = Guid.NewGuid().ToString();
            //txtContatoSalvo.Text = nome;

            string strCon = @"Data Source=.\sqlexpress;Initial Catalog=Agenda;Integrated Security=True;";

            SqlConnection Con = new SqlConnection(strCon);

            Con.Open();

            string sql = String.Format("insert into Contato (id, nome) values ('{0}','{1}')", id, nome);

            SqlCommand cmd = new SqlCommand(sql, Con);

            cmd.ExecuteNonQuery();

            sql = String.Format("select nome from Contato where id = '{0}'", id);

            cmd = new SqlCommand(sql, Con);

            txtContatoSalvo.Text = cmd.ExecuteScalar().ToString();

            Con.Close();
        }
    }
}
