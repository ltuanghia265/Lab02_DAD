﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

delegate int SoSanh(object a, object b);

namespace VD2
{
    internal static class Program
    {
        enum KieuTim
        {
            TimTheoTen,
            TimTheoMa,
            TimTheoSDT
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmGiaoVien());
        }
    }
}
