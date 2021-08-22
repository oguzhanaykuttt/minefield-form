using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mayinTarlasi1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kolayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tarla(10, 10);
        }        
        private void ortaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tarla(13, 13);
        }

        private void zorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tarla(16, 16);
        }
        void Tarla(int satir, int sutun)
        {
            flowLayoutPanel1.Controls.Clear();
            int mayin = satir * sutun / 10;
            int[] mayinlar = new int[mayin];
            Random rnd = new Random();
            for (int i = 0; i < mayinlar.Length; i++)
            {
                int secilen = rnd.Next(0, satir * sutun);
                if (mayinlar.Contains(secilen) == true)
                {
                    i--;
                }
                else
                {
                    mayinlar[i] = secilen;
                }
            }
            for (int i = 0; i < satir * sutun; i++)
            {
                Button btn = new Button();
                btn.Width = btn.Height = 30;
                btn.BackColor = Color.Green;
                if (mayinlar.Contains(i) == true)
                    btn.Tag = true;
                else
                    btn.Tag = false;
                btn.Click += btn_Click;
                btn.Margin = new Padding(5, 5, 0, 0);
                flowLayoutPanel1.Controls.Add(btn);
            }
            flowLayoutPanel1.Width = sutun * 35;
            flowLayoutPanel1.Width = satir * 35;
            this.Width = flowLayoutPanel1.Width + 50;
            this.Height = flowLayoutPanel1.Height + 80;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button tiklanan = sender as Button;
            if ((bool)tiklanan.Tag==true)
            {
                foreach (Control item in flowLayoutPanel1.Controls)
                {
                    Button btn = item as Button;
                    if ((bool)btn.Tag==true)
                    {
                        btn.BackColor=Color.DarkRed;

                    }
                    else
                    {
                        btn.BackColor = Color.Green;
                    }
                }
                MessageBox.Show("Oyun Bitti. Yeni Oyun Başlatın!");
                flowLayoutPanel1.Controls.Clear();
            }
            else
            {
                tiklanan.BackColor = Color.Gray;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
