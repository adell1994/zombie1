using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossEnemyAI : MonoBehaviour
{
    public enum BossEnemyAiState
    {
        WAIT,            //行動を一旦停止
        MOVE,            //移動
        ATTACK,        //停止して攻撃
        MOVEANDATTACK,    //移動しながら攻撃
        IDLE,            //待機
        AVOID,        //回避
    }
    public BossEnemyAiState aiState = BossEnemyAiState.WAIT;
    public BossEnemyAiState nextState = BossEnemyAiState.WAIT;
    private bool isChasing;
    public bool isAiStateRunning;
    public bool enemyCanShoot;
    public bool wait;
    public float distance;
    public float shootDistance;
    public float attackDistance;
    public int damage;
    private int number;
    public GameObject enemyWepon;
    public GameObject player;
    NavMeshAgent m_navMeshAgent;

    void Start()
    {
        SetAi();
        player = GameObject.FindGameObjectWithTag("Player");
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        isChasing = true;
        enemyCanShoot = true;
        StartCoroutine("AiTimer");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetAi()
    {
        if (isAiStateRunning)
        {
            return;
        }
        InitAi();
        aiState = nextState;
    }
    IEnumerator AiTimer()
    {
        while (true)
        {
            AiMainRoutine();
            yield return new WaitForSeconds(0.5f);
        }

    }
    void InitAi()
    {

    }


    void AiMainRoutine()
    {
        if (wait)
        {
            aiState = BossEnemyAiState.WAIT;
            wait = false;
            return;
        }
        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (enemyCanShoot && isChasing && distance < shootDistance)
        {
            nextState = BossEnemyAiState.MOVEANDATTACK;
        }
        else
        {
            nextState = BossEnemyAiState.MOVE;
        }
        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (enemyCanShoot && isChasing && distance < attackDistance)
        {
            // １から１００までの中からランダムに数字を選択する。
            number = Random.Range(1, 100);
            // 選択した数字が２０以下ならばATTACKに移行する。
            if (number <= 30)
            {
                nextState = BossEnemyAiState.ATTACK;
            }
            else
            {
                nextState = BossEnemyAiState.MOVE;
            }

        }
        else
        {
            nextState = BossEnemyAiState.MOVE;
        }
        UpdateAI();
    }
    void UpdateAI()
    {
        SetAi();
        switch (aiState)
        {
            case BossEnemyAiState.WAIT:
                Wait();
                break;
            case BossEnemyAiState.MOVE:
                Move();
                break;
            case BossEnemyAiState.ATTACK:
                Attack();
                break;
            case BossEnemyAiState.MOVEANDATTACK:
                MoveAndAttack();
                break;
            case BossEnemyAiState.IDLE:
                Idle();
                break;
            case BossEnemyAiState.AVOID:
                Avoid();
                break;
        }
    }
    void Wait()
    {

    }
    void Move()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Attack", false);
    }
    void Attack()
    {
        m_navMeshAgent.speed = 0f;
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Attack", true);
        m_navMeshAgent.speed = 10.0f;
        Invoke("CoolTime", 1.0f);
        if (enemyWepon.transform.tag == "Player")
        {
            PlayerParameter player = gameObject.GetComponent<PlayerParameter>();
            player.TakeDamage(damage);
        }
    }
    void MoveAndAttack()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("MoveAttack", true);
        if (enemyWepon.transform.tag == "Player")
        {
            PlayerParameter player = gameObject.GetComponent<PlayerParameter>();
            player.TakeDamage(damage);
        }
    }
    void Idle()
    {

    }
    void Avoid()
    {

    }
    public void CoolTime()
    {
        m_navMeshAgent.speed = 0f;
        Invoke("Action", 2.0f);
    }
    public void Action()
    {
        m_navMeshAgent.speed = 3.5f;
    }
}
