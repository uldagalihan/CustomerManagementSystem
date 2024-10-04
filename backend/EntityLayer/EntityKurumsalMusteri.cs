using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityKurumsalMusteri
    {
        private int m_musteriNo;
        private string m_vergiKimlikNo;
        private DateTime m_firmaKurulusTarihi;
        private int m_musteriTuruKod;
        private int m_calisanSayisi;
        private int m_nominalSermaye;
        private int m_kayitDrm;
        private string m_unvan;
        private string m_kisaUnvan;
        private string m_gercekTuzelDrm;

        public int musteriNo { get { return m_musteriNo; } set { m_musteriNo = value; } }
        public string vergiKimlikNo { get { return m_vergiKimlikNo; } set { m_vergiKimlikNo = value; } }
        public DateTime firmaKurulusTarihi { get { return m_firmaKurulusTarihi; } set { m_firmaKurulusTarihi = value; } }
        public int musteriTuruKod { get { return m_musteriTuruKod; } set { m_musteriTuruKod = value; } }
        public int calisanSayisi { get { return m_calisanSayisi; } set { m_calisanSayisi = value; } }
        public int nominalSermaye { get { return m_nominalSermaye; } set { m_nominalSermaye = value; } }
        public int kayitDrm { get { return m_kayitDrm; } set { m_kayitDrm = value; } }

        public string unvan { get{ return m_unvan; }set{ m_unvan = value; } }
        public string kisaUnvan { get { return m_kisaUnvan; } set { m_kisaUnvan = value; } }
        public string gercekTuzelDrm { get { return m_gercekTuzelDrm; } set { m_gercekTuzelDrm = value; } }


    }
}
