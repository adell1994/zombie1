using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerParameter : MonoBehaviour
{
    public int playerHitPoint;�@�@�@�@�@�@//Player��HP
    public int havePoints;               //���݂̏����|�C���g
    public bool isDead;�@�@�@�@�@�@�@�@ //Player������ł��邩�ǂ����@�@
    public GameObject gameOverText;
    public float timeInvincible = 1.5f;�@ //���G����
    public float timeHpRecovery = 15.0f;�@//HP�����S�񕜂��鎞��
    bool isInvincible;�@�@�@�@�@�@�@�@�@�@//���G��ԂɂȂ��Ă��邩
    bool isHpRecovery;�@�@�@�@�@�@�@�@�@�@//HP�񕜏�����ԂɂȂ��Ă��邩
    bool isDamageSE;�@�@�@�@�@�@�@�@�@�@�@//�_���[�W��SE�Đ���ԂɂȂ��Ă��邩
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
        if (playerHitPoint <= 0) �@�@//HP��0�ɂȂ�����Q�[���I�[�o�[
        {
            if (isDead == true)
            {
                return;
            }
            isDead = true;
            Battle.state = Battle.BattleState.End;
            gameOver.SetGameOver();
        }
        if (isInvincible == true)�@�@//���G��ԂŃ^�C�}�[��0�ɂȂ����疳�G��ԉ���
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
        if (isHpRecovery == true)�@�@//HP�񕜏�����ԂŃ^�C�}�[��0�ɂȂ�����HP���񕜂���SE�Đ����~�߂�
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
