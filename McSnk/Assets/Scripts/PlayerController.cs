using System.Collections;
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
        float verticalInput = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pawn.Attack();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput = 1;
        }

        pawn.Move(verticalInput);
    }
}
