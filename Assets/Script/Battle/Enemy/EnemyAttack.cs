using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerParameter playerParameter;
    // Start is called before the first frame update
    void Start()
    {
        playerParameter = GameObject.Find("Player").GetComponent<PlayerParameter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerParameter.TakeDamage(25);
        }
    }
}
