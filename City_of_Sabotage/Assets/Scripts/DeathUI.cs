using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathUI : MonoBehaviour
{
    public Text score;
    public Text highScore;

    // Run on the first frame
    void Start()
    {
        score.text = GameManager.instance.score.ToString();
        highScore.text = GameManager.instance.highscore.ToString();
    }

    public void RestartGame()
    {
        GameManager.instance.Reset();
    }
}
