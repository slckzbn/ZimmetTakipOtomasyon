﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace AkbasHoldingVol2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        
        SqlBaglanti baglan = new SqlBaglanti();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                string yetki;
            if (txtKullaniciAdi.Text!="" && txtSifre.Text!="")
            {
                SqlCommand komut = new SqlCommand("Select * from tblKullanici where KullaniciAdi=@p1 and Sifre=@p2 ", baglan.Baglanti());
                komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    Login.yetki = Convert.ToInt32(dr[2]);
                    Login.depID = Convert.ToInt32(dr[3]);
                }

                if (Login.yetki == 0)
                    yetki = "Admin";
                else if (Login.yetki == 1)
                    yetki = "Satın Alma";
                else if (Login.yetki == 2)
                    yetki = "Bölüm Başkanı";
                else
                    yetki = "";
                if (yetki != "")
                {
                    XtraMessageBox.Show("" + yetki + " yetkisi ile giriş yapıldı", "Giriş Başarılı", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Hatalı Kullanıcı Adı yada Şifre", "Giriş Başarısız", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                baglan.Baglanti().Close();
            }
            else
                XtraMessageBox.Show("Boş Alan Bırakılamaz !", "Giriş Başarısız", MessageBoxButtons.OK,MessageBoxIcon.Warning);
           

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Bağlantı Hatası", ex.ToString(), MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
        }

        private void txtKullaniciAdi_KeyPress(object sender, KeyPressEventArgs e) //KULLANICI ADINA SADECE KARAKTER GİRİLEBİLİR
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e) //ŞİFRE KISMINA SADECE SAYI GİRİLEBİLİR
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
