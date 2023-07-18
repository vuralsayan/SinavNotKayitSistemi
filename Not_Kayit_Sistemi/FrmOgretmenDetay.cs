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

namespace Not_Kayit_Sistemi
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=Vural\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True");

        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayitDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLDERS (OGRNUMARA, OGRAD, OGRSOYAD) VALUES(@P1,@P2,@P3)",baglanti);
            komut.Parameters.AddWithValue("@P1", MskNumara.Text);    
            komut.Parameters.AddWithValue("@P2", TxtAd.Text);
            komut.Parameters.AddWithValue("@P3", TxtSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MskNumara.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            double ortalama, sinav1, sinav2, sinav3;
            string durum;
            sinav1 = Convert.ToDouble(TxtSinav1.Text);
            sinav2 = Convert.ToDouble(TxtSinav2.Text);
            sinav3 = Convert.ToDouble(TxtSinav3.Text);

            ortalama = (sinav1 + sinav2 + sinav3) / 3;
            LblOrtalama.Text = ortalama.ToString("0.00");

            if (ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE TBLDERS SET OGRS1=@P1, OGRS2=@P2, OGRS3=@P3, ORTALAMA=@P4, DURUM=@P5 WHERE OGRNUMARA=@P6",baglanti);
            komut.Parameters.AddWithValue("@P1", TxtSinav1.Text);
            komut.Parameters.AddWithValue("@P2", TxtSinav2.Text);
            komut.Parameters.AddWithValue("@P3", TxtSinav3.Text);
            komut.Parameters.AddWithValue("@P4", decimal.Parse(LblOrtalama.Text));
            komut.Parameters.AddWithValue("@P5", durum);
            komut.Parameters.AddWithValue("@P6", MskNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Notları Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);
            
        }
    }
}
