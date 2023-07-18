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

        private void Bilgiler()
        {
            LblGecenSayisi.Text = dbNotKayitDataSet.TBLDERS.Count(x => x.DURUM == true).ToString();
            LblKalanSayisi.Text = dbNotKayitDataSet.TBLDERS.Count(x => x.DURUM == false).ToString();
            LblOrtalama.Text = dbNotKayitDataSet.TBLDERS.Average(x => x.ORTALAMA).ToString("0.00");
        }


        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayitDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);
            Bilgiler();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLDERS (OGRNUMARA, OGRAD, OGRSOYAD, DURUM, ORTALAMA, OGRS1, OGRS2, OGRS3) VALUES(@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)", baglanti);
            komut.Parameters.AddWithValue("@P1", MskNumara.Text);
            komut.Parameters.AddWithValue("@P2", TxtAd.Text);
            komut.Parameters.AddWithValue("@P3", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@P4", false);
            komut.Parameters.AddWithValue("@P5", ortalama.ToString());
            komut.Parameters.AddWithValue("@P6", TxtSinav1.Text);
            komut.Parameters.AddWithValue("@P7", TxtSinav2.Text);
            komut.Parameters.AddWithValue("@P8", TxtSinav3.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);
            label9.Text = "Genel Ortalama";
            Bilgiler();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MskNumara.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            LblOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

            label9.Text = "Öğrenci Ortalama";

        }
        public double ortalama = 0;
        public double sinav1, sinav2, sinav3;
        public string durum;
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
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
            SqlCommand komut = new SqlCommand("UPDATE TBLDERS SET OGRS1=@P1, OGRS2=@P2, OGRS3=@P3, ORTALAMA=@P4, DURUM=@P5 WHERE OGRNUMARA=@P6", baglanti);
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
            Bilgiler();

        }
    }
}
