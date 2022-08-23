using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace image001
{
    public partial class Form1 : Form
    {
        Bitmap SRC_IMG , DEST_IMG , Temp_IMG;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[,] K = new double[3, 3];
            K[0, 0] = 1 / 11.0; K[0, 1] = 1 / 11.0; K[0, 2] = 1 / 11.0;
            K[1, 0] = 1 / 11.0; K[1, 1] = 3 / 11.0; K[1, 2] = 1 / 11.0;
            K[2, 0] = 1 / 11.0; K[2, 1] = 1 / 11.0; K[2, 2] = 1 / 11.0;
            Convolution(K);
            pictureBox2.Image = DEST_IMG;
        }
        private void Convolution(double[,]K)
        {
            
            for (int x = 1; x < pictureBox1.Image.Width - 1; x++)
                for (int y = 1; y < pictureBox1.Image.Height - 1; y++)
                {
                    int ResR = 0;
                    int ResG = 0;
                    int ResB = 0;
                    //Convolution
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                        {
                            ResR += (int)(K[i, j] * SRC_IMG.GetPixel(x + i - 1, y + j - 1).R);
                            ResG += (int)(K[i, j] * SRC_IMG.GetPixel(x + i - 1, y + j - 1).G);
                            ResB += (int)(K[i, j] * SRC_IMG.GetPixel(x + i - 1, y + j - 1).B);
                        }
                    //Assign to new image
                    if (ResR > 255) ResR = 255; else if (ResR < 0) ResR = 0;
                    if (ResG > 255) ResG = 255; else if (ResG < 0) ResG = 0;
                    if (ResB > 255) ResB = 255; else if (ResB < 0) ResB = 0;
                    DEST_IMG.SetPixel(x, y, Color.FromArgb(ResR, ResG, ResB));
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[,] K = new double[3, 3];
            K[0, 0] = 0.0275; K[0, 1] = 0.1102; K[0, 2] = 0.0275;
            K[1, 0] = 0.1102; K[1, 1] = 0.4421; K[1, 2] = 0.1102;
            K[2, 0] = 0.0275; K[2, 1] = 0.1102; K[2, 2] = 0.0275;
            Convolution(K);
            pictureBox2.Image = DEST_IMG;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double[,] K = new double[3, 3];
            K[0, 0] = 0; K[0, 1] = -1; K[0, 2] = 0;
            K[1, 0] = -1; K[1, 1] = 4; K[1, 2] = -1;
            K[2, 0] = 0; K[2, 1] = -1; K[2, 2] = 0;
            Convolution(K);
            pictureBox2.Image = DEST_IMG;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double[,] K = new double[3, 3];
            K[0, 0] = -1; K[0, 1] = -1; K[0, 2] = -1;
            K[1, 0] = -1; K[1, 1] = 8; K[1, 2] = -1;
            K[2, 0] = -1; K[2, 1] = -1; K[2, 2] = -1;
            Convolution(K);
            pictureBox2.Image = DEST_IMG;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double[,] K = new double[3, 3];
            K[0, 0] = 0; K[0, 1] = -1; K[0, 2] = 0;
            K[1, 0] = -1; K[1, 1] = 5; K[1, 2] = -1;
            K[2, 0] = 0; K[2, 1] = -1; K[2, 2] = 0;
            Convolution(K);
            pictureBox2.Image = DEST_IMG;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double[,] K = new double[3, 3];
            K[0, 0] = -1; K[0, 1] = -1; K[0, 2] = -1;
            K[1, 0] = -1; K[1, 1] = 9; K[1, 2] = -1;
            K[2, 0] = -1; K[2, 1] = -1; K[2, 2] = -1;
            Convolution(K);
            pictureBox2.Image = DEST_IMG;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox2.Image;
            SRC_IMG = DEST_IMG;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            textBox1.Text = hScrollBar1.Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            for(int x=0; x<pictureBox1.Image.Width;x++)
                for(int y=0; y<pictureBox1.Image.Height;y++)
                {
                    int ResR;
                    int ResG;
                    int ResB;
                    ResR = hScrollBar1.Value + SRC_IMG.GetPixel(x, y).R;
                    ResG = hScrollBar1.Value + SRC_IMG.GetPixel(x, y).G;
                    ResB = hScrollBar1.Value + SRC_IMG.GetPixel(x, y).B;
                    
                    if (ResR > 255) ResR = 255; else if (ResR < 0) ResR = 0;
                    if (ResG > 255) ResG = 255; else if (ResG < 0) ResG = 0;
                    if (ResB > 255) ResB = 255; else if (ResB < 0) ResB = 0;

                    //Assign to new image
                    DEST_IMG.SetPixel(x, y, Color.FromArgb(ResR, ResG, ResB));
                }
            pictureBox2.Image = DEST_IMG;
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            textBox2.Text = hScrollBar2.Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int C = hScrollBar1.Value;
            double F = (259.0 * (C + 255.0)) / (255.0 * (255.0 - C));
            for(int x=0;x<pictureBox1.Image.Width;x++)
                for(int y=0;y<pictureBox1.Image.Height;y++)
                {
                    double ResR,ResG, ResB;

                    ResR = F * (SRC_IMG.GetPixel(x, y).R - 128) + 128;
                    ResG = F * (SRC_IMG.GetPixel(x, y).G - 128) + 128;
                    ResB = F * (SRC_IMG.GetPixel(x, y).B - 128) + 128;

                    if (ResR > 255) ResR = 255; else if (ResR < 0) ResR = 0;
                    if (ResG > 255) ResG = 255; else if (ResG < 0) ResG = 0;
                    if (ResB > 255) ResB = 255; else if (ResB < 0) ResB = 0;

                    //Assign to new image
                    DEST_IMG.SetPixel(x, y, Color.FromArgb((int)ResR, (int)ResG,(int) ResB));
                }
            pictureBox2.Image = DEST_IMG;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            double Y = hScrollBar3.Value/10.0;
            for (int x = 0; x < pictureBox1.Image.Width; x++)
                for (int y = 0; y < pictureBox1.Image.Height; y++)
                {
                    double ResR, ResG, ResB;

                    ResR = 255 * Math.Pow(SRC_IMG.GetPixel(x, y).R / 255.0, 1 / Y);
                    ResG = 255 * Math.Pow(SRC_IMG.GetPixel(x, y).G / 255.0, 1 / Y);
                    ResB = 255 * Math.Pow(SRC_IMG.GetPixel(x, y).B / 255.0, 1 / Y);

                    if (ResR > 255) ResR = 255; else if (ResR < 0) ResR = 0;
                    if (ResG > 255) ResG = 255; else if (ResG < 0) ResG = 0;
                    if (ResB > 255) ResB = 255; else if (ResB < 0) ResB = 0;

                    //Assign to new image
                    DEST_IMG.SetPixel(x, y, Color.FromArgb((int)ResR, (int)ResG, (int)ResB));
                }
            pictureBox2.Image = DEST_IMG;
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            textBox4.Text = (hScrollBar3.Value/10.0).ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DEST_IMG.SetResolution(pictureBox1.Image.Width / 2, pictureBox1.Image.Height / 2);
            for(int x=0;x<pictureBox1.Image.Width-2; x+=2)
                for(int y=0;y<pictureBox1.Image.Height-2;y+=2)
                {
                    int PivotR = (SRC_IMG.GetPixel(x, y).R + SRC_IMG.GetPixel(x + 1, y).R +
                        SRC_IMG.GetPixel(x, y + 1).R + SRC_IMG.GetPixel(x + 1, y + 1).R) / 4;

                    int PivotG = (SRC_IMG.GetPixel(x, y).G + SRC_IMG.GetPixel(x + 1, y).G +
                        SRC_IMG.GetPixel(x, y + 1).G + SRC_IMG.GetPixel(x + 1, y + 1).G) / 4;

                    int PivotB = (SRC_IMG.GetPixel(x, y).B + SRC_IMG.GetPixel(x + 1, y).B +
                        SRC_IMG.GetPixel(x, y + 1).B + SRC_IMG.GetPixel(x + 1, y + 1).B) / 4;

                    //Assign to new image 
                    DEST_IMG.SetPixel(x/2, y/2,Color.FromArgb(PivotR,PivotG,PivotB ));
                }
            pictureBox2.Image = DEST_IMG;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < (pictureBox1.Image.Width - 2)/2; x++)
                for (int y = 0; y < (pictureBox1.Image.Height - 2)/2; y++)
                {
                    int PivotR = SRC_IMG.GetPixel(x, y).R;
                    int PivotG = SRC_IMG.GetPixel(x, y).G;
                    int PivotB = SRC_IMG.GetPixel(x, y).B;

                    //Assign to new image
                    DEST_IMG.SetPixel(x * 2, y * 2, Color.FromArgb(PivotR, PivotG, PivotB));
                    DEST_IMG.SetPixel(x * 2+1, y * 2, Color.FromArgb(PivotR, PivotG, PivotB));
                    DEST_IMG.SetPixel(x * 2 , y * 2+1, Color.FromArgb(PivotR, PivotG, PivotB));
                    DEST_IMG.SetPixel(x * 2+1, y * 2+1, Color.FromArgb(PivotR, PivotG, PivotB));
                }
            pictureBox2.Image = DEST_IMG;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < (pictureBox1.Image.Width - 2) / 2; x++)
                for (int y = 0; y < (pictureBox1.Image.Height - 2) / 2; y++)
                {
                    int PivotR = SRC_IMG.GetPixel(x, y).R;
                    int PivotG = SRC_IMG.GetPixel(x, y).G;
                    int PivotB = SRC_IMG.GetPixel(x, y).B;

                    //Assign to new image
                    Temp_IMG.SetPixel(x * 2, y * 2, Color.FromArgb(PivotR, PivotG, PivotB));
                    Temp_IMG.SetPixel(x * 2 + 1, y * 2, Color.FromArgb(PivotR, PivotG, PivotB));
                    Temp_IMG.SetPixel(x * 2, y * 2 + 1, Color.FromArgb(PivotR, PivotG, PivotB));
                    Temp_IMG.SetPixel(x * 2 + 1, y * 2 + 1, Color.FromArgb(PivotR, PivotG, PivotB));
                }
            for(int x=0; x < (pictureBox1.Image.Width - 2) / 2;x++)
                for(int y=0; y<(pictureBox1.Image.Height-2)/2;y++)
                {
                    int PivotR = (Temp_IMG.GetPixel(x, y).R + Temp_IMG.GetPixel(x + 1, y).R +
                        Temp_IMG.GetPixel(x, y + 1).R + Temp_IMG.GetPixel(x + 1, y + 1).R) / 4;

                    int PivotG = (Temp_IMG.GetPixel(x, y).G + Temp_IMG.GetPixel(x + 1, y).G +
                        Temp_IMG.GetPixel(x, y + 1).G + Temp_IMG.GetPixel(x + 1, y + 1).G) / 4;

                    int PivotB = (Temp_IMG.GetPixel(x, y).B + Temp_IMG.GetPixel(x + 1, y).B +
                        Temp_IMG.GetPixel(x, y + 1).B + Temp_IMG.GetPixel(x + 1, y + 1).B) / 4;

                    //Assign to new image 
                    DEST_IMG.SetPixel(x , y , Color.FromArgb(PivotR, PivotG, PivotB));
                }
            pictureBox2.Image = DEST_IMG;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            for(int x = 0; x<pictureBox1.Image.Width; x++)
                for(int y = 0; y<pictureBox1.Image.Height; y++)
                {
                    int x_ = x;
                    int y_ = pictureBox1.Image.Height-1-y;
                    int pivotR = SRC_IMG.GetPixel(x, y).R;
                    int pivotG = SRC_IMG.GetPixel(x, y).G;
                    int pivotB = SRC_IMG.GetPixel(x, y).B;
                    DEST_IMG.SetPixel(x_, y_, Color.FromArgb((int)pivotR, (int)pivotG, (int)pivotB));
                }
            pictureBox2.Image = DEST_IMG;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < pictureBox1.Image.Width; x++)
                for (int y = 0; y < pictureBox1.Image.Height; y++)
                {
                    int x_ = pictureBox1.Image.Width - 1 - x;
                    int y_ = y;
                    int pivotR = SRC_IMG.GetPixel(x, y).R;
                    int pivotG = SRC_IMG.GetPixel(x, y).G;
                    int pivotB = SRC_IMG.GetPixel(x, y).B;
                    DEST_IMG.SetPixel(x_, y_, Color.FromArgb((int)pivotR, (int)pivotG, (int)pivotB));          
                }
            pictureBox2.Image = DEST_IMG;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < pictureBox1.Image.Width; x++)
                for (int y = 0; y < pictureBox1.Image.Height; y++)
                {
                    int x_ = pictureBox1.Image.Width - 1 - x;
                    int y_ = pictureBox1.Image.Height - 1 - y;
                    int pivotR = SRC_IMG.GetPixel(x, y).R;
                    int pivotG = SRC_IMG.GetPixel(x, y).G;
                    int pivotB = SRC_IMG.GetPixel(x, y).B;
                    DEST_IMG.SetPixel(x_, y_, Color.FromArgb((int)pivotR, (int)pivotG, (int)pivotB));
                }
            pictureBox2.Image = DEST_IMG;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Bitmap Temp2_IMG=new Bitmap(SRC_IMG.Height , SRC_IMG.Width);
            for (int x = 0; x < pictureBox1.Image.Width; x++)
                for (int y = 0; y < pictureBox1.Image.Height; y++)
                {
                    int x_ = y;
                    int y_ = pictureBox1.Image.Width - 1 - x;
                    int PivotR = SRC_IMG.GetPixel(x, y).R;
                    int PivotG = SRC_IMG.GetPixel(x, y).G;
                    int PivotB = SRC_IMG.GetPixel(x, y).B;
                    Temp2_IMG.SetPixel(x_, y_, Color.FromArgb((int)PivotR, (int)PivotG, (int)PivotB));
                }
            pictureBox2.Image = Temp2_IMG;
            DEST_IMG = Temp2_IMG;
            Temp_IMG = Temp2_IMG;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Bitmap Temp2_IMG = new Bitmap(SRC_IMG.Height, SRC_IMG.Width);
            for (int x = 0; x < pictureBox1.Image.Width; x++)
                for (int y = 0; y < pictureBox1.Image.Height; y++)
                {
                    int x_ = pictureBox1.Image.Height - 1- y;
                    int y_ = x;
                    int PivotR = SRC_IMG.GetPixel(x, y).R;
                    int PivotG = SRC_IMG.GetPixel(x, y).G;
                    int PivotB = SRC_IMG.GetPixel(x, y).B;
                    Temp2_IMG.SetPixel(x_, y_, Color.FromArgb((int)PivotR, (int)PivotG, (int)PivotB));
                }
            pictureBox2.Image = Temp2_IMG;
            DEST_IMG = Temp2_IMG;
            Temp_IMG = Temp2_IMG;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            double TH;
            double.TryParse(textBox3.Text, out TH);
            TH = TH / 180.0 * Math.PI;
            int x0 = pictureBox1.Image.Width / 2;
            int y0 = pictureBox1.Image.Height / 2;
            for (int x = 0; x < pictureBox1.Image.Width; x++)
                for (int y = 0; y < pictureBox1.Image.Height; y++)
                {
                    int x_ = (int)Math.Round(Math.Cos(TH) * (x - x0) + Math.Sin(TH) * (y - y0));
                    int y_ = (int)Math.Round(-Math.Sin(TH) * (x - x0) + Math.Cos(TH) * (y - y0));

                    x_ = x0 + x_;
                    y_ = y0 + y_;

                    if (x_ < 0) x_ = 0;
                    if (y_ < 0) y_ = 0;
                    if (x_ > DEST_IMG.Width - 1) x_ = DEST_IMG.Width - 1;
                    if (y_ > DEST_IMG.Width - 1) y_ = DEST_IMG.Height - 1;

                    int PivotR = SRC_IMG.GetPixel(x, y).R;
                    int PivotG = SRC_IMG.GetPixel(x, y).G;
                    int PivotB = SRC_IMG.GetPixel(x, y).B;
                    if ((x_ >= 0) && (x_ < DEST_IMG.Width) && (y_ >= 0) && (y_ < DEST_IMG.Height))
                        DEST_IMG.SetPixel(x_, y_, Color.FromArgb((int)PivotR, (int)PivotG, (int)PivotB));
                }
            pictureBox2.Image = DEST_IMG;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("C:\\2.jpg");
            SRC_IMG = new Bitmap(pictureBox1.Image);
            DEST_IMG = new Bitmap(SRC_IMG.Width, SRC_IMG.Height);
            Temp_IMG= new Bitmap(SRC_IMG.Width, SRC_IMG.Height);
        }
    }
}
