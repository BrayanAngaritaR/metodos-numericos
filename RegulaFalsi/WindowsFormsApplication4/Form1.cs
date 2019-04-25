using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static double f(double x)
        {

            // e ^ -x  - ln(x) 
            return (Math.Exp(-x) - Math.Log(x));

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxa0.Text) && string.IsNullOrEmpty(textBoxb0.Text))
            {
                MessageBox.Show("Señor usuario por favor ingrese un valor correcto");
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


                double a0 = Convert.ToDouble(value: textBoxa0.Text);
                double b0 = Convert.ToDouble(value: textBoxb0.Text);
                double errorPedido = Convert.ToDouble(value: textBoxEpsilon.Text);
                DateTime tiempo1 = DateTime.Now;
                if (a0 <= 0 || b0 <= 0)
                {
                    MessageBox.Show("Señor usuario a0 y b0 no pueden ser menores o iguales a 0" + "\r\n " + "Por favor cambie los valores ingresados");

                }



                else
                {

                    double x0 = (((f(a0) * b0) - (f(b0) * a0)) / (f(a0) - f(b0)));

                    if (f(a0) * f(b0) > 0)
                    {

                        MessageBox.Show("Por Favor Cambie Los valores ingresados ya que F(a0)*F(b0)>0");

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

                        if (f(a0) * f(x0) > 0)
                        {
                            a0 = x0;

                        }
                        else if (f(a0) * f(x0) < 0)
                        {
                            b0 = x0;

                        }
                        else if (f(a0) * f(x0) == 0)
                        {
                            MessageBox.Show("La solución aproximada es: " + x0);
                            foreach (Control ctrl in this.Controls)
                            {
                                if (ctrl is TextBox)
                                {
                                    ctrl.Text = "";
                                }
                            }
                        }

                        double x1 = (((f(a0) * b0) - (f(b0) * a0)) / (f(a0) - f(b0)));

                        double errorObtenido = (Math.Abs(x1 - x0));

                        int contador = 1;
                        while (errorObtenido > errorPedido)
                        {

                            if (f(a0) * f(x1) > 0)
                            {
                                a0 = x1;

                            }
                            else if (f(a0) * f(x1) < 0)
                            {
                                b0 = x1;

                            }
                            else if (f(a0) * f(x1) == 0)
                            {
                                MessageBox.Show("La solución aproximada es: " + x1);
                                foreach (Control ctrl in this.Controls)
                                {
                                    if (ctrl is TextBox)
                                    {
                                        ctrl.Text = "";
                                    }
                                }

                            }

                            double x2 = (((f(a0) * b0) - (f(b0) * a0)) / (f(a0) - f(b0)));

                            errorObtenido = (Math.Abs(x2 - x1));

                            x1 = x2;
                            contador++;
                        }
                        DateTime tiempo2 = DateTime.Now;
                        TimeSpan total = new TimeSpan(tiempo2.Millisecond + tiempo1.Millisecond);

                        MessageBox.Show("La solución aproximada es: " + x1 + "\r\n " + "Con " + contador + " iteraciones " + "\r\n " + "En un tiempo de " + total.ToString());
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
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           


           
           
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                Form2 frm2 = new Form2();

                frm2.Show();
            
        }
    }
}
