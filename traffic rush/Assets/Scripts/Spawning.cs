using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject type1, type2; //basic, turret
    GameObject toSpawn;
    public bool horiz = false;

    void Spawn() {
        if (Random.value < 0.3f) { toSpawn = type2; } else toSpawn = type1;

        GameObject clone = Instantiate(toSpawn, this.transform.position, this.transform.rotation);
        clone.GetComponent<EnemyScript>().horizontal = horiz;
    }

    public void Call()
    {
        var count = GameObject.FindGameObjectsWithTag("Enemy");

        if (count.Length < 4)
        {
            Spawn();
        }
    }
}
