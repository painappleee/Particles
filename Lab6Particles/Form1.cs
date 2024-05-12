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

            int offsetAngle = 4;

            float R = Math.Abs((int)picDisplay.Width / 2 - emitterV.X);

            for (int i=0; i < 3; i++)
            {
                float alphaV = emitterV.Direction+offsetAngle*i;

                float dXV = R * (float)Math.Cos(alphaV / 180 * Math.PI);
                float dYV = R * (float)Math.Sin(alphaV / 180 * Math.PI);

                AntiGravityPoint AgPoint1V = new AntiGravityPoint();
                AgPoint1V.X = emitterV.X + dXV;
                AgPoint1V.Y = emitterV.Y + dYV;

                emitterG.impactPoints.Add( AgPoint1V );

                if (i != 0)
                {
                    AntiGravityPoint AgPoint2V = new AntiGravityPoint();
                    AgPoint2V.X = emitterV.X + dXV;
                    AgPoint2V.Y = emitterV.Y - dYV;

                    emitterG.impactPoints.Add( AgPoint2V );

                }

                float alphaG = emitterG.Direction - offsetAngle * i;

                float dXG = R * (float)Math.Cos(alphaG / 180 * Math.PI);
                float dYG = R * (float)Math.Sin(alphaG / 180 * Math.PI);

                AntiGravityPoint AgPoint1G = new AntiGravityPoint();
                AgPoint1G.X = emitterG.X + dXG;
                AgPoint1G.Y = emitterG.Y + dYG;

                emitterV.impactPoints.Add(AgPoint1G);

                if (i != 0)
                {
                    AntiGravityPoint AgPoint2G = new AntiGravityPoint();
                    AgPoint2G.X = emitterG.X + dXG;
                    AgPoint2G.Y = emitterG.Y - dYG;

                    emitterV.impactPoints.Add(AgPoint2G);

                }








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
