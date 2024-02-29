using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ТИПиС_3
{
    public partial class Form2 : Form
    {
        Form1 newForm1;

        Random random = new Random();

        static private double gauss(Random random)
        {
            return random.NextDouble() / Math.Sqrt(7);
        }

        public Form2(Form1 newForm1)
        {
            InitializeComponent();
            this.newForm1 = newForm1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            newForm1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int N = 0;
            int L = 0;
            bool q = false;
            try
            {
                N = Convert.ToInt32(textBox1.Text);
                L = Convert.ToInt32(textBox2.Text);
                if ((N <= 0) || (L <= 0) || (L > N))
                    MessageBox.Show("Введено неположительное значение или значение L превышает значение N. Повторите попытку!", "Ошибка ввода данных");
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

                double[] s = new double[L];
                double[] k = new double[L];
                double[] x = new double[N];
                double[] y = new double[N];

                int i, p, n;

                for (i = 0; i < L; i++)
                {
                    s[i] = 0.2 * Math.Sin(2.0 * Math.PI * i / 50);
                    x[i] = s[i] * 1.375;
                }

                for (i = 0; i < L; i++)
                    k[i] = s[L - i - 1];

                for (i = 0; i < N; i++)
                    x[i] = x[i] + gauss(random);

                for (i = 0; i < N; i++)
                {
                    y[i] = 0.0;
                    for (p = 0; p < L; p++)
                    {
                        if ((i - p) >= 0)
                            y[i] = y[i] + x[i - p] * k[p];
                    }
                }

                for (int w = 0; w < N; w++)
                {
                    listBox1.Items.Add(Math.Round(x[w], 5));
                    listBox2.Items.Add(Math.Round(y[w], 5));
                    chart1.Series[0].Points.Add(x[w]);
                    chart1.Series[1].Points.Add(y[w]);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

            listBox1.Items.Clear();
            listBox2.Items.Clear();

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            textBox1.Clear();
        }
    }
}
