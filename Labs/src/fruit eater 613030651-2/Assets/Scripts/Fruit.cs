using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
        int countDestroy = 0;
        private GameManager gameManager;
        
    // Start is called before the first frame update
    void Start()
    {
       GameObject gameObject = GameObject.Find("GameManager");
       gameManager = gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Player") {
            gameManager.score += 10;
            Destroy(gameObject);
        } else if (other.gameObject.name == "ground")
        {
            countDestroy++;
            
            if(countDestroy > 1) {
                Destroy(gameObject);
            }
        }
    }
}
