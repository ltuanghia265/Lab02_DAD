using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForm
{
    public class GiaoVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh;
        public DanhMucMonHoc dsMonHoc;
        public string GioiTinh;
        public string[] NgoaiNgu;
        public string SoDT;
        public string Mail;
        public GiaoVien()
        {
            dsMonHoc = new DanhMucMonHoc();
            NgoaiNgu = new string[10];
        }

        public GiaoVien(string maSo, string hoTen,DateTime ngaySinh,DanhMucMonHoc ds,string gt, string []nn,string sdt, string mail)
        {
            this.MaSo = maSo;
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.dsMonHoc = ds;
            this.GioiTinh = gt;
            this.NgoaiNgu = nn;
            this.SoDT = sdt;
            this.Mail = mail;
        }

        public override string ToString()
        {
            string s = "Ma so:" + MaSo + '\n' + "Ho ten:" + HoTen + '\n' + "Ngay sinh:" + NgaySinh.ToString() + '\n' + "Gioi tinh:" + GioiTinh + "\n" + "SDT:" + SoDT + '\n' + "Mail" + Mail;
            string sNgoaiNgu = "Ngoai ngu:";
            foreach(string t in NgoaiNgu)
            {
                sNgoaiNgu += t + ";";
            }
            string Monday = "Danh sach mon day";
            foreach (MonHoc mh in dsMonHoc.ds)
                Monday += mh + ";";
            s += '\n' + sNgoaiNgu + '\n' + Monday;
            return s;
        }
    }
}
