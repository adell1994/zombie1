using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FormidableEnemyParametor : MonoBehaviour
{
    public int hitPoint = 100;
    public bool isDead = false;
    public GameObject head;
    public AudioClip headShotSE;
    public AudioClip zombieSE;
    public AudioSource audioSource;
    NavMeshAgent m_navMeshAgent;

    // Update is called once per frame
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(zombieSE);
        m_navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {

        if (hitPoint <= 0)
        {
            if (isDead == true)
            {
                return;
            }
            Animator anim = GetComponent<Animator>();
            m_navMeshAgent.speed = 0f;
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
    public void HeadShot()
    {
        Damage(50);
    }
}