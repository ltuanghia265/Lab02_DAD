using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VD2
{
    public partial class frmGiaoVien : Form
    {
        public frmGiaoVien()
        {
            InitializeComponent();
        }

        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            string lienhe = "https://github.com/ltuanghia265?tab=repositories";
            this.lblLienHe.Links.Add(0,lienhe.Length,lienhe);
            this.cbMaSo.SelectedItem = this.cbMaSo.Items[0];
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int i = this.lbDanhSachMonHoc.SelectedItems.Count - 1;
            while (i >= 0)
            {
                this.lbMonHocDay.Items.Add(lbDanhSachMonHoc.SelectedItems[i]);
                this.lbDanhSachMonHoc.Items.Remove(lbDanhSachMonHoc.SelectedItems[i]);
                i--;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i = this.lbMonHocDay.SelectedItems.Count - 1;
            while (i >= 0)
            {
                this.lbDanhSachMonHoc.Items.Add(lbMonHocDay.SelectedItems[i]);
                this.lbMonHocDay.Items.Remove(lbMonHocDay.SelectedItems[i]);
                i--;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            this.cbMaSo.Text = "";
            this.tbHoTen.Text = "";
            this.tbEmail.Text = "";
            this.mskSDT.Text = "";
            this.rdNam.Checked = true;

            for(int i = 0; i < clbNgoaiNgu.Items.Count - 1; i++)
            {
                clbNgoaiNgu.SetItemChecked(i, false);
            }
            foreach (object ob in lbMonHocDay.Items)
                this.lbDanhSachMonHoc.Items.Add(ob);
            this.lbMonHocDay.Items.Clear();
        }

        private void lblLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s=e.Link.LinkData.ToString();
            Process.Start(s);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            frmTBGiaoVien frm = new frmTBGiaoVien();
            frm.SetText(GetGiaoVien().ToString());
            frm.ShowDialog();
        }

        public GiaoVien GetGiaoVien()
        {
            string gt = "Nam";
            if (rdNu.Checked)
                gt = "Nữ";
            GiaoVien gv = new GiaoVien();
            gv.MaSo=this.cbMaSo.Text;
            gv.GioiTinh = gt;
            gv.HoTen=this.tbHoTen.Text;
            gv.NgaySinh=this.dtpNgaySinh.Value;
            gv.Mail=this.tbEmail.Text;
            gv.SoDT=this.mskSDT.Text;

            string ngoaingu = "";
            for(int i = 0; i < clbNgoaiNgu.Items.Count - 1; i++)
            {
                if (clbNgoaiNgu.GetItemChecked(i))
                    ngoaingu += clbNgoaiNgu.Items[i] + ";";
            }
            gv.NgoaiNgu=ngoaingu.Split(';');
            DanhMucMonHoc mh = new DanhMucMonHoc();
            foreach (object ob in lbMonHocDay.Items)
                mh.Them(new MonHoc(ob.ToString()));
            gv.dsMonHoc = mh;

            return gv;
        }
    }
}
