using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{
    
    public override float getTargetAngle()
    {
        //Create a variable that works out the direction to target
        Vector3 direction = target.transform.position - character.transform.position;

        //Create a variable for the target angle with the direction's x and z components
        float targetAngle = Mathf.Atan2(direction.x, direction.y);
        //Change to degrees
        targetAngle *= Mathf.Rad2Deg;


        return targetAngle;
    }
}

