using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seperator : Kinematic
{
    //Create a variable from the Seperation behavior script
    //Create a variable from the LookWhereGoing behavior Script

    Separation myMoveType;
    LookWhereGoing myRotateType;

    public Kinematic[] targets;

    void Start()
    {
        //How the character moves including the Separation behavior script
        myMoveType = new Separation();
        myMoveType.character = this;
        myMoveType.targets = targets;

        //How the character will rotate to the target
        myRotateType = new LookWhereGoing();
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
