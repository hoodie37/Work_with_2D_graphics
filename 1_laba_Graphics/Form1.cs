using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;

namespace _1_laba_Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

         Point p1 = new Point(500, 5);
        Point p2 = new Point(600, 60);

        SolidBrush b = new SolidBrush(Color.Blue);
      

        Single[] s = { 0, 130, 205, 290, 360 };
        SolidBrush[] b1 = {new SolidBrush(Color.Yellow),
        new SolidBrush(Color.Blue),new SolidBrush(Color.Green),new SolidBrush(Color.Red)}; 
       

        Pen p = new Pen(Brushes.Red,5);
        Rectangle r = new Rectangle(50,50,100,100);



        private void pBox_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
             
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics();
            g.Clear(Color.White);
            Point p1 = new Point(50, 50);
            Point p2 = new Point(150, 150);
            Pen p = new Pen(Brushes.Red, 5);
            g.DrawLine(p, p1, p2);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics();
            g.Clear(Color.White);
            g.DrawEllipse(p, r);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics();
            g.Clear(Color.White);

            Point pp1 = new Point(10, 50);
            Point pp2 = new Point(110, 150);
            Point pp3 = new Point(210, 30);
            Point pp4 = new Point(310, 50);
            g.DrawBezier(p, pp1, pp2, pp3, pp4);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics();
            g.Clear(Color.White);
            Point[] MyPoints = {new Point(10, 100),
        new Point(75, 10), new Point(80, 50),
        new Point(100, 150), new Point(125, 80),
        new Point(175, 200), new Point(200, 80)};
            g.DrawBeziers(p, MyPoints);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics();
            g.Clear(Color.White);
            Single start = 0.0F;
            Single end = 120.0F;
           g.FillPie(b, r, start, end);

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics();
            g.Clear(Color.White);
            g.DrawEllipse(p, r);
            for (int i = 1; i < 5; i++)
            {
                SolidBrush b = b1[i-1];

                g.FillPie(b, r, s[i-1],
           s[i] - s[i - 1]);
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics();
            g.Clear(Color.White);
            PointF p1 = new PointF(30.0F, 50.0F);
            PointF p2 = new PointF(100.0F, 75.0F);
            PointF p3 = new PointF(200.0F, 50.0F);
            PointF p4 = new PointF(250.0F, 75.0F);
            PointF p5 = new PointF(300.0F, 100.0F);
            PointF p6 = new PointF(350.0F, 200.0F);
            PointF p7 = new PointF(200.0F, 200.0F);
            PointF p8 = new PointF(130.0F, 230.0F);
            PointF[] pp = { p1, p2, p3, p4, p5, p6, p7, p8 };
            HatchBrush h = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.DarkGoldenrod, Color.Crimson);
            FillMode f = FillMode.Winding;
            g.FillPolygon(h, pp, f);

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics();
            g.Clear(Color.White);
            LinearGradientBrush line = new LinearGradientBrush(new Point(0, 10),new Point(200, 10), Color.DarkOliveGreen, Color.DarkOrchid);
            PointF[] first = {new PointF(0.0F, 50.0F),new PointF(100.0F, 100.0F), new PointF(200.0F, 55.0F),new PointF(250.0F, 100.0F)};
            PointF[] second = {new PointF(300.0F, 150.0F), new PointF(350.0F, 250.0F), new PointF(200.0F, 250.0F),new PointF(130.0F, 280.0F) };
            GraphicsPath path = new GraphicsPath() ;
            path.AddPolygon(first);
            path.AddPolygon(second);
            g.FillPath(line, path);
        }

        private void Images_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics();
            g.Clear(Color.White);
            Image img;
            img = Image.FromFile("D:\\image1.png");
            pBox.Image = img;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            Stream mystream;
            OpenFileDialog MyopenFileDialog = new OpenFileDialog();

            MyopenFileDialog.InitialDirectory = "D:\\";
            MyopenFileDialog.Filter = "Images|*.PNG;*JPG;*.TIF;*BMP";
            MyopenFileDialog.FilterIndex = 2;
            MyopenFileDialog.RestoreDirectory = true;

            if (MyopenFileDialog.ShowDialog() == DialogResult.OK) {
                mystream = MyopenFileDialog.OpenFile();
                if ( mystream != null) {
                    pBox.Image = Image.FromFile(MyopenFileDialog.FileName);
                    mystream.Close();
                 }
            }

        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics();
            g.Clear(Color.White);
            Image img;
            img = Image.FromFile("D:\\image1.png");
            pBox.Image = img;
            pBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pBox.Invalidate();
            int tmp=0;
            tmp = pBox.Width;
            pBox.Width = pBox.Height;
            pBox.Width = tmp;
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics();
            g.Clear(Color.White);
            PointF[] Mypoints = {
                new Point(0, 0),new Point(100, 10),new Point(200, 200), new Point(100, 400)};
            GraphicsPath MyPath = new GraphicsPath();
            MyPath.AddPolygon(Mypoints);

            

            RectangleF clipRect =new RectangleF(0, 0, 300, 300);

            g.SetClip(MyPath);
            g.DrawImage(Image.FromFile("D:\\image1.png"), 0, 0);

        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics();
            g.Clear(Color.White);
            pBox.Image = Image.FromFile("D:\\image1.PNG");

        Bitmap bitmap = new Bitmap(pBox.Image);
            pBox.Image = bitmap;
       

            int x;
            int y;
            //Для ширины изображения
            for (x = 0; x <= bitmap.Width - 1; x++)
            {
                //Для высоты изображения
                for (y = 0; y <= bitmap.Height - 1; y += 1)
                {
                    //Пиксель изображения на замену
                    Color oldColor = bitmap.GetPixel(x, y);
                    //Задание нового пикселя для замены старого
                    Color newColor;
                    //Задаем значение нового пикселя
                    newColor = Color.FromArgb(oldColor.A, 255 - oldColor.R, 255 - oldColor.G, 255 - oldColor.B);
                    //Заменяем новый пиксель вместо старого
                    bitmap.SetPixel(x, y, newColor);
                }
            }
           
            pBox.Image = bitmap;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics();
            g.Clear(Color.White);
            pBox.Image = Image.FromFile("D:\\image1.PNG");

            Bitmap image2 = new Bitmap(pBox.Image);
            

            int[,] arrR = new int[image2.Width, image2.Height];
            int[,] arrG = new int[image2.Width, image2.Height];
            int[,] arrB = new int[image2.Width, image2.Height];

            for (int i = 0; i < image2.Width; i++)
            {
                for (int j = 0; j < image2.Height; j++)
                {
                    arrR[i, j] = image2.GetPixel(i, j).R;
                    arrG[i, j] = image2.GetPixel(i, j).G;
                    arrB[i, j] = image2.GetPixel(i, j).B;
                }
            }

            for (int i = 1; i < image2.Width - 1; i++)
            {
                for (int j = 1; j < image2.Height - 1; j++)
                {
                    int arrRSum = 0, arrGSum = 0, arrBSum = 0;
                    int arrsrR = 0, arrsrG = 0, arrsrB = 0;
                    for (int x = -1; x < 2; x++)
                    {
                        for (int y = -1; y < 2; y++)
                        {
                            arrRSum = arrRSum + arrR[i + x, j + y];
                            arrGSum = arrGSum + arrG[i + x, j + y];
                            arrBSum = arrBSum + arrB[i + x, j + y];

                        }
                    }
                    arrsrR = arrRSum / 9;
                    arrsrG = arrGSum / 9;
                    arrsrB = arrBSum / 9;
                    image2.SetPixel(i, j, Color.FromArgb(arrsrR, arrsrG, arrsrB));

                }
            }

            pBox.Image = image2;
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            Graphics g = pBox.CreateGraphics();
            g.Clear(Color.White);
            pBox.Image = Image.FromFile("D:\\image1.PNG");

            Bitmap image2 = new Bitmap(pBox.Image);
        }

        public static Image ChangeBrightness(Bitmap image, float brightness)
        {
            ImageAttributes imageAttributes = new ImageAttributes();
            int width = image.Width;
            int height = image.Height;

            float[][] colorMatrixElements = {
            new float[] {brightness, 0, 0, 0, 0},
            new float[] {0, brightness, 0, 0, 0},
            new float[] {0, 0, brightness, 0, 0},
            new float[] {0, 0, 0, 1, 0},
            new float[] {0, 0, 0, 0, 1}
            };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, width,
                height,
                GraphicsUnit.Pixel,
                imageAttributes);
            return image;
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            Graphics g1 = pBox.CreateGraphics();
            g1.Clear(Color.White);
            pBox.Image = Image.FromFile("D:\\image1.PNG");

            Bitmap ub = new Bitmap(pBox.Image);

            pBox.Image = ChangeBrightness(ub, 2);
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            //toolStripButton16.Text = "RezkostFilter";
            Graphics g1 = pBox.CreateGraphics();
            g1.Clear(Color.White);
            pBox.Image = Image.FromFile("D:\\image1.PNG");

            Bitmap bitmap = new Bitmap(pBox.Image);
            Bitmap tempmap = new Bitmap(pBox.Image);
            int x;
            int y;
            int red, green, blue;
            //Для ширины изображения
            for (x = 1; x < tempmap.Height - 2; x++)
            {
                //Для высоты изображения
                for (y = 1; y < tempmap.Width - 2; y++)
                {
                    red = Convert.ToInt32(tempmap.GetPixel(y, x).R) + Convert.ToInt32(0.5 * (tempmap.GetPixel(y, x).R)) - Convert.ToInt32(tempmap.GetPixel(y - 1, x - 1).R);
                    green = Convert.ToInt32(tempmap.GetPixel(y, x).G + 0.5 * (tempmap.GetPixel(y, x).G) - tempmap.GetPixel(y - 1, x - 1).G);
                    blue = Convert.ToInt32(tempmap.GetPixel(y, x).B + 0.5 * (tempmap.GetPixel(y, x).B) - tempmap.GetPixel(y - 1, x - 1).B);
                    red = Math.Min(Math.Max(red, 0), 255);
                    green = Math.Min(Math.Max(green, 0), 255);
                    blue = Math.Min(Math.Max(blue, 0), 255);


                    bitmap.SetPixel(y, x, Color.FromArgb(red, green, blue));

                }
            }

            pBox.Image = bitmap;
        }
    }
}
