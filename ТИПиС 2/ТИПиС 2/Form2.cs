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
    public partial class Form2 : Form
    {
        Form1 newForm1;

        Random random = new Random();

        double gauss_function(double M, double d)
        {
            return (random.NextDouble() - M) / Math.Sqrt(d);
        }

        public double other_gauss_function(double M, double D)
        {
            double x = 0;

            for (int i = 0; i < 10; i++)
                x += random.Next(0, 2);

            x = (x - M) / Math.Sqrt(D);

            return x;
        }

        public Form2(Form1 newForm1)
        {
            InitializeComponent();

            listBox1.Hide();
            listBox2.Hide();

            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();

            this.newForm1 = newForm1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            newForm1.Show();
        }

        private void button2_Click(object sender, EventArgs e0)
        {
            int N = 0;
            bool q = false;

            try
            {
                N = Convert.ToInt32(textBox1.Text);
                if (N <= 0)
                    MessageBox.Show("Введено неположительное значение. Повторите попытку!", "Ошибка ввода данных");
                else q = true;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Не введено значение. Повторите попытку!", "Ошибка ввода данных");
            }

            if(q)
            {
                listBox1.Hide();
                listBox2.Hide();

                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();

                listBox1.Items.Clear();
                listBox2.Items.Clear();

                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();

                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
                chart1.ChartAreas[0].Axes[0].MajorGrid.Interval = 100;

                double D = 7, a = 0.05, p = 0.965;
                
                double k2 = Math.Exp(-a);
                double k1 = Math.Sqrt(D * (1 - Math.Pow(k2, 2)));

                double[] y = new double[N - 1];
                double[] x = new double[N];
                x[0] = gauss_function(0, D);

                for (int i = 1; i < N; i++)
                {
                    double e = other_gauss_function(0, D);
                    x[i] = k1 * e + k2 * x[i - 1];
                    y[i - 1] = x[i] - p * x[i - 1];
                }

                double[] r = new double[N];

                for (int i = 0; i < N; i++)
                {
                    r[i] = 0;
                    for (int j = 0; j < N - 1 - i - 1; j++)
                        r[i] = r[i] + 1 / (double)(N - 1 - i) * y[j] * y[j + i];
                }

                double[] h = new double[N - 1];
                double[] k = new double[N];

                for (int i = 0; i < h.Length; i++)
                    h[i] = i;

                for (int i = 0; i < k.Length; i++)
                    k[i] = i;

                chart1.Series[0].Points.DataBindXY(h, y);
                chart1.Series[1].Points.DataBindXY(k, r);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int N = 0;
            bool q = false;

            try
            {
                N = Convert.ToInt32(textBox1.Text);
                if (N <= 0)
                    MessageBox.Show("Введено неположительное значение. Повторите попытку!", "Ошибка ввода данных");
                else if (N < 39)
                    MessageBox.Show("Невозможно построить график из-за недопустимого значения. Повторите попытку!", "Ошибка работы с данными");
                else q = true;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Не введено значение. Повторите попытку!", "Ошибка ввода данных");
            }

            if (q)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();

                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();

                chart1.ChartAreas[0].AxisX.Minimum = 0;

                double[] E = new double[N];

                for (int i = 0; i < N; i++)
                    E[i] = gauss_function(0, 1);

                double[] c = new double[N];
                double D = 5, a = 0.05129;
                int p = (int)(2 / a);

                for (int i = 0; i <= p; i++)
                    if (i != 0)
                        c[i] = Math.Sqrt(D) / Math.Sqrt(Math.PI * a) * Math.Sin(a * i) / i;
                    else c[i] = Math.Sqrt(D) / Math.Sqrt(Math.PI * a) * a;

                double[] x = new double[N];
                double a0;

                for (int i = 0; i < N; i++)
                {
                    x[i] = 0;
                    for (int j = -p; j <= p; j++)
                    {
                        if (j < 0)
                            a0 = c[-j];
                        else a0 = c[j];
                        if (((i - j) >= 0) && ((i - j) < N))
                            x[i] = a0 * E[i - j] + x[i];
                    }
                }

                for (int i = 0; i < (N - 2 * p); i++)
                    x[i] = x[i + p];

                double[] r = new double[N];
                int N0 = N - 2 * p;

                for (int i = 0; i < N; i++)
                {
                    r[i] = 0;

                    for (int j = 0; j < (N0 - i - 1); j++)
                        r[i] = r[i] + 1 / (double)(N0 - i) * x[j] * x[j + i];

                    chart1.Series[1].Points.AddXY(i, r[i]);
                }

                for (int i = 0; i < x.Length; i++)
                    listBox1.Items.Add("x[" + i + "] = " + x[i]);

                for (int i = 0; i < r.Length; i++)
                    if (r[i] != 0)
                        listBox2.Items.Add("r[" + i + "] = " + r[i]);

                label4.Show();
                label5.Show();

                label2.Hide();
                label3.Hide();

                listBox1.Show();
                listBox2.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e0)
        {
            int N = 0;
            bool q = false;

            try
            {
                N = Convert.ToInt32(textBox1.Text);
                if (N <= 0)
                    MessageBox.Show("Введено неположительное значение. Повторите попытку!", "Ошибка ввода данных");
                else q = true;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Не введено значение. Повторите попытку!", "Ошибка ввода данных");
            }

            if (q)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();

                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();

                chart1.ChartAreas[0].AxisX.Minimum = 0;

                double D = 5, a = 0.05129;

                double k2 = Math.Exp(-a);
                double k1 = Math.Sqrt(D * (1 - Math.Pow(k2, 2)));

                double[] x = new double[N];
                x[0] = gauss_function(0, D);

                for (int i = 1; i < N; i++)
                {
                    double e = gauss_function(0, 1);
                    listBox1.Items.Add("e[" + i + "] = " + e);
                    x[i] = k1 * e + k2 * x[i - 1];
                }

                for (int i = 0; i < N; i++)
                {
                    listBox2.Items.Add("x[" + i + "] = " + x[i]);
                    chart1.Series[0].Points.AddXY(i - 1, x[i]);
                }

                label2.Show();
                label3.Show();

                label4.Hide();
                label5.Hide();

                listBox1.Show();
                listBox2.Show();
            }    
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Hide();
            listBox2.Hide();

            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();

            listBox1.Items.Clear();
            listBox2.Items.Clear();

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            textBox1.Clear();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
