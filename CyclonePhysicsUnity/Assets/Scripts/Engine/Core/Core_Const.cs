using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TrueSync;

namespace CyclonePhysics.Core
{
    public static class Const
    {
        private static FP sleepEpsilon;

        public static FP getSleepEpsilon()
        {
            return sleepEpsilon;
        }

        public static void setSleepEpsilon(FP value)
        {
            sleepEpsilon = value;
        }
    }
}
