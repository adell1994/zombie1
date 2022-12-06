using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Round : MonoBehaviour
{
    public int roundNum = 0;
    public int enemyNum;
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
        if(enemyNum >= 200)
        {
            return;
        }
        enemyNum = roundNum * 10;
    }
        

     public void ForwardRound()
     {
        audioSource.PlayOneShot(roundProgresses, 1.0f);
        roundNum++;
     }
}
