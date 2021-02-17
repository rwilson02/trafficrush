using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float hSpeed, vSpeed, rSpeed;
   // public KeyCode ram;
    float horiz, vert;
    Vector2 moveDir;
    static int points = 0;
    public static int hp = 100, totalScore = 0;
    static float dist = 0;
    public bool horizontal = false;
    public GameObject explosion, gameOver;
    bool dmg = true;
   // bool ramming = false;
    Rigidbody2D body;
    AudioSource hit;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        hit = GetComponent<AudioSource>();
        if (horizontal) { gameObject.transform.Rotate(0, 0, -90); } else gameObject.transform.Rotate(0,0,0);
    }

    void Move(Vector2 dir)
    {
        if (horizontal) { 
            body.velocity = new Vector2(dir.x * vSpeed, dir.y * hSpeed);
        }
        else body.velocity = new Vector2(dir.x * hSpeed, dir.y * vSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("EnemyBullet") && dmg){
            StartCoroutine(Hurt(25));
            Destroy(collision.gameObject);
        } else if (collision.collider.gameObject.CompareTag("Enemy") && dmg)
        {
            StartCoroutine(Hurt(10));
        }
    }

    IEnumerator Hurt(int pain)
    {
        hp -= pain;
        hit.Play();
        dmg = false;
        yield return new WaitForSeconds(1.5f);
        dmg = true;
    }

    void Die()
    {
        Instantiate(explosion, this.transform.position, this.transform.rotation);
        gameOver.GetComponent<EventScript>().EndGame(0);
        print("bye");
        this.gameObject.SetActive(false);
    }

    public static void Points(int pts)
    {
        points += pts;
    }

    // Update is called once per frame
    void Update()
    {
        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        moveDir = new Vector2(horiz, vert);

        dist += 10 * Time.deltaTime;
        totalScore = Mathf.FloorToInt(dist + points);

        if(hp <= 0) { Die(); };

        if(Mathf.Abs(transform.position.x) > 10 || Mathf.Abs(transform.position.y) > 7)
        {
            gameOver.GetComponent<EventScript>().EndGame(1);
            print("bye");
            this.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        Move(moveDir);
    }
}
