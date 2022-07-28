using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -1.5 || player.transform.position.y > 10)
        {
            SceneManager.LoadScene(0);
        }
    }
}
