using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;
    GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
        player = GameObject.Find("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObj.GetComponent<PlayerHealth>().hp > 0)
        {
            nav.SetDestination(player.position);
        }

        else
        {
            nav.SetDestination(gameObject.transform.position);
        }
    }
}
