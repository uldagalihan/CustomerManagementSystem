using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusteriKayitSistemi
{
    public partial class BireyselMusteriGuncelleme : Form
    {
        public BireyselMusteriGuncelleme()
        {
            InitializeComponent();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime bugün = DateTime.Today;
               
                    tboxTCKimlikNo.Text = "";
                    tboxAd.Text = "";
                    tboxSoyad.Text = "";
                    tboxBabaAdi.Text = "";
                    tboxAnneAdi.Text = "";
                    tboxKKTCKimlikNo.Text = "";
                    tboxOzlukMusteriNo.Text = "";
                    dtimePickerDogumTarihi.Value = bugün;
                    cboxSahisFirmaDrm.SelectedIndex = -1;

                    tboxAdresBilgisi.Text = "";
                    tboxEAdresBilgisi.Text = "";
                    tboxAlanKodu.Text = "";
                    tboxTelefonNumarası.Text = "";
                    tboxIletisimMusteriNo.Text = "";
                    cboxAdresTipi.SelectedIndex = -1;
                    cboxEAdresTipi.SelectedIndex = -1;
                    cboxTelefonTipi.SelectedIndex = -1;
                    cboxHatTipi.SelectedIndex = -1;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgiler Temizlenemedi! Hata: ", ex.Message);

            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex;
                int adresTipiIndex, eadresTipiIndex, telefonTipiIndex, hatTipiIndex;
                int sonuc;

                EntityBireyselMusteri bm = new EntityBireyselMusteri();
                bm.tcKimlikNo = tboxTCKimlikNo.Text;
                bm.musteriAd = tboxAd.Text;
                bm.musteriSoyad = tboxSoyad.Text;
                bm.dogumTarihi = dtimePickerDogumTarihi.Value;
                bm.musteriBabaAdi = tboxBabaAdi.Text;
                bm.musteriAnneAdi = tboxAnneAdi.Text;
                bm.KKTCKimlikNo = tboxKKTCKimlikNo.Text;
                bm.musteriNo = Convert.ToInt32(tboxOzlukMusteriNo.Text);

                selectedIndex = cboxSahisFirmaDrm.SelectedIndex;
                bm.sahisFirmaDrm = selectedIndex;
                EntityIrtibatMusteri im = new EntityIrtibatMusteri();

                im.adresBilgisi = tboxAdresBilgisi.Text;
                im.eadresBilgisi = tboxEAdresBilgisi.Text;
                im.alanKod = tboxAlanKodu.Text;
                im.telNo = tboxTelefonNumarası.Text;

                adresTipiIndex = cboxAdresTipi.SelectedIndex;
                eadresTipiIndex = cboxEAdresTipi.SelectedIndex;
                telefonTipiIndex = cboxTelefonTipi.SelectedIndex;
                hatTipiIndex = cboxHatTipi.SelectedIndex;

                im.adresTipKd = adresTipiIndex;
                im.eadresTipKd = eadresTipiIndex;
                im.telefonTipKd = telefonTipiIndex;
                im.hatTipiKd = hatTipiIndex;
                im.musteriNo = Convert.ToInt32(tboxIletisimMusteriNo.Text);
                im.iletisimDrm = checkBox1.Checked ? 1 : 0;
                CommonEntityTumMusteriler dto = new CommonEntityTumMusteriler();

                dto.irtibatMusteri = new List<EntityIrtibatMusteri>(1);
                List<EntityIrtibatMusteri> listIrtibat = new List<EntityIrtibatMusteri>(1);
                dto.bireyselMusteri = new List<EntityBireyselMusteri>(1);
                List<EntityBireyselMusteri> listBireysel = new List<EntityBireyselMusteri>(1);
                
                listBireysel.Add(bm);
                listIrtibat.Add(im);

                dto.irtibatMusteri = listIrtibat;
                dto.bireyselMusteri = listBireysel;

                sonuc = BLBireyselMusteri.BMusteriTumBilgileriGuncelle(dto);
                switch (sonuc)
                {
                    case 1:
                        MessageBox.Show("TC Kimlik No ya da KKTC Kimlik No Hatalı! Lütfen tekrar giriniz");
                        tboxTCKimlikNo.Text = "";
                        break;
                    case 2:
                        MessageBox.Show("Ad veya Soyad Hatalı! Lütfen tekrar giriniz");
                        tboxAd.Text = "";
                        tboxSoyad.Text = "";
                        break;
                    case 3:
                        MessageBox.Show("Doğum Tarihi Hatalı! Lütfen tekrar giriniz");
                        dtimePickerDogumTarihi.Value = DateTime.Today;
                        break;
                    case 4:
                        MessageBox.Show("Adres  Hatalı! Lütfen tekrar giriniz");
                        tboxAdresBilgisi.Text = "";
                        break;
                    case 5:
                        MessageBox.Show("Alan Kodu veya Telefon Numarası Hatalı! Lütfen tekrar giriniz");
                        tboxAlanKodu.Text = "";
                        tboxTelefonNumarası.Text = "";
                        break;
                    case 7:
                        MessageBox.Show("İletişim Bilgilerini Kontrol Ediniz!");
                        break;
                    case 8:
                        MessageBox.Show("E-Adres Hatalı! Lütfen Tekrar Giriniz");
                        tboxEAdresBilgisi.Text = "";
                        break;
                    case 9:
                        MessageBox.Show("Güncelleme Başarılı!");
                        break;
                    case 10:
                        MessageBox.Show("Şahıs Firma Durum Bilgisi Boş Bırakılamaz!");
                        break;
                    case 11:
                        MessageBox.Show("Adres E-Adres Tip Bilgileri Boş Bırakılamaz!");
                        break;
                    case 12:
                        MessageBox.Show("Telefon Hat Tipi Bilgileri Boş Bırakılamaz!");
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme İşlemi Gerçekleştirilemedi! Hata:", ex.Message);
            }
        }

        private void tboxTCKimlikNo_TextChanged(object sender, EventArgs e)
        {
            if (tboxTCKimlikNo.Text.Length == 11)
            {
                EntityBireyselMusteri bm = new EntityBireyselMusteri();
                bm.tcKimlikNo = tboxTCKimlikNo.Text;
                int sonuc = BLBireyselMusteri.BMusteriKNOVarmiKontrol(bm);
                if (sonuc == 1)
                {
                    DataTable dt = BLBireyselMusteri.BMusteriKimlikNoIleBilgileriGetir(bm.tcKimlikNo);

                    if (dt.Rows.Count > 0) // Veri var mı kontrol 
                    {
                        tboxAd.Text = dt.Rows[0]["Ad"].ToString().Trim();
                        tboxSoyad.Text = dt.Rows[0]["Soyad"].ToString().Trim();
                        tboxBabaAdi.Text = dt.Rows[0]["babaAdi"].ToString().Trim();
                        tboxAnneAdi.Text = dt.Rows[0]["anneAdi"].ToString().Trim();
                        tboxOzlukMusteriNo.Text = dt.Rows[0]["musteriNo"].ToString().Trim();
                        tboxKKTCKimlikNo.Text = dt.Rows[0]["KKTCKimlikNo"].ToString().Trim();
                        tboxAdresBilgisi.Text = dt.Rows[0]["adresBilgisi"].ToString().Trim();
                        tboxEAdresBilgisi.Text = dt.Rows[0]["eadresBilgisi"].ToString().Trim();
                        tboxAlanKodu.Text = dt.Rows[0]["alanKod"].ToString().Trim();
                        tboxTelefonNumarası.Text = dt.Rows[0]["telNo"].ToString().Trim();
                        tboxIletisimMusteriNo.Text = dt.Rows[0]["musteriNo"].ToString().Trim();
                        cboxAdresTipi.SelectedIndex = (int)dt.Rows[0]["adresTipKd"];
                        cboxEAdresTipi.SelectedIndex = (int)dt.Rows[0]["eadresTipKd"];
                        cboxTelefonTipi.SelectedIndex = (int)dt.Rows[0]["telefonTipKd"];
                        cboxHatTipi.SelectedIndex = (int)dt.Rows[0]["hatTipiKd"];
                        cboxSahisFirmaDrm.SelectedIndex = (int)dt.Rows[0]["sahisFirmaDrm"];
                        dtimePickerDogumTarihi.Value = (DateTime)dt.Rows[0]["dogumTarihi"];
                    }
                    else
                    {
                        MessageBox.Show("Müşteri bulunamadı.");
                    }
                }


            }
        }

      
        private void tboxKKTCKimlikNo_TextChanged(object sender, EventArgs e)
        {
            if (tboxKKTCKimlikNo.Text.Length == 10)
            {
                EntityBireyselMusteri bm = new EntityBireyselMusteri();
                bm.KKTCKimlikNo = tboxKKTCKimlikNo.Text;
                int sonuc = BLBireyselMusteri.BMusteriKKTCKNOVarmiKontrol(bm);
                if (sonuc == 1)
                {
                    DataTable dt = BLBireyselMusteri.BMusteriKKTCKimlikNoIleBilgileriGetir(bm.KKTCKimlikNo);

                    if (dt.Rows.Count > 0) // Veri var mı kontrol 
                    {
                        tboxAd.Text = dt.Rows[0]["Ad"].ToString().Trim();
                        tboxSoyad.Text = dt.Rows[0]["Soyad"].ToString().Trim();
                        tboxBabaAdi.Text = dt.Rows[0]["babaAdi"].ToString().Trim();
                        tboxAnneAdi.Text = dt.Rows[0]["anneAdi"].ToString().Trim();
                        tboxOzlukMusteriNo.Text = dt.Rows[0]["musteriNo"].ToString().Trim();
                        tboxKKTCKimlikNo.Text = dt.Rows[0]["KKTCKimlikNo"].ToString().Trim();
                        tboxAdresBilgisi.Text = dt.Rows[0]["adresBilgisi"].ToString().Trim();
                        tboxEAdresBilgisi.Text = dt.Rows[0]["eadresBilgisi"].ToString().Trim();
                        tboxAlanKodu.Text = dt.Rows[0]["alanKod"].ToString().Trim();
                        tboxTelefonNumarası.Text = dt.Rows[0]["telNo"].ToString().Trim();
                        tboxIletisimMusteriNo.Text = dt.Rows[0]["musteriNo"].ToString().Trim();
                        cboxAdresTipi.SelectedIndex = (int)dt.Rows[0]["adresTipKd"];
                        cboxEAdresTipi.SelectedIndex = (int)dt.Rows[0]["eadresTipKd"];
                        cboxTelefonTipi.SelectedIndex = (int)dt.Rows[0]["telefonTipKd"];
                        cboxHatTipi.SelectedIndex = (int)dt.Rows[0]["hatTipiKd"];
                        cboxSahisFirmaDrm.SelectedIndex = (int)dt.Rows[0]["sahisFirmaDrm"];
                        dtimePickerDogumTarihi.Value = (DateTime)dt.Rows[0]["dogumTarihi"];
                    }
                    else
                    {
                        MessageBox.Show("Müşteri bulunamadı.");
                    }
                }


            }
        }
       

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            EntityBireyselMusteri bm = new EntityBireyselMusteri();
            bm.musteriNo = int.Parse(tboxOzlukMusteriNo.Text);

            BLBireyselMusteri.BMusteriPasifeCek(bm.musteriNo);
            MessageBox.Show("Müşteri Başarıyla Silindi!");
        }

        private void tboxOzlukMusteriNo_Leave(object sender, EventArgs e)
        {
            try
            {
                EntityBireyselMusteri bm = new EntityBireyselMusteri();
                bm.musteriNo = String.IsNullOrEmpty(tboxOzlukMusteriNo.Text) ? 0 : int.Parse(tboxOzlukMusteriNo.Text);
                int sonuc = BLBireyselMusteri.BMusteriMNOVarmiKontrol(bm);
                if (sonuc == 1)
                {
                    DataTable dt = BLBireyselMusteri.BMusteriMusteriNoIleBilgileriGetir(bm.musteriNo);

                    if (dt.Rows.Count > 0) // Veri var mı kontrol 
                    {
                        tboxAd.Text =  dt.Rows[0]["Ad"] != null && !String.IsNullOrEmpty(dt.Rows[0]["Ad"].ToString()) ? dt.Rows[0]["Ad"].ToString().Trim() : string.Empty;
                        tboxSoyad.Text = dt.Rows[0]["Soyad"].ToString().Trim();
                        tboxBabaAdi.Text = dt.Rows[0]["babaAdi"].ToString().Trim();
                        tboxAnneAdi.Text = dt.Rows[0]["anneAdi"].ToString().Trim();
                        tboxTCKimlikNo.Text = dt.Rows[0]["tcKimlikNo"].ToString().Trim();
                        tboxKKTCKimlikNo.Text = dt.Rows[0]["KKTCKimlikNo"].ToString().Trim();
                        tboxAdresBilgisi.Text = dt.Rows[0]["adresBilgisi"].ToString().Trim();
                        tboxEAdresBilgisi.Text = dt.Rows[0]["eadresBilgisi"].ToString().Trim();
                        tboxAlanKodu.Text = dt.Rows[0]["alanKod"].ToString().Trim();
                        tboxTelefonNumarası.Text = dt.Rows[0]["telNo"].ToString().Trim();
                        tboxIletisimMusteriNo.Text = dt.Rows[0]["musteriNo"].ToString().Trim();
                        cboxAdresTipi.SelectedIndex = (int)dt.Rows[0]["adresTipKd"];
                        cboxEAdresTipi.SelectedIndex = (int)dt.Rows[0]["eadresTipKd"];
                        cboxTelefonTipi.SelectedIndex = (int)dt.Rows[0]["telefonTipKd"];
                        cboxHatTipi.SelectedIndex = (int)dt.Rows[0]["hatTipiKd"];
                        cboxSahisFirmaDrm.SelectedIndex = (int)dt.Rows[0]["sahisFirmaDrm"];
                        dtimePickerDogumTarihi.Value = (DateTime)dt.Rows[0]["dogumTarihi"];
                       
                        
                    }
                    else
                    {
                        MessageBox.Show("Müşteri bulunamadı");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen Müşteri Numarasını Tekrar Giriniz!", ex.Message);
            }

        }

        private void tboxIletisimMusteriNo_Leave(object sender, EventArgs e)
        {
            try
            {
                EntityBireyselMusteri bm = new EntityBireyselMusteri();
                bm.musteriNo = String.IsNullOrEmpty(tboxIletisimMusteriNo.Text) ? 0 : int.Parse(tboxIletisimMusteriNo.Text);
                int sonuc = BLBireyselMusteri.BMusteriMNOVarmiKontrol(bm);
                if (sonuc == 1)
                {
                    DataTable dt = BLBireyselMusteri.BMusteriMusteriNoIleBilgileriGetir(bm.musteriNo);

                    if (dt.Rows.Count > 0) // Veri var mı kontrol 
                    {
                        tboxAd.Text = dt.Rows[0]["Ad"].ToString().Trim();
                        tboxSoyad.Text = dt.Rows[0]["Soyad"].ToString().Trim();
                        tboxBabaAdi.Text = dt.Rows[0]["babaAdi"].ToString().Trim();
                        tboxAnneAdi.Text = dt.Rows[0]["anneAdi"].ToString().Trim();
                        tboxOzlukMusteriNo.Text = dt.Rows[0]["musteriNo"].ToString().Trim();
                        tboxKKTCKimlikNo.Text = dt.Rows[0]["KKTCKimlikNo"].ToString().Trim();
                        tboxAdresBilgisi.Text = dt.Rows[0]["adresBilgisi"].ToString().Trim();
                        tboxEAdresBilgisi.Text = dt.Rows[0]["eadresBilgisi"].ToString().Trim();
                        tboxAlanKodu.Text = dt.Rows[0]["alanKod"].ToString().Trim();
                        tboxTelefonNumarası.Text = dt.Rows[0]["telNo"].ToString().Trim();
                        tboxTCKimlikNo.Text = dt.Rows[0]["tcKimlikNo"].ToString().Trim();
                        cboxAdresTipi.SelectedIndex = (int)dt.Rows[0]["adresTipKd"];
                        cboxEAdresTipi.SelectedIndex = (int)dt.Rows[0]["eadresTipKd"];
                        cboxTelefonTipi.SelectedIndex = (int)dt.Rows[0]["telefonTipKd"];
                        cboxHatTipi.SelectedIndex = (int)dt.Rows[0]["hatTipiKd"];
                        cboxSahisFirmaDrm.SelectedIndex = (int)dt.Rows[0]["sahisFirmaDrm"];
                        dtimePickerDogumTarihi.Value = (DateTime)dt.Rows[0]["dogumTarihi"];
                    }
                    else
                    {
                        MessageBox.Show("Müşteri bulunamadı");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen Müşteri Numarasını Tekrar Giriniz!", ex.Message);
            }
        }
    }
}
