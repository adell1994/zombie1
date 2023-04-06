using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDogParametor : MonoBehaviour
{
    public int hitPoint = 50;
    public bool isDead = false;
    public AudioClip dogSE;
    public AudioSource audioSource;
    NavMeshAgent m_navMeshAgent;
    Battle battle;
    PlayerParameter playerParameter;

    // Update is called once per frame
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(dogSE);
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        battle = GameObject.Find("Battle").GetComponent<Battle>();
        playerParameter = GameObject.Find("Player").GetComponent<PlayerParameter>();
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
            battle.EnemyDead();
            Invoke("Erase", 3.0f);
        }

    }

    public void Damage(int damage)
    {
        playerParameter.havePoints += 20;
        hitPoint -= damage;
    }
    public void Erase()
    {
        Destroy(gameObject);
    }
}