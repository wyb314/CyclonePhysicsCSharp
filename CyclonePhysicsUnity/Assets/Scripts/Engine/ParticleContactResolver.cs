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
            int numContacts = contactArray.Count;

            while (this.iterationsUsed < this.iterations)
            {
                FP max = FP.MaxValue;

                int maxIdx = int.MaxValue;

                for (int i = 0; i < numContacts; i++)
                {
                    FP sepVel = contactArray[i].calculateSeparatingVelocity();

                    if (sepVel < max && (sepVel < 0 || contactArray[i].penetration > 0))
                    {
                        max = sepVel;
                        maxIdx = i;
                    }
                }

                if (maxIdx == numContacts)
                {
                    break;
                }

                contactArray[maxIdx].resolve(duration);
                TSVector[] move = contactArray[maxIdx].particleMovements;

                for (int i = 0; i < numContacts; i++)
                {
                    if (contactArray[i].particles[0] == contactArray[maxIdx].particles[0])
                    {
                        contactArray[i].penetration -= move[0]*contactArray[i].contactNormal;
                    }
                    else if (contactArray[i].particles[0] == contactArray[maxIdx].particles[1])
                    {
                        contactArray[i].penetration -= move[1]*contactArray[i].contactNormal;
                    }

                    if (contactArray[i].particles[1] != null)
                    {
                        if (contactArray[i].particles[1] == contactArray[maxIdx].particles[0])
                        {
                            contactArray[i].penetration += move[0]*contactArray[i].contactNormal;
                        }
                        else if(contactArray[i].particles[1] == contactArray[maxIdx].particles[1])
                        {
                            contactArray[i].penetration += move[1]*contactArray[i].contactNormal;
                        }
                    }

                }
            }

            

        }

    }
}
