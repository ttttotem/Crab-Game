using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound sm;

    private void Awake()
    {
        if (sm != null && sm != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            sm = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

}
