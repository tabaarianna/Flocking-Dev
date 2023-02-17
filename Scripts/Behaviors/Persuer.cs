using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persuer : Kinematic
{
    Pursue myMoveType;
    Face myPursueRotateType;
    LookWhereGoing myEvadeRoateType;

    public bool evade = false;

    private void Start()
    {
        myMoveType = new  Pursue();
        myMoveType.character = this;
        myMoveType.target = myTarget;

        myPursueRotateType = new Face();
        myPursueRotateType.character = this;
        myPursueRotateType.target = myTarget;

        myEvadeRoateType = new LookWhereGoing();
        myEvadeRoateType.character = this;
        myEvadeRoateType.target = myTarget;
    }

    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = evade ? myEvadeRoateType.getSteering().angular : myPursueRotateType.getSteering().angular;
        base.Update();
    }
}