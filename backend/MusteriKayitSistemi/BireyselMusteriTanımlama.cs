using BusinessLayer;
using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MusteriKayitSistemi
{
    public partial class BireyselMusteriTanımlama : Form
    {
        public BireyselMusteriTanımlama()
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
               
                    int selectedIndex;
                    int sonuc;
                    int adresTipiIndex, eadresTipiIndex, telefonTipiIndex, hatTipiIndex;

                    EntityBireyselMusteri bm = new EntityBireyselMusteri();
                    EntityIrtibatMusteri im = new EntityIrtibatMusteri();
                    CommonEntityTumMusteriler dto = new CommonEntityTumMusteriler();

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
                    im.iletisimDrm = checkBox1.Checked ? 1 : 0;


                    bm.tcKimlikNo = tboxTCKimlikNo.Text;
                    bm.KKTCKimlikNo = tboxKKTCKimlikNo.Text;
                    bm.musteriAd = tboxAd.Text;
                    bm.musteriSoyad = tboxSoyad.Text;
                    bm.dogumTarihi = dtimePickerDogumTarihi.Value;
                    bm.musteriBabaAdi = tboxBabaAdi.Text;
                    bm.musteriAnneAdi = tboxAnneAdi.Text;
                    

                    selectedIndex = cboxSahisFirmaDrm.SelectedIndex;
                    bm.sahisFirmaDrm = selectedIndex;

                    dto.irtibatMusteri = new List<EntityIrtibatMusteri>(1);
                     List<EntityIrtibatMusteri> listIrtibat = new List<EntityIrtibatMusteri>(1);
                    dto.bireyselMusteri = new List<EntityBireyselMusteri>(1);
                    List<EntityBireyselMusteri> listBireysel = new List<EntityBireyselMusteri>(1);
               
                    listBireysel.Add(bm);
                    listIrtibat.Add(im);
               
                    dto.irtibatMusteri = listIrtibat;
                
                    dto.bireyselMusteri = listBireysel;

                    sonuc = BLBireyselMusteri.BMusteriTumBilgileriEkle(dto);
                    switch (sonuc)
                    { 
                        case 0:
                            MessageBox.Show("Bu TC Kimlik Numarasına Kayıtlı Müşteri Zaten Var! Lütfen tekrar giriniz");
                            tboxTCKimlikNo.Text = "";
                            break;
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
                                MessageBox.Show("Kayıt Başarılı!");
                                tboxOzlukMusteriNo.Text = BLBireyselMusteri.BMusteriNoGetir(bm.tcKimlikNo).ToString();
                                tboxIletisimMusteriNo.Text = BLBireyselMusteri.BMusteriNoGetir(bm.tcKimlikNo).ToString();
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
                    case 13:
                        MessageBox.Show("Lütfen TC Kimlik Numarası veya KKTC Kimlik Numarası Bilgisi Giriniz!");
                        break;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri Kaydetme İşlemi Gerçekleştirilemedi! Hata: ", ex.Message);
            }
                

        }

        private void BireyselMusteriTanımlama_Load(object sender, EventArgs e)
        {
            tboxOzlukMusteriNo.Enabled = false;
            tboxIletisimMusteriNo.Enabled = false;
        }

        
    }

       
  }

