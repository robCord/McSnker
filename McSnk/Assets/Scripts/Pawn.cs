using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float health = 100f;
    public float max = 100f;
    public Transform tf;

    

    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
    }
    public virtual void Attack()
    {
        Debug.Log(("Pawn Attack"));
    }

    public virtual void Rotate(Vector3 direction)
    {
        transform.Rotate(direction);
    }

    public virtual void Move(Vector3 playerMovement)
    {
        //  tf.localPosition += playerMovement;
        transform.Translate(playerMovement);
        Debug.Log("Moved with pawn");
    }
}
