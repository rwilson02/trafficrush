using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurretScript : MonoBehaviour
{
    private Camera cam;
    private Vector2 thisPos, mousePos, diffPos;
    public GameObject tip, bullet;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    void Shoot()
    {
        var count = GameObject.FindGameObjectsWithTag("PlayerBullet");

        if (count.Length < 3)
        {
            GameObject clone = Instantiate(bullet, tip.transform.position, tip.transform.rotation);
            clone.GetComponent<Rigidbody2D>().velocity = tip.transform.up * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        diffPos = Input.mousePosition - cam.WorldToScreenPoint(this.transform.position);

        var angle = Mathf.Atan2(diffPos.y, diffPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
}
