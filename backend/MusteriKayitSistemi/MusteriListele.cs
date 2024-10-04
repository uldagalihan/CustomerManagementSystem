using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusteriKayitSistemi
{
    public partial class MusteriListele : Form
    {
        public MusteriListele()
        {
            InitializeComponent();
        }

        private void btnBireyselListele_Click(object sender, EventArgs e)
        {
          
            CommonEntityTumMusteriler commonDto = new CommonEntityTumMusteriler();
            commonDto = BLBireyselMusteri.TumBireyselMusteriGetir();


            guna2DataGridView1.DataSource = commonDto;

            guna2DataGridView1.BorderStyle = BorderStyle.None;
            guna2DataGridView1.EnableHeadersVisualStyles = false;
            guna2DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 88, 255);
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            guna2DataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            guna2DataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(107, 185, 240);
            guna2DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            guna2DataGridView1.RowTemplate.Height = 70;

            guna2DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 244, 255);

            guna2DataGridView1.ColumnHeadersHeight = 45;
           
            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            guna2DataGridView1.GridColor = Color.White;
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void btnKurumsalListele_Click(object sender, EventArgs e)
        {

            CommonEntityTumMusteriler commonDto = new CommonEntityTumMusteriler();
            commonDto = BLKurumsalMusteri.TumKurumsalMusteriGetir();


            guna2DataGridView1.DataSource = commonDto.kurumsalMusteri;


            guna2DataGridView1.BorderStyle = BorderStyle.None;
            guna2DataGridView1.EnableHeadersVisualStyles = false;
            guna2DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 88, 255);
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            guna2DataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            guna2DataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(107, 185, 240);
            guna2DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            guna2DataGridView1.RowTemplate.Height = 70;

            guna2DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 244, 255);

            guna2DataGridView1.ColumnHeadersHeight = 45;

            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            guna2DataGridView1.GridColor = Color.White;
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnTumMusteriListele_Click(object sender, EventArgs e)
        {
            DataTable dtAll = new DataTable();
            DataTable dtBmusteri = new DataTable();
            DataTable dtKmusteri = new DataTable();
            dtBmusteri = BLBireyselMusteri.BMusteriListele();
            dtKmusteri = BLKurumsalMusteri.KMusteriListele();
            dtAll.Merge(dtBmusteri);
            dtAll.Merge(dtKmusteri);


            guna2DataGridView1.DataSource = dtAll;

            guna2DataGridView1.BorderStyle = BorderStyle.None;
            guna2DataGridView1.EnableHeadersVisualStyles = false;
            guna2DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 88, 255);
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            guna2DataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            guna2DataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(107, 185, 240);
            guna2DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            guna2DataGridView1.RowTemplate.Height = 60;

            guna2DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 244, 255);

            guna2DataGridView1.ColumnHeadersHeight = 40;

            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            guna2DataGridView1.GridColor = Color.White;
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
