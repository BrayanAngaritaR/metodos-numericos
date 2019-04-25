using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newtonRaphson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        
        public static double f(double x)
        {
          
            return (Math.Pow(x, Math.Sin(x)) - 5);

        }

        public static double fPD(double x)

        {

            return (Math.Pow(x, Math.Sin(x)) * ((Math.Sin(x) / (x))+ (Math.Cos(x)*Math.Log(x))));


       

        }


        private void button1_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(textBoxX.Text) || string.IsNullOrEmpty(textBoxEpsilon.Text))
            {
                MessageBox.Show("Señor Usuario Por Favor Ingrese Un Valor Correcto");
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ctrl.Text = "";
                    }
                }

            }

         
            else
            {

                double x0 = Convert.ToDouble(value: textBoxX.Text);
                double epsilon = Convert.ToDouble(value: textBoxEpsilon.Text);

              

                DateTime tiempo1 = DateTime.Now;
                double x1 = 0;

                if (x0 <= 0)
                {
                    MessageBox.Show("X no puede ser menos que 0 ");
                }

                else
                {
                    x1 = (x0 - (f(x0) / fPD(x0)));

                    int contador = 1;

                    double x2 = x1 - (f(x1) / fPD(x1));
                    double errorObtenido = (Math.Abs(x2 - x1));


                    while (errorObtenido > epsilon)
                    {

                        double x3 = x2 - (f(x2) / fPD(x2));


                        errorObtenido = (Math.Abs(x3 - x2));

                        x1 = x2;
                        x2 = x3;
                        contador++;
                    }
                    DateTime tiempo2 = DateTime.Now;
                    TimeSpan total = new TimeSpan(tiempo2.Millisecond + tiempo1.Millisecond);

                    MessageBox.Show("La Solución Aproximada Es: " + x2 + " , Con Un Numero De " + contador + " , Iteraciones En Un Tiempo De " + total.ToString());
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is TextBox)
                        {
                            ctrl.Text = "";
                        }
                    }

                }


            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();

            frm2.Show();
        }

        
    }
}
