using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieParameter : MonoBehaviour
{
    public int hitPoint = 100;
    public bool isDead = false;

    // Update is called once per frame
    void Update()
    {

        if (hitPoint <= 0)
        {
            if(isDead == true)
            {
                return;
            }
            Animator anim = GetComponent<Animator>();
            anim.SetBool("Dead", true);
            isDead = true;
            Invoke("Erase", 3.0f);

        }

    }

    public void Damage(int damage)
    {
        hitPoint -= damage;
    }
    public void Erase()
    {
        Destroy(gameObject);
    }
}
