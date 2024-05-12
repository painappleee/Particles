using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Particles
{
    public class Emitter
    {
        List<Particle> particles = new List<Particle>();
        public List<Point> gravityPoints = new List<Point>();


        public float GravitationX = 0;
        public float GravitationY = 1;

        public int MousePositionX = 0;
        public int MousePositionY = 0;

        public void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.Life -= 1;

                if (particle.Life < 0)
                {
                    particle.Life = 20 + Particle.random.Next(100);

                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;

                    var direction = (double)Particle.random.Next(360);
                    var speed = Particle.random.Next(10) + 1;

                    particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                    particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);


                    particle.Radius = Particle.random.Next(10) + 2;
                }
                else
                {
                    float gX = gravityPoints[0].X - particle.X;
                    float gY = gravityPoints[0].Y - particle.Y;

                    float r2 = gX*gX + gY * gY;
                    float M = 100;

                    particle.SpeedX += (gX) * M / r2;
                    particle.SpeedY += (gY) * M / r2;

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;

                }

            }

            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < 500)
                {
                    var particle = new ParticleColorful();

                    particle.FromColor = Color.Yellow;
                    particle.ToColor = Color.FromArgb(0, Color.Magenta);

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

        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            foreach (var point in gravityPoints)
            {
                g.FillEllipse(
                    new SolidBrush(Color.Orange),
                    point.X-5,
                    point.Y-5,
                    10,
                    10
                 );
            }
        }

    }
}
