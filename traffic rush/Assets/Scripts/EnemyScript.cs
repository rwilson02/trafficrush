using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    int hp = 3;
    public AudioSource hit;
    public float speed;
    public Rigidbody2D rb;
    public Renderer rend;
    public GameObject explosion;
    public bool horizontal;
    bool reconsidered = false;
    Vector2 moveDir;
    static readonly Color[] colors =
    {
        Color.white,
        Color.red,
        Color.green,
        Color.yellow,
        Color.cyan,
        Color.gray,
        Color.magenta,
        new Color(1, 0.5f, 0, 1)
    };

    private void Awake()
    {
        speed = 2*Random.value + 0.5f;
        rend.material.color = colors[Random.Range(0,colors.Length)];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("PlayerBullet"))
        {
            hp -= 1;
            hit.Play();
            Destroy(collision.gameObject);
            if(hp == 0)
            {
                Instantiate(explosion,this.transform.position, this.transform.rotation);
                PlayerScript.Points(250);
                Destroy(this.gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!reconsidered) { Reconsider(); }

        rb.velocity = moveDir * speed;

        if(gameObject.transform.position.y < -7 || gameObject.transform.position.x < -10)
        {
            Destroy(this.gameObject);
        }
    }

    void Reconsider()
    {
        if (horizontal) { gameObject.transform.Rotate(0, 0, -90); moveDir = Vector2.left; }
        else moveDir = Vector2.down;

        reconsidered = true;
    }
}
