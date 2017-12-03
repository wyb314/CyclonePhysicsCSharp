using System;
using System.Collections.Generic;

namespace CyclonePhysics
{
    public abstract class ParticleContactGenerator
    {
        public virtual void addContact(ParticleContact contact , uint limit)
        {
        }

    }
}
