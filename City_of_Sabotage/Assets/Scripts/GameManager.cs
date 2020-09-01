using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int highscore = 0;
    public static GameManager instance = null;
    
    public void scoreIncrease(int amount)
    {
        score += amount;

        print("New Score: " + score.ToString());

        if (score > highscore)
        {
            highscore = score;
            print("New Highscore: " + highscore.ToString());
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
