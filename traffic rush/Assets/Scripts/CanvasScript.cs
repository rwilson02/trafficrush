using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Image hp, ram, signal;
    public Text score;
    public Sprite fwd, rev;
    int intermed;
    int prev;

    // Update is called once per frame
    void Update()
    {
        hp.fillAmount = PlayerScript.hp / 100f;
        score.text = PlayerScript.totalScore.ToString("00000000");
        intermed = Mathf.FloorToInt((PlayerScript.totalScore + 500) / 3000);

        if (intermed > 0 && prev != intermed%2)
        {
            if (intermed % 2 == 1)
            {
                signal.sprite = fwd;
                signal.enabled = true;
                prev = intermed % 2;
            }
            else { signal.sprite = rev; signal.enabled = true; prev = intermed % 2; }
        }
    }

    public void BlinkerOff() { signal.enabled = false; }
}
