using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class View : MonoBehaviour
{
    public Transform upper;
    public Transform center;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back() {
        transform.DOMoveY(upper.position.y, 1);

    }

    public void MoveIn() {
        transform.DOMoveY(center.position.y, 1);
    }
}
