using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameter : MonoBehaviour
{
    public int playerHitPoint;
    public bool isDead;
    public GameObject gameOverText;
    public float timeInvincible = 1.5f;
    public float timeHpRecovery = 15.0f;
    bool isInvincible;
    bool isHpRecovery;
    float invincibleTimer;
    float hpRecoveryTimer;
    public AudioClip takeDamageSE;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHitPoint <= 0)
        {
            if (isDead == true)
            {
                return;
            }
            isDead = true;
            Battle.state = Battle.BattleState.End; 
            gameOverText.SetActive(true);
        }
        if (isInvincible == true)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
        if (isHpRecovery == true)
        {
            hpRecoveryTimer -= Time.deltaTime;
            if (hpRecoveryTimer < 0)
            {
                playerHitPoint += (100 - playerHitPoint);
                isHpRecovery = false;
            }
        }

    }
    public void TakeDamage(int damage)
    {
        if(isInvincible == true)
        {
            return;
        }
        audioSource.PlayOneShot(takeDamageSE);
        playerHitPoint -= damage;
        isInvincible = true;
        isHpRecovery = true;
        invincibleTimer = timeInvincible;
        hpRecoveryTimer = timeHpRecovery;
    }
}
