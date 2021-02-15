using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Declare variables
    public int score;
    public int gameTime;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DecreaseTime", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score + "";
        timeText.text = gameTime + "";
    }

    void DecreaseTime()
    {
        gameTime--;
        if (gameTime <= 0)
        {
            CancelInvoke("DecreaseTime");
        }
    }
}
