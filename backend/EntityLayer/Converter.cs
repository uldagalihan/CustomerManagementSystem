using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EntityLayer
{
    public static class Converter
    {

        #region EntityBireyselMusteri
        public static List<EntityBireyselMusteri> ToEntityBireyselMusteriList(DataTable dt)
        {
            List<EntityBireyselMusteri> dtoList = new List<EntityBireyselMusteri>(100);
            foreach (DataRow dr in dt.Rows)
            {
                dtoList.Add(ToEntityBireyselMusteri(dr));


            }
            return dtoList;

        }
        public static EntityBireyselMusteri ToEntityBireyselMusteri(DataRow dataRow)
        {

            EntityBireyselMusteri dto = new EntityBireyselMusteri();
            if (dataRow.Table.Columns.Contains("MUSTERINO"))
                dto.musteriNo = EntityLayer.TypeConverter.Convert<int>((dataRow["MUSTERINO"]));

            if (dataRow.Table.Columns.Contains("GERCEKTUZELDURUM"))
                dto.gercekTuzelDrm = EntityLayer.TypeConverter.Convert<string>((dataRow["GERCEKTUZELDURUM"]));

            if (dataRow.Table.Columns.Contains("KAYITDURUM"))
                dto.kayitDrm = EntityLayer.TypeConverter.Convert<int>((dataRow["KAYITDURUM"]));

            if (dataRow.Table.Columns.Contains("TCKIMLIKNO"))
                dto.tcKimlikNo = EntityLayer.TypeConverter.Convert<string>((dataRow["TCKIMLIKNO"]));

            if (dataRow.Table.Columns.Contains("KKTCKIMLIKNO"))
                dto.KKTCKimlikNo = EntityLayer.TypeConverter.Convert<string>((dataRow["KKTCKIMLIKNO"]));

            if (dataRow.Table.Columns.Contains("DOGUMTARIHI"))
                dto.dogumTarihi = EntityLayer.TypeConverter.Convert<DateTime>((dataRow["DOGUMTARIHI"]));

            if (dataRow.Table.Columns.Contains("AD"))
                dto.musteriAd = EntityLayer.TypeConverter.Convert<string>((dataRow["AD"]));

            if (dataRow.Table.Columns.Contains("SOYAD"))
                dto.musteriSoyad = EntityLayer.TypeConverter.Convert<string>((dataRow["SOYAD"]));

            if (dataRow.Table.Columns.Contains("BABAADI"))
                dto.musteriBabaAdi = EntityLayer.TypeConverter.Convert<string>((dataRow["BABAADI"]));

            if (dataRow.Table.Columns.Contains("ANNEADI"))
                dto.musteriAnneAdi = EntityLayer.TypeConverter.Convert<string>((dataRow["ANNEADI"]));

            if (dataRow.Table.Columns.Contains("SAHISFIRMADURUM"))
                dto.sahisFirmaDrm = EntityLayer.TypeConverter.Convert<int>((dataRow["SAHISFIRMADURUM"]));

            return dto;

        }
        #endregion

        #region EntityKurumsalMusteri
        public static List<EntityIrtibatMusteri> ToEntityIrtibatMusteriList(DataTable dt)
        {
            List<EntityIrtibatMusteri> dtoList = new List<EntityIrtibatMusteri>(100);
            foreach (DataRow dr in dt.Rows)
            {
                dtoList.Add(ToEntityIrtibatMusteri(dr));


            }
            return dtoList;

        }
        public static EntityIrtibatMusteri ToEntityIrtibatMusteri(DataRow dataRow)
        {

            EntityIrtibatMusteri dto = new EntityIrtibatMusteri();
            if (dataRow.Table.Columns.Contains("IRTIBATID"))
                dto.irtibatID = EntityLayer.TypeConverter.Convert<int>((dataRow["IRTIBATID"]));

            if (dataRow.Table.Columns.Contains("MUSTERINO"))
                dto.musteriNo = EntityLayer.TypeConverter.Convert<int>((dataRow["MUSTERINO"]));

            if (dataRow.Table.Columns.Contains("KAYITDURUM"))
                dto.kayitDrm = EntityLayer.TypeConverter.Convert<int>((dataRow["KAYITDURUM"]));

            if (dataRow.Table.Columns.Contains("ILETISIMDURUM"))
                dto.iletisimDrm = EntityLayer.TypeConverter.Convert<int>((dataRow["ILETISIMDURUM"]));

            if (dataRow.Table.Columns.Contains("ADRESTIPI"))
                dto.adresTipKd = EntityLayer.TypeConverter.Convert<int>((dataRow["ADRESTIPI"]));

            if (dataRow.Table.Columns.Contains("ADRES"))
                dto.adresBilgisi = EntityLayer.TypeConverter.Convert<string>((dataRow["ADRES"]));

            if (dataRow.Table.Columns.Contains("E-ADRESTIPI"))
                dto.eadresTipKd = EntityLayer.TypeConverter.Convert<int>((dataRow["E-ADRESTIPI"]));

            if (dataRow.Table.Columns.Contains("E-ADRES"))
                dto.eadresBilgisi = EntityLayer.TypeConverter.Convert<string>((dataRow["E-ADRES"]));

            if (dataRow.Table.Columns.Contains("TELEFONTIPI"))
                dto.telefonTipKd = EntityLayer.TypeConverter.Convert<int>((dataRow["TELEFONTIPI"]));

            if (dataRow.Table.Columns.Contains("HATTIPI"))
                dto.hatTipiKd = EntityLayer.TypeConverter.Convert<int>((dataRow["HATTIPI"]));

            if (dataRow.Table.Columns.Contains("ALANKODU"))
                dto.alanKod = EntityLayer.TypeConverter.Convert<string>((dataRow["ALANKODU"]));

            if (dataRow.Table.Columns.Contains("TELNO"))
                dto.telNo = EntityLayer.TypeConverter.Convert<string>((dataRow["TELNO"]));

            return dto;
        }
        #endregion

        #region EntityIrtibatMusteri
        public static List<EntityKurumsalMusteri> ToEntityKurumsalMusteriList(DataTable dt) {
            List<EntityKurumsalMusteri> dtoList = new List<EntityKurumsalMusteri>(100);
            foreach (DataRow dr in dt.Rows) {
                dtoList.Add(ToEntityKurumsalMusteri(dr));
            
                
            }
            return dtoList;
        
        }
        public static EntityKurumsalMusteri ToEntityKurumsalMusteri(DataRow dataRow) {

            EntityKurumsalMusteri dto = new EntityKurumsalMusteri();
            if (dataRow.Table.Columns.Contains("MUSTERINO"))
                dto.musteriNo = EntityLayer.TypeConverter.Convert<int>((dataRow["MUSTERINO"]));

            if (dataRow.Table.Columns.Contains("GERCEKTUZELDURUM"))
                dto.gercekTuzelDrm = EntityLayer.TypeConverter.Convert<string>((dataRow["GERCEKTUZELDURUM"]));

            if (dataRow.Table.Columns.Contains("VERGIKIMLIKNO"))
                dto.vergiKimlikNo = EntityLayer.TypeConverter.Convert<string>((dataRow["VERGIKIMLIKNO"]));

            if (dataRow.Table.Columns.Contains("FIRMAKURULUSTARIHI"))
                dto.firmaKurulusTarihi = EntityLayer.TypeConverter.Convert<DateTime>((dataRow["FIRMAKURULUSTARIHI"]));

            if (dataRow.Table.Columns.Contains("MUSTERITURU"))
                dto.musteriTuruKod = EntityLayer.TypeConverter.Convert<int>((dataRow["MUSTERITURU"]));

            if (dataRow.Table.Columns.Contains("CALISANSAYISI"))
                dto.calisanSayisi = EntityLayer.TypeConverter.Convert<int>((dataRow["CALISANSAYISI"]));

            if (dataRow.Table.Columns.Contains("NOMINALSERMAYE"))
                dto.nominalSermaye = EntityLayer.TypeConverter.Convert<int>((dataRow["NOMINALSERMAYE"]));

            if (dataRow.Table.Columns.Contains("KAYITDURUM"))
                dto.kayitDrm = EntityLayer.TypeConverter.Convert<int>((dataRow["KAYITDURUM"]));

            if (dataRow.Table.Columns.Contains("UNVAN"))
                dto.unvan = EntityLayer.TypeConverter.Convert<string>((dataRow["UNVAN"]));

            if (dataRow.Table.Columns.Contains("KISAUNVAN"))
                dto.kisaUnvan = EntityLayer.TypeConverter.Convert<string>((dataRow["KISAUNVAN"]));

            return dto;
        }

        #endregion
    }
}
