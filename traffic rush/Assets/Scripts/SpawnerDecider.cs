using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerDecider : MonoBehaviour
{
    Transform[] spawners, trimmedSpawners;
    public Transform player;
    public readonly int spawnerNumber;
    int i, prev = -1;
    List<float> distances;

    // Start is called before the first frame update
    void Start()
    {
        spawners = gameObject.GetComponentsInChildren<Transform>();

        List<Transform> tempList = new List<Transform>();
        foreach (Transform lane in spawners)
        {
            if(lane.parent != null)
            {
                tempList.Add(lane);
            }
        }

        trimmedSpawners = tempList.ToArray();
        distances = new List<float>(trimmedSpawners.Length);
    }

    bool Closest(float l)
    {
        if (l == distances.Min()) { return true; } else return false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform j in trimmedSpawners)
        {
            Vector2 dist = new Vector2(j.position.x - player.position.x, j.position.y - player.position.y);
            distances.Add(dist.magnitude);
        }
        i = distances.FindIndex(Closest);

        Debug.Log(new Vector2(i, prev));

        if (prev > -1) { trimmedSpawners[prev].gameObject.SetActive(true); }
        trimmedSpawners[i].gameObject.SetActive(false);
        if (prev != i) { prev = i; }
        distances.Clear();
    }
}
