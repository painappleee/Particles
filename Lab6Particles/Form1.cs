using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6Particles
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitterV;
        Emitter emitterG;
        public Form1()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);



            this.emitterV = new Emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 15,
                SpeedMax = 15,
                ColorFrom = Color.LightGreen,
                ColorTo = Color.FromArgb(0, Color.DarkGreen),
                ParticlesPerTick = 10,
                X = 93,
                Y = picDisplay.Height / 2 + 25
            };

            this.emitterG = new Emitter
            {
                Direction = 180,
                Spreading = 10,
                SpeedMin = 15,
                SpeedMax = 15,
                ColorFrom = Color.Red,
                ColorTo = Color.FromArgb(0, Color.DarkRed),
                ParticlesPerTick = 10,
                X = picDisplay.Width - 92,
                Y = picDisplay.Height / 2 + 25
            };


            /*emitter.impactPoints.Add(new GravityPoint
            {
                X = picDisplay.Width / 2 +100,
                Y = picDisplay.Height / 2
            });

            emitter.impactPoints.Add(new GravityPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2
            });
            

            tbGravitation.Value = ((GravityPoint)emitter.impactPoints[0]).Power;
            lblGravitation.Text = ((GravityPoint)emitter.impactPoints[0]).Power+"";
            */

            int offset = 25;
            List<GravityPoint> gpoints = new List<GravityPoint>();
           

            for (int i=0; i < 5; i++)
            {
                AntiGravityPoint point1 = new AntiGravityPoint();
                point1.X = picDisplay.Width / 2;
                point1.Y = offset * i + picDisplay.Height/2+25;

               

                emitterV.impactPoints.Add(point1);
                if (i != 0)
                {
                    AntiGravityPoint point2 = new AntiGravityPoint();
                    point2.X = picDisplay.Width / 2;
                    point2.Y = -offset * i + picDisplay.Height / 2+25;
                    emitterV.impactPoints.Add(point2);
                    emitterG.impactPoints.Add(point2);
                }
                

                emitterG.impactPoints.Add(point1);  

            }


            /*
            emitter.gravityPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.75),
                Y = picDisplay.Height / 2
            });
            */

        }


        /*private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }
        */
       
 


        private void timer1_Tick(object sender, EventArgs e)
        {
            emitterV.UpdateState();
            emitterG.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.White);
                drawPersons(g);

                emitterV.Render(g);
                emitterG.Render(g);

            }

            picDisplay.Invalidate();    
        }
        
        private void drawPersons(Graphics g)
        {
            Bitmap bmpHogwarts = new Bitmap(Properties.Resources.hog4, new Size(picDisplay.Width+20, picDisplay.Height+20));
            g.DrawImage(bmpHogwarts, new Point(-20, -10));

            Bitmap bmpVolodya = new Bitmap(Properties.Resources.volodya2, new Size(84,120));
            g.DrawImage(bmpVolodya, new Point(0, picDisplay.Height/2-42));

            Bitmap bmpGarrick = new Bitmap(Properties.Resources.garrick2, new Size(84, 120));
            g.DrawImage(bmpGarrick, new Point(picDisplay.Width-84, picDisplay.Height / 2 - 42));

        }

        /*private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°";
        }

        private void tbSpreading_Scroll(object sender, EventArgs e)
        {
            emitter.Spreading = tbSpreading.Value;
            lblSpreading.Text = $"{tbSpreading.Value}°";
        }

        private void tbGravitation_Scroll(object sender, EventArgs e)
        {
            foreach (var p in emitter.impactPoints)
            {
                if (p is GravityPoint)
                {
                    (p as GravityPoint).Power = tbGravitation.Value;
                    lblGravitation.Text = tbGravitation.Value + "";
                }
            }
            
        }
        */
    }
}
