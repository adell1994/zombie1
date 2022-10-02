using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour 
{
    public GameObject TargetObject; /// �ڕW�ʒu
    NavMeshAgent m_navMeshAgent; /// NavMeshAgent
    public Animator animator;
    // Use this for initialization
    void Start()
    {
        // NavMeshAgent�R���|�[�l���g���擾
        m_navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        // NavMesh�������ł��Ă���Ȃ�
        if (m_navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            animator.SetFloat("Speed", m_navMeshAgent.velocity.sqrMagnitude);

            // NavMeshAgent�ɖړI�n���Z�b�g
            m_navMeshAgent.SetDestination(TargetObject.transform.position);
        }
    }
}
