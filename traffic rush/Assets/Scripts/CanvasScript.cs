using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Image hp, ram;
    public Text score;

    // Update is called once per frame
    void Update()
    {
        hp.fillAmount = PlayerScript.hp / 100f;
        score.text = PlayerScript.totalScore.ToString("00000000");
    }
}
