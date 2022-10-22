using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameter : MonoBehaviour
{
    public int playerHitPoint;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHitPoint <= 0)
        {
            if (isDead == true)
            {
                return;
            }
            isDead = true;
        }

    }
    public void TakeDamage(int damage)
    {
        playerHitPoint -= damage;
    }
}
