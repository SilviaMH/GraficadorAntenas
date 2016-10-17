using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antenas
{
    class PatronesdeRadiación : GraficadorPolar
    {
        private int n, cf, ff;
        private double a, b, d;
        private string IntensidadCampo, num, den;
        public string Num
        {
            set { num = value; }
            get { return (num); }
        }

        public string Den
        {
            set { den = value; }
            get { return (den); }
        }
        public void CalculaCampoBroadside(int n, double d)
        {
            this.n = n;
            this.d = d;
            a = Math.PI * d;
            b = a * n;
            IntensidadCampo = "abs(sin(" + b + "*cos(theta))/sin(" + a + "*cos(theta)))";
            num = "sin( " + Math.Round(b, 2) + " cos(theta) )";
            den = "sin( " + Math.Round(a, 2) + " cos(theta) )";
        }
        public void CalculaCampoEndfire0(int n, double d)
        {
            this.n = n;
            this.d = d;
            a = Math.PI * d;
            b = a * n;
            IntensidadCampo = "abs(sin(" + b + "*(cos(theta)-1))/sin(" + a + "*(cos(theta)-1)))";
            num = "sin( " + Math.Round(b, 2) + " (cos(theta)-1)) )";
            den = "sin( " + Math.Round(a, 2) + " (cos(theta)-1)) )";
        }
        public void CalculaCampoEndfire180(int n, double d)
        {
            this.n = n;
            this.d = d;
            a = Math.PI * d;
            b = a * n;
            IntensidadCampo = "abs(sin(" + b + "*(cos(theta)+1))/sin(" + a + "*(cos(theta)+1)))";
            num = "sin( " + Math.Round(b, 2) + " (cos(theta)+1)) )";
            den = "sin( " + Math.Round(a, 2) + " (cos(theta)+1)) )";
        }
        public void PatróndeRadiación(int cf, int ff)
        {
            this.cf = cf;
            this.ff = ff;
            Graficar(cf, ff, IntensidadCampo); 
        }
    }
}