using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seperator : Kinematic
{

    Separation myMoveType;
    LookWhereGoing myRotateType;

    public Kinematic[] targets;


    void Start()
    {
        myMoveType = new Separation();
        myMoveType.character = this;
        myMoveType.targets = targets;

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
