using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Face

{
    public float wanderOffset;
    float wanderRadious;

    float wanderRate;
    float wanderOrientation;
    public float maxAcceleration;
    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        Vector3 newPos = character.transform.position + (Random.insideUnitSphere * wanderOffset);
        Vector3 targetPosition = new Vector3(newPos.x, 0, newPos.z);

        result.linear = targetPosition - character.transform.position;

        result.linear.Normalize();
        result.linear *= maxAcceleration;

        result.linear.y = 0f;

        return result;



    }
}

