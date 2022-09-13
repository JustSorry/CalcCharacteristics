using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Privod
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

//double Sk, Mn, Mkr, Sn, M, n, Nnom;
//double P = double.Parse(Console.ReadLine()) * 1000;
//double LMBD = double.Parse(Console.ReadLine());
//double N1 = double.Parse(Console.ReadLine());
//double PerCent = double.Parse(Console.ReadLine());
//Nnom = N1 * PerCent / 100;
//Mn = 9.55 * (P / Nnom);
//Sn = (N1 - Nnom) / N1;
//Sk = Sn * (LMBD + Math.Sqrt(Math.Pow(LMBD, 2) - 1));
//Mkr = LMBD * Mn;
//for (double S = 0.2; S <= 1; S += 0.1)
//{
//    M = 2 * Mkr / ((S / Sk) + (Sk / S));
//}
//for (double S = 0.2; S <= 1; S += 0.1)
//{
//    n = N1 * (1 - S);
//}
