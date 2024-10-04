using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;
using System.Data.Common;
using System.ComponentModel.Design;

namespace DataAccessLayer
{
    public class DALBireyselMusteri
    {

        public static void BMusteriOzlukEkle(EntityBireyselMusteri bm) {

            SqlCommand commandEkle = new SqlCommand("Insert into tblBireyselMusteri (tcKimlikNo,dogumTarihi,Ad,Soyad,babaAdi,anneAdi,sahisFirmaDrm,KKTCKimlikNo) values (@ptcKimlikNo,@pdogumTarihi,@pAd,@pSoyad,@pbabaAdi,@panneAdi,@psahisFirmaDrm,@pKKTCKimlikNo) ",Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);

            if (bm.tcKimlikNo == null )
            {
                commandEkle.Parameters.AddWithValue("@ptcKimlikNo", "");
            }
            else
            {
                commandEkle.Parameters.AddWithValue("@ptcKimlikNo", bm.tcKimlikNo);
            }
            commandEkle.Parameters.AddWithValue("@pdogumTarihi",bm.dogumTarihi);
            commandEkle.Parameters.AddWithValue("@pAd",bm.musteriAd);
            commandEkle.Parameters.AddWithValue("@pSoyad",bm.musteriSoyad);
            commandEkle.Parameters.AddWithValue("@pbabaAdi",bm.musteriBabaAdi);
            commandEkle.Parameters.AddWithValue("@panneAdi",bm.musteriAnneAdi);
            commandEkle.Parameters.AddWithValue("@psahisFirmaDrm",bm.sahisFirmaDrm);
            if (bm.KKTCKimlikNo == null)
            {
                commandEkle.Parameters.AddWithValue("@pKKTCKimlikNo", "");
            }
            else
            {
                commandEkle.Parameters.AddWithValue("@pKKTCKimlikNo", bm.KKTCKimlikNo);
            }

            commandEkle.ExecuteNonQuery();


        }

        public static void BMusteriOzlukGuncelle(EntityBireyselMusteri bm) {

            SqlCommand commandGuncelle = new SqlCommand("Update tblBireyselMusteri set tcKimlikNo=@ptcKimlikNo, dogumTarihi = @pdogumTarihi, Ad = @pAd,Soyad =@pSoyad, babaAdi =@pbabaAdi, anneAdi = @panneAdi,sahisFirmaDrm =@psahisFirmaDrm,KKTCKimlikNo = @pKKTCKimlikNo where musteriNo = @pmusteriNo", Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);

            commandGuncelle.Parameters.AddWithValue("@ptcKimlikNo", bm.tcKimlikNo);
            commandGuncelle.Parameters.AddWithValue("@pdogumTarihi", bm.dogumTarihi);
            commandGuncelle.Parameters.AddWithValue("@pAd", bm.musteriAd);
            commandGuncelle.Parameters.AddWithValue("@pSoyad", bm.musteriSoyad);
            commandGuncelle.Parameters.AddWithValue("@pbabaAdi", bm.musteriBabaAdi);
            commandGuncelle.Parameters.AddWithValue("@panneAdi", bm.musteriAnneAdi);
            commandGuncelle.Parameters.AddWithValue("@psahisFirmaDrm", bm.sahisFirmaDrm);
            commandGuncelle.Parameters.AddWithValue("@pKKTCKimlikNo", bm.KKTCKimlikNo);
            commandGuncelle.Parameters.AddWithValue("@pmusteriNo", bm.musteriNo);

            commandGuncelle.ExecuteNonQuery();

        }

        public static void BMusteriIletisimEkle(EntityIrtibatMusteri im) {

            SqlCommand commandAdd = new SqlCommand("Insert into tblIrtibatMusteri (iletisimDrm,kayitDrm,adresTipKd,adresBilgisi,eadresTipKd,eadresBilgisi,telefonTipKd,hatTipiKd,alanKod,telNo) values(@piletisimDrm,@pkayitDrm,@padresTipKd,@padresBilgisi,@peadresTipKd,@peadresBilgisi,@ptelefonTipKd,@phatTipiKd,@palanKod,@ptelNo)",Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);

            commandAdd.Parameters.AddWithValue("@piletisimDrm", im.iletisimDrm);
            commandAdd.Parameters.AddWithValue("@pkayitDrm", im.kayitDrm);
            commandAdd.Parameters.AddWithValue("@padresTipKd", im.adresTipKd);
            commandAdd.Parameters.AddWithValue("@padresBilgisi", im.adresBilgisi);
            commandAdd.Parameters.AddWithValue("@peadresTipKd", im.eadresTipKd);
            commandAdd.Parameters.AddWithValue("@peadresBilgisi", im.eadresBilgisi);
            commandAdd.Parameters.AddWithValue("@ptelefonTipKd", im.telefonTipKd);
            commandAdd.Parameters.AddWithValue("@phatTipiKd", im.hatTipiKd);
            commandAdd.Parameters.AddWithValue("@palanKod", im.alanKod);
            commandAdd.Parameters.AddWithValue("@ptelNo", im.telNo);

            commandAdd.ExecuteNonQuery();
        }


        public static void BMusteriIletisimGuncelle(EntityIrtibatMusteri im) {

            SqlCommand commandUpdate = new SqlCommand("Update tblIrtibatMusteri set adresTipKd = @padresTipKd,iletisimDrm=@piletisimDrm, adresBilgisi = @padresBilgisi, eadresTipKd = @peadresTipkd,eadresBilgisi = @peadresBilgisi, telefonTipKd = @ptelefonTipKd,hatTipiKd = @phatTipiKd,alanKod = @palanKod,telNo = @ptelNo where musteriNo = @pmusteriNo",Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);


            commandUpdate.Parameters.AddWithValue("@padresTipKd", im.adresTipKd);
            commandUpdate.Parameters.AddWithValue("@piletisimDrm", im.iletisimDrm);
            commandUpdate.Parameters.AddWithValue("@padresBilgisi", im.adresBilgisi);
            commandUpdate.Parameters.AddWithValue("@peadresTipKd", im.eadresTipKd);
            commandUpdate.Parameters.AddWithValue("@peadresBilgisi", im.eadresBilgisi);
            commandUpdate.Parameters.AddWithValue("@ptelefonTipKd", im.telefonTipKd);
            commandUpdate.Parameters.AddWithValue("@phatTipiKd", im.hatTipiKd);
            commandUpdate.Parameters.AddWithValue("@palanKod", im.alanKod);
            commandUpdate.Parameters.AddWithValue("@ptelNo", im.telNo);
            commandUpdate.Parameters.AddWithValue("@pmusteriNo", im.musteriNo);

            commandUpdate.ExecuteNonQuery();
        }

        public static DataTable BMusteriListele() {

            SqlCommand commandListele = new SqlCommand(@"
                SELECT 
                    bm.musteriNo AS [MUSTERINO], 
                    bm.GercekTuzelDrm AS [GERCEKTUZELDURUM], 
                    bm.kayitDrm AS [KAYITDURUM],
                    bm.tcKimlikNo AS [TCKIMLIKNO],
                    bm.KKTCKimlikNo AS [KKTCKIMLIKNO],
                    bm.dogumTarihi AS [DOGUMTARIHI], 
                    bm.Ad AS [AD], 
                    bm.Soyad AS [SOYAD],
                    bm.babaAdi AS [BABAADI], 
                    bm.anneAdi AS [ANNEADI],
                    bm.sahisFirmaDrm AS [SAHISFIRMADURUM],
                    im.iletisimDrm AS [ILETISIMDURUM],
                    im.adresTipKd AS [ADRESTIPI],
                    im.adresBilgisi AS [ADRES],
                    im.eadresTipKd AS [E-ADRESTIPI],
                    im.eadresBilgisi AS [E-ADRES],
                    im.telefonTipKd AS [TELEFONTIPI],
                    im.hatTipiKd AS [HATTIPI],
                    im.alanKod AS [ALANKODU], 
                    im.telNo AS [TELNO]
                FROM 
                    tblBireyselMusteri bm 
                INNER JOIN 
                    tblIrtibatMusteri im ON bm.musteriNo = im.musteriNo"
             , Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);
            SqlDataAdapter da = new SqlDataAdapter(commandListele);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
       
        }

        public static CommonEntityTumMusteriler TumBireyselMusteriGetir()
        {
            CommonEntityTumMusteriler commonDto = new CommonEntityTumMusteriler();
            commonDto.bireyselMusteri = new List<EntityBireyselMusteri>();
            commonDto.irtibatMusteri = new List<EntityIrtibatMusteri>();
            
             List <EntityBireyselMusteri> entityBireysel = Converter.ToEntityBireyselMusteriList(BMusteriListele());

             List<EntityIrtibatMusteri> entityIrtibat = Converter.ToEntityIrtibatMusteriList(BMusteriListele());

            commonDto.bireyselMusteri = entityBireysel;
            commonDto.irtibatMusteri = entityIrtibat;
            
            return commonDto;
        }

        public static CommonEntityTumMusteriler BireyselMusteriGetir(int musteriNo)
        {
            
            if (musteriNo > 0)
            {
                CommonEntityTumMusteriler commonDto = new CommonEntityTumMusteriler();
                commonDto.bireyselMusteri = new List<EntityBireyselMusteri>();
                commonDto.irtibatMusteri = new List<EntityIrtibatMusteri>();

                List<EntityBireyselMusteri> entityBireysel = Converter.ToEntityBireyselMusteriList(BMusteriMusteriNoIleBilgileriGetir(musteriNo));
                List<EntityIrtibatMusteri> entityIrtibat = Converter.ToEntityIrtibatMusteriList(BMusteriMusteriNoIleBilgileriGetir(musteriNo));

                commonDto.bireyselMusteri = entityBireysel;
                commonDto.irtibatMusteri = entityIrtibat;

                return commonDto;
            }
            
            else
            {
                return new CommonEntityTumMusteriler();
            }
            
        }

        public static CommonEntityTumMusteriler KNOBireyselMusteriGetir(string kimlikNo) {
            if (!String.IsNullOrEmpty(kimlikNo) && kimlikNo.Length == 11)
            {
                CommonEntityTumMusteriler commonDto = new CommonEntityTumMusteriler();
                commonDto.bireyselMusteri = new List<EntityBireyselMusteri>();
                commonDto.irtibatMusteri = new List<EntityIrtibatMusteri>();
                List<EntityBireyselMusteri> entityBireysel = Converter.ToEntityBireyselMusteriList(BMusteriKimlikNoIleBilgileriGetir(kimlikNo));
                List<EntityIrtibatMusteri> entityIrtibat = Converter.ToEntityIrtibatMusteriList(BMusteriKimlikNoIleBilgileriGetir(kimlikNo));

                commonDto.bireyselMusteri = entityBireysel;
                commonDto.irtibatMusteri = entityIrtibat;

                return commonDto;
            }
            else if (!String.IsNullOrEmpty(kimlikNo) && kimlikNo.Length == 10)
            {
                CommonEntityTumMusteriler commonDto = new CommonEntityTumMusteriler();
                commonDto.bireyselMusteri = new List<EntityBireyselMusteri>();
                commonDto.irtibatMusteri = new List<EntityIrtibatMusteri>();
                List<EntityBireyselMusteri> entityBireysel = Converter.ToEntityBireyselMusteriList(BMusteriKKTCKimlikNoIleBilgileriGetir(kimlikNo));
                List<EntityIrtibatMusteri> entityIrtibat = Converter.ToEntityIrtibatMusteriList(BMusteriKimlikNoIleBilgileriGetir(kimlikNo));

                commonDto.bireyselMusteri = entityBireysel;
                commonDto.irtibatMusteri = entityIrtibat;

                return commonDto;
            }
            else
            {
                return new CommonEntityTumMusteriler();
            }

        }

        public static int BMusteriNoGetir(string tcKimlikNo) {
            int musteriNo=-1;
            
            string query = "Select musteriNo from tblBireyselMusteri where tcKimlikNo = @ptcKimlikNo";
            SqlCommand musteriNoGetir = new SqlCommand(query, Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);

            musteriNoGetir.Parameters.AddWithValue("@ptcKimlikNo",tcKimlikNo);

            SqlDataAdapter da = new SqlDataAdapter(musteriNoGetir);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                musteriNo = Convert.ToInt32(dt.Rows[0]["musteriNo"]);
            }

            return musteriNo;
        }

      
        // Kimlik Numarası ile Bireysel Müşteri Var mı Kontrolü 
        public static int BMusteriKNOVarmiKontrol(EntityBireyselMusteri bm) {
            int kontrol=0;

            string query = "Select count(*) from tblBireyselMusteri where tcKimlikNo = @ptckimlikNo";
            SqlCommand musteriNoKontrol = new SqlCommand(query, Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);
            musteriNoKontrol.Parameters.AddWithValue("@ptckimlikNo",bm.tcKimlikNo);

            kontrol = (int)musteriNoKontrol.ExecuteScalar();  // Müşteri varsa 1 yoksa 0 yollar.
            return kontrol;
        }

        //KKTC Kimlik Numarası ile Bireysel Müşteri Var mı Kontrolü
        public static int BMusteriKKTCKNOVarmiKontrol(EntityBireyselMusteri bm)
        {
            int kontrol = 0;

            string query = "Select count(*) from tblBireyselMusteri where KKTCKimlikNo = @pKKTCKimlikNo";
            SqlCommand musteriNoKontrol = new SqlCommand(query, Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);
            musteriNoKontrol.Parameters.AddWithValue("@pKKTCKimlikNo", bm.KKTCKimlikNo);

            kontrol = (int)musteriNoKontrol.ExecuteScalar();  // Müşteri varsa 1 yoksa 0 yollar.
            return kontrol;
        }

        //Müşteri Numarası ile Bireysel Müşteri Var mı Kontrolü
        public static int BMusteriMNOVarmiKontrol(EntityBireyselMusteri bm)
        {
            int kontrol = 0;

            string query = "Select count(*) from tblBireyselMusteri where musteriNo = @pmusteriNo";
            SqlCommand musteriNoKontrol = new SqlCommand(query, Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);
            musteriNoKontrol.Parameters.AddWithValue("@pmusteriNo", bm.musteriNo);

            kontrol = (int)musteriNoKontrol.ExecuteScalar();  // Müşteri varsa 1 yoksa 0 yollar.
            return kontrol;
        }

       

        // Kimlik Numarasına göre müşteri bilgileri getirme.
        public static DataTable BMusteriKimlikNoIleBilgileriGetir(string tcKimlikNo) {

            string query = @"
                SELECT 
                    bm.musteriNo AS [MUSTERINO], 
                    bm.GercekTuzelDrm AS [GERCEKTUZELDURUM], 
                    bm.kayitDrm AS [KAYITDURUM],
                    bm.tcKimlikNo AS [TCKIMLIKNO],
                    bm.KKTCKimlikNo AS [KKTCKIMLIKNO],
                    bm.dogumTarihi AS [DOGUMTARIHI], 
                    bm.Ad AS [AD], 
                    bm.Soyad AS [SOYAD],
                    bm.babaAdi AS [BABAADI], 
                    bm.anneAdi AS [ANNEADI],
                    bm.sahisFirmaDrm AS [SAHISFIRMADURUM],
                    im.iletisimDrm AS [ILETISIMDURUM],
                    im.adresTipKd AS [ADRESTIPI],
                    im.adresBilgisi AS [ADRES],
                    im.eadresTipKd AS [E-ADRESTIPI],
                    im.eadresBilgisi AS [E-ADRES],
                    im.telefonTipKd AS [TELEFONTIPI],
                    im.hatTipiKd AS [HATTIPI],
                    im.alanKod AS [ALANKODU], 
                    im.telNo AS [TELNO],
                    im.irtibatID AS [IRTIBATID]
                FROM 
                    tblBireyselMusteri bm 
                INNER JOIN 
                    tblIrtibatMusteri im ON bm.musteriNo = im.musteriNo where bm.tcKimlikNo = @ptckimlikNo and bm.kayitDrm=1";
            SqlCommand musteriBilgisiGetir = new SqlCommand(query, Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);

            musteriBilgisiGetir.Parameters.AddWithValue("@ptcKimlikNo", tcKimlikNo);

            SqlDataAdapter da = new SqlDataAdapter(musteriBilgisiGetir);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        
        }
        public static DataTable BMusteriKKTCKimlikNoIleBilgileriGetir(string KKTCKimlikNo)
        {

            string query = @"
                SELECT 
                    bm.musteriNo AS [MUSTERINO], 
                    bm.GercekTuzelDrm AS [GERCEKTUZELDURUM], 
                    bm.kayitDrm AS [KAYITDURUM],
                    bm.tcKimlikNo AS [TCKIMLIKNO],
                    bm.KKTCKimlikNo AS [KKTCKIMLIKNO],
                    bm.dogumTarihi AS [DOGUMTARIHI], 
                    bm.Ad AS [AD], 
                    bm.Soyad AS [SOYAD],
                    bm.babaAdi AS [BABAADI], 
                    bm.anneAdi AS [ANNEADI],
                    bm.sahisFirmaDrm AS [SAHISFIRMADURUM],
                    im.iletisimDrm AS [ILETISIMDURUM],
                    im.adresTipKd AS [ADRESTIPI],           
                    im.adresBilgisi AS [ADRES],
                    im.eadresTipKd AS [E-ADRESTIPI],
                    im.eadresBilgisi AS [E-ADRES],
                    im.telefonTipKd AS [TELEFONTIPI],
                    im.hatTipiKd AS [HATTIPI],
                    im.alanKod AS [ALANKODU], 
                    im.telNo AS [TELNO],
                    im.irtibatID AS [IRTIBATID]
                FROM 
                    tblBireyselMusteri bm 
                INNER JOIN 
                    tblIrtibatMusteri im ON bm.musteriNo = im.musteriNo where bm.KKTCKimlikNo = @pKKTCKimlikNo and bm.kayitDrm=1";
            SqlCommand musteriBilgisiGetir = new SqlCommand(query, Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);

            musteriBilgisiGetir.Parameters.AddWithValue("@pKKTCKimlikNo", KKTCKimlikNo);
            SqlDataAdapter da = new SqlDataAdapter(musteriBilgisiGetir);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        // Müşteri Numarasına göre müşteri bilgileri getirme.
        public static DataTable BMusteriMusteriNoIleBilgileriGetir(int musteriNo)
        {

            string query = @"
                SELECT 
                    bm.musteriNo AS [MUSTERINO], 
                    bm.GercekTuzelDrm AS [GERCEKTUZELDURUM], 
                    bm.kayitDrm AS [KAYITDURUM],
                    bm.tcKimlikNo AS [TCKIMLIKNO],
                    bm.KKTCKimlikNo AS [KKTCKIMLIKNO],
                    bm.dogumTarihi AS [DOGUMTARIHI], 
                    bm.Ad AS [AD], 
                    bm.Soyad AS [SOYAD],
                    bm.babaAdi AS [BABAADI], 
                    bm.anneAdi AS [ANNEADI],
                    bm.sahisFirmaDrm AS [SAHISFIRMADURUM],
                    im.iletisimDrm AS [ILETISIMDURUM],
                    im.adresTipKd AS [ADRESTIPI],           
                    im.adresBilgisi AS [ADRES],
                    im.eadresTipKd AS [E-ADRESTIPI],
                    im.eadresBilgisi AS [E-ADRES],
                    im.telefonTipKd AS [TELEFONTIPI],
                    im.hatTipiKd AS [HATTIPI],
                    im.alanKod AS [ALANKODU], 
                    im.telNo AS [TELNO],
                    im.irtibatID AS [IRTIBATID]
                FROM 
                    tblBireyselMusteri bm 
                INNER JOIN 
                    tblIrtibatMusteri im ON bm.musteriNo = im.musteriNo where bm.musteriNo = @pmusteriNo and bm.kayitDrm=1";
            SqlCommand musteriBilgisiGetir = new SqlCommand(query, Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);

            musteriBilgisiGetir.Parameters.AddWithValue("@pmusteriNo",musteriNo);

            SqlDataAdapter da = new SqlDataAdapter(musteriBilgisiGetir);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public static void BMusteriPasifeCek(int musteriNo) {
            string query = "Update tblBireyselMusteri set kayitDrm=@pkayitDrm where musteriNo=@pmusteriNo";
            string query2 = "Update tblIrtibatMusteri set kayitDrm=@pKayitDrm where musteriNo=@pmusteriNo";
            SqlCommand musteriSil = new SqlCommand(query,Baglanti.connection);
            SqlCommand musteriSil2 = new SqlCommand(query2, Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);
            musteriSil.Parameters.AddWithValue("@pkayitDrm",0);
            musteriSil.Parameters.AddWithValue("@pmusteriNo",musteriNo);
            musteriSil2.Parameters.AddWithValue("@pkayitDrm", 0);
            musteriSil2.Parameters.AddWithValue("@pmusteriNo", musteriNo);

            musteriSil.ExecuteNonQuery();
            musteriSil2.ExecuteNonQuery();
        }


    }
}
