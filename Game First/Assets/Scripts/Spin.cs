using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    float t;
    // Start is called before the first frame update
    void OnEnable()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t < 0.75f){
            transform.Rotate(480f*Time.deltaTime, 0f, 0f, Space.Self);
        }
    }
}
