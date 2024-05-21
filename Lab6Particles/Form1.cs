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

            float R = Math.Abs((int)picDisplay.Width / 2 - emitterV.X);

            emitterV.DirectPoint = new DirectAntiGravityPoint(emitterV, R);

            emitterG.impactPoints.Add(emitterV.DirectPoint);
            foreach (var point in emitterV.DirectPoint.SubPoints)
            {
                emitterG.impactPoints.Add(point);
            }

            emitterG.DirectPoint = new DirectAntiGravityPoint(emitterG, R);
            emitterV.impactPoints.Add(emitterG.DirectPoint);
            foreach (var point in emitterG.DirectPoint.SubPoints)
            {
                emitterV.impactPoints.Add(point);
            }
            DirectionTrackBar_Scroll(null, null);
        }

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

            DebugLabel.Text = $"V.Power: {emitterV.DirectPoint.Power} | G.Power: {emitterG.DirectPoint.Power}";
            picDisplay.Invalidate();
        }

        private void drawPersons(Graphics g)
        {
            Bitmap bmpHogwarts = new Bitmap(Properties.Resources.hog4, new Size(picDisplay.Width + 20, picDisplay.Height + 20));
            g.DrawImage(bmpHogwarts, new Point(-20, -10));

            Bitmap bmpVolodya = new Bitmap(Properties.Resources.volodya2, new Size(84, 120));
            g.DrawImage(bmpVolodya, new Point(0, picDisplay.Height / 2 - 42));

            Bitmap bmpGarrick = new Bitmap(Properties.Resources.garrick2, new Size(84, 120));
            g.DrawImage(bmpGarrick, new Point(picDisplay.Width - 84, picDisplay.Height / 2 - 42));

        }

        private void DirectionTrackBar_Scroll(object sender, EventArgs e)
        {
            float angle = DirectionTrackBar.Value / 10;
            emitterV.DirectPoint.Rotate(angle);
            emitterG.DirectPoint.Rotate(-angle + 180);
        }

        private void ForceTrackBar_Scroll(object sender, EventArgs e)
        {
            int offset = ForceTrackBar.Value;
            emitterV.DirectPoint.Move(offset);
            emitterG.DirectPoint.Move(offset);

            if (offset > 0)
            {
                emitterV.DirectPoint.Power = (8.65f + 0.02487f * Math.Abs(offset));
                emitterG.DirectPoint.Power = (8.65f - 0.0047f * Math.Abs(offset));

                emitterG.Spreading = (int)(10 + 0.027f * Math.Abs(offset));
                emitterV.Spreading = 10;
            }
            else
            {
                emitterG.DirectPoint.Power = (8.65f + 0.02487f * Math.Abs(offset));
                emitterV.DirectPoint.Power = (8.65f - 0.0047f * Math.Abs(offset));

                emitterV.Spreading = (int)(10 + 0.027f * Math.Abs(offset));
                emitterG.Spreading = 10;
            }
        }
    }
}
