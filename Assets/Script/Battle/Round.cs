using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Round : MonoBehaviour
{
    public int roundNum = 0;
    public int enemyNum;
    public int bossEnemyNum;
    public int roundCount;
    public int num;
    public float roundBlock;
    public bool isBossEnemy;
    public EnemyGenerator enemyGenerator;
    public AudioSource audioSource;
    public AudioClip roundProgresses;
    public TextMeshProUGUI roundText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        roundText.text = roundNum + "R";
    }
    public void Setup()
    {
        num = roundNum % 10;
        roundCount++;
        if(roundCount == 10)
        {
            num = 10;
            roundCount = 0;
        }
        Debug.Log(num);
        //roundBlock = Mathf.Floor(roundNum / 15);
        Enemy.bossType = Enemy.BossType.None;					
        if (num == 5) 
        {
          //中ボス出現				
            Enemy.bossType = Enemy.BossType.Boss1st;
            bossEnemyNum = 20;
            enemyNum = bossEnemyNum;
            return;
        } else if (num == 10)
        {
           //ボス出現				
           Enemy.bossType = Enemy.BossType.Boss2nd;
            // 一度ボス戦が終わっていたら敵の数を追加する
            if(isBossEnemy == true)
            {
                bossEnemyNum = 100;
                enemyNum = bossEnemyNum;
                return;
            }
            bossEnemyNum = 1;
            enemyNum = bossEnemyNum;
            isBossEnemy = true;
            return;
        }

        if (enemyNum >= 200)
        {
            return;
        }
        enemyNum = roundNum * 10;
        Debug.Log(Enemy.bossType);
    }
        

     public void ForwardRound()
     {
        audioSource.PlayOneShot(roundProgresses, 1.0f);
        roundNum++;
     }
}
