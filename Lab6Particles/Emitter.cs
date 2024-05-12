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
        List<ParticleColorful> particles = new List<ParticleColorful>();
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();

        public int X;
        public int Y;
        public int Direction=0;
        public int Spreading = 360;
        public int SpeedMin = 1;
        public int SpeedMax = 10;
        public int RadiusMin = 2;
        public int RadiusMax = 10;
        public int LifeMin = 20;
        public int LifeMax = 140;

        public int ParticlesPerTick = 1;

        public Color ColorFrom = Color.White;
        public Color ColorTo = Color.FromArgb(0, Color.Black);

        public int ParticlesCount = 500;

        public float GravitationX = 0;
        public float GravitationY = 0;

        public int MousePositionX = 0;
        public int MousePositionY = 0;

        
        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick;

            foreach (var particle in particles)
            {

                if (particle.Life <= 0)
                {
                    if (particlesToCreate > 0)
                    {
                        particlesToCreate -= 1;
                        ResetParticle(particle);

                    }
                }
                else
                {

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;

                    particle.Life -= 1;

                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }


                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    

                }

            }

            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
               
            }
        }

        public virtual void ResetParticle(ParticleColorful particle)
        {
            particle.Life = Particle.random.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction
                + (double)Particle.random.Next(Spreading)
                - Spreading/2;
            var speed = Particle.random.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);


            particle.Radius = Particle.random.Next(RadiusMin, RadiusMax);
        }

        public virtual ParticleColorful CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }

        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            /*
            foreach (var particle in impactPoints)
            {
                particle.Render(g);
            }
            */

        }

    }

    public class TopEmitter : Emitter
    {
        public int Width;

        public override void ResetParticle(ParticleColorful particle)
        {
            base.ResetParticle(particle);

            particle.X = Particle.random.Next(Width);
            particle.Y = 0;

            particle.SpeedY = 1;
            particle.SpeedX = Particle.random.Next(-2, 2);
        }
    }
}


