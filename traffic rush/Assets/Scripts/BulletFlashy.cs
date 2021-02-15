using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlashy : MonoBehaviour
{
    private Renderer b;
    Color start = Color.red, end = Color.white;
    public float dur = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        b = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time, dur);
        b.material.color = Color.Lerp(start, end, time);
    }
}
