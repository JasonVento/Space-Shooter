using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarField : MonoBehaviour
{
    private ParticleSystem ps;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        ps = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        var main = ps.main;
        var emission = ps.emission;
        if (gameController.score >= 200)
        {
            emission.rateOverTime = 50.0f;
            main.simulationSpeed = 50.0f;
        }
    }
}

