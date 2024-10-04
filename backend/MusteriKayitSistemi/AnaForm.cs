using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;

namespace MusteriKayitSistemi
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();

        }

        private void btnBireyselMusteriTanımla_Click(object sender, EventArgs e)
        {
            BireyselMusteriTanımlama frm = new BireyselMusteriTanımlama();
            frm.ShowDialog();

        }

        private void btnBireyselMusteriGuncelle_Click(object sender, EventArgs e)
        {
            BireyselMusteriGuncelleme frm = new BireyselMusteriGuncelleme();
            frm.ShowDialog();
        }

        private void btnKurumsalMusteriTanımla_Click(object sender, EventArgs e)
        {
            KurumsalMusteriTanımlama frm = new KurumsalMusteriTanımlama();
            frm.ShowDialog();
        }

        private void btnKurumsalMusteriGuncelle_Click(object sender, EventArgs e)
        {
            KurumsalMusteriGuncelleme frm = new KurumsalMusteriGuncelleme();
            frm.ShowDialog();
        }

        private void btnMusteriListele_Click(object sender, EventArgs e)
        {
            MusteriListele frm = new MusteriListele();
            frm.ShowDialog();   
        }

       
    }
}
