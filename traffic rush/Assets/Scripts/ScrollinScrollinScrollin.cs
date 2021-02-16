using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollinScrollinScrollin : MonoBehaviour
{
    public float speed;
    public bool horizontal;
    Transform[] backgrounds;
    Vector2 dir;

    private void Start() {
        backgrounds = gameObject.GetComponentsInChildren<Transform>();

        if (horizontal)
        { dir = Vector2.left; } else dir = Vector2.down;
    }

    private void FixedUpdate()
    {
        foreach (Transform bg in backgrounds)
        {
            if (bg.parent != null) { bg.Translate(dir * speed * Time.deltaTime); }
        }
    }
}
