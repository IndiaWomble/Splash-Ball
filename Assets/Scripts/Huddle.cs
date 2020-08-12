using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huddle : MonoBehaviour
{
    public float speed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (speed * Time.deltaTime));
        if (transform.position.z <= -9.0f)
            gameObject.SetActive(false);
    }
}
