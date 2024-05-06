using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Particles
{
    internal class Particle
    {
        public int Radius;
        public float X;
        public float Y;

        public float Direction;
        public float Speed;
        public float Life;

        public static Random random = new Random();

        public Particle()
        {
            Direction = random.Next(360);
            Speed = random.Next(10) + 1;
            Radius = random.Next(10) + 2;
            Life = random.Next(100) + 20;
        }

        public void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);

            int alpha = (int)(k * 255);

            var color = Color.FromArgb(alpha, Color.Black);
            
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }
}
