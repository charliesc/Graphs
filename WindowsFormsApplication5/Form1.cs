using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            addInput();


        }

        Point startControl = new Point(0,0);
        List<TextBox> allInputs = new List<TextBox>();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addInput();

        }

        private void addInput()
        {
            Label label = new Label();
            label.Text = "y = ";
            label.Width = 25;
            TextBox textBox = new TextBox();
            textBox.Width = pnlInputs.Width - label.Width - 25;
            label.Location = startControl;
            textBox.Location = new Point(startControl.X + label.Width, startControl.Y);
            startControl = new Point(startControl.X, startControl.Y + textBox.Height + 10);
            pnlInputs.Controls.Add(label);
            pnlInputs.Controls.Add(textBox);
            allInputs.Add(textBox);
        }

        
        private void pnlDraw_Click(object sender, EventArgs e)
        {
            UpdateImage();
        }

        private void UpdateImage()
        {
            Bitmap bmp = new Bitmap(pnlCS.Width, pnlCS.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            //g.DrawEllipse(new Pen(Color.BlanchedAlmond,5.0f), 50, 50, 15, 13);
            Parser parser;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int biasX = pnlCS.Width / 2;
            int biasY = pnlCS.Height / 2;
            g.DrawLine(new Pen(Color.Black), 0, biasY, pnlCS.Width, biasY);
            g.DrawLine(new Pen(Color.Black), biasX, 0, biasX, pnlCS.Height);
            //path.FillMode = System.Drawing.Drawing2D.FillMode.Winding
            g.FillPolygon(new SolidBrush(Color.Black), new Point[] {new Point(pnlCS.Width - 10, biasY - 3), 
                new Point(pnlCS.Width, biasY), 
                new Point(pnlCS.Width - 10, biasY + 3)
            });
            g.FillPolygon(new SolidBrush(Color.Black), new Point[] {new Point(biasX - 3, 10-2), 
                new Point(biasX, -2), 
                new Point(biasX + 3, 10-2)
            });
            HashSet<Color> used = new HashSet<Color>();
            Random rand = new Random();
            foreach (TextBox t in allInputs)
            {
                if (t.Text == "") continue;
                parser = new Parser(t.Text);

                Pen pen = new Pen(Color.FromArgb(rand.Next() % 250, rand.Next() % 250, rand.Next() % 250), 2.0f);
                while (used.Contains(pen.Color))
                    pen = new Pen(Color.FromArgb(rand.Next() % 250, rand.Next() % 250, rand.Next() % 250), 2.0f);
                used.Add(pen.Color);

                List<Point> pts = new List<Point>();
                for (int i = 0; i <= pnlCS.Width; i++)
                {
                    try
                    {
                        double y = parser.Calculate((i - biasX) * trackBar1.Value / 1000.0);
                        if (y >= 99999) continue;
                        pts.Add(new Point(i, biasY - (int)Math.Ceiling(y)));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка вычисления: " + ex.Message, "Еггог");
                    }
                }
                try
                {
                    g.DrawLines(pen, pts.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка отрисовки: " + ex.Message, "Еггог");
                }

            }
            pnlCS.BackgroundImage = bmp;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            startControl = new Point(0, 0);
            allInputs = new List<TextBox>();
            allInputs.Clear();
            pnlInputs.Controls.Clear();
            pnlCS.BackgroundImage = new Bitmap(pnlCS.Width, pnlCS.Height);
            addInput();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateImage();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Bitmap|.bmp";
            if (sfd.ShowDialog() == DialogResult.OK)
                pnlCS.BackgroundImage.Save(sfd.FileName);
        }
    }
}
