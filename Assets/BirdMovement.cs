using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float swoopSpeed = 20f;
    private Rigidbody2D m_Rigidbody2D;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    private Vector3 m_Velocity = Vector3.zero;
    public bool swoop = false;
    public float flySpeed = 40f; //make it sqrt swoop^2 + swoop^2 for same speed
    public float swoopTo = 1f;
    public Transform player;
    bool stopSwoop = false;
    public float swoopDistance = 20f;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, new Vector3(-1, 0, 0) * flySpeed * Time.fixedDeltaTime, ref m_Velocity, m_MovementSmoothing);
    }

    public void Update()
    {
        if (this.transform.position.x < player.transform.position.x + swoopDistance)
        {
            swoop = true;
        }
    }


    private void FixedUpdate()
    {
        if (swoop == true && stopSwoop == false)
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(-1, -1) * swoopSpeed * Time.fixedDeltaTime;
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            if (m_Rigidbody2D.position.y <= swoopTo || m_Rigidbody2D.position.y <= player.transform.position.y)
            {
                stopSwoop = true;
                m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, new Vector3(-1,0,0) * flySpeed * Time.fixedDeltaTime, ref m_Velocity, m_MovementSmoothing);
            }
        }
    }
}
