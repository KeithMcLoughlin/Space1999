using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class CameraFollow : MonoBehaviour
    {
        public Boid target;

        void Update()
        {
            Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime);
        }
    }
}
