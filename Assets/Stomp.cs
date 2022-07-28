using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : MonoBehaviour
{
    public float bounce = 5f;
    public Movement controller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            controller.Bounce(bounce);
            Destroy(collision.gameObject, 0.05f);
        }
    }
}
