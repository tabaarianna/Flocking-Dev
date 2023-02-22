using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Face
{
    //VARIABLES

    //The radius and foward offset of the wandering circle
    public float wanderOffSet;
    public float wanderRadius;

    //The max rate at which the wander orientation can change
    public float wanderRate;
    //Current orientation of the target (wander)
    public float wanderOrientation;
    //Max acceleration of the character
    public float maxAcceleration;

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        //This becomes the variable that holds the new postion of the character as it wanders??
        //ASK FOR CLARIFICATION FOR THIS VARIABLE
        Vector3 newPosition = character.transform.position + (Random.insideUnitSphere * wanderOffSet);
        //This is the variable that holds the newPosition variables on the xz plane for the character
        Vector3 targetPosition = new Vector3(newPosition.x, 0, newPosition.z);

        //This is the variable that holds the distance between the target position and the character position
        //Esentially the slope between the character and the target?
        result.linear = targetPosition - character.transform.position;

        result.linear.Normalize();
        result.linear *= maxAcceleration;

        result.linear.y = 0f;

        return result;
    }

}
