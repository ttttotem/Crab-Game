using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleAttack : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GM.gm.Reset();
        }
    }
}
