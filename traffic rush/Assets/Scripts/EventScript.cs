using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScript : MonoBehaviour
{
    public Text msg, go;
    public Button back;

    public void EndGame(int cas)
    {
        print("hi");
        if (cas == 1)
        {
            msg.text = "So long, space cowboy.";
        }
        else msg.text = "You exploded, like a lot.";

        go.enabled = true;
        msg.enabled = true;
        back.gameObject.SetActive(true);
    }
}
