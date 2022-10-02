using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieParameter : MonoBehaviour
{
    public int hitPoint = 100;

    // Update is called once per frame
    void Update()
    {

        if (hitPoint <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void Damage(int damage)
    {
        hitPoint -= damage;
    }
}
