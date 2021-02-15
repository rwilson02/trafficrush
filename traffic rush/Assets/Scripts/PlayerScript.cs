using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float hSpeed, vSpeed, rSpeed, dist = 0;
   // public KeyCode ram;
    float horiz, vert;
    Vector2 moveDir;
    int points = 0;
    static int totalScore = 0, hp = 100;
   // bool ramming = false;
    Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Move(Vector2 dir)
    {
        body.velocity = new Vector2(dir.x * hSpeed, dir.y * vSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        moveDir = new Vector2(horiz, vert);

        dist += 10 * Time.deltaTime;
        totalScore = Mathf.FloorToInt(dist + points);
    }

    private void FixedUpdate()
    {
        Move(moveDir);
    }
}
