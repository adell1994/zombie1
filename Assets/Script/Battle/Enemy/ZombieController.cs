using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour 
{
    public GameObject TargetObject; /// 目標位置
    NavMeshAgent m_navMeshAgent; /// NavMeshAgent
    public Animator animator;
    public int damage;        
    private GameObject enemy;  
    private ZombieParameter hp;
    // Use this for initialization
    void Start()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        enemy = GameObject.Find("Zombie1");
        hp = enemy.GetComponent<ZombieParameter>();
    }
    // Update is called once per frame
    void Update()
    {
        // NavMeshが準備できているなら
        if (m_navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            animator.SetFloat("Speed", m_navMeshAgent.velocity.sqrMagnitude);

            // NavMeshAgentに目的地をセット
            m_navMeshAgent.SetDestination(TargetObject.transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletSpawn"))
        {

            hp.Damage(damage);

            Destroy(other.gameObject);
        }
    }
}
