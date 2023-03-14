using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VD2
{
    public partial class frmTBGiaoVien : Form
    {
        public frmTBGiaoVien()
        {
            InitializeComponent();
        }

        private void lblThongBao_Click(object sender, EventArgs e)
        {

        }

        public void SetText(string s)
        {
            this.lblThongBao.Text = s;
        }
    }
}
