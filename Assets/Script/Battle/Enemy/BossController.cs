using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public GameObject TargetObject; /// 目標位置
    NavMeshAgent m_navMeshAgent; /// NavMeshAgent
    public Animator animator;
    public bool isBorn = false;

    // Use this for initialization
    void Start()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        if (TargetObject == null)
        {
            TargetObject = GameObject.FindGameObjectWithTag("Player");
            isBorn = true;
        }
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
}
