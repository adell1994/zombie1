using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerParameter : MonoBehaviour
{
    public int playerHitPoint;　　　　　　//PlayerのHP
    public int havePoints;               //現在の所持ポイント
    public bool isDead;　　　　　　　　 //Playerが死んでいるかどうか　　
    public GameObject gameOverText;
    public float timeInvincible = 1.5f;　 //無敵時間
    public float timeHpRecovery = 15.0f;　//HPが完全回復する時間
    bool isInvincible;　　　　　　　　　　//無敵状態になっているか
    bool isHpRecovery;　　　　　　　　　　//HP回復準備状態になっているか
    bool isDamageSE;　　　　　　　　　　　//ダメージ時SE再生状態になっているか
    float invincibleTimer;
    float hpRecoveryTimer;
    public AudioClip takeDamageSE;
    public AudioClip damageSE;
    private AudioSource audioSource;
    public TextMeshProUGUI havePointsText;
    public GameOver gameOver;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        havePointsText.text = havePoints + "P";
        if (playerHitPoint <= 0) 　　//HPが0になったらゲームオーバー
        {
            if (isDead == true)
            {
                return;
            }
            isDead = true;
            Battle.state = Battle.BattleState.End;
            gameOver.SetGameOver();
        }
        if (isInvincible == true)　　//無敵状態でタイマーが0になったら無敵状態解除
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
        if (isHpRecovery == true)　　//HP回復準備状態でタイマーが0になったらHPを回復してSE再生を止める
        {
            hpRecoveryTimer -= Time.deltaTime;
            if (hpRecoveryTimer < 0)
            {
                playerHitPoint += (100 - playerHitPoint);
                isHpRecovery = false;
                isDamageSE = false;
            }
        }

    }
    public void TakeDamage(int damage)
    {
        if(isInvincible == true)
        {
            return;
        }
        audioSource.PlayOneShot(takeDamageSE,0.5f);
        DamageSE();
        playerHitPoint -= damage;
        isInvincible = true;
        isHpRecovery = true;
        isDamageSE = true;
        invincibleTimer = timeInvincible;
        hpRecoveryTimer = timeHpRecovery;
    }
    public void DamageSE()
    {
        if(isDamageSE == true)
        {
            return;
        }
        audioSource.PlayOneShot(damageSE, 1.0f);
    }
}
