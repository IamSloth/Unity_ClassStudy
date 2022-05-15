using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public float time;
    public Transform[] point;

    public int max;
    public int count;

    void Create()
    {
        if(count >= max)
        {
            return;
        }

        count++;
        int i = Random.Range(0, point.Length);
        Instantiate(prefab, point[i]);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Create", time, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
