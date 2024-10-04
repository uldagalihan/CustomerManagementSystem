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
    public partial class KurumsalMusteriGuncelleme : Form
    {
        public KurumsalMusteriGuncelleme()
        {
            InitializeComponent();
        }

        private void butonTemizle_Click(object sender, EventArgs e)
        {
            try
            {
                
                    tboxVergiKimlikNo.Text = "";
                    tboxUnvan.Text = "";
                    tboxCalisanSayisi.Text = "";
                    tboxNominalSermaye.Text = "";
                    tboxOzlukMusteriNo.Text = "";
                    dtimepickerKurulus.Value = DateTime.Today;
                    cboxMusteriTuru.SelectedIndex = -1;
                    tboxAdresBilgisi.Text = "";
                    tboxEAdresBilgisi.Text = "";
                    tboxAlanKodu.Text = "";
                    tboxTelefonNo.Text = "";
                    tboxIletisimMusteriNo.Text = "";
                    cboxAdresTip.SelectedIndex = -1;
                    cboxEAdresTipi.SelectedIndex = -1;
                    cboxTelefonTipi.SelectedIndex = -1;
                    cboxHatTipi.SelectedIndex = -1;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgiler Temizlenemedi! Hata: ", ex.Message);

            }

        }

        private void butonGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                    int adresTipiIndex, eadresTipiIndex, telefonTipiIndex, hatTipiIndex;
                    int selectedIndex;
                    int sonuc;
                    string kisaUnvan = "";

                    EntityKurumsalMusteri km = new EntityKurumsalMusteri();
                    km.vergiKimlikNo = tboxVergiKimlikNo.Text;
                    km.unvan = tboxUnvan.Text;
                    if (km.unvan.Length > 50)
                    {
                        kisaUnvan = km.unvan.Substring(0, 50);
                    }
                    else
                    {
                        kisaUnvan = km.unvan;
                    }
                    km.kisaUnvan = kisaUnvan;
                    km.calisanSayisi = String.IsNullOrEmpty(tboxCalisanSayisi.Text) ? 0 : int.Parse(tboxCalisanSayisi.Text);
                    km.nominalSermaye = String.IsNullOrEmpty(tboxNominalSermaye.Text) ? 0 : int.Parse(tboxNominalSermaye.Text);
                    km.musteriNo = Convert.ToInt32(tboxOzlukMusteriNo.Text);

                    km.firmaKurulusTarihi = dtimepickerKurulus.Value;
                    selectedIndex = cboxMusteriTuru.SelectedIndex;
                    km.musteriTuruKod = selectedIndex;

                    EntityIrtibatMusteri im = new EntityIrtibatMusteri();

                    im.adresBilgisi = tboxAdresBilgisi.Text;
                    im.eadresBilgisi = tboxEAdresBilgisi.Text;
                    im.alanKod = tboxAlanKodu.Text;
                    im.telNo = tboxTelefonNo.Text;

                    adresTipiIndex = cboxAdresTip.SelectedIndex;
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
                    dto.kurumsalMusteri = new List<EntityKurumsalMusteri>(1);
                    List<EntityKurumsalMusteri> listKurumsal = new List<EntityKurumsalMusteri>(1);

                    listIrtibat.Add(im);
                    listKurumsal.Add(km);
                    dto.irtibatMusteri = listIrtibat;
                    dto.kurumsalMusteri = listKurumsal;
                   
                sonuc = BLKurumsalMusteri.KMusteriTumBilgileriGuncelle(dto);
                    switch (sonuc)
                    {
                        case 1:
                            MessageBox.Show("Vergi Kimlik No Hatalı! Lütfen tekrar giriniz");
                            tboxVergiKimlikNo.Text = "";
                            break;
                        case 2:
                            MessageBox.Show("Unvan Bilgisi Hatalı! Lütfen tekrar giriniz");
                            tboxUnvan.Text = "";
                            break;
                        case 3:
                            MessageBox.Show("Kuruluş Tarihi Bugünden Büyük Tarih Olamaz! Lütfen tekrar giriniz");
                            dtimepickerKurulus.Value = DateTime.Today;
                            break;
                        case 4:
                            MessageBox.Show("Adres Hatalı! Lütfen tekrar giriniz");
                            tboxAdresBilgisi.Text = "";
                            break;
                        case 5:
                            MessageBox.Show("Alan Kodu veya Telefon Numarası Hatalı! Lütfen tekrar giriniz");
                            tboxAlanKodu.Text = "";
                            tboxTelefonNo.Text = "";
                            break;
                        case 6:
                            MessageBox.Show(" Özlük  Bilgilerini Kontrol Ediniz!");
                            break;
                        case 7:
                            MessageBox.Show(" İletişim Bilgilerini Kontrol Ediniz!");
                            break;
                        case 8:
                            MessageBox.Show("E-Adres Hatalı! Lütfen tekrar giriniz!!");
                            tboxEAdresBilgisi.Text = "";
                        break;
                        case 9:
                            MessageBox.Show("Çalışan Sayısı veya Nominal Sermaye Bilgileri Hatalı! Lütfen Tekrar Giriniz!");
                            break;
                        case 10:
                            MessageBox.Show("Güncelleme Başarılı!");
                            break;
                        case 11:
                            MessageBox.Show("Adres E-Adres Tip Bilgisi Boş Bırakılamaz!");
                            break;
                        case 12:
                            MessageBox.Show("Telefon Hat Tipi Bilgisi Boş Bırakılamaz!");
                            break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme İşlemi Gerçekleştirilemedi! Hata:", ex.Message);
            }
        }

        private void tboxVergiKimlikNo_TextChanged(object sender, EventArgs e)
        {
            if (tboxVergiKimlikNo.Text.Length == 10)
            {
                EntityKurumsalMusteri km = new EntityKurumsalMusteri();
                km.vergiKimlikNo = tboxVergiKimlikNo.Text;
                int sonuc = BLKurumsalMusteri.KMusteriKNOVarmiKontrol(km);
                if (sonuc == 1)
                {
                    DataTable dt = BLKurumsalMusteri.KMusteriKimlikNoIleBilgileriGetir(km.vergiKimlikNo);

                    if (dt.Rows.Count > 0) // Veri var mı kontrol 
                    {
                        tboxUnvan.Text = dt.Rows[0]["unvan"].ToString().Trim();
                        tboxVergiKimlikNo.Text = dt.Rows[0]["vergiKimlikNo"].ToString().Trim();
                        tboxCalisanSayisi.Text = dt.Rows[0]["calisanSayisi"].ToString().Trim();
                        tboxNominalSermaye.Text = dt.Rows[0]["nominalSermaye"].ToString().Trim();
                        tboxOzlukMusteriNo.Text = dt.Rows[0]["musteriNo"].ToString().Trim();
                        tboxAdresBilgisi.Text = dt.Rows[0]["adresBilgisi"].ToString().Trim();
                        tboxEAdresBilgisi.Text = dt.Rows[0]["eadresBilgisi"].ToString().Trim();
                        tboxAlanKodu.Text = dt.Rows[0]["alanKod"].ToString().Trim();
                        tboxTelefonNo.Text = dt.Rows[0]["telNo"].ToString().Trim();
                        tboxIletisimMusteriNo.Text = dt.Rows[0]["musteriNo"].ToString().Trim();
                        cboxMusteriTuru.SelectedIndex = (int)dt.Rows[0]["musteriTuruKod"];
                        cboxAdresTip.SelectedIndex = (int)dt.Rows[0]["adresTipKd"];
                        cboxEAdresTipi.SelectedIndex = (int)dt.Rows[0]["eadresTipKd"];
                        cboxTelefonTipi.SelectedIndex = (int)dt.Rows[0]["telefonTipKd"];
                        cboxHatTipi.SelectedIndex = (int)dt.Rows[0]["hatTipiKd"];
                        dtimepickerKurulus.Value = (DateTime)dt.Rows[0]["firmaKurulusTarihi"];
                    }
                    else
                    {
                        MessageBox.Show("Müşteri bulunamadı.");
                    }
                }

            }
        }

        

       

        private void btnMusteriIptal_Click(object sender, EventArgs e)
        {
            try
            {
                EntityKurumsalMusteri km = new EntityKurumsalMusteri();
                km.musteriNo = int.Parse(tboxOzlukMusteriNo.Text);

                BLKurumsalMusteri.KMusteriPasifeCek(km);
                MessageBox.Show("Müşteri Başarıyla Silindi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri Silinemedi! Hata: ",ex.Message);
            }
           
        }

        private void KurumsalMusteriGuncelleme_Load(object sender, EventArgs e)
        {
            var enumValues = Enum.GetValues(typeof(KurumsalMusteriTurleri)).Cast<KurumsalMusteriTurleri>()
      .Select(v => v.ToString().Replace("Anonim", "Anonim Şirket").Replace("Limited", "Limited Şirket")).ToList();

            cboxMusteriTuru.DataSource = enumValues;
        }

        private void tboxOzlukMusteriNo_Leave(object sender, EventArgs e)
        {
            try
            {
                EntityKurumsalMusteri km = new EntityKurumsalMusteri();
                km.musteriNo = String.IsNullOrEmpty(tboxOzlukMusteriNo.Text) ? 0 : int.Parse(tboxOzlukMusteriNo.Text);
                int sonuc = BLKurumsalMusteri.KMusteriMNOVarmiKontrol(km);
                if (sonuc == 1)
                {
                    DataTable dt = BLKurumsalMusteri.KMusteriMusteriNoIleBilgileriGetir(km.musteriNo);

                    if (dt.Rows.Count > 0) // Veri var mı kontrol 
                    {
                        tboxUnvan.Text = dt.Rows[0]["unvan"].ToString().Trim();
                        tboxVergiKimlikNo.Text = dt.Rows[0]["vergiKimlikNo"].ToString().Trim();
                        tboxCalisanSayisi.Text = dt.Rows[0]["calisanSayisi"].ToString().Trim();
                        tboxNominalSermaye.Text = dt.Rows[0]["nominalSermaye"].ToString().Trim();
                        tboxOzlukMusteriNo.Text = dt.Rows[0]["musteriNo"].ToString().Trim();
                        tboxAdresBilgisi.Text = dt.Rows[0]["adresBilgisi"].ToString().Trim();
                        tboxEAdresBilgisi.Text = dt.Rows[0]["eadresBilgisi"].ToString().Trim();
                        tboxAlanKodu.Text = dt.Rows[0]["alanKod"].ToString().Trim();
                        tboxTelefonNo.Text = dt.Rows[0]["telNo"].ToString().Trim();
                        tboxIletisimMusteriNo.Text = dt.Rows[0]["musteriNo"].ToString().Trim();
                        cboxMusteriTuru.SelectedIndex = (int)dt.Rows[0]["musteriTuruKod"];
                        cboxAdresTip.SelectedIndex = (int)dt.Rows[0]["adresTipKd"];
                        cboxEAdresTipi.SelectedIndex = (int)dt.Rows[0]["eadresTipKd"];
                        cboxTelefonTipi.SelectedIndex = (int)dt.Rows[0]["telefonTipKd"];
                        cboxHatTipi.SelectedIndex = (int)dt.Rows[0]["hatTipiKd"];
                        dtimepickerKurulus.Value = (DateTime)dt.Rows[0]["firmaKurulusTarihi"];
                    }
                    else
                    {
                        MessageBox.Show("Müşteri bulunamadı");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen Müşteri Numarasını Tekrar Giriniz! ", ex.Message);
            }
        }

        private void tboxIletisimMusteriNo_Leave(object sender, EventArgs e)
        {
            try
            {
                EntityKurumsalMusteri km = new EntityKurumsalMusteri();
                km.musteriNo = String.IsNullOrEmpty(tboxIletisimMusteriNo.Text) ? 0 : int.Parse(tboxIletisimMusteriNo.Text);
                int sonuc = BLKurumsalMusteri.KMusteriMNOVarmiKontrol(km);
                if (sonuc == 1)
                {
                    DataTable dt = BLKurumsalMusteri.KMusteriMusteriNoIleBilgileriGetir(km.musteriNo);

                    if (dt.Rows.Count > 0) // Veri var mı kontrol 
                    {
                        tboxUnvan.Text = dt.Rows[0]["unvan"].ToString().Trim();
                        tboxVergiKimlikNo.Text = dt.Rows[0]["vergiKimlikNo"].ToString().Trim();
                        tboxCalisanSayisi.Text = dt.Rows[0]["calisanSayisi"].ToString().Trim();
                        tboxNominalSermaye.Text = dt.Rows[0]["nominalSermaye"].ToString().Trim();
                        tboxOzlukMusteriNo.Text = dt.Rows[0]["musteriNo"].ToString().Trim();
                        tboxAdresBilgisi.Text = dt.Rows[0]["adresBilgisi"].ToString().Trim();
                        tboxEAdresBilgisi.Text = dt.Rows[0]["eadresBilgisi"].ToString().Trim();
                        tboxAlanKodu.Text = dt.Rows[0]["alanKod"].ToString().Trim();
                        tboxTelefonNo.Text = dt.Rows[0]["telNo"].ToString().Trim();
                        tboxIletisimMusteriNo.Text = dt.Rows[0]["musteriNo"].ToString().Trim();
                        cboxMusteriTuru.SelectedIndex = (int)dt.Rows[0]["musteriTuruKod"];
                        cboxAdresTip.SelectedIndex = (int)dt.Rows[0]["adresTipKd"];
                        cboxEAdresTipi.SelectedIndex = (int)dt.Rows[0]["eadresTipKd"];
                        cboxTelefonTipi.SelectedIndex = (int)dt.Rows[0]["telefonTipKd"];
                        cboxHatTipi.SelectedIndex = (int)dt.Rows[0]["hatTipiKd"];
                        dtimepickerKurulus.Value = (DateTime)dt.Rows[0]["firmaKurulusTarihi"];
                    }
                    else
                    {
                        MessageBox.Show("Müşteri bulunamadı");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen Müşteri Numarasını Tekrar Giriniz! ", ex.Message);
            }
        }
    }
}
