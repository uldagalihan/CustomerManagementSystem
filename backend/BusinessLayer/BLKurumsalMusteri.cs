using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLKurumsalMusteri
    {

        public static bool kontrolRakam(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public static int KMusteriTumBilgileriEkle(CommonEntityTumMusteriler dto)
        {
            int sonuc = kontrolMusteriTumBilgileriEkle(dto);

            EntityKurumsalMusteri km = dto.kurumsalMusteri.FirstOrDefault();
            EntityIrtibatMusteri im = dto.irtibatMusteri.FirstOrDefault();
            if (sonuc == 10)
            {
                DALKurumsalMusteri.KMusteriOzlukEkle(km);
                DALKurumsalMusteri.KMusteriIletisimEkle(im);
            }
            return sonuc;
        }

        public static int KMusteriTumBilgileriGuncelle(CommonEntityTumMusteriler dto)
        {
            int sonuc = kontrolMusteriTumBilgileriGuncelle(dto);
            EntityKurumsalMusteri km = dto.kurumsalMusteri.FirstOrDefault();
            EntityIrtibatMusteri im = dto.irtibatMusteri.FirstOrDefault();
            if (sonuc == 10)
            {
                DALKurumsalMusteri.KMusteriOzlukGuncelle(km);
                DALKurumsalMusteri.KMusteriIletisimGuncelle(im);
            }
            return sonuc;
        }

        public static int KMusteriOzlukGuncelle(EntityKurumsalMusteri km)
        {
            int sonuc = kontrolMusteriOzlukGuncelle(km);

            if (sonuc == 10)
            {
                DALKurumsalMusteri.KMusteriOzlukGuncelle(km);
            }
            return sonuc;
        }


        public static int KMusteriIletisimGuncelle(EntityIrtibatMusteri im)
        {
            int sonuc = kontrolMusteriIletisimGuncelle(im);

            if (sonuc == 10)
            {
                DALKurumsalMusteri.KMusteriIletisimGuncelle(im);
            }

            return sonuc;

        }

        public static DataTable KMusteriListele()
        {

            return DALKurumsalMusteri.KMusteriListele();

        }

        public static int KMusteriNoGetir(string vergiKimlikNo)
        {
            int sonuc = DALKurumsalMusteri.KMusteriNoGetir(vergiKimlikNo);
            return sonuc;
        }

        public static int kontrolMusteriTumBilgileriEkle(CommonEntityTumMusteriler dto)
        {

            EntityKurumsalMusteri km = dto.kurumsalMusteri.FirstOrDefault();
            EntityIrtibatMusteri im = dto.irtibatMusteri.FirstOrDefault();

            int bmSonuc = kontrolMusteriOzlukEkle(km);
            int imSonuc = kontrolMusteriIletisimEkle(im);
            int gercekSonuc = 8;

           

            if (bmSonuc == 10 && bmSonuc == imSonuc)
            {
                gercekSonuc = 10;
            }
            if (bmSonuc == 10 && imSonuc != 10)
            {
                gercekSonuc = imSonuc;
            }
            if (bmSonuc != 10 && imSonuc == 10)
            {
                gercekSonuc = bmSonuc;
            }
            if (bmSonuc != 10 && imSonuc != 10)
            {
                gercekSonuc = bmSonuc;
            }
            if (bmSonuc == 0)
            {
                gercekSonuc = (int)KurumsalMusteriHataKayitKodlari.MusteriVarmiHata;
            }

            return gercekSonuc;

        }

        public static int kontrolMusteriTumBilgileriGuncelle(CommonEntityTumMusteriler dto)
        {

            EntityKurumsalMusteri km = dto.kurumsalMusteri.FirstOrDefault();
            EntityIrtibatMusteri im = dto.irtibatMusteri.FirstOrDefault();

            int bmSonuc = kontrolMusteriOzlukGuncelle(km);
            int imSonuc = kontrolMusteriIletisimGuncelle(im);
            int gercekSonuc = 8;

            if (bmSonuc == 10 && bmSonuc == imSonuc)
            {
                gercekSonuc = 10;
            }
            if (bmSonuc == 10 && imSonuc != 10)
            {
                gercekSonuc = imSonuc;
            }
            if (bmSonuc != 10 && imSonuc == 10)
            {
                gercekSonuc = bmSonuc;
            }
            if (bmSonuc != 10 && imSonuc != 10)
            {
                gercekSonuc = bmSonuc;
            }
           
            return gercekSonuc;

        }
        public static int kontrolMusteriOzlukEkle(EntityKurumsalMusteri km)
        {
            int kontrol = 10;
           
            int musteriVarmi = KMusteriKNOVarmiKontrol(km);

            DateTime bugün = DateTime.Today;

            if (musteriVarmi == 1)
            {
                return kontrol = (int)KurumsalMusteriHataKayitKodlari.MusteriVarmiHata;
            }

            // Vergi Kimlik No kontrolleri
            if (String.IsNullOrEmpty(km.vergiKimlikNo) ||
                km.vergiKimlikNo.Length != 10 || !kontrolRakam(km.vergiKimlikNo)
                )

            {
                return kontrol = (int)KurumsalMusteriHataKayitKodlari.KimlikNoHata;

            }

            if (String.IsNullOrWhiteSpace(km.unvan) ||
                 km.unvan.Length > 100
            )

            {
                return kontrol = (int)KurumsalMusteriHataKayitKodlari.UnvanHata;
               
            }


            //Doğum Tarihi Kontrolleri
            if ( km.firmaKurulusTarihi > bugün)
            {
                return kontrol = (int)KurumsalMusteriHataKayitKodlari.KurulusTarihiHata;
               
            }

            if (km.calisanSayisi == 0 ||
                km.nominalSermaye == 0)
            {
             return kontrol = (int)KurumsalMusteriHataKayitKodlari.CalisanNominalSermayeHata;
              
            }

            return kontrol;
        }


        public static int kontrolMusteriOzlukGuncelle(EntityKurumsalMusteri km)
        {
            int kontrol = 10;

            DateTime bugün = DateTime.Today;

            // Vergi Kimlik No kontrolleri
            if (String.IsNullOrEmpty(km.vergiKimlikNo) ||
                km.vergiKimlikNo.Length != 10 || !kontrolRakam(km.vergiKimlikNo)
                )

            {
                return kontrol = (int)KurumsalMusteriHataKayitKodlari.KimlikNoHata;

            }

            if (String.IsNullOrWhiteSpace(km.unvan) ||
                 km.unvan.Length > 100
            )

            {
                return kontrol = (int)KurumsalMusteriHataKayitKodlari.UnvanHata;

            }


            //Doğum Tarihi Kontrolleri
            if (km.firmaKurulusTarihi > bugün)
            {
                return kontrol = (int)KurumsalMusteriHataKayitKodlari.KurulusTarihiHata;

            }

            if (km.calisanSayisi == 0 ||
                km.nominalSermaye == 0)
            {
                return kontrol = (int)KurumsalMusteriHataKayitKodlari.CalisanNominalSermayeHata;

            }

            return kontrol;
        }

        public static int kontrolMusteriIletisimEkle(EntityIrtibatMusteri im)
        {
            int kontrol = 10;

            if (String.IsNullOrEmpty(im.adresBilgisi) &&
                String.IsNullOrEmpty(im.eadresBilgisi) 
               )
            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.IletisimBilgiHata;

            }
            if (String.IsNullOrEmpty(im.adresBilgisi) ||
               im.adresBilgisi.Length > 200)

            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.AdresHata;

            }
            if (
                String.IsNullOrEmpty(im.eadresBilgisi) ||
                im.eadresBilgisi.Length > 50 ||
               !im.eadresBilgisi.Contains("@")  //@ işareti zorunlu

                )
            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.EAdresHata;

            }


            if (String.IsNullOrEmpty(im.alanKod) ||
                 String.IsNullOrEmpty(im.telNo) ||
                 (im.alanKod.Length < 3 || im.alanKod.Length > 4) ||
                 im.telNo.Length != 7 ||
                 !kontrolRakam(im.alanKod) ||
                 !kontrolRakam(im.telNo)
                )
            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.AlanKoduTelNoHata;


            }
            if (im.adresTipKd == -1 || im.eadresTipKd == -1)
            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.AdresEAdresTipi;


            }

            if (im.telefonTipKd == -1 || im.hatTipiKd == -1)
            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.TelefonHatTipi;

            }

            return kontrol;

        }



        public static int kontrolMusteriIletisimGuncelle(EntityIrtibatMusteri im)
        {
            int kontrol = 10;

            
            if (String.IsNullOrEmpty(im.adresBilgisi) ||
               im.adresBilgisi.Length > 200)

            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.AdresHata;

            }
            if (
                String.IsNullOrEmpty(im.eadresBilgisi) ||
                im.eadresBilgisi.Length > 50 ||
               !im.eadresBilgisi.Contains("@")  //@ işareti zorunlu

                )
            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.EAdresHata;

            }

            if (String.IsNullOrEmpty(im.alanKod) ||
                 String.IsNullOrEmpty(im.telNo) ||
                 (im.alanKod.Length < 3 || im.alanKod.Length > 4) ||
                 im.telNo.Length != 7 ||
                 !kontrolRakam(im.alanKod) ||
                 !kontrolRakam(im.telNo)
                )
            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.AlanKoduTelNoHata;


            }
            if (im.adresTipKd == -1 || im.eadresTipKd == -1)
            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.AdresEAdresTipi;

            }

            if (im.telefonTipKd == -1 || im.hatTipiKd == -1)
            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.TelefonHatTipi;

            }

            return kontrol;

        }

        public static int KMusteriKNOVarmiKontrol(EntityKurumsalMusteri km)
        {
            int sonuc = DALKurumsalMusteri.KMusteriKNOVarmiKontrol(km);
            return sonuc;
        }
        public static int KMusteriMNOVarmiKontrol(EntityKurumsalMusteri km)
        {
            int sonuc = DALKurumsalMusteri.KMusteriMNOVarmiKontrol(km);
            return sonuc;
        }
       
        public static DataTable KMusteriKimlikNoIleBilgileriGetir(string vergiKimlikNo)
        {

            DataTable dt = DALKurumsalMusteri.KMusteriKimlikNoIleBilgileriGetir(vergiKimlikNo);
            return dt;

        }

        public static DataTable KMusteriMusteriNoIleBilgileriGetir(int musteriNo)
        {

            DataTable dt = DALKurumsalMusteri.KMusteriMusteriNoIleBilgileriGetir(musteriNo);
            return dt;

        }

        public static int KMusteriPasifeCek(int musteriNo)
        {
            int sonuc = kontrolKMusteriPasifeCek(musteriNo);
            if(sonuc == 1) { 
            DALKurumsalMusteri.KMusteriPasifeCek(musteriNo);
            }
            return sonuc;
        }

        public static int kontrolKMusteriPasifeCek(int musteriNo)
        {
            int kontrol = 0;
            if (musteriNo > 0)
            {

                kontrol = 1;
            }
            return kontrol;

        }

        public static CommonEntityTumMusteriler TumKurumsalMusteriGetir()
        {

            CommonEntityTumMusteriler commonDto = DALKurumsalMusteri.TumKurumsalMusteriGetir();

            return commonDto;

        }

        public static CommonEntityTumMusteriler KurumsalMusteriGetir(int musteriNo)
        {

            CommonEntityTumMusteriler commonDto = DALKurumsalMusteri.KurumsalMusteriGetir(musteriNo);

            return commonDto;
        }
        public static CommonEntityTumMusteriler KNOKurumsalMusteriGetir(string kimlikNo)
        {

            CommonEntityTumMusteriler commonDto = DALKurumsalMusteri.KNOKurumsalMusteriGetir(kimlikNo);

            return commonDto;
        }

    }
}
