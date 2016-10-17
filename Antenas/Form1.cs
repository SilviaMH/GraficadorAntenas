using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Antenas
{
    public partial class Form1 : Form
    {
        int cf, ff, n;
        double d;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cb1.SelectedIndex == -1)
            {
                MessageBox.Show("Elija un tipo de arreglo");
                return;
            }


            if (string.IsNullOrEmpty(número.Text))
            {
                MessageBox.Show("Ingrese el valor de 'n'");
                return;
            }
            else
            {
                n = Int32.Parse(número.Text);
            }

       
            if (string.IsNullOrEmpty(distancia.Text))
            {
                MessageBox.Show("Ingrese el valor de 'd'");
                return;
            }
            else
            {
                d = Double.Parse(distancia.Text);
            }

            if (d < 0)
            {
                MessageBox.Show("Valor Inválido");
                return;
            }

            expresión_intensidad.Items.Clear();
            cf = pbgrafica.Size.Width;
            ff = pbgrafica.Size.Height;
            Graphics gr1 = pbgrafica.CreateGraphics(); 
            PatronesdeRadiación obj = new PatronesdeRadiación(); 
            gr1.Clear(Color.White); 

            if (cb1.SelectedIndex == 0)  
            {
                if (d >= 1)
                {
                    MessageBox.Show("Para obtener un sólo lóbulo máximo de tipo Broadside se recomienda que:\nd < lambda.\nVea la sección de teoría para más detalles.");
                }
                obj.CalculaCampoBroadside(n, d);  
            }

            if (cb1.SelectedIndex == 1)  
            {
                if (d >= 0.5)
                {
                    MessageBox.Show("Para obtener un sólo lóbulo máximo Endfire se recomienda que:\nd < lambda/2.\nVea la sección de teoría para más detalles.");
                }
                obj.CalculaCampoEndfire0(n, d);
 
            }

            if (cb1.SelectedIndex == 2) 
            {
                if (d >= 0.5)
                {
                    MessageBox.Show("Para obtener un sólo lóbulo máximo Endfire se recomienda que:\nd < lambda/2.\nVea la sección de teoría para más detalles.");
                }
                obj.CalculaCampoEndfire180(n, d);
            
            }

            obj.PatróndeRadiación(cf, ff); 
            expresión_intensidad.Items.Add(obj.Num); 
            expresión_intensidad.Items.Add("------------------------------------");
            expresión_intensidad.Items.Add(obj.Den);
            gr1.DrawEllipse(Pens.LightBlue, 0, 0, cf, ff);
            gr1.DrawEllipse(Pens.LightBlue, (cf - (cf / 100 * 75)) / 2, (ff - (ff / 100 * 75)) / 2, (cf / 100) * 75, (ff / 100) * 75);
            gr1.DrawEllipse(Pens.LightBlue, (cf - cf / 2) / 2, (ff - ff / 2) / 2, cf / 2, ff / 2);
            gr1.DrawEllipse(Pens.LightBlue, (cf - cf / 4) / 2, (ff - ff / 4) / 2, cf / 4, ff / 4);
            gr1.DrawLine(Pens.LightBlue, cf / 2, 0, cf / 2, ff);
            gr1.DrawLine(Pens.LightBlue, 0, ff / 2, cf, ff / 2);
            gr1.DrawLine(Pens.LightBlue, 0, 0, cf, ff);
            gr1.DrawLine(Pens.LightBlue, cf, 0, 0, ff);

            for (int k = 0; k < 360; k++)
            {
                gr1.DrawLine(Pens.Red, obj.C[k], obj.F[k], obj.C[k + 1], obj.F[k + 1]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile(@"Antenas.pdf");
            cb1.SelectedIndex = 0;
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            axAcroPDF2.LoadFile(@"Tutorial.pdf");
        }

        private void firmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Martínez.exe");
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
