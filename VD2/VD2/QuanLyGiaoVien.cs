using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD2
{
    public class QuanLyGiaoVien:List<GiaoVien>
    {
        
        public GiaoVien this[int index]
        {
            get { return (GiaoVien)this[index]; }
            set { this[index] = value; }
        }

        public QuanLyGiaoVien() { }

        public bool Them(GiaoVien gv)
        {
            
        }
    }
}
