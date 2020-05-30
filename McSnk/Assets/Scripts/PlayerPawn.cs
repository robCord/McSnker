using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPawn : Pawn
{
    public NoiseMaker noiseMaker;
    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        noiseMaker = gameObject.GetComponent<NoiseMaker>();
        Attack();
    }

    // Update is called once per frame
    void Update()
    {
        noiseMaker.volumeDistance = 0;
    }

    public override void Attack()
    {
        noiseMaker.volumeDistance += 20; 
        Debug.Log("Player Attack");
        base.Attack();
    }

    public override void Move(Vector3 playerMovement)
    {
        noiseMaker.volumeDistance += 5;
        base.Move(playerMovement);
    }

}
