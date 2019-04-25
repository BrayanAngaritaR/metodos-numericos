using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
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
            return ( Math.Exp(-x) - Math.Log(x));

        }


        // e ^ -x  - ln(x) 


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxX1.Text) && string.IsNullOrEmpty(textBoxX2.Text))
            {
                //  MessageBox.Show("Señor Usuario Por Favor Ingrese un intervalo");

            }

            else
            {

                double x1 = Convert.ToDouble(value: textBoxX1.Text);
                double x2 = Convert.ToDouble(value: textBoxX2.Text);
                double errorPedido = Convert.ToDouble(value: textBoxEpsilon.Text);
                DateTime tiempo1 = DateTime.Now;
                if (x1 <= 0 || x2 <= 0)
                {
                    MessageBox.Show("Señor Usuario X1 y X2 no pueden ser menores o iguales a 0" + "\r\n " + "Por favor cambie los valores ingresados");

                }

                else
                {

                    if (f(x1) * f(x2) > 0)
                    {

                        MessageBox.Show("Por Favor Cambie Los valores ingresados ya que F(X1)*F(X2)>0");

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
                        double x3 = (x1 + x2) / 2;
                        double errorObtenido = Math.Abs(x1 - x3);
                        int contador = 1;

                        while (errorObtenido > errorPedido)
                        {

                            if (f(x1) * f(x3) < 0)
                            {
                                x2 = x3;
                            }
                            else
                            {
                                x1 = x3;
                            }

                            x3 = (x1 + x2) / 2;
                            errorObtenido = Math.Abs(x1 - x3);
                            contador++;
                        }
                        DateTime tiempo2 = DateTime.Now;
                        TimeSpan total = new TimeSpan(tiempo2.Millisecond + tiempo1.Millisecond);

                        MessageBox.Show("-La Solución Aproximada Es: " + x3 + "\r\n " + "-Con Un Numero De " + contador + "  iteraciones " + "\r\n " + "-En Un Tiempo De " + total.ToString());


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
       private void textBoxEpsilon_TextChanged(object sender, EventArgs e)
       {

       }

       private void button2_Click(object sender, EventArgs e)
       {
           if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
           {
               Application.Exit();
           }
       }

       private void textBoxX1_TextChanged(object sender, EventArgs e)
       {

       }

       private void label4_Click(object sender, EventArgs e)
       {

       }

       private void label2_Click(object sender, EventArgs e)
       {

       }

       private void label6_Click(object sender, EventArgs e)
       {

       }

       private void button3_Click(object sender, EventArgs e)
       {
           Form2 frm2 = new Form2();

           frm2.Show();
       }

       
        }
    }

