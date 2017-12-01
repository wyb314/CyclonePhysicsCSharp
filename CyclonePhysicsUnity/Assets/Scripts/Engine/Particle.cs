using System.Collections;
using System.Collections.Generic;
using TrueSync;
using UnityEngine;


namespace CyclonePhysics
{

    public class Particle
    {

        protected FP inverseMass;

        protected FP damping;

        protected TSVector position;

        protected TSVector velocity;

        protected TSVector forceAccum;

        protected TSVector acceleration;


        public void integrate(FP duration)
        {
        }


        public void setMass(FP mass)
        {
            this.inverseMass = (mass == FP.MaxValue ? FP.Zero : FP.ONE/mass);
        }

        public FP getMass()
        {
            if (this.inverseMass == FP.Zero)
            {
                return FP.MaxValue;
            }
            else
            {
                return FP.ONE/this.inverseMass;
            }
        }

        public void setInverseMass(FP inverseMass)
        {
            this.inverseMass = inverseMass;
        }

        public FP getInverseMass()
        {
            return this.inverseMass;
        }


        public bool hasFiniteMass()
        {
            //TODO://
            return inverseMass >= FP.Zero;
        }


        public void setDamping(FP damping)
        {
            this.damping = damping;
        }


        public FP getDamping()
        {
            return this.damping;
        }

        public void setPosition(TSVector position)
        {
            this.position = position;
        }


        public void setPosition(FP x, FP y, FP z)
        {
            TSVector position  = new TSVector(x,y,z);
            this.position = position;

        }

        public TSVector getPosition()
        {
            return this.position;
        }

        public void setVelocity(TSVector velocity)
        {
            this.velocity = velocity;
        }

        public void setVelocity(FP x, FP y, FP z)
        {
            TSVector velocity = new TSVector(x,y,z);
            this.velocity = velocity;
        }

        public TSVector getVelocity()
        {
            return this.velocity;
        }

        public void setAcceleration(TSVector acceleration)
        {
            
        }

        public void setAcceleration(FP x, FP y, FP z)
        {

        }


        public void getAcceleration(TSVector acceleration)
        {
            
        }


        public TSVector getAcceleration() { }


        public void clearAccumulator() { }

        public void addForce(TSVector force)
        {
            
        }
    }

}

