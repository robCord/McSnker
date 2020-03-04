using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform tf;
    //default state
    public string AIState = "Idle";

    public float Hitpoints;

    public Transform target;

    public float AttackRange;

    public float HpCutOff;

    private float speed = 5.0f;

    //track healing rate per second 
    public float restingHealRate = 1.0f;
    //maximum hp 
    public float maxHp = 100;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AIState == "Idle")
        {
            Idle();
            if (isInRange())
            {
                ChangeState("Seek");
            }
        }
        else if (AIState == "Rest")
        {
            //state behavior
            Rest();
            //check for transitions
            if (Hitpoints >= HpCutOff)
            {
                ChangeState("Idle");
            }
        }
        else if (AIState == " Seek")
        {
            //do the state behavior
            Seek();
            //check for transitions
            if (Hitpoints < HpCutOff)
            {
                ChangeState("Rest");
            }

            if (!isInRange())
            {
                ChangeState("Idle");
            }
        }
        else
        {
            Debug.LogError("State does not exist");
        }
    }

    public void Idle()
    {
        // do nothing
    }

    public void Rest()
    {
        //stand still and heal
        Hitpoints += restingHealRate * Time.deltaTime;
        Hitpoints = Math.Min(Hitpoints, maxHp);
    }

    public  void Seek()
    {
        Vector3 vectorToTarget = target.position - tf.position;
        tf.position += vectorToTarget.normalized * speed * Time.deltaTime;
    }

    public void ChangeState(string newState)
    {
        AIState = newState;


    }

    public bool isInRange()
    {
        return (Vector3.Distance(tf.position, target.position) <= AttackRange);
    }
}
