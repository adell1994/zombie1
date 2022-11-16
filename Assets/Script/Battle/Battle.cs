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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyDead()
    {
        remainingEnemyNum -= 1;
        if (remainingEnemyNum <= 0 && Enemy.bossType != Enemy.BossType.None)
        {
            enemyGenerator.BossSetUp();
        }
        else if (remainingEnemyNum <= 0)
        {
            RoundClear();
        }
    }
    void RoundClear()
    {
        RoundSetup();
    }
    void RoundSetup()
    {
        round.ForwardRound();
        round.Setup();
        enemyGenerator.SetUp();
        remainingEnemyNum = round.enemyNum;
    }
}
