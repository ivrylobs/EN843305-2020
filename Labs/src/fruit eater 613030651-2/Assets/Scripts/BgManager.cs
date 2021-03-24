using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgManager : MonoBehaviour
{
    public int randomBg;
    // Start is called before the first frame update
    void Start()
    {
        randomBg = Random.Range(0, 2);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        transform.GetChild(randomBg).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
