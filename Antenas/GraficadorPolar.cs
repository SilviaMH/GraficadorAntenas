using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using info.lundin.math;

namespace Antenas
{
    class GraficadorPolar
    {
        private double x, y, xi, yi, xf, yf, h, th, r, thi, thf, rmax;
        private int ci, fi, cf, ff, n, c1, f1;
        private int[] c;
        private int[] f;
        private string fun;

        public GraficadorPolar() 
        {
            n = 361;
            c = new int[n];
            f = new int[n];
        }

        public int C1
        {
            set { c1 = value; }
            get { return (c1); }
        }

        public int F1
        {
            set { f1 = value; }
            get { return (f1); }
        }

        public int[] C
        {
            set { c = value; }
            get { return (c); }
        }

        public int[] F
        {
            set { f = value; }
            get { return (f); }
        }

        public double X
        {
            set { x = value; }
            get { return (x); }
        }

        public double función(double th, string fun)
        {
            ExpressionParser opar = new ExpressionParser();
            opar.Values.Add("theta", th);
            return (opar.Parse(fun));
        }
        public int Col(double x)
        {
            int co;
            co = (int)(((x - xi) / (xf - xi)) * cf + ((xf - x) / (xf - xi)) * ci);
            return co;
        }
        public int Fil(double y)
        {
            int fil;
            fil = (int)(((yf - y) / (yf - yi)) * ff + ((y - yi) / (yf - yi)) * fi);
            return fil;
        }
        public void Graficar(int cf, int ff, string func)
        {
            ci = 1;
            fi = 1;
            xi = 0;
            xf = 0.000000001;
            yi = 0;
            yf = 0.000000001;
            thi = 0;
            thf = 360;
            this.cf = cf;  
            this.ff = ff;  
            fun = func;
            h = (thf - thi) / n;
            rmax = 0;

            for (int k = 0; k < n; k++)
            {
                th = thi + k * h;
                th = (th * Math.PI) / 180; 
                r = Math.Abs(función(th, fun));
                if (!(Double.IsInfinity(r) || Double.IsNaN(r))) 
                {                                                                              
                    if (r > rmax) { rmax = r; }
                }

            }
            xi = yi = -1 * rmax; 
            xf = yf = rmax;
 
            for (int k = 0; k < n; k++)
            {
                th = thi + k * h;
                th = (th * Math.PI) / 180;
                r = función(th, fun);
                if (Double.IsInfinity(r) || Double.IsNaN(r))
                {
                    th = thi + (k + 0.1) * h;
                    th = (th * Math.PI) / 180;
                    r = función(th, fun);
                }
                x = r * Math.Cos(th);
                y = r * Math.Sin(th);
                C[k] = Col(x);
                F[k] = Fil(y);

            }
        }
    }
}

