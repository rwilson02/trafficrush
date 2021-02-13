using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float hSpeed, vSpeed, rSpeed, timer;
    public KeyCode ram;
    float horiz, vert;
    Vector2 moveDir;
    int points = 0, dist = 0, totalScore = 0;
    bool ramming = false;
    Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Move(Vector2 dir)
    {
        body.velocity = new Vector2(dir.x * hSpeed, dir.y * vSpeed);
    }

    void Ram(Vector2 dir)
    {
        timer = 0.5f;
        while(timer >= 0)
        {
            print(timer);
            body.velocity = dir * rSpeed;
        }
        ramming = false;
    }

    // Update is called once per frame
    void Update()
    {
        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        moveDir = new Vector2(horiz, vert);

        if (Input.GetKeyDown(ram))
        {
            ramming = true;
        }

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (ramming)
        {
            Ram(moveDir);
        }
       else Move(moveDir);
    }
}
