using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerParameter : MonoBehaviour
{
    public int playerHitPoint;
    public int havePoints;
    public bool isDead;
    public GameObject gameOverText;
    public float timeInvincible = 1.5f;
    public float timeHpRecovery = 15.0f;
    bool isInvincible;
    bool isHpRecovery;
    bool isDamageSE;
    float invincibleTimer;
    float hpRecoveryTimer;
    public AudioClip takeDamageSE;
    public AudioClip damageSE;
    private AudioSource audioSource;
    public TextMeshProUGUI havePointsText;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        havePointsText.text = havePoints + "P";
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
