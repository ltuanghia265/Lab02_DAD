using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForm
{
    public class MonHoc
    {
        public int ID { get; set; }
        public string TenMh { get; set; }
        public int SoTC { get; set; }
        public MonHoc()
        {

        }

        public MonHoc(string ten)
        {
            this.TenMh = ten;
        }

        public MonHoc(int id, string tenmh, int tc)
        {
            this.ID = id;
            this.TenMh = tenmh;
            this.SoTC = tc;
        }
        public override string ToString()
        {
            return TenMh;
        }
    }
}
