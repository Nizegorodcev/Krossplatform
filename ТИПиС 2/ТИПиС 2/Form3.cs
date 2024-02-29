using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ТИПиС_2
{
    public partial class Form3 : Form
    {
        Form1 newForm1;

        Random r = new Random();

        public double gauss(double M, double D)
        {
            double x = 0;

            for (int i = 0; i < 10; i++)
                x = x + r.Next(0, 2);

            x = (x - M) / Math.Sqrt(D);

            return x;
        }

        public Form3(Form1 newForm1)
        {
            InitializeComponent();
            this.newForm1 = newForm1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            newForm1.Show();
        }

        private void button4_Click(object sender, EventArgs e0)
        {
            int N = 0;
            double D = 0;
            bool q = false;

            try
            {
                D = Convert.ToDouble(textBox2.Text);
                N = Convert.ToInt32(textBox1.Text);
                if ((N <= 0) || (D <= 0))
                    MessageBox.Show("Введены неположительные значения. Повторите попытку!", "Ошибка ввода данных");
                else if (N < 70)
                    MessageBox.Show("Невозможно построить график из-за недопустимых значений. Повторите попытку!", "Ошибка работы с данными");
                else q = true;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Не введены значения. Повторите попытку!", "Ошибка ввода данных");
            }

            if (q)
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();

                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisX.Maximum = N;
                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
                chart1.ChartAreas[0].Axes[0].MajorGrid.Interval = 100;

                double a = 0.05, b = 0.965;

                double k2 = Math.Exp(-a);
                double k1 = Math.Sqrt(D * (1.0 - k2 * k2));

                int p = (int)(2 / a);
                double[] c = new double[N];

                double[] y = new double[N - 1];
                double[] x = new double[N];
                x[0] = gauss(0, D);

                for (int i = 1; i < N; i++)
                {
                    double sum = 0;
                    double e = gauss(0, D);

                    for (int j = 0; j <= 2 * p; j++)
                    {
                        if (j != 0)
                            c[j] = Math.Sqrt(D) / Math.Sqrt(Math.PI * a) * Math.Sin(a * j) / j;
                        else c[j] = Math.Sqrt(D) / Math.Sqrt(Math.PI * a) * a;
                        sum += c[j];
                    }

                    x[i] = sum * e;
                    y[i - 1] = 2 * x[i] + b * x[i - 1];
                }

                double[] r = new double[N];

                for (int m = 0; m < N; m++)
                {
                    for (int j = 0; j < N - 1 - m - 1; j++)
                        r[m] = r[m] + 1.0 / (N - 1 - m) * (y[j] * y[j + m]) / N;
                }

                double[] h = new double[N - 1];

                for (int i = 0; i < h.Length; i++)
                    h[i] = i;

                double[] k = new double[N];

                for (int i = 0; i < k.Length; i++)
                    k[i] = i;

                for (int i = 1; i < N; i++)
                    y[i - 1] -= 1.5 * p;

                for (int i = 0; i < N; i++)
                    r[i] -= 100 * p / N;

                chart1.Series[0].Points.DataBindXY(h, y);
                chart1.Series[1].Points.DataBindXY(k, r);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
