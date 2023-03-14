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

namespace MyForm
{
    public partial class frmGiaoVien : Form
    {
        public frmGiaoVien()
        {
            InitializeComponent();
        }

        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            string lienhe = "https://lms.dlu.edu.vn/mod/attendance/view.php?id=84646";
            this.lbLienHe.Links.Add(0, lienhe.Length, lienhe);
            this.cbMaSo.SelectedItem = this.cbMaSo.Items[0];
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int i = this.lbDSMH.SelectedItems.Count - 1;
            while(i>=0)
            {
                this.lbMHDay.Items.Add(lbDSMH.SelectedItems[i]);
                this.lbDSMH.Items.Remove(lbDSMH.SelectedItems[i]);
                i--;
            }
        }

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            int i = this.lbMHDay.SelectedItems.Count - 1;
            while(i>=0)
            {
                this.lbDSMH.Items.Add(lbMHDay.SelectedItems[i]);
                this.lbMHDay.Items.Remove(lbMHDay.SelectedItems[i]);
                i--;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        public void Reset()
        {
            this.cbMaSo.Text = "";
            this.tbHoTen.Text = "";
            this.tbMail.Text = "";
            this.mtbSDT.Text = "";
            this.rdNam.Checked = true;
            for(int i=0;i <clbNgoaiNgu.SelectedItems.Count-1;i++)
            {
                clbNgoaiNgu.SetItemChecked(i, false);
            }

            foreach (object ob in this.lbMHDay.Items)
                this.lbDSMH.Items.Add(ob);
            this.lbMHDay.Items.Clear();

        }

        private void lbLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = e.Link.LinkData.ToString();
            Process.Start(s);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmTBGiaoVien frm = new frmTBGiaoVien();
            frm.SetText(GetGiaoVien().ToString());
            frm.ShowDialog();
        }

        public GiaoVien GetGiaoVien()
        {
            string gt = "Nam";
            if (rdNu.Checked)
                gt = "Nu";
            GiaoVien gv = new GiaoVien();
            gv.MaSo = this.cbMaSo.Text;
            gv.GioiTinh = gt;
            gv.HoTen = this.tbHoTen.Text;
            gv.NgaySinh = this.dtpNgaySinh.Value;
            gv.Mail = this.tbMail.Text;
            gv.SoDT = this.mtbSDT.Text;

            string ngoaingu = "";
            for (int i = 0; i < clbNgoaiNgu.Items.Count - 1; i++)
                if (clbNgoaiNgu.GetItemChecked(i))
                    ngoaingu += clbNgoaiNgu.Items[i] + ";";
            gv.NgoaiNgu = ngoaingu.Split(';');
            DanhMucMonHoc mh = new DanhMucMonHoc();
            foreach (object ob in lbDSMH.Items)
                mh.Them(new MonHoc(ob.ToString()));
            gv.dsMonHoc = mh;
            return gv;
        }
    }
}
