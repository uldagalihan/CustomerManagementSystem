using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityIrtibatMusteri
    {
        private int m_irtibatID;
        private int m_musteriNo;
        private int m_iletisimDrm;
        private int m_kayitDrm;
        private int m_adresTipKd;
        private string m_adresBilgisi;
        private int m_eadresTipKd;
        private string m_eadresBilgisi;
        private int m_telefonTipKd;
        private int m_hatTipiKd;
        private string m_alanKod;
        private string m_telNo;

        public int irtibatID { get{ return m_irtibatID; }set{ m_irtibatID = value; } }
        public int musteriNo { get { return m_musteriNo; } set { m_musteriNo = value; } }
        public int iletisimDrm { get { return m_iletisimDrm; } set { m_iletisimDrm = value; } }
        public int kayitDrm { get { return m_kayitDrm; } set { m_kayitDrm = value; } }

        public int adresTipKd { get { return m_adresTipKd; } set { m_adresTipKd = value; } }

        public string adresBilgisi { get { return m_adresBilgisi; } set { m_adresBilgisi = value; } }

        public int eadresTipKd {get { return m_eadresTipKd; }set{ m_eadresTipKd = value; } }

        public string eadresBilgisi { get { return m_eadresBilgisi; } set { m_eadresBilgisi = value; } }

        public int telefonTipKd { get { return m_telefonTipKd; } set { m_telefonTipKd = value; } }
        public int hatTipiKd { get { return m_hatTipiKd; } set { m_hatTipiKd = value; } }

        public string alanKod { get { return m_alanKod; } set { m_alanKod = value; } }

        public string telNo { get { return m_telNo; } set { m_telNo = value; } }

    }
}
