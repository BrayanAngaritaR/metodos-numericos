using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puntofijo
{
    public partial class Form1 : Form
    {
        // tang^-1(x)+x-1=0
        public static double g2(double x)
        {
            return (1 - Math.Atan(x));
            //x = 1 - tang^-1(x)


        }

        public static double g2P(double x)
        {
            return (-(1 / ( 1 + 2*x)));
            // - (1/1+2x)


        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void hallar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxX.Text))
            {
                MessageBox.Show("El valor ingresado no fue el que solicitamos");
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
                double valor = x0;
                double x = x0;
                double errorPedido = Convert.ToDouble(value: textBoxEpsilon.Text);

                double errorObtenido = 1;

                DateTime tiempo1 = DateTime.Now;

                int contador = 1;

                while (errorObtenido > errorPedido)
                {

                    if (Math.Abs(g2P(x0)) < 1)
                    {
                        double x1 = g2(x0);
                        errorObtenido = Math.Abs(x1 - x0);
                        x0 = x1;
                        contador++;
                    }

                }

                DateTime tiempo2 = DateTime.Now;
                TimeSpan total = new TimeSpan(tiempo2.Millisecond + tiempo1.Millisecond);

                MessageBox.Show("La solución aproximada es: " + x0 + "\n\n El número de interacciones fue de " + contador + "\n\n El tiempo de ejecución fue de " + total.ToString());
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ctrl.Text = "";
                    }
                }






            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
