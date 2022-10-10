using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take_Damage : MonoBehaviour
{
    public int damage;
    private GameObject enemy;
    private ZombieParameter hp;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Zombie1");
        hp = enemy.GetComponent<ZombieParameter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shell"))
        {

            hp.Damage(damage);

            Destroy(other.gameObject);
        }
    }
}
