using System;
using System.Collections.Generic;
using TrueSync;


namespace CyclonePhysics
{
    public class ParticleContact
    {

        public Particle[] particles;

        public FP restitution;

        public TSVector contactNormal;

        public FP penetration;

        public TSVector[] particleMovements;


        public void resolve(FP duratoin)
        {
            this.resolveVelocity(duratoin);
            this.resolveInterpenetration(duratoin);
        }


        public FP calculateSeparatingVelocity()
        {
            TSVector relativeVelocity = particles[0].getVelocity();
            if (particles[1] != null)
            {
                relativeVelocity -= particles[1].getVelocity();
            }
            return relativeVelocity * contactNormal;
        }


        private void resolveVelocity(FP duration)
        {
            FP separatingVelocity = calculateSeparatingVelocity();

            if (separatingVelocity > FP.Zero)//处于脱离穿透的状态，no need resolve
            {
                return;
            }

            FP newSepVelocity = -separatingVelocity * this.restitution;
            TSVector accCausedVelocity = particles[0].getAcceleration();

            if (particles[1] != null)
            {
                accCausedVelocity -= particles[1].getAcceleration();
            }

            FP accCausedSepVelocity = accCausedVelocity*contactNormal*duration;

            if (accCausedSepVelocity < FP.Zero)
            {
                newSepVelocity += restitution*accCausedSepVelocity;

                if (newSepVelocity < FP.Zero)
                {
                    newSepVelocity = FP.Zero;
                }
            }

            FP deltaVelocity = newSepVelocity - separatingVelocity;

            FP totalInverseMass = particles[0].getInverseMass();
            if (particles[1] != null)
            {
                totalInverseMass += particles[1].getInverseMass();
            }

            if (totalInverseMass <= FP.Zero)
            {
                return;
            }

            FP impulse = deltaVelocity/totalInverseMass;

            TSVector impulsePerIMass = contactNormal*impulse;

            particles[0].setVelocity(particles[0].getVelocity() 
                + impulsePerIMass * particles[0].getInverseMass());
            if (particles[1] != null)
            {
                particles[1].setVelocity(particles[1].getVelocity()
                    + impulsePerIMass * particles[1].getInverseMass());
            }

        }

        private void resolveInterpenetration(FP duration)
        {
            if (penetration <= 0)
            {
                return;
            }

            

        }


    }
}
