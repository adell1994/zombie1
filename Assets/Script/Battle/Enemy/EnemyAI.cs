using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
   public enum EnemyAiState
    {
        WAIT,            //çsìÆÇàÍíUí‚é~
        MOVE,            //à⁄ìÆ
        ATTACK,        //í‚é~ÇµÇƒçUåÇ
        MOVEANDATTACK,    //à⁄ìÆÇµÇ»Ç™ÇÁçUåÇ
        IDLE,            //ë“ã@
        AVOID,        //âÒî
    }
    public EnemyAiState aiState = EnemyAiState.WAIT;
    private bool isChasing;
    public bool isAiStateRunning;
    public bool enemyCanShoot;
    public bool wait;
    public int distance;
    public int shootDistance;
    public int damage;
    public GameObject enemyWepon;
    public GameObject player;

    void Start()
    {
        SetAi();
        player = GameObject.FindGameObjectWithTag("Player");
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
            aiState = EnemyAiState.WAIT;
            wait = false;
            return;
        }
        //distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (enemyCanShoot && isChasing && distance < shootDistance)
        {
            aiState = EnemyAiState.MOVEANDATTACK;
        }
        else
        {
            aiState = EnemyAiState.MOVE;
        }
        UpdateAI();
    }
    void UpdateAI()
    {
        SetAi();
        switch (aiState)
        {
            case EnemyAiState.WAIT:
                Wait();
                break;
            case EnemyAiState.MOVE:
                Move();
                break;
            case EnemyAiState.ATTACK:
                Attack();
                break;
            case EnemyAiState.MOVEANDATTACK:
                MoveAndAttack();
                break;
            case EnemyAiState.IDLE:
                Idle();
                break;
            case EnemyAiState.AVOID:
                Avoid();
                break;
        }
    }
    void Wait()
    {

    }
    void Move()
    {

    }
    void Attack()
    {

    }
    void MoveAndAttack()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Attack", true);
        if(enemyWepon.transform.tag == "Player")
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

    // Start is called before the first frame update

}
