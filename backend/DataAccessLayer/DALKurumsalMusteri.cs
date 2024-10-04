using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALKurumsalMusteri
    {
        public static void KMusteriOzlukEkle(EntityKurumsalMusteri km)
        {

            SqlCommand commandEkle = new SqlCommand("Insert into tblKurumsalMusteri (vergiKimlikNo,firmaKurulusTarihi,musteriTuruKod,calisanSayisi,nominalSermaye,unvan,kisaUnvan) values (@pvergiKimlikNo,@pfirmaKurulusTarihi,@pmusteriTuruKod,@pcalisanSayisi,@pnominalSermaye,@punvan,@pkisaUnvan) ", Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);

            commandEkle.Parameters.AddWithValue("@pvergiKimlikNo", km.vergiKimlikNo);
            commandEkle.Parameters.AddWithValue("@pfirmaKurulusTarihi", km.firmaKurulusTarihi);
            commandEkle.Parameters.AddWithValue("@pmusteriTuruKod", km.musteriTuruKod);
            commandEkle.Parameters.AddWithValue("@pcalisanSayisi", km.calisanSayisi);
            commandEkle.Parameters.AddWithValue("@pnominalSermaye", km.nominalSermaye);
            commandEkle.Parameters.AddWithValue("@punvan", km.unvan);

            if (km.unvan.Length > 50)
            {
                commandEkle.Parameters.AddWithValue("@pkisaUnvan", km.unvan.Substring(0,50));
            }
            else
            {
                commandEkle.Parameters.AddWithValue("@pkisaUnvan", km.unvan);
            }
           

            commandEkle.ExecuteNonQuery();


        }

        public static void KMusteriOzlukGuncelle(EntityKurumsalMusteri km)
        {

            SqlCommand commandGuncelle = new SqlCommand("Update tblKurumsalMusteri set vergiKimlikNo = @pvergiKimlikNo, firmaKurulusTarihi=@pfirmaKurulusTarihi,musteriTuruKod=@pmusteriTuruKod,calisanSayisi=@pcalisanSayisi,nominalSermaye=@pnominalSermaye,unvan=@punvan,kisaUnvan=@pkisaUnvan  where musteriNo = @pmusteriNo", Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);

            commandGuncelle.Parameters.AddWithValue("@pvergiKimlikNo", km.vergiKimlikNo);
            commandGuncelle.Parameters.AddWithValue("@pfirmaKurulusTarihi", km.firmaKurulusTarihi);
            commandGuncelle.Parameters.AddWithValue("@pmusteriTuruKod", km.musteriTuruKod);
            commandGuncelle.Parameters.AddWithValue("@pcalisanSayisi", km.calisanSayisi);
            commandGuncelle.Parameters.AddWithValue("@pnominalSermaye", km.nominalSermaye);
            commandGuncelle.Parameters.AddWithValue("@punvan", km.unvan);
            if (km.unvan.Length > 50)
            {
                commandGuncelle.Parameters.AddWithValue("@pkisaUnvan", km.unvan.Substring(0, 50));
            }
            else
            {
                commandGuncelle.Parameters.AddWithValue("@pkisaUnvan", km.unvan);
            }
            commandGuncelle.Parameters.AddWithValue("@pmusteriNo", km.musteriNo);

            commandGuncelle.ExecuteNonQuery();

        }

        public static void KMusteriIletisimEkle(EntityIrtibatMusteri im)
        {

            SqlCommand commandAdd = new SqlCommand("Insert into tblIrtibatMusteri (iletisimDrm,kayitDrm,adresTipKd,adresBilgisi,eadresTipKd,eadresBilgisi,telefonTipKd,hatTipiKd,alanKod,telNo) values(@piletisimDrm,@pkayitDrm,@padresTipKd,@padresBilgisi,@peadresTipKd,@peadresBilgisi,@ptelefonTipKd,@phatTipiKd,@palanKod,@ptelNo)", Baglanti.connection);
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


        public static void KMusteriIletisimGuncelle(EntityIrtibatMusteri im)
        {

            SqlCommand commandUpdate = new SqlCommand("Update tblIrtibatMusteri set adresTipKd = @padresTipKd,iletisimDrm=@piletisimDrm, adresBilgisi = @padresBilgisi, eadresTipKd = @peadresTipkd,eadresBilgisi = @peadresBilgisi, telefonTipKd = @ptelefonTipKd,hatTipiKd = @phatTipiKd,alanKod = @palanKod,telNo = @ptelNo where musteriNo = @pmusteriNo", Baglanti.connection);
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

        public static DataTable KMusteriListele()
        {

            SqlCommand commandListele = new SqlCommand(@"
                SELECT 
                    km.musteriNo AS [MUSTERINO], 
                    km.GercekTuzelDrm AS [GERCEKTUZELDURUM], 
                    km.vergiKimlikNo AS [VERGIKIMLIKNO],
                    km.firmaKurulusTarihi AS [FIRMAKURULUSTARIHI], 
                    km.musteriTuruKod AS [MUSTERITURU],
                    km.calisanSayisi AS [CALISANSAYISI], 
                    km.nominalSermaye AS [NOMINALSERMAYE], 
                    km.kayitDrm AS [KAYITDURUM],
                    km.unvan AS [UNVAN], 
                    km.kisaUnvan AS [KISAUNVAN],
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
                    tblKurumsalMusteri km 
                INNER JOIN 
                    tblIrtibatMusteri im ON km.musteriNo = im.musteriNo
            ", Baglanti.connection);

            Baglanti.BaglantiAc(Baglanti.connection);
            SqlDataAdapter da = new SqlDataAdapter(commandListele);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public static CommonEntityTumMusteriler TumKurumsalMusteriGetir()
        {
            CommonEntityTumMusteriler commonDto = new CommonEntityTumMusteriler();

            commonDto.kurumsalMusteri = new List<EntityKurumsalMusteri>();
            commonDto.irtibatMusteri = new List<EntityIrtibatMusteri>();

            List<EntityKurumsalMusteri> entityKurumsal = Converter.ToEntityKurumsalMusteriList(KMusteriListele());

            List<EntityIrtibatMusteri> entityIrtibat = Converter.ToEntityIrtibatMusteriList(KMusteriListele());

            commonDto.kurumsalMusteri = entityKurumsal;
            commonDto.irtibatMusteri = entityIrtibat;

            return commonDto;
        }

        public static CommonEntityTumMusteriler KurumsalMusteriGetir(int musteriNo)
        {
            if (musteriNo > 0)
            {
                CommonEntityTumMusteriler commonDto = new CommonEntityTumMusteriler();
                commonDto.kurumsalMusteri = new List<EntityKurumsalMusteri>();
                commonDto.irtibatMusteri = new List<EntityIrtibatMusteri>();

                List<EntityKurumsalMusteri> entityKurumsal = Converter.ToEntityKurumsalMusteriList(KMusteriMusteriNoIleBilgileriGetir(musteriNo));
                List<EntityIrtibatMusteri> entityIrtibat = Converter.ToEntityIrtibatMusteriList(KMusteriMusteriNoIleBilgileriGetir(musteriNo));

                commonDto.kurumsalMusteri = entityKurumsal;
                commonDto.irtibatMusteri = entityIrtibat;

                return commonDto;
            }
       
            else
            {
                return new CommonEntityTumMusteriler();
            }

        }
        public static CommonEntityTumMusteriler KNOKurumsalMusteriGetir(string kimlikNo) {


            if (!String.IsNullOrEmpty(kimlikNo))
            {
                CommonEntityTumMusteriler commonDto = new CommonEntityTumMusteriler();
                List<EntityKurumsalMusteri> entityKurumsal = Converter.ToEntityKurumsalMusteriList(KMusteriKimlikNoIleBilgileriGetir(kimlikNo));
                List<EntityIrtibatMusteri> entityIrtibat = Converter.ToEntityIrtibatMusteriList(KMusteriKimlikNoIleBilgileriGetir(kimlikNo));

                commonDto.kurumsalMusteri = entityKurumsal;
                commonDto.irtibatMusteri = entityIrtibat;

                return commonDto;
            }

            else
            {
                return new CommonEntityTumMusteriler();
            }
        }


        public static int KMusteriNoGetir(string vergiKimlikNo)
        {
            int musteriNo = -1;

            string query = "Select musteriNo from tblKurumsalMusteri where vergiKimlikNo = @pvergiKimlikNo";
            SqlCommand musteriNoGetir = new SqlCommand(query, Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);

            musteriNoGetir.Parameters.AddWithValue("@pvergiKimlikNo", vergiKimlikNo);

            SqlDataAdapter da = new SqlDataAdapter(musteriNoGetir);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                musteriNo = Convert.ToInt32(dt.Rows[0]["musteriNo"]);
            }

            return musteriNo;
        }


        // Vergi Kimlik Numarası ile Kurumsal Müşteri Var mı Kontrolü 
        public static int KMusteriKNOVarmiKontrol(EntityKurumsalMusteri km)
        {
            int kontrol = 0;

            string query = "Select count(*) from tblKurumsalMusteri where vergiKimlikNo = @pvergiKimlikNo";
            SqlCommand musteriNoKontrol = new SqlCommand(query, Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);
            musteriNoKontrol.Parameters.AddWithValue("@pvergiKimlikNo", km.vergiKimlikNo);

            kontrol = (int)musteriNoKontrol.ExecuteScalar();  // Müşteri varsa 1 yoksa 0 yollar.
            return kontrol;
        }
        // Vergi Kimlik Numarası ile Kurumsal Müşteri Var mı Kontrolü 
        public static int KMusteriMNOVarmiKontrol(EntityKurumsalMusteri km)
        {
            int kontrol = 0;

            string query = "Select count(*) from tblKurumsalMusteri where musteriNo = @pmusteriNo";
            SqlCommand musteriNoKontrol = new SqlCommand(query, Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);
            musteriNoKontrol.Parameters.AddWithValue("@pmusteriNo", km.musteriNo);

            kontrol = (int)musteriNoKontrol.ExecuteScalar();  // Müşteri varsa 1 yoksa 0 yollar.
            return kontrol;
        }

        // Kimlik Numarasına göre müşteri bilgileri getirme.
        public static DataTable KMusteriKimlikNoIleBilgileriGetir(string vergiKimlikNo)
        {

            string query = @"
                SELECT 
                    km.musteriNo AS [MUSTERINO], 
                    km.GercekTuzelDrm AS [GERCEKTUZELDURUM], 
                    km.vergiKimlikNo AS [VERGIKIMLIKNO],
                    km.firmaKurulusTarihi AS [FIRMAKURULUSTARIHI], 
                    km.musteriTuruKod AS [MUSTERITURU],
                    km.calisanSayisi AS [CALISANSAYISI], 
                    km.nominalSermaye AS [NOMINALSERMAYE], 
                    km.kayitDrm AS [KAYITDURUM],
                    km.unvan AS [UNVAN], 
                    km.kisaUnvan AS [KISAUNVAN],
                    km.musteriTuruKod as [MUSTERITURU],
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
                    tblKurumsalMusteri km 
                INNER JOIN 
                    tblIrtibatMusteri im ON km.musteriNo = im.musteriNo where km.vergiKimlikNo = @pvergikimlikNo and km.kayitDrm=1";
            SqlCommand musteriBilgisiGetir = new SqlCommand(query, Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);

            musteriBilgisiGetir.Parameters.AddWithValue("@pvergiKimlikNo", vergiKimlikNo);
            

            SqlDataAdapter da = new SqlDataAdapter(musteriBilgisiGetir);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        // Müşteri Numarasına göre müşteri bilgileri getirme.
        public static DataTable KMusteriMusteriNoIleBilgileriGetir(int musteriNo)
        {

            string query = @"
                SELECT 
                    km.musteriNo AS [MUSTERINO], 
                    km.GercekTuzelDrm AS [GERCEKTUZELDURUM], 
                    km.vergiKimlikNo AS [VERGIKIMLIKNO],
                    km.firmaKurulusTarihi AS [FIRMAKURULUSTARIHI], 
                    km.musteriTuruKod AS [MUSTERITURU],
                    km.calisanSayisi AS [CALISANSAYISI], 
                    km.nominalSermaye AS [NOMINALSERMAYE], 
                    km.kayitDrm AS [KAYITDURUM],
                    km.unvan AS [UNVAN], 
                    km.kisaUnvan AS [KISAUNVAN],
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
                    tblKurumsalMusteri km 
                INNER JOIN 
                    tblIrtibatMusteri im ON km.musteriNo = im.musteriNo where km.musteriNo = @pmusteriNo and km.kayitDrm=1";
            SqlCommand musteriBilgisiGetir = new SqlCommand(query, Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);

            musteriBilgisiGetir.Parameters.AddWithValue("@pmusteriNo", musteriNo);

            SqlDataAdapter da = new SqlDataAdapter(musteriBilgisiGetir);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public static void KMusteriPasifeCek(int musteriNo)
        {
            string query = "Update tblKurumsalMusteri set kayitDrm=@pkayitDrm where musteriNo=@pmusteriNo";
            string query2 = "Update tblIrtibatMusteri set kayitDrm=@pKayitDrm where musteriNo=@pmusteriNo";
            SqlCommand musteriSil = new SqlCommand(query, Baglanti.connection);
            SqlCommand musteriSil2 = new SqlCommand(query2, Baglanti.connection);
            Baglanti.BaglantiAc(Baglanti.connection);
            musteriSil.Parameters.AddWithValue("@pkayitDrm", 0);
            musteriSil.Parameters.AddWithValue("@pmusteriNo", musteriNo);
            musteriSil2.Parameters.AddWithValue("@pkayitDrm", 0);
            musteriSil2.Parameters.AddWithValue("@pmusteriNo", musteriNo);

            musteriSil.ExecuteNonQuery();
            musteriSil2.ExecuteNonQuery();
        }

        

    }
}


