using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowManager : MonoBehaviour
{

    public Transform target;
    public float shadowHeight = 2f;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2 (target.position.x, shadowHeight);
    }
}
