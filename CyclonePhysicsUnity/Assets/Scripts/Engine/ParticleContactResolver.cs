using System;
using System.Collections.Generic;
using TrueSync;

namespace CyclonePhysics
{
    public class ParticleContactResolver
    {
        protected uint iterations;

        protected uint iterationsUsed;

        public ParticleContactResolver(uint iterations)
        {
            this.iterations = iterations;
        }

        public void setIterations(uint iterations)
        {
            this.iterations = iterations;
        }

        public void resolveContacts(List<ParticleContact> contactArray,FP duration )
        {
            this.iterationsUsed = 0;
            int contactArrayCount = contactArray.Count;

            while (this.iterationsUsed < this.iterations)
            {
                FP max = FP.MaxValue;

                int maxIdx = int.MaxValue;

                for (int i = 0; i < contactArrayCount; i++)
                {
                    FP sepVel = contactArray[i].calculateSeparatingVelocity();

                    if (sepVel < max && (sepVel < 0 || contactArray[i].penetratoin > 0))
                    {
                        max = sepVel;
                        maxIdx = i;
                    }

                }

            }

        }

    }
}
