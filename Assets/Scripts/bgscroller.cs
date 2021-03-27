using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgscroller : MonoBehaviour
{
    public float scrollSpeed;
    public float someLength;
    private Vector3 startPosition;
    public GameController gameController;
    public bool beenset;
    void Start()
    {
        startPosition = transform.position;
       
    }

    void Update()
    {
        if (gameController.score >= 200)
        {
            scrollSpeed = scrollSpeed * 1;
        }

        if (!beenset && gameController.score >= 200)
        {
            beenset = true;
            scrollSpeed = -20;
        }

        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, someLength);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}