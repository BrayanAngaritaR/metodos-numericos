using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jacobi
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(5);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void hallar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                bool bCampoVacio = false;
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell dc in dr.Cells)
                    {
                        if (dc.Value == null || string.IsNullOrEmpty(dc.Value.ToString()))
                        {
                            bCampoVacio = true;
                        }
                    }
                }
                if (bCampoVacio)
                    MessageBox.Show("Encontramos un campo vacío, por favor verifica");
            }

            if (string.IsNullOrEmpty(textBoxX0.Text) && string.IsNullOrEmpty(textBoxY0.Text) && string.IsNullOrEmpty(textBoxZ0.Text) && string.IsNullOrEmpty(textBoxT0.Text) && string.IsNullOrEmpty(textBoxU0.Text) && string.IsNullOrEmpty(textBoxEpsilon.Text))
            {
                MessageBox.Show("Señor usuario, el valor ingresado no es el que solicitamos");
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
                // Obtener el dato del int valor = Convert.ToInt32(dataGridView1.Rows[0].Cells[1].Value);


                double[,] matriz;
                matriz = new double[5, 5];

                //Ecuacion 1
                matriz[0, 0] = Convert.ToDouble(dataGridView1.Rows[0].Cells[0].Value);
                matriz[0, 1] = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value);
                matriz[0, 2] = Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value);
                matriz[0, 3] = Convert.ToDouble(dataGridView1.Rows[0].Cells[3].Value);
                matriz[0, 4] = Convert.ToDouble(dataGridView1.Rows[0].Cells[4].Value);

                //Ecuacion 2
                matriz[1, 0] = Convert.ToDouble(dataGridView1.Rows[1].Cells[0].Value);
                matriz[1, 1] = Convert.ToDouble(dataGridView1.Rows[1].Cells[1].Value);
                matriz[1, 2] = Convert.ToDouble(dataGridView1.Rows[1].Cells[2].Value);
                matriz[1, 3] = Convert.ToDouble(dataGridView1.Rows[1].Cells[3].Value);
                matriz[1, 4] = Convert.ToDouble(dataGridView1.Rows[1].Cells[4].Value);

                //Ecuacion 3
                matriz[2, 0] = Convert.ToDouble(dataGridView1.Rows[2].Cells[0].Value);
                matriz[2, 1] = Convert.ToDouble(dataGridView1.Rows[2].Cells[1].Value);
                matriz[2, 2] = Convert.ToDouble(dataGridView1.Rows[2].Cells[2].Value);
                matriz[2, 3] = Convert.ToDouble(dataGridView1.Rows[2].Cells[3].Value);
                matriz[2, 4] = Convert.ToDouble(dataGridView1.Rows[2].Cells[4].Value);

                //Ecuacion 4
                matriz[3, 0] = Convert.ToDouble(dataGridView1.Rows[3].Cells[0].Value);
                matriz[3, 1] = Convert.ToDouble(dataGridView1.Rows[3].Cells[1].Value);
                matriz[3, 2] = Convert.ToDouble(dataGridView1.Rows[3].Cells[2].Value);
                matriz[3, 3] = Convert.ToDouble(dataGridView1.Rows[3].Cells[3].Value);
                matriz[3, 4] = Convert.ToDouble(dataGridView1.Rows[3].Cells[4].Value);

                //Ecuacion 5
                matriz[4, 0] = Convert.ToDouble(dataGridView1.Rows[4].Cells[0].Value);
                matriz[4, 1] = Convert.ToDouble(dataGridView1.Rows[4].Cells[1].Value);
                matriz[4, 2] = Convert.ToDouble(dataGridView1.Rows[4].Cells[2].Value);
                matriz[4, 3] = Convert.ToDouble(dataGridView1.Rows[4].Cells[3].Value);
                matriz[4, 4] = Convert.ToDouble(dataGridView1.Rows[4].Cells[4].Value);

                // Sumas 
                double Sum1 = matriz[0, 1] + matriz[0, 2] + matriz[0, 3] + matriz[0, 4];
                double Sum2 = matriz[1, 0] + matriz[1, 2] + matriz[1, 3] + matriz[1, 4];
                double Sum3 = matriz[2, 0] + matriz[2, 1] + matriz[2, 3] + matriz[2, 4];
                double Sum4 = matriz[3, 0] + matriz[3, 1] + matriz[3, 2] + matriz[3, 4];
                double Sum5 = matriz[4, 0] + matriz[4, 1] + matriz[4, 2] + matriz[4, 3];

                // Igual (De Las Ecuaciones)

                double igual1 = Convert.ToDouble(dataGridView1.Rows[0].Cells[5].Value);
                double igual2 = Convert.ToDouble(dataGridView1.Rows[1].Cells[5].Value);
                double igual3 = Convert.ToDouble(dataGridView1.Rows[2].Cells[5].Value);
                double igual4 = Convert.ToDouble(dataGridView1.Rows[3].Cells[5].Value);
                double igual5 = Convert.ToDouble(dataGridView1.Rows[4].Cells[5].Value);


                //Vaariables De Entrada Para Hallar Igualdad
                double x0 = Convert.ToDouble(value: textBoxX0.Text);
                double y0 = Convert.ToDouble(value: textBoxY0.Text);
                double z0 = Convert.ToDouble(value: textBoxZ0.Text);
                double t0 = Convert.ToDouble(value: textBoxT0.Text);
                double u0 = Convert.ToDouble(value: textBoxU0.Text);

                double errorPedido = Convert.ToDouble(value: textBoxEpsilon.Text);
                DateTime tiempo1 = DateTime.Now;

                if (Math.Abs(matriz[0, 0]) > Math.Abs(Sum1) && Math.Abs(matriz[1, 1]) > Math.Abs(Sum2) && Math.Abs(matriz[2, 2]) > Math.Abs(Sum3) && Math.Abs(matriz[3, 3]) > Math.Abs(Sum4) && Math.Abs(matriz[4, 4]) > Math.Abs(Sum5))
                {
                    int contador = 1;

                    double x1 = (igual1 - 0 - (matriz[0, 1] * y0) - (matriz[0, 2] * z0) - (matriz[0, 3] * t0) - (matriz[0, 4] * u0)) / matriz[0, 0];
                    double y1 = (igual2 - (matriz[1, 0] * x0) - 0 - (matriz[1, 2] * z0) - (matriz[1, 3] * t0) - (matriz[1, 4] * u0)) / matriz[1, 1];
                    double z1 = (igual3 - (matriz[2, 0] * x0) - (matriz[2, 1] * y0) - 0 - (matriz[2, 3] * t0) - (matriz[2, 4] * u0)) / matriz[2, 2];
                    double t1 = (igual4 - (matriz[3, 0] * x0) - (matriz[3, 1] * y0) - (matriz[3, 2] * z0) - 0 - (matriz[3, 4] * u0)) / matriz[3, 3];
                    double u1 = (igual5 - (matriz[4, 0] * x0) - (matriz[4, 1] * y0) - (matriz[4, 2] * z0) - (matriz[4, 3] * t0) - 0) / matriz[4, 4];


                    double errorX = Math.Abs(x1 - x0);
                    double errorY = Math.Abs(y1 - y0);
                    double errorZ = Math.Abs(z1 - z0);
                    double errorT = Math.Abs(t1 - t0);
                    double errorU = Math.Abs(u1 - u0);

                    //Metodo De La Burbuja Ordenamiento De Los Valores
                    double[] vector;
                    vector = new double[5];
                    vector[0] = errorX;
                    vector[1] = errorY;
                    vector[2] = errorZ;
                    vector[3] = errorT;
                    vector[4] = errorU;

                    double t;
                    for (double a = 1; a < vector.Length; a++)
                        for (int b = vector.Length - 1; b >= a; b--)
                        {
                            if (vector[b - 1] > vector[b])
                            {
                                t = vector[b - 1];
                                vector[b - 1] = vector[b];
                                vector[b] = t;
                            }
                        }



                    double errorObtenido = vector[4];


                    while (errorObtenido > errorPedido)
                    {
                        double x2 = (igual1 - 0 - (matriz[0, 1] * y1) - (matriz[0, 2] * z1) - (matriz[0, 3] * t1) - (matriz[0, 4] * u1)) / matriz[0, 0];
                        double y2 = (igual2 - (matriz[1, 0] * x1) - 0 - (matriz[1, 2] * z1) - (matriz[1, 3] * t1) - (matriz[1, 4] * u1)) / matriz[1, 1];
                        double z2 = (igual3 - (matriz[2, 0] * x1) - (matriz[2, 1] * y1) - 0 - (matriz[2, 3] * t1) - (matriz[2, 4] * u1)) / matriz[2, 2];
                        double t2 = (igual4 - (matriz[3, 0] * x1) - (matriz[3, 1] * y1) - (matriz[3, 2] * z1) - 0 - (matriz[3, 4] * u1)) / matriz[3, 3];
                        double u2 = (igual5 - (matriz[4, 0] * x1) - (matriz[4, 1] * y1) - (matriz[4, 2] * z1) - (matriz[4, 3] * t1) - 0) / matriz[4, 4];

                        errorX = Math.Abs(x2 - x1);
                        errorY = Math.Abs(y2 - y1);
                        errorZ = Math.Abs(z2 - z1);
                        errorT = Math.Abs(t2 - t1);
                        errorU = Math.Abs(u2 - u1);

                        //Metodo De La Burbuja Ordenamiento De Los Valores

                        vector[0] = errorX;
                        vector[1] = errorY;
                        vector[2] = errorZ;
                        vector[3] = errorT;
                        vector[4] = errorU;


                        for (double a = 1; a < vector.Length; a++)
                            for (int b = vector.Length - 1; b >= a; b--)
                            {
                                if (vector[b - 1] > vector[b])
                                {
                                    t = vector[b - 1];
                                    vector[b - 1] = vector[b];
                                    vector[b] = t;
                                }
                            }



                        errorObtenido = vector[4];

                        x1 = x2;
                        y1 = y2;
                        z1 = z2;
                        t1 = t2;
                        u1 = u2;
                        contador++;



                    }



                    DateTime tiempo2 = DateTime.Now;
                    TimeSpan total = new TimeSpan(tiempo2.Millisecond + tiempo1.Millisecond);

                    MessageBox.Show("La solución es: \n \n X = " + x1 + "\n" + " Y =  " + y1 + "\n Z =  " + z1 + "\n T =  " + t1 + "\n U =  " + u1 + "\n \n El número de interacciones es de " + contador + ".\n \n El tiempo de ejecución fue de " + total.ToString() + ". \n \n El error obtenido es " + errorObtenido);
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
                    MessageBox.Show("Señor Usuario La Matriz No Es Diagonalmente Dominante, Por Lo Tanto No Tiene Solución Por Este Metodo");
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
        }

        private void atras_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            this.Hide();
            m.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

      
    }
}
