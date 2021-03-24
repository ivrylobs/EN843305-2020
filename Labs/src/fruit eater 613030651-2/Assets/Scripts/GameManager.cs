using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Declare variables
    public int score = 3;
    public int gameTime;
    public int life = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public GameObject fruit;
    
    float height;
    float width;

    public string[] fruitWave;

    int waveState = 0;
    int waveCount = 0;

    public GameObject Left;
    public GameObject Right;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DecreaseTime", 1.0f, 1.0f);

        height = Camera.main.orthographicSize * 2.0f;
        width = height * Screen.width / Screen.height;

        InvokeRepeating("SpawnFruitWave", 0.5f, 2.0f);

        Left.transform.position = new Vector2(-width/2, 0);
        Right.transform.position = new Vector2(width/2, 0);

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score + "";
        timeText.text = gameTime + "";

        if (life == 0) {
            GameObject.Find("GameOver").GetComponent<View>().MoveIn();
        }
    }

    public void DecreaseLife()
    {
        life--;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    void DecreaseTime()
    {
        gameTime--;
        if (gameTime <= 0 || life <= 0)
        {
            CancelInvoke("DecreaseTime");
        }
    }

    void SpawnFruitWave()
    {
        if (life > 0)
        {
            if (waveCount > fruitWave[waveState].Length - 1)
            {
                waveCount = 0;
                waveState++;
                if (waveState > fruitWave.Length - 1)
                {
                    CancelInvoke("SpawnFruitWave");
                }
            }
            int fruitPosition = int.Parse(fruitWave[waveState][waveCount].ToString());
            Vector2 position = new Vector2(-width/2 + (width/10f) * fruitPosition, height/2);
            Instantiate(fruit, position, Quaternion.identity);
            waveCount++;
        }
    }
}
