using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BIBLIOTEKA_NR1.Algebra_Liniowa;

namespace Gauss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            format();
        }

        int N = 6; // liczba równań
        double[] X, B;
        double[,] A;

        void format()
        {
            
            // macierz A
            dataGridView1.ColumnCount = N;
            dataGridView1.RowCount = N;

            //wektor B i X
            dataGridView2.ColumnCount = 1;
            dataGridView2.RowCount = N;
            dataGridView3.ColumnCount = 1;
            dataGridView3.RowCount = N;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;

            Random random = new Random();
            double r_value, sumator = 0;

            for (int i = 0; i < N; i++)
            {
                sumator = 0;
                for (int j = 0; j < N; j++)
                {
                    r_value = random.Next(21);
                    dataGridView1[j, i].Value = r_value.ToString("0.00");
                    sumator = sumator + r_value;
                }

            dataGridView3[0, i].Value = sumator;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            
            Random random = new Random();
            double x;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    x = random.Next(-99,100) + random.NextDouble();
                    dataGridView1.Rows[i].Cells[j].Value = x.ToString("0.00");
                }
                x = random.Next(-99, 100) + random.NextDouble();
                dataGridView3[0,i].Value = x.ToString("0.00");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            B = new double[N+1];
            X = new double[N+1];
            A = new double[N+1, N+1];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    A[i+1, j+1] = Convert.ToDouble(dataGridView1[j, i].Value);
                }
                B[i+1] = Convert.ToDouble(dataGridView3[0, i].Value);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            N = (int)trackBar1.Value;
            numericUpDown1.Value = N;
            label7.Text = "N = " + N.ToString();

            format();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            N = (int)numericUpDown1.Value;
            trackBar1.Value = N;
            label7.Text = "N = " + N.ToString();


            format();
        }
    }
}
