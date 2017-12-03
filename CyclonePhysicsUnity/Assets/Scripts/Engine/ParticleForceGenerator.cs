using System;
using System.Collections.Generic;
using TrueSync;


namespace CyclonePhysics
{
    public abstract class ParticleForceGenerator
    {
        public virtual void updateForce(Particle particle , FP duration)
        {
        }
    }
}
