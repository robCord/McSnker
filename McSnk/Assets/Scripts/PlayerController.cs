﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    // Start is called before the first frame update
    void Start()
    {
        pawn = FindObjectOfType<PlayerPawn>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(verticalInput, 0, 0) * Time.deltaTime;

        Vector3 rotateMovement = new Vector3(0, 0, horizontalInput) * Time.deltaTime * 100;
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    pawn.Attack();
        //}

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    verticalInput = 1;
       // }

        pawn.Move(movement);
        pawn.Rotate(rotateMovement);
    

    }

}
