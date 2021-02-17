using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretScript : MonoBehaviour
{
    private Vector2 diffPos;
    public GameObject tip, bullet, player;
    public float speed, rate;
    public AudioSource shoot;
    public Collider2D self;
    float timer = 0;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Shoot()
    {
        GameObject clone = Instantiate(bullet, tip.transform.position, tip.transform.rotation);
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), self);
        clone.GetComponent<Rigidbody2D>().velocity = tip.transform.up * speed;
        shoot.Play();
    }

    // Update is called once per frame
    void Update()
    {
        diffPos = player.transform.position - this.transform.position;
        print(diffPos);

        var angle = Mathf.Atan2(diffPos.y, diffPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        
        timer += Time.deltaTime;
        if(timer > rate)
        {
            Shoot();
            timer -= rate;
        }
    }
}
