using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : Seek
{
    //Create Variables//
    //A group of gameObjects that are "points" on the path
    public GameObject[] path;
    int pathIndex;
    //I want to see if I can the difference between the values 
    public float targetRadius;
    //Did we reach the target / Did we not reach the target
    bool reachedTarget;

    public override SteeringOutput getSteering()
    {
        int nearestPathIndex = 0;
        float distToNearest = float.PositiveInfinity; 
        

        //Test to see the target is there
        if(target == null)
        {
            //Go through the points along the path 
            for(int i = 0; i < path.Length; i++)
            {
                //VARIABLES//
                //This object is a possible target depending on the iteration that satisfies the for loop
                GameObject possibleTarget = path[i];
                //Holds a series of points that consists of the possibleTarget's position minus the AI character's position
                Vector3 vectorToTarget = possibleTarget.transform.position - character.transform.position;
                //The distance between the character and possibleTarget?
                float distToPossibleTarget = vectorToTarget.magnitude; 

                //Check to see if the distance of a possible target is less than the actual distance
                if(distToPossibleTarget < distToNearest)
                {
                    nearestPathIndex = i;
                    distToNearest = distToPossibleTarget; 
                }

                target = path[nearestPathIndex]; 
            }

            float distToTarget = (target.transform.position - character.transform.position).magnitude;
            bool reachedTarget = distToTarget < targetRadius; 

        }

        //If we do see the target, update the pathIndex AND return where the target is with the pathIndex??
        if(reachedTarget)
        {
            pathIndex++; 
            
            if(pathIndex > path.Length - 1)
            {
                pathIndex = 0;
            }

            target = path[pathIndex];
        }

        return base.getSteering();
    }
}
