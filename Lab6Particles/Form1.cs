﻿using System;
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

        List<Particle> particles = new List<Particle>();
        public Form1()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
           
        }

        private int MousePositionX = 0;
        private int MousePositionY = 0;

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            MousePositionX = e.X;
            MousePositionY = e.Y;
        }
        private void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.Life -= 1;

                if (particle.Life < 0)
                {
                    particle.Life = 20 + Particle.random.Next(100);

                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;

                    particle.Direction = Particle.random.Next(360);
                    particle.Speed = Particle.random.Next(10) + 1;
                    particle.Radius = Particle.random.Next(10) + 2;
                }
                else
                {
                    var directionInRadians = particle.Direction / 180 * Math.PI;
                    particle.X += (float)(particle.Speed * Math.Cos(directionInRadians));
                    particle.Y += (float)(particle.Speed * Math.Sin(directionInRadians));

                }

            }

            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < 500)
                {
                    var particle = new Particle();
                    particle.X = MousePositionX; 
                    particle.Y = MousePositionY;   
                    particles.Add(particle);
                }
                else
                {
                    break;
                }
                
            }
        }

        private void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.White);
                Render(g);

            }

            picDisplay.Invalidate();    
        }

        
    }
}
