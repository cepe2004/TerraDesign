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


        public static void AvgMarkFirstKm()
        {
            GlobalVars.Hcp = (GlobalVars.H / GlobalVars.N) + GlobalVars.hc;
        }
    }
}