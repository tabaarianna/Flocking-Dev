using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrioritySteering 
{
    //This is our constant value, 0 works as well?

    float epsilon = 0.1f;

    public BlendedSteering[] groups;

    public SteeringOutput getSteering()
    {
        SteeringOutput steering = new SteeringOutput(); 
        
        foreach(BlendedSteering group in groups)
        {
            steering = group.getSteering();

            if (steering.linear.magnitude > epsilon || Mathf.Abs(steering.angular) > epsilon)
            {
                Debug.Log(group.behaviors[0].behavior);
                return steering; 
            }
        }

        return steering;
    }
}
