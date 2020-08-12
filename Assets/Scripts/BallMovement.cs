using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    public float speed = 4.0f;
    [HideInInspector]
    public int score = 0;

    public Text gameOverText;
    public Button quit;
    public Button replay;

    // Start is called before the first frame update
    void Awake()
    {
        gameOverText.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        replay.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        targetPos = Camera.main.ScreenToWorldPoint(targetPos);
        Vector3 followXonly = new Vector3(targetPos.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, followXonly, speed * Time.deltaTime);
        if (transform.position.y < -0.1f)
        {
            gameOverText.gameObject.SetActive(true);
            quit.gameObject.SetActive(true);
            replay.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        score++;
    }
}
