using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CommonEntityTumMusteriler
    {
        private List<EntityBireyselMusteri> m_bireyselMusteri;
        private List<EntityKurumsalMusteri> m_kurumsalMusteri;
        private List<EntityIrtibatMusteri> m_irtibatMusteri;

        public List<EntityBireyselMusteri> bireyselMusteri 
        {
            get { return m_bireyselMusteri;}
            set { m_bireyselMusteri = value; }
        }
           
        public List<EntityKurumsalMusteri> kurumsalMusteri {

            get { return m_kurumsalMusteri; }
            set { m_kurumsalMusteri = value; }
        
        }

        public List<EntityIrtibatMusteri> irtibatMusteri
        {
            get { return m_irtibatMusteri;}
            set { m_irtibatMusteri = value; }

        }
    }

}
