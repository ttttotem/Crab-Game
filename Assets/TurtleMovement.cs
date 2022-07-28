using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    private Rigidbody2D m_Rigidbody2D;
    public float flipTime = 3f;
    private float curTime = 3f;
    private Vector3 m_Velocity = Vector3.zero;
    private float direction = 1f;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        curTime = flipTime;
        Flip();
    }

        private void FixedUpdate()
    {
        curTime -= Time.fixedDeltaTime;
        if (curTime < -flipTime)
        {
            curTime = flipTime;
        }

        if (curTime > 0)
        {
            if(direction == -1)
            {
                Flip();
            }
            direction = 1;
        } else
        {
            if (direction == 1)
            {
                Flip();
            }
            direction = -1;
        }

        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(moveSpeed*Time.fixedDeltaTime*direction, m_Rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    public void Flip()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
