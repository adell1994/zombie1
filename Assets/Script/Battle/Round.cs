using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Round : MonoBehaviour
{
    public int roundNum = 0;
    public int enemyNum;
    public int bossEnemyNum = 20;
    int roundCount = 0;
    public float roundBlock;
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
        int num = roundNum % 10;
        roundCount++;
        Debug.Log(num);
        if(roundCount == 10)
        {
            num = 10;
            roundCount = 0;
        }
        //roundBlock = Mathf.Floor(roundNum / 15);
        Enemy.bossType = Enemy.BossType.None;					
        if (num == 4) 
        {
          //中ボス出現				
         Enemy.bossType = Enemy.BossType.Boss1st;
        } else if (num == 9)
        {
           //ボス出現				
          Enemy.bossType = Enemy.BossType.Boss2nd;
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
