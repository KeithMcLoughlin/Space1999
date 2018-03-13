using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class OffsetPursue : SteeringBehaviour
    {
        public Boid leader;
        public Vector3 target = Vector3.zero;
        public Vector3 positionToLeader;

        void Start()
        {
            positionToLeader = this.transform.position - leader.transform.position;
        }

        override public Vector3 Calculate()
        {
            //ran out of time so copied seek behaviour
            return boid.SeekForce(target);
        }
    }
}
