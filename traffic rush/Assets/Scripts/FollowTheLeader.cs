using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheLeader : MonoBehaviour
{
    public float ScrolloffDist;
    public GameObject prev;
    public bool Horizontal = false;

    private void FixedUpdate()
    {
        if (Horizontal)
        {
            WarpH();
        }
        else Warp();
    }

    private void Warp()
    {
        if(gameObject.transform.position.y < ScrolloffDist)
        {
            gameObject.transform.position = new Vector2(0, prev.transform.position.y - ScrolloffDist);
        }
    }

    private void WarpH()
    {
        if (gameObject.transform.position.x < ScrolloffDist)
        {
            gameObject.transform.position = new Vector2(prev.transform.position.x - ScrolloffDist, 0);
        }
    }
}
