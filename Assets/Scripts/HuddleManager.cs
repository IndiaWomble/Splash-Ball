using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuddleManager : MonoBehaviour
{
    public static HuddleManager sharedInstance;
    public List<GameObject> huddles;
    public GameObject huddle;
    public int amount;

    private void Awake()
    {
        sharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        huddles = new List<GameObject>();
        for (int i = 0; i < amount; i++)
        {
            GameObject temp = (GameObject)Instantiate(huddle);
            temp.SetActive(false);
            huddles.Add(temp);
        }
        InvokeRepeating("Spawn", 0.0f, 1.0f);
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < huddles.Count; i++)
            if (!huddles[i].activeInHierarchy)
                return huddles[i];
        return null;
    }

    void Spawn()
    {
        GameObject currentHuddle = GetPooledObject();
        if (currentHuddle != null)
        {
            currentHuddle.transform.position = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, 4.0f);
            currentHuddle.transform.rotation = Quaternion.identity;
            currentHuddle.SetActive(true);
        }
    }
}
