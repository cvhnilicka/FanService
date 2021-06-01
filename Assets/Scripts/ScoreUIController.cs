using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIController : MonoBehaviour
{

    Text scoreRaw;
    private float curScore;
    private bool keepScore;
    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform child in transform)
        {
            if (child.name == "ScoreRaw")
            {
                scoreRaw = child.GetComponent<Text>();
                scoreRaw.text = "0";
            }
        }
        curScore = 0;
        keepScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (keepScore)
        {
            curScore += Mathf.Ceil(Time.deltaTime*100);
            scoreRaw.text = curScore.ToString();
        }
       
    }

    public float GetScore()
    {
        return this.curScore;
    }

    public void KillScoreUpdate()
    {
        keepScore = false;
    }
}
