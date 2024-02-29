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
    public partial class Form4 : Form
    {
        Form1 newForm1;

        int N = 50;
        int M = 20;
        int MM = 15;

        Random random = new Random();

        double sogl(double[] x, double[] k)
        {
            int i;
            double sym = 0;

            for (i = 0; i < N; i++)
                sym = sym + x[i] * k[N - 1 - i];

            return sym;
        }

        static private double gauss(Random random)
        {
            return random.NextDouble() / Math.Sqrt(5);
        }

        public Form4(Form1 newForm1)
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
            double porog = 0;
            double z = 0, A;
            int a = 1;

            double[] s = new double[N];
            double[] k = new double[N];
            double[] x = new double[N];

            double[] mass_porog = new double[M];
            double[] veroa = new double[M];

            double[] d_prav = new double[MM];

            int i, j, n;
            long nn;
            double disp;

            bool q = false;
            try
            {
                porog = Convert.ToDouble(textBox1.Text);
                N = Convert.ToInt32(textBox2.Text);
                M = Convert.ToInt32(textBox3.Text);
                MM = Convert.ToInt32(textBox4.Text);
                if ((porog <= 0) || (N <= 0) || (M <= 0) || (MM <= 0) || (M >= N))
                    MessageBox.Show("Введено неположительное значение, значение MM превышает значение M или значение M превышает значение N. Повторите попытку!", "Ошибка ввода данных");
                else q = true;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Не введено значение. Повторите попытку!", "Ошибка ввода данных");
            }

            if (q)
            {
                try
                {
                    chart1.Series[0].Points.Clear();
                    chart1.Series[1].Points.Clear();

                    listBox1.Items.Clear();
                    listBox2.Items.Clear();

                    for (i = 0; i < N; i++)
                        s[i] = -Math.Sin(2.0 * Math.PI * i / N);

                    for (i = 0; i < N; i++)
                        k[i] = s[N - 1 - i];

                    disp = 0;

                    for (i = 0; i < 200; i++)
                    {
                        for (j = 0; j < N; j++)
                            x[j] = gauss(random);
                        z = sogl(x, k);
                        disp = disp + z * z;
                    }

                    disp = disp / 200;

                    for (i = 0; i < M; i++)
                    {
                        mass_porog[i] = Math.Sqrt(disp) * (1.0 + 0.1 * i);

                        for (nn = 0; nn < 30000L; nn++)
                        {
                            for (j = 0; j < N; j++)
                                x[j] = gauss(random);
                            z = sogl(x, k);
                            for (j = 0; j < M; j++)
                                if (z >= mass_porog[j])
                                    veroa[j]++;
                        }

                        for (j = 0; j < M; j++)
                            veroa[j] = veroa[j] / 30000;

                        for (n = 0; n < MM; n++)
                        {
                            A = 0.2 + 0.02 * n;

                            for (j = 0; j < 200; j++)
                            {
                                for (i = 0; i < N; i++)
                                    x[i] = gauss(random) - A * s[i];

                                z = sogl(x, k);

                                if (-z >= porog)
                                    d_prav[n] = d_prav[n] + 1.0 / 200;
                            }

                            if ((d_prav[n] == 0.95) || ((d_prav[n] > 0.93) && (d_prav[n] < 0.97)))
                            {
                                listBox1.Items.Add(Math.Round(d_prav[n], 5));
                                listBox2.Items.Add(Math.Round(Math.Abs(a * d_prav[n] * z), 5));
                            }

                            for (int w = 0; w < N; w++)
                            {
                                chart1.Series[0].Points.Add(x[w]);
                                chart1.Series[1].Points.Add(k[w]);
                            }
                        }
                    }
                }
                catch (System.Exception)
                {

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }
    }
}
