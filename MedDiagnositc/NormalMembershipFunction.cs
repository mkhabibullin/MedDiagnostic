using AForge.Fuzzy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedDiagnositc
{
    public class NormalMembershipFunction : IMembershipFunction
    {
        public float LeftLimit { get; set; }

        public float RightLimit { get; set; }

        public NormalMembershipFunction(float b, float sigma)
        {
            this.LeftLimit = b;
            this.RightLimit = sigma;
        }

        public float GetMembership(float x)
        {
            return (float)Math.Exp(-(x - LeftLimit) * (x - LeftLimit) / (2.0 * RightLimit * RightLimit));
        }
    }
}