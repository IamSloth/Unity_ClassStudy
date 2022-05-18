using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 100;

    bool bDamage;

    public RawImage imgBar;
    public RawImage imgDamage;
    public Slider sliderHp;

    Vector3 posRespawn;

    public void Damage(int amount)
    {
        if (hp <= 0)
            return;

        hp -= amount;
        imgBar.transform.localScale = new Vector3(hp / 100.0f, 1, 1);
        sliderHp.value = hp;
        bDamage = true;

        if (hp <= 0)
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<PlayerMove>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;

            Invoke("Respawn", 3);
        }
    }

    public void Respawn()
    {
        hp = 100;

        transform.position = posRespawn;
        GetComponent<Animator>().SetTrigger("Respawn");

        GetComponent<PlayerMove>().enabled = true;
        GetComponent<PlayerAttack>().enabled = true;

        imgBar.transform.localScale = new Vector3(1, 1, 1);
        sliderHp.value = hp;
    }

    // Start is called before the first frame update
    void Start()
    {
        posRespawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (bDamage)
        {
            imgDamage.color = new Color(1, 0, 0, 1);
        }

        else
        {
            imgDamage.color = Color.Lerp(imgDamage.color, Color.clear, 0.01f);
        }
        bDamage = false;
    }
}
