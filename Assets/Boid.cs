using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class Boid : MonoBehaviour {

    public float mass = 1;
    public float maximumSpeed = 10;
    public SteeringBehaviour steeringBehaviour;
    Vector3 velocity = Vector3.zero;
    Vector3 force = Vector3.zero;
    Vector3 acceleration = Vector3.zero;

    // Use this for initialization
    void Start ()
    {
        steeringBehaviour = GetComponent<SteeringBehaviour>();
    }

    public Vector3 SeekForce(Vector3 targetDest)
    {
        Vector3 toDest = targetDest - transform.position;
        toDest.Normalize();
        toDest *= maximumSpeed;
        return toDest - velocity;
    }

    Vector3 Calculate()
    {
        Vector3 steeringBehaviourForce = Vector3.zero;
        steeringBehaviourForce += steeringBehaviour.Calculate() * steeringBehaviour.weight;
        return steeringBehaviourForce;
    }

    // Update is called once per frame
    void Update()
    {
        //get force based on steering behaviour
        force = Calculate();
        Vector3 newAcceleration = force / mass;
        
        acceleration = Vector3.Lerp(acceleration, newAcceleration, Time.deltaTime);

        velocity += acceleration * Time.deltaTime;
        //prevent it from going faster than max speed
        velocity = Vector3.ClampMagnitude(velocity, maximumSpeed);
        
        //move the boid
        transform.position += velocity * Time.deltaTime;
    }
}
