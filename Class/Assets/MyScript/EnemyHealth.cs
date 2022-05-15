using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    int hp = 100;
    public void Damage(int amount)
    {
        if (hp <= 0)
            return;
        hp -= amount;
        if(hp<=0)
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<NavMeshAgent>().enabled = false;

            Destroy(gameObject,2);
            GameObject.Find("GameManager").GetComponent<Spawn>().count--;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
