using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCheck : MonoBehaviour
{


    // Declare variables
    public float speed = 0.0f;
    public float distance = 0.0f;
    public float time = 0.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    void CheckSpeed()
    {
        speed = distance / time;
        if (speed > 70 || speed < 40)
        {
            print("You are breaking the law!");
        }
        print("You are traveling at " + speed + "MPH");

    }

    // Update is called once per frame
    void Update()
    {
        CheckSpeed();
    }
}
