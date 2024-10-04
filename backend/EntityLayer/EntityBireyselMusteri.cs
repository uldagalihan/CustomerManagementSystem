using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityBireyselMusteri
    {
        private int m_musteriNo;
        private string m_tcKimlikNo;
        private DateTime m_dogumTarihi;
        private string m_musteriAd;
        private string m_musteriSoyad;
        private string m_musteriBabaAdi;
        private string m_musteriAnneAdi;
        private int m_kayitDrm;
        private int? m_sahisFirmaDrm;
        private string m_KKTCKimlikNo;
        private string m_gercekTuzelDrm;
        public int musteriNo
        {
            get { return m_musteriNo; }
            set { m_musteriNo = value; }
        }

        public string tcKimlikNo {

            get { return m_tcKimlikNo; }
            set { m_tcKimlikNo = value; }
        }

        public DateTime dogumTarihi
        {

            get { return m_dogumTarihi; }
            set { m_dogumTarihi = value; }
        }

        public string musteriAd
        {

            get { return m_musteriAd; }
            set { m_musteriAd = value; }
        }

        public string musteriSoyad
        {

            get { return m_musteriSoyad; }
            set { m_musteriSoyad = value; }
        }
        public string musteriBabaAdi
        {

            get { return m_musteriBabaAdi; }
            set { m_musteriBabaAdi = value; }
        }
        public string musteriAnneAdi
        {

            get { return m_musteriAnneAdi; }
            set { m_musteriAnneAdi = value; }
        }

        public int kayitDrm { 
        
        get { return m_kayitDrm; }
        set { m_kayitDrm = value; }
        
        }
        public int? sahisFirmaDrm
        {

            get { return m_sahisFirmaDrm; }
            set { m_sahisFirmaDrm = value; }
        }
        public string KKTCKimlikNo
        {

            get { return m_KKTCKimlikNo; }
            set { m_KKTCKimlikNo = value; }
        }
        public string gercekTuzelDrm
        {

            get { return m_gercekTuzelDrm; }
            set { m_gercekTuzelDrm = value; }
        }

    }
}
