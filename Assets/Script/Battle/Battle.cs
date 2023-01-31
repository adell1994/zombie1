using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{

    public enum BattleState
    {
        Redy,
        Battle,
        End
    }
    public static  BattleState state = BattleState.Battle;
    public enum GrenadeState
    {
        Redy,
        Throw,
        End
    }
    public static  GrenadeState grenadeState = GrenadeState.Redy;


    public int remainingEnemyNum;
    public EnemyGenerator enemyGenerator;
    public Round round;
    public BGM bgm;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RoundSetup", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyDead()
    {
       // Debug.Log("EnemyDead");
        remainingEnemyNum -= 1;
        Debug.Log("remainingEnemyNum" + remainingEnemyNum);

        if (remainingEnemyNum <= 0)
        {
            RoundClear();
        }
    }
    void RoundClear()
    {
        Debug.Log("RoundClear");
        RoundSetup();
    }
    void RoundSetup()
    {
        Debug.Log("RoundSetup");
        round.ForwardRound();
        round.Setup();
        if (remainingEnemyNum <= 0 && Enemy.bossType != Enemy.BossType.None)
        {
            bgm.SetUp();
            enemyGenerator.BossSetUp();
            remainingEnemyNum = round.bossEnemyNum;
        }
        else
        {
            bgm.SetUp();
            enemyGenerator.SetUp();
            remainingEnemyNum = round.enemyNum;
        }

    }
}
