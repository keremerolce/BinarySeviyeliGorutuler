using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinarySeviyeliGörüntüler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "resimler|*.bmp|All Files|*.*";
            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            pictureBox1.ImageLocation = sfd.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap Binary = BinaryYap(image);

            pictureBox2.Image = Binary;
        }

        private Bitmap BinaryYap(Bitmap image)
        {
            Bitmap gri = griyap(image);
            int esik = 100;
            int temp = 0;
            Color renk;
            for (int i = 0; i < gri.Height-1; i++)
            {
                for (int j = 0; j < gri.Width-1; j++)
                {
                    temp = gri.GetPixel(j, i).R;

                    if (temp<esik)
                    {
                        renk = Color.FromArgb(0, 0, 0);
                        gri.SetPixel(j, i, renk);
                    }
                    else
                    {
                        renk = Color.FromArgb(255,255,255);
                        gri.SetPixel(j,i,renk);
                    }
                }
            }

            return image;
        }
        private Bitmap griyap(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Height - 1; i++)
            {
                for (int j = 0; j < bmp.Width - 1; j++)
                {
                    int deger = (bmp.GetPixel(j, i).R + bmp.GetPixel(j, i).G + bmp.GetPixel(j, i).B) / 3;
                    Color renk;
                    renk = Color.FromArgb(deger, deger, deger);

                    bmp.SetPixel(j, i, renk);
                }
            }
            return bmp;
        }
    }
}
