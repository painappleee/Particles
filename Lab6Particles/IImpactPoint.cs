using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Particles
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;
        public Color color = Color.Red;

        public abstract void ImpactParticle(Particle particle);

        public void Render(Graphics g)
        {
            g.FillEllipse(
                   new SolidBrush(color),
                   X - 5,
                   Y - 5,
                   10,
                   10
                );
        }

    }

    public class GravityPoint : IImpactPoint
    {
        public int Power = 100;

        public override void ImpactParticle(Particle particle)
        {

            float gX = X - particle.X;
            float gY = Y - particle.Y;

            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX += (gX) * Power / r2;
            particle.SpeedY += (gY) * Power / r2;
        }
    }

    public class AntiGravityPoint : IImpactPoint
    {
        public float Power = 8.65f;

        public override void ImpactParticle(Particle particle)
        {

            float gX = X - particle.X;
            float gY = Y - particle.Y;

            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX -= (gX) * Power / r2;
            particle.SpeedY -= (gY) * Power / r2;
        }
    }

    public class DirectAntiGravityPoint : AntiGravityPoint
    {
        public Emitter emitter;
        public float R;
        public float angle = 0;
        public float offsetX = 0;

        public List<AntiGravityPoint> SubPoints;

        public DirectAntiGravityPoint(Emitter emitter, float R, int SubPointsNum = 4)
        {
            SubPoints = new List<AntiGravityPoint>();
            this.emitter = emitter;
            this.R = R;
            for (int i = 0; i < SubPointsNum; i++)
            {
                AntiGravityPoint point = new AntiGravityPoint();
                SubPoints.Add(point);
            }
        }

        public void Rotate(float ang)
        {
            this.angle = ang;
            float dx = (float)(R * Math.Cos(angle / 180 * Math.PI));
            float dy = (float)(R * Math.Sin(angle / 180 * Math.PI));

            X = emitter.X + dx + offsetX;
            Y = emitter.Y + dy;

            UpdateSubpoints();
        }

        public void Move(float offsetX)
        {
            this.offsetX = offsetX;

            foreach (var point in SubPoints)
            {
                point.Power = Power;
            }
            Rotate(angle);
            UpdateSubpoints();
        }

        public void UpdateSubpoints()
        {
            float angleOffset = 4;
            for (int i = 0; i < SubPoints.Count / 2; i++)
            {
                float ang = angle + angleOffset * (i + 1);
                float dx = (float)(R * Math.Cos(ang / 180 * Math.PI));
                float dy = (float)(R * Math.Sin(ang / 180 * Math.PI));
                SubPoints[i].X = emitter.X + dx + offsetX;
                SubPoints[i].Y = emitter.Y + dy;
            }
            for (int i = SubPoints.Count / 2; i < SubPoints.Count; i++)
            {
                float ang = angle - angleOffset * ((i - SubPoints.Count / 2) + 1);
                float dx = (float)(R * Math.Cos(ang / 180 * Math.PI));
                float dy = (float)(R * Math.Sin(ang / 180 * Math.PI));
                SubPoints[i].X = emitter.X + dx + offsetX;
                SubPoints[i].Y = emitter.Y + dy;
            }

        }

        public void SetColor(Color col)
        {
            this.color = col;
            foreach(var point in SubPoints)
            {
                point.color = col;
            }
        }
    }

}
