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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2RPJPRH;Initial Catalog=AkbasHoldingTest;Integrated Security=True");
        frmLogin frmLogin;
        frmSatinAlma frmSatinAlma;
        frmZimmet frmZimmet;
        frmPersonelArama frmPersonelArama;
        frmAtikKontrol frmAtikKontrol;
        frmKullaniciEkle frmKullaniciEkle;
        frmStok frmStok;

        private void btnLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormKapatma();
            Login.yetki = -1; //Her logine tıklandığında cıkış işlemi yapılacak
            Login.depID = -1;
            if (frmLogin == null)
            {
                frmLogin = new frmLogin();
                frmLogin.MdiParent = this;
                frmLogin.FormClosed += frmLoginClosed;
                frmLogin.Show();
            }
            else
                frmLogin.Show();
            
        }
        private void frmLoginClosed(object sender,FormClosedEventArgs e)
        {
            frmLogin = null;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Login.yetki = -1;
            Login.depID = -1;
            frmLogin = new frmLogin();
            frmLogin.MdiParent = this;
            frmLogin.FormClosed += frmLoginClosed;
            frmLogin.Show();
        }
        
        private void btnSatinAlma_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormKapatma();
            if (Login.yetki == 0 || Login.yetki == 1)
            {
                if (frmSatinAlma == null)
                {
                    frmSatinAlma = new frmSatinAlma();
                    frmSatinAlma.MdiParent = this;
                    frmSatinAlma.FormClosed += frmSatinAlmaClosed;
                    frmSatinAlma.Show();
                }
                else
                    frmSatinAlma.Show();
            }
            else
                XtraMessageBox.Show("Bu işlem için yetkiniz yok !", "Yetki Hatası", MessageBoxButtons.OK);
        }
        private void frmSatinAlmaClosed(object sender, FormClosedEventArgs e)
        {
            frmSatinAlma = null;
        }

        private void btnZimmet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormKapatma();
            if (Login.yetki == 0 || Login.yetki == 1)
            {
                if (frmZimmet == null)
                {
                    frmZimmet = new frmZimmet();
                    frmZimmet.MdiParent = this;
                    frmZimmet.FormClosed += frmZimmetClosed;
                    frmZimmet.Show();
                }
                else
                    frmZimmet.Show();
            }
            else
                XtraMessageBox.Show("Bu işlem için yetkiniz yok !", "Yetki Hatası", MessageBoxButtons.OK);
        }
        private void frmZimmetClosed(object sender, FormClosedEventArgs e)
        {
            frmZimmet = null;
        }

        private void btnAtikKontrol_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormKapatma();
            if (Login.yetki == 0 || Login.yetki == 1)
            {
                if (frmAtikKontrol == null)
                {
                    frmAtikKontrol = new frmAtikKontrol();
                    frmAtikKontrol.MdiParent = this;
                    frmAtikKontrol.FormClosed += frmAtikKontrolClosed;
                    frmAtikKontrol.Show();
                }
                else
                    frmAtikKontrol.Show();
            }
            else
                XtraMessageBox.Show("Bu işlem için yetkiniz yok !", "Yetki Hatası", MessageBoxButtons.OK);
        }
        private void frmAtikKontrolClosed(object sender, FormClosedEventArgs e)
        {
            frmAtikKontrol = null;
        }

        private void btnRaporİslem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormKapatma();
            if (Login.yetki ==-1)
            {
                XtraMessageBox.Show("Bu işlem için yetkiniz yok !", "Yetki Hatası", MessageBoxButtons.OK);
            }
            else
            {
                //raporislem formu acılacak
            }
        }

        private void btnStok_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormKapatma();
            if (Login.yetki == 0 || Login.yetki == 1)
            {
                if (frmStok == null)
                {
                    frmStok = new frmStok();
                    frmStok.MdiParent = this;
                    frmStok.FormClosed += frmStokClosed;
                    frmStok.Show();
                }
                else
                    frmStok.Show();
            }
            else
                XtraMessageBox.Show("Bu işlem için yetkiniz yok !", "Yetki Hatası", MessageBoxButtons.OK);
        }
        private void frmStokClosed(object sender, FormClosedEventArgs e)
        {
            frmStok = null;
        }

        private void btnKullaniciEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormKapatma();
            if (Login.yetki == 0 )
            {
                if (frmKullaniciEkle == null)
                {
                    frmKullaniciEkle = new frmKullaniciEkle();
                    frmKullaniciEkle.MdiParent = this;
                    frmKullaniciEkle.FormClosed += frmKullaniciEkleClosed;
                    frmKullaniciEkle.Show();
                }
                else
                    frmKullaniciEkle.Show();
            }
            else
                XtraMessageBox.Show("Bu işlem için yetkiniz yok !", "Yetki Hatası", MessageBoxButtons.OK); 
        } 
        private void frmKullaniciEkleClosed(object sender, FormClosedEventArgs e)
        {
            frmKullaniciEkle = null;
        }

        private void btnArama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormKapatma();
            if (Login.yetki == -1)
            {
                XtraMessageBox.Show("Öncelikle Giriş Yapmalısınız", "Yetki Hatası", MessageBoxButtons.OK);
            }
            else
            {
                if (frmPersonelArama == null)
                {
                    frmPersonelArama = new frmPersonelArama();
                    frmPersonelArama.MdiParent = this;
                    frmPersonelArama.FormClosed += frmPersonelAramaClosed;
                    frmPersonelArama.Show();
                }
                else
                    frmPersonelArama.Show();
            }

        }
        private void frmPersonelAramaClosed(object sender, FormClosedEventArgs e)
        {
            frmPersonelArama = null;
        }

        private void FormKapatma()
        {
            if(frmLogin!=null)
                frmLogin.Close();
            if(frmAtikKontrol!=null)
                frmAtikKontrol.Close();
            if (frmKullaniciEkle != null)
                frmKullaniciEkle.Close();
            if (frmPersonelArama != null)
                frmPersonelArama.Close();
            if (frmSatinAlma != null)
                frmSatinAlma.Close();
            if (frmStok != null)
                frmStok.Close();
            if (frmZimmet != null)
                frmZimmet.Close();
        }
    }
}
