using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prioritySteering
{

    float epsilon = .1f;
    public BlendedSteering[] groups;

    public SteeringOutput getSteering()
    {
        SteeringOutput steering = new SteeringOutput();
        foreach (BlendedSteering g in groups)
        {
            steering = g.getSteering();

            if (steering.linear.magnitude > epsilon || Mathf.Abs(steering.angular) > epsilon)
            {
                return steering;
            }
        }

        return steering;
    }
}