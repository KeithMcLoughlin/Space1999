using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class Seek : SteeringBehaviour
    {
        public Vector3 target = Vector3.zero;

        override public Vector3 Calculate()
        {
            return boid.SeekForce(target);
        }
    }
}
