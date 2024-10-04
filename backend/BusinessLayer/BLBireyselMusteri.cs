using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLayer
{
    public class BLBireyselMusteri
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

        
        public static int BMusteriTumBilgileriEkle(CommonEntityTumMusteriler dto) {

            int sonuc = kontrolMusteriTumBilgileriEkle(dto);

            EntityBireyselMusteri bm = dto.bireyselMusteri.FirstOrDefault();
            EntityIrtibatMusteri im = dto.irtibatMusteri.FirstOrDefault();

            if (sonuc==9)
            {
                DALBireyselMusteri.BMusteriOzlukEkle(bm);
                DALBireyselMusteri.BMusteriIletisimEkle(im);
            }
            return sonuc;
        }

        //2
        public static int BMusteriTumBilgileriGuncelle(CommonEntityTumMusteriler dto) {

            int sonuc = kontrolMusteriTumBilgileriGuncelle(dto);
            EntityBireyselMusteri bm = dto.bireyselMusteri.FirstOrDefault();
            EntityIrtibatMusteri im = dto.irtibatMusteri.FirstOrDefault();

            if (sonuc == 9)
            {
                DALBireyselMusteri.BMusteriOzlukGuncelle(bm);
                DALBireyselMusteri.BMusteriIletisimGuncelle(im);
            }

            return sonuc;
        }
      
        public static int BMusteriOzlukGuncelle(EntityBireyselMusteri bm)
        {
            int sonuc = kontrolMusteriOzlukGuncelle(bm);

            if (sonuc == 9)
            {
                DALBireyselMusteri.BMusteriOzlukGuncelle(bm);
            }
            return sonuc;
        }


        public static int BMusteriIletisimGuncelle(EntityIrtibatMusteri im) {
            int sonuc = kontrolMusteriIletisimGuncelle(im);

            if (sonuc == 9)
            {
                DALBireyselMusteri.BMusteriIletisimGuncelle(im);
            }

            return sonuc;

        }

        
        public static DataTable BMusteriListele() {

          return DALBireyselMusteri.BMusteriListele();
     
        }


        //4
        public static int BMusteriNoGetir(string tcKimlikNo) {
            int sonuc = DALBireyselMusteri.BMusteriNoGetir(tcKimlikNo);
            return sonuc;
        }

       
        public static int kontrolMusteriTumBilgileriEkle(CommonEntityTumMusteriler dto) {

            EntityBireyselMusteri bm = dto.bireyselMusteri.FirstOrDefault();
            EntityIrtibatMusteri im = dto.irtibatMusteri.FirstOrDefault();

            int bmSonuc = kontrolMusteriOzlukEkle(bm); 
            int imSonuc = kontrolMusteriIletisimEkle(im);
            int gercekSonuc = 8;

            if (bmSonuc == 9 && bmSonuc == imSonuc)
            {
                gercekSonuc = 9;
            }
            if (bmSonuc == 9 && imSonuc != 9)
            {
                gercekSonuc = imSonuc;
            }
            if (bmSonuc != 9 && imSonuc == 9)
            {
                gercekSonuc = bmSonuc;
            }
            if (bmSonuc != 9 && imSonuc != 9)
            {
                gercekSonuc = bmSonuc;
            }

            if (bmSonuc == 0)
            {
                gercekSonuc = (int)BireyselMusteriHataKayitKodlari.MusteriVarmiHata;
            }

            return gercekSonuc;
        
        }

        public static int kontrolMusteriTumBilgileriGuncelle(CommonEntityTumMusteriler dto) {

            EntityBireyselMusteri bm=dto.bireyselMusteri.FirstOrDefault();
            EntityIrtibatMusteri im = dto.irtibatMusteri.FirstOrDefault();

            int bmSonuc = kontrolMusteriOzlukGuncelle(bm);
            int imSonuc = kontrolMusteriIletisimGuncelle(im);
            int gercekSonuc = 8;

            if (bmSonuc == 9 && bmSonuc == imSonuc)
            {
                gercekSonuc = 9;
            }
            if (bmSonuc == 9 && imSonuc != 9)
            {
                gercekSonuc = imSonuc;
            }
            if (bmSonuc != 9 && imSonuc == 9)
            {
                gercekSonuc = bmSonuc;
            }
            if (bmSonuc != 9 && imSonuc != 9)
            {
                gercekSonuc = bmSonuc;
            }
            
            return gercekSonuc;

        }


        public static int kontrolMusteriOzlukEkle(EntityBireyselMusteri bm) {
            int kontrol = 9;
            if (String.IsNullOrEmpty(bm.tcKimlikNo) && String.IsNullOrEmpty(bm.KKTCKimlikNo))
            {
                return (int)BireyselMusteriHataKayitKodlari.KimlikNoBos;
             }
            
            int musteriVarmi = BMusteriKNOVarmiKontrol(bm);

            DateTime bugün = DateTime.Today;
            TimeSpan fark = bugün - bm.dogumTarihi;
            double yaş = fark.Days / 365.25;


            if (musteriVarmi == 1)
            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.MusteriVarmiHata;

            }

            // TC Kimlik No ve KKTC Kimlik No kontrolleri
            if ((String.IsNullOrEmpty(bm.tcKimlikNo) && String.IsNullOrEmpty(bm.KKTCKimlikNo)) ||
                 (!String.IsNullOrEmpty(bm.tcKimlikNo) && !String.IsNullOrEmpty(bm.KKTCKimlikNo)) ||
                 (String.IsNullOrEmpty(bm.tcKimlikNo) && (bm.KKTCKimlikNo.Length != 10 || !kontrolRakam(bm.KKTCKimlikNo))) ||
                 (String.IsNullOrEmpty(bm.KKTCKimlikNo) && (bm.tcKimlikNo.Length != 11 || !kontrolRakam(bm.tcKimlikNo)))
                 )

            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.KimlikNoHata;

            }

            //Ad, Soyad,Anne Adı ve Baba adı kontrolleri
            if (String.IsNullOrWhiteSpace(bm.musteriAd)|| 
                String.IsNullOrWhiteSpace(bm.musteriSoyad)||
                String.IsNullOrWhiteSpace(bm.musteriBabaAdi)||
                String.IsNullOrWhiteSpace(bm.musteriAnneAdi) ||
                bm.musteriAd.Length>50 ||
                bm.musteriSoyad.Length>50||
                bm.musteriBabaAdi.Length>50||
                bm.musteriAnneAdi.Length>50)

            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.AdSoyadHata;
               
            }

            //Doğum Tarihi Kontrolleri
            if (yaş < 18 || bm.dogumTarihi>bugün)
            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.DogumTarihiHata;
                
            }
            if (bm.sahisFirmaDrm==-1)
            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.AdresEAdresTipi;
                
            }

            return kontrol;
        }


        public static int kontrolMusteriOzlukGuncelle(EntityBireyselMusteri bm)
        {
            int kontrol = 9;
          
            DateTime bugün = DateTime.Today;
            TimeSpan fark = bugün - bm.dogumTarihi;
            double yaş = fark.Days / 365.25;


            // TC Kimlik No ve KKTC Kimlik No kontrolleri
            if ((String.IsNullOrEmpty(bm.tcKimlikNo) && String.IsNullOrEmpty(bm.KKTCKimlikNo)) ||
                 (!String.IsNullOrEmpty(bm.tcKimlikNo) && !String.IsNullOrEmpty(bm.KKTCKimlikNo)) ||
                 (String.IsNullOrEmpty(bm.tcKimlikNo) && (bm.KKTCKimlikNo.Length != 10 || !kontrolRakam(bm.KKTCKimlikNo))) ||
                 (String.IsNullOrEmpty(bm.KKTCKimlikNo) && (bm.tcKimlikNo.Length != 11 || !kontrolRakam(bm.tcKimlikNo)))
                 )

            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.KimlikNoHata;

            }

            //Ad, Soyad,Anne Adı ve Baba adı kontrolleri
            if (String.IsNullOrWhiteSpace(bm.musteriAd) ||
                String.IsNullOrWhiteSpace(bm.musteriSoyad) ||
                String.IsNullOrWhiteSpace(bm.musteriBabaAdi) ||
                String.IsNullOrWhiteSpace(bm.musteriAnneAdi) ||
                bm.musteriAd.Length > 50 ||
                bm.musteriSoyad.Length > 50 ||
                bm.musteriBabaAdi.Length > 50 ||
                bm.musteriAnneAdi.Length > 50)

            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.AdSoyadHata;
                
            }

            //Doğum Tarihi Kontrolleri
            if (yaş < 18 || bm.dogumTarihi > bugün)
            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.DogumTarihiHata;
              
            }
            if (bm.sahisFirmaDrm == -1)
            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.AdresEAdresTipi;
                
            }

            return kontrol;
        }

        public static int kontrolMusteriIletisimEkle(EntityIrtibatMusteri im) {
            int kontrol = 9;

            if (String.IsNullOrEmpty(im.adresBilgisi) &&
                String.IsNullOrEmpty(im.eadresBilgisi) 
                )
            {
              return  kontrol = (int)BireyselMusteriHataKayitKodlari.IletisimBilgiHata;
               
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
           

            if ( String.IsNullOrEmpty(im.alanKod) ||
                 String.IsNullOrEmpty(im.telNo) ||
                 (im.alanKod.Length<3 || im.alanKod.Length>4) ||
                 im.telNo.Length != 7 ||
                 !kontrolRakam(im.alanKod) ||
                 !kontrolRakam(im.telNo)
                )
            {
              return   kontrol = (int)BireyselMusteriHataKayitKodlari.AlanKoduTelNoHata;
                
               
            }
            if (im.adresTipKd == -1 || im.eadresTipKd == -1)
            {
                return kontrol = (int)BireyselMusteriHataKayitKodlari.AdresEAdresTipi;
                 

            }

            if (im.telefonTipKd==-1 || im.hatTipiKd==-1)
            {
                return kontrol =(int) BireyselMusteriHataKayitKodlari.TelefonHatTipi;
                
            }
            
            return kontrol;

        }

        public static int kontrolMusteriIletisimGuncelle(EntityIrtibatMusteri im)
        {
            int kontrol = 9;

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
              return  kontrol = (int)BireyselMusteriHataKayitKodlari.AlanKoduTelNoHata;


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

        public static int BMusteriKNOVarmiKontrol(EntityBireyselMusteri bm)
        {
            int sonuc = DALBireyselMusteri.BMusteriKNOVarmiKontrol(bm);
            return sonuc;
        }
        public static int BMusteriKKTCKNOVarmiKontrol(EntityBireyselMusteri bm)
        {
            int sonuc = DALBireyselMusteri.BMusteriKKTCKNOVarmiKontrol(bm);
            return sonuc;
        }
        public static int BMusteriMNOVarmiKontrol(EntityBireyselMusteri bm)
        {
            int sonuc = DALBireyselMusteri.BMusteriMNOVarmiKontrol(bm);
            return sonuc;
        }
        
        public static DataTable BMusteriKimlikNoIleBilgileriGetir(string tcKimlikNo) {

            DataTable dt = DALBireyselMusteri.BMusteriKimlikNoIleBilgileriGetir(tcKimlikNo);
            return dt;
        
        }

        public static DataTable BMusteriKKTCKimlikNoIleBilgileriGetir(string KKTCKimlikNo)
        {

            DataTable dt = DALBireyselMusteri.BMusteriKKTCKimlikNoIleBilgileriGetir(KKTCKimlikNo);
            return dt;

        }
        public static DataTable BMusteriMusteriNoIleBilgileriGetir(int musteriNo)
        {
            DataTable dt = DALBireyselMusteri.BMusteriMusteriNoIleBilgileriGetir(musteriNo);
            return dt;

        }

        public static int BMusteriPasifeCek(int musteriNo) {
            int sonuc = kontrolBMusteriPasifeCek(musteriNo);
            if (sonuc == 1)
            {
                DALBireyselMusteri.BMusteriPasifeCek(musteriNo);
            }

            return sonuc;
        }

        public static int kontrolBMusteriPasifeCek(int musteriNo)
        {
            int kontrol = 0;
            if (musteriNo>0)
            {
               
                kontrol = 1;
            }
            return kontrol;

        }
        public static CommonEntityTumMusteriler TumBireyselMusteriGetir() {
            
            CommonEntityTumMusteriler commonDto = DALBireyselMusteri.TumBireyselMusteriGetir();

            return commonDto;

        }

        public static CommonEntityTumMusteriler BireyselMusteriGetir(int musteriNo) {

            CommonEntityTumMusteriler commonDto = DALBireyselMusteri.BireyselMusteriGetir(musteriNo);

            return commonDto;
        }
        public static CommonEntityTumMusteriler KNOBireyselMusteriGetir(string kimlikNo)
        {

            CommonEntityTumMusteriler commonDto = DALBireyselMusteri.KNOBireyselMusteriGetir(kimlikNo);

            return commonDto;
        }

    }
}
