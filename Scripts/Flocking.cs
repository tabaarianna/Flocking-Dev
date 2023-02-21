using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : Kinematic
{
    public bool avoidObstacles = false;
    public GameObject centerOfFlock;
    BlendedSteering mySteering;
    prioritySteering myPriority;
    public Kinematic[] kBirds;

    void Start()
    {
        //Separation
        Separation separate = new Separation();
        separate.character = this;

        GameObject[] goBirds = GameObject.FindGameObjectsWithTag("bird");
        kBirds = new Kinematic[goBirds.Length - 1];
        int j = 0;
        for (int i = 0; i < goBirds.Length - 1; i++)
        {
            if (goBirds[i] == this)
            {
                continue;
            }
            kBirds[j++] = goBirds[i].GetComponent<Kinematic>();
        }
        separate.targets = kBirds;

        //Arrive
        Arrive arrive = new Arrive();
        arrive.character = this;
        arrive.target = centerOfFlock;

        //Look Where Going
        LookWhereGoing LWG = new LookWhereGoing();
        LWG.character = this;

        //Blended Steering
        mySteering = new BlendedSteering();
        mySteering.behaviours = new behaviourAndWeight[3];
        mySteering.behaviours[0] = new behaviourAndWeight();
        mySteering.behaviours[0].behaviour = separate;
        mySteering.behaviours[0].weight = 1f;
        mySteering.behaviours[1] = new behaviourAndWeight();
        mySteering.behaviours[1].behaviour = arrive;
        mySteering.behaviours[1].weight = 1f;
        mySteering.behaviours[2] = new behaviourAndWeight();
        mySteering.behaviours[2].behaviour = LWG;
        mySteering.behaviours[2].weight = 1f;
    }

   

    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();


        steeringUpdate = mySteering.getSteering();
        base.Update();
    }
}