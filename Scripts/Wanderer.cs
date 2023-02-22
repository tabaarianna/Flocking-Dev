using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Kinematic
{
    //Create a variable using the Wander behavior script
    Wander myMoveType;
    //Create a variable using the Face behavior script
    Face myRotateType;

    public float offset;

    private void Start()
    {
        myMoveType = new Wander();
        myMoveType.character = this;
        myMoveType.target = myTarget;
        myMoveType.wanderOffSet = offset;
        myMoveType.maxAcceleration = maxSpeed;

        myRotateType = new Face();
        myRotateType.character = this;
        myRotateType.target = myTarget;

    }

    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = myRotateType.getSteering().angular;

        base.Update();
    }
}
