using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Privod
{
    public partial class Form1 : Form
    {
        DataTable results = new DataTable();
        double P, LMBD, N1, PerCent, Nnom, Mn, Sn, Sk, Mkr, M = 0, n, S = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            results.Columns.Add("S", typeof(string));
            results.Columns.Add("0,2", typeof(double));
            results.Columns.Add("0,3", typeof(double));
            results.Columns.Add("0,4", typeof(double));
            results.Columns.Add("0,5", typeof(double));
            results.Columns.Add("0,6", typeof(double));
            results.Columns.Add("0,7", typeof(double));
            results.Columns.Add("0,8", typeof(double));
            results.Columns.Add("0,9", typeof(double));
            results.Columns.Add("1", typeof(double));
        }

        public Form1()
        {
            InitializeComponent();
        }

        public struct resultsStructN
        {
            public double N;
            public double S;
            public resultsStructN (double N, double S)
            {
                this.N = N;
                this.S = S;
            }
        }
        public struct resultsStructM
        {
            public double M;
            public double S;
            public resultsStructM(double M, double S)
            {
                this.S = S;
                this.M = M;
            }
        }

        List<resultsStructM> ResM = new List<resultsStructM>();
        List<resultsStructN> ResN = new List<resultsStructN>();

        private void check()
        {
            if (textBoxLMBD.Text == "" || textBoxN1.Text == "" || textBoxPC.Text == "" || textBoxPn.Text == "")
            {
                MessageBox.Show("Ты драки хочешь? Введи входные данные!");
                return;
            }
            else
            {
                LMBD = double.Parse(textBoxLMBD.Text);
                N1 = double.Parse(textBoxN1.Text);
                PerCent = double.Parse(textBoxPC.Text);
                P = double.Parse(textBoxPn.Text);
            }
        }

        private void doBoth()
        {
            this.chart1.Series[0].Points.Clear();
            this.chart2.Series[0].Points.Clear();
            while (S <= 1)
            {
                M = 2 * Mkr / ((S / Sk) + (Sk / S));
                n = N1 * (1 - S);
                ResM.Add(new resultsStructM(M, S));
                ResN.Add(new resultsStructN(n, S));
                this.chart2.Series[0].Points.AddXY(S, M);
                this.chart1.Series[0].Points.AddXY(M, n);
                S += 0.1;
            }
            results.Rows.Add("M", ResM[2].M, ResM[3].M, ResM[4].M, ResM[5].M, ResM[6].M, ResM[7].M, ResM[8].M, ResM[9].M, ResM[10].M);
            results.Rows.Add("n", ResN[2].N, ResN[3].N, ResN[4].N, ResN[5].N, ResN[6].N, ResN[7].N, ResN[8].N, ResN[9].N, ResN[10].N);
            dataGridView1.DataSource = results;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            this.chart2.Series[0].Points.Clear();
            textBoxPn.Text = ("");
            textBoxN1.Text = ("");
            textBoxLMBD.Text = ("");
            textBoxPC.Text = ("");
            label1.Text = (" ");
            label2.Text = (" ");
            label3.Text = (" ");
            label4.Text = (" ");
            label5.Text = (" ");
            results.Rows.Clear();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            check();
            label1.Text = Convert.ToString(Nnom = N1 * PerCent / 100);
            label2.Text = Convert.ToString(Mn = 9.55 * (P / Nnom));
            label3.Text = Convert.ToString(Sn = (N1 - Nnom) / N1);
            label4.Text = Convert.ToString(Sk = Sn * (LMBD + Math.Sqrt(Math.Pow(LMBD, 2) - 1)));
            label5.Text = Convert.ToString(Mkr = LMBD * Mn);
            doBoth();
        }
    }
}
