using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    public int roundNum = 1;
    public int enemyNum;
    public float roundBlock;
    public EnemyGenerator enemyGenerator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Setup()
    {
        int num = roundNum % 15 + 1;
        roundBlock = Mathf.Floor(roundNum / 15);					
        Enemy.bossType = Enemy.BossType.None;
        if (num == 5) 
        {
          //中ボス出現				
         Enemy.bossType = Enemy.BossType.Boss1st;
        } else if (num == 10)
        {
           //ボス出現				
          Enemy.bossType = Enemy.BossType.Boss2nd;
        }
        enemyNum = roundNum + 5;
    }
        

     public void ForwardRound()
     {
        roundNum++;
     }
}
