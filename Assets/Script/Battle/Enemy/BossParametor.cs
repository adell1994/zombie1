using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossParametor : MonoBehaviour
{
    public int hitPoint = 1500;
    public bool isDead = false;
    public AudioClip damageSE;
    public AudioSource audioSource;
    NavMeshAgent m_navMeshAgent;
    Battle battle;
    PlayerParameter playerParameter;

    // Update is called once per frame
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
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
    public void WeakPointDamage(int damage)
    {
        playerParameter.havePoints += 50;
        audioSource.PlayOneShot(damageSE);
        hitPoint -= damage;
    }
    public void Erase()
    {
        Destroy(gameObject);
    }
}
