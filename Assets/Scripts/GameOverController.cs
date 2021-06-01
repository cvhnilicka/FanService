using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

    public GameObject finalScore;
    public GameObject quit;
    public GameObject start;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Start")
            {
                start = child.gameObject;
                start.SetActive(false);
            }
            if (child.name == "Quit")
            {
                quit = child.gameObject;
                quit.SetActive(false);
            }
            if (child.name == "FinalScore")
            {
                finalScore = child.gameObject;
                finalScore.SetActive(false);
            }
        }

    }

    public void ActivateGameOver()
    {
        start.SetActive(true);
        quit.SetActive(true);
        finalScore.SetActive(true);
    }

    public void SetFinalScore(float score)
    {
        finalScore.GetComponent<Text>().text = "Your Score: " + score.ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}
