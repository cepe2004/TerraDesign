using System.Diagnostics;
using System;
using System.Runtime.InteropServices;
using Npgsql;
namespace TerraDesign
{
    internal class GlobalVars
    {
        public static double hc, Bzp, hp, m, n, hdorod, bprc, bukrp, H; //принадлежит форме LScheck
        public static double Hcp,Fcp,L1p,L2p,h1,h2,h3;  //принадлежит форме LStotal
        public static int N,Index;
        public static double Q, i,L, Ksch, hk,bk;
        public static double[] v,N1,N2,N3,N4,N5;
        public static double[] Sp, Vrgr, Vvos;
        public static bool[] mound;

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        public static void CloseExcelApp(Microsoft.Office.Interop.Excel.Application excelApp)
        {
            int hWnd = excelApp.Application.Hwnd;
            uint processID;

            GetWindowThreadProcessId((IntPtr)hWnd, out processID);
            Process.GetProcessById((int)processID).Kill();
        }
        public static int IdUser, RoleUser;
        public static string FIOUser;
        
        public static NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;port=5432;database=TerraDesign;Username=postgres;password = 12345");




        public static void AvgMarkFirstKm()
        {
            GlobalVars.Hcp = (GlobalVars.H / GlobalVars.N) + GlobalVars.hc;
        }
    }
}