using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossEnemyAI : MonoBehaviour
{
    public enum BossEnemyAiState
    {
        WAIT,            //çsìÆÇàÍíUí‚é~
        MOVE,            //à⁄ìÆ
        JUMPATTACK,      //ÉWÉÉÉìÉvÇµÇƒçUåÇ
        ATTACK,          //çUåÇ
        IDLE,            //ë“ã@
        AVOID,           //âÒî
    }
    public BossEnemyAiState aiState = BossEnemyAiState.WAIT;
    public BossEnemyAiState nextState = BossEnemyAiState.WAIT;
    private bool isChasing;
    private bool isAttack;
    private bool isLottery;
    private bool isScream;
    public bool isAiStateRunning;
    public bool enemyCanShoot;
    public bool wait;
    public float distance;
    public float shootDistance;
    public float attackDistance;
    public int damage;
    private int number;
    public AudioClip bossSE;
    public AudioSource audioSource;
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
        if (enemyCanShoot && isChasing && (distance < attackDistance) && (distance < shootDistance))
        {
            nextState = BossEnemyAiState.ATTACK;
        }
        else
        {
            if(enemyCanShoot && isChasing && distance < attackDistance)
            {
                if (isLottery == true)
                {
                    return;
                }
                // ÇPÇ©ÇÁÇPÇOÇOÇ‹Ç≈ÇÃíÜÇ©ÇÁÉâÉìÉ_ÉÄÇ…êîéöÇëIëÇ∑ÇÈÅB
                number = Random.Range(1, 100);
                isLottery = true;
                // ëIëÇµÇΩêîéöÇ™50à»â∫Ç»ÇÁÇŒATTACKÇ…à⁄çsÇ∑ÇÈÅB
                if (number <= 50)
                {
                    nextState = BossEnemyAiState.JUMPATTACK;
                }
                else
                {
                    nextState = BossEnemyAiState.MOVE;
                }
            }

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
            case BossEnemyAiState.JUMPATTACK:
                JumpAttack();
                break;
            case BossEnemyAiState.ATTACK:
                Attack();
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
        audioSource = gameObject.GetComponent<AudioSource>();
        Animator anim = GetComponent<Animator>();
        m_navMeshAgent.speed = 0f;
        if(isScream == true)
        {
            return;
        }
        audioSource.PlayOneShot(bossSE);
        anim.SetBool("Scream", true);
        isScream = true;
        Invoke("Action", 2.0f);

    }
    void Move()
    {

    }
    void JumpAttack()
    {
        if (enemyWepon.transform.tag == "Player")
        {
            PlayerParameter player = gameObject.GetComponent<PlayerParameter>();
            player.TakeDamage(damage);
        }
        if (isAttack == true)
        {
            return;
        }
        m_navMeshAgent.speed = 0f;
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Jump", true);
        m_navMeshAgent.speed = 10.0f;
        Invoke("CoolTime", 1.0f);
        isAttack = true;
    }
    void Attack()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Attack", true);
        CoolTime();
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
        Invoke("Action", 3.0f);
    }
    public void Action()
    {
        Animator anim = GetComponent<Animator>();
        m_navMeshAgent.speed = 4.0f;
        isLottery = false;
        anim.SetBool("Attack", false);
        anim.SetBool("Jump", false);
        anim.SetBool("Scream", false);
        isAttack = false;
        nextState = BossEnemyAiState.MOVE;
    }
}
