using System;
using System.Collections.Generic;
using TrueSync;

namespace CyclonePhysics
{
    using Registry = List<ParticleForceRegistry.ParticleForceRegistration>;
    public class ParticleForceRegistry
    {
        public class ParticleForceRegistration
        {
            public Particle particle;

            public ParticleForceGenerator fg;
        }

        protected Registry registrations = new Registry();


        public void add(Particle particle , ParticleForceGenerator fg)
        {
            ParticleForceRegistration registration = new ParticleForceRegistration();
            registration.particle = particle;
            registration.fg = fg;
            registrations.Add(registration);
        }

        public void remove(Particle particle , ParticleForceGenerator fg)
        {
            if (this.registrations.Count > 0)
            {
                ParticleForceRegistration _registration = null;
                foreach (var registration in this.registrations)
                {
                    if (registration.particle == particle && registration.fg == fg)
                    {
                        _registration = registration;
                        break;
                    }
                }

                if (_registration != null)
                {
                    this.registrations.Remove(_registration);
                }
            }
            
        }

        public void clear()
        {
            this.registrations.Clear();
        }


        public void updateForces(FP duration)
        {
            if (this.registrations.Count > 0)
            {
                foreach (var registration in this.registrations)
                {
                    registration.fg.updateForce(registration.particle,duration);
                }
            }
            
        }

    }
}
