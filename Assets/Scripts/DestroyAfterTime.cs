using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    public int delay = 200;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, delay);
    }
}
