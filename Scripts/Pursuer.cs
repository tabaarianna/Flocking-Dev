using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuer : Kinematic
{
    //Create variables from Pursue, Face, and LookWhereGoing behaviors
    Pursue myMoveType;
    Face myPursueRotateType;
    LookWhereGoing myEvadeRotateType;

    //This determines whether our character ACTUALLY evades the target??
    //Initally set to false until desired conditions are met??
    //CLARIFICATION NEEDED
    public bool evade = false;

    private void Start()
    {
        //1.The character's move type will be derived from the persue behavior
        //2.We declare our character as the one we attach the script to
        //3.We declare our character's target as the one we place into the myTarget slot
        myMoveType = new Pursue();
        myMoveType.character = this;
        myMoveType.target = myTarget;

        //Essentially the same process but with the Face behavior script
        myPursueRotateType = new Face();
        myPursueRotateType.character = this;
        myPursueRotateType.target = myTarget;

        myEvadeRotateType = new LookWhereGoing();
        myEvadeRotateType.character = this;
        myEvadeRotateType.target = myTarget;
    }

    protected override void Update()
    {
        //1. Create a steering variable that is derived from a new steeringoutput behavior
        //2. ??
        //3. ?? 
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = evade ? myEvadeRotateType.getSteering().angular : myPursueRotateType.getSteering().angular; 
        base.Update();
    }
}
