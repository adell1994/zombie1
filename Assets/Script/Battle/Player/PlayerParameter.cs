using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameter : MonoBehaviour
{
    public int playerHitPoint;
    public bool isDead;
    public GameObject gameOverText;
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
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
            Battle.state = Battle.BattleState.Battle; 
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
        invincibleTimer = timeInvincible;
    }
}
