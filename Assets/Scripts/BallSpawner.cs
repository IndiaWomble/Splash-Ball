using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    public float spawnTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", spawnTime);
    }

    void Spawn()
    {
        ball.SetActive(true);
    }
}
