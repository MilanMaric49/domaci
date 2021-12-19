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

namespace Domaci
{
    public partial class Form1 : Form
    {
        string cs = "Data source=DESKTOP-7NG08EG\\MARIC; Initial catalog=domaci; Integrated security=true";
        int red = 0;
        DataTable drzava = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            red = 0;
            promeni(red);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter("select * from drzava" , veza);
            adapter.Fill(drzava);
            promeni(red);
            txt_id.Enabled = false;
        }
        public void promeni(int x) 
        {
            txt_id.Text= drzava.Rows[x]["id"].ToString();
            txt_naziv.Text = drzava.Rows[x]["Naziv"].ToString();
            txt_kontinent.Text = drzava.Rows[x]["Kontinent"].ToString();
            txt_glavni_grad.Text = drzava.Rows[x]["Glavni_grad"].ToString();
            txt_povrsina.Text = drzava.Rows[x]["Povrsina"].ToString();
            txt_broj_stanovnika.Text = drzava.Rows[x]["Broj_stanovnika"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (red<drzava.Rows.Count-1)
            {
                red = red + 1;
                promeni(red);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (red >0)
            {
                red = red - 1;
                promeni(red);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            red = drzava.Rows.Count-1;
            promeni(red);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("insert into drzava(naziv, kontinent, glavni_grad, povrsina, broj_stanovnika ) values ('" + txt_naziv.Text + "' ,'" + txt_kontinent.Text + "', '" + txt_glavni_grad.Text + "' , '" + txt_povrsina.Text + "' ,'" + txt_broj_stanovnika.Text + "' ) ", veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from drzava", veza);
            drzava.Clear();
            adapter.Fill(drzava);
            promeni(red);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("delete from drzava where id= "+ txt_id.Text, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from drzava", veza);
            drzava.Clear();
            adapter.Fill(drzava);
            if (red == drzava.Rows.Count) { red = red - 1; }
            promeni(red);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("update drzava set Naziv='"+txt_naziv.Text+"' ,kontinent='"+txt_kontinent.Text+"',glavni_grad='"+txt_glavni_grad.Text+"', povrsina="+txt_povrsina.Text+", broj_stanovnika="+txt_broj_stanovnika.Text+ " where id="+txt_id.Text,  veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from drzava", veza);
            drzava.Clear();
            adapter.Fill(drzava);
            
            promeni(red);
        }
    }
}
