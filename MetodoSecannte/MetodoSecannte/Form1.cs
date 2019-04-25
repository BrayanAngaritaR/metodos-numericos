using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodoSecannte
{
    public partial class Form1 : Form
    {

        public static double f(double x)
        {



            return 5 / 2 * (Math.Exp(x / 5) - Math.Exp(- x / 5));
            //f(x) = 5/2 (e^x/5 - e^-x/5)
         

            
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
         if (string.IsNullOrEmpty(textBoxX0.Text) && string.IsNullOrEmpty(textBoxX1.Text))
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


                double x0 = Convert.ToDouble(value: textBoxX0.Text);
                double x1 = Convert.ToDouble(value: textBoxX1.Text);
                double errorPedido = Convert.ToDouble(value: textBoxEpsilon.Text);
                DateTime tiempo1 = DateTime.Now;

                if (x0 <= 0 && x1 >= 0 || x0 >= 0 && x1 <= 0)
                {
                
                 
           
           

                double x2 = x1-((f(x1)*(x1-x0))/(f(x1)-f(x0)));
                double x3 = x2 - ((f(x2) * (x2 - x1)) / (f(x2) - f(x1)));
                
                double errorObtenido = (Math.Abs(x3- x2));

                int contador = 1;
                while (errorObtenido > errorPedido)
                {
                    double x4  = x3 - ((f(x3) * (x3 - x2)) / (f(x3) - f(x2)));
              
                    errorObtenido = (Math.Abs(x4 - x3));

                    x3 = x4;
                    contador++;
                }
                DateTime tiempo2 = DateTime.Now;
                TimeSpan total = new TimeSpan(tiempo2.Millisecond + tiempo1.Millisecond);

                MessageBox.Show("La Solución Aproximada Es: " + x3 + " , Con Un Numero De " + contador + " , Iteraciones En Un Tiempo De " + total.ToString());
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox)
                        if (ctrl is TextBox)
                    {
                        ctrl.Text = "";
                    }
                }



                }
                else
                {
                    MessageBox.Show("Señor usuario para este metodo los valores tienen que tener signo contrario");
                }
            } 
        }

        private void grafica_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.TopMost = true;

            frm2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            Close();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }

        }
        Point lastPoint;


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}





