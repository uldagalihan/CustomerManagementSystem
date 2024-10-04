using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusteriKayitSistemi
{
    public partial class KurumsalMusteriTanımlama : Form
    {
        public KurumsalMusteriTanımlama()
        {
            InitializeComponent();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
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
                MessageBox.Show("Bilgiler Temizlenemedi! Hata: ",ex.Message);
                
            }
           

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(tboxOzlukMusteriNo.Text) ||
                !String.IsNullOrEmpty(tboxIletisimMusteriNo.Text))
                {
                    MessageBox.Show("Hata! Müşteri Numarası Ataması Yapılamaz!");
                    tboxOzlukMusteriNo.Text = "";
                    tboxIletisimMusteriNo.Text = "";
                }
                else
                {
                    int selectedIndex;
                    int sonuc;
                    int adresTipiIndex, eadresTipiIndex, telefonTipiIndex, hatTipiIndex;
                    string kisaUnvan = "";

                    EntityKurumsalMusteri km = new EntityKurumsalMusteri();
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
                    im.iletisimDrm = checkBox1.Checked ? 1 : 0;

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
                    km.firmaKurulusTarihi = dtimepickerKurulus.Value;

                    selectedIndex = cboxMusteriTuru.SelectedIndex;
                    km.musteriTuruKod = selectedIndex;

                    CommonEntityTumMusteriler dto = new CommonEntityTumMusteriler();

                    dto.irtibatMusteri = new List<EntityIrtibatMusteri>(1);
                    List<EntityIrtibatMusteri> listIrtibat = new List<EntityIrtibatMusteri>(1);
                    dto.kurumsalMusteri = new List<EntityKurumsalMusteri>(1);
                    List<EntityKurumsalMusteri> listKurumsal = new List<EntityKurumsalMusteri>(1);

                    listIrtibat.Add(im);
                    listKurumsal.Add(km);
                    dto.irtibatMusteri = listIrtibat;
                    dto.kurumsalMusteri = listKurumsal;
                  
                    sonuc = BLKurumsalMusteri.KMusteriTumBilgileriEkle(dto);
                    switch (sonuc)
                    {

                        case 0:
                            MessageBox.Show("Bu Vergi Kimlik Numarasına Kayıtlı Müşteri Zaten Var! Lütfen tekrar giriniz");
                            tboxVergiKimlikNo.Text = "";
                            break;
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
                            MessageBox.Show("E-Adres Hatalı! Lütfen tekrar girini");
                            tboxEAdresBilgisi.Text = "";
                            break;    
                        case 9:
                            MessageBox.Show("Çalışan Sayısı veya Nominal Sermaye Bilgileri Hatalı! Lütfen Tekrar Giriniz!");
                            break;
                        case 10:
                            MessageBox.Show("Kayıt Başarılı!");
                            tboxOzlukMusteriNo.Text = BLKurumsalMusteri.KMusteriNoGetir(km.vergiKimlikNo).ToString();
                            tboxIletisimMusteriNo.Text = BLKurumsalMusteri.KMusteriNoGetir(km.vergiKimlikNo).ToString();
                            break;        
                        case 11:
                            MessageBox.Show("Adres E-Adres Bilgileri Boş Bırakılamaz!");
                            break;
                        case 12:
                            MessageBox.Show("Telefon Hat Tipi Bilgileri Boş Bırakılamaz!");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri Kaydetme İşlemi Gerçekleştirilemedi! Hata: ", ex.Message);
                
            }
            

        }


        private void KurumsalMusteriTanımlama_Load(object sender, EventArgs e)
        {
            tboxOzlukMusteriNo.Enabled = false;
            tboxIletisimMusteriNo.Enabled = false;
            var enumValues = Enum.GetValues(typeof(KurumsalMusteriTurleri)).Cast<KurumsalMusteriTurleri>()
           .Select(v => v.ToString().Replace("Anonim", "Anonim Şirket").Replace("Limited", "Limited Şirket")).ToList();

            cboxMusteriTuru.DataSource = enumValues;
        }

        private void tboxIletisimMusteriNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
