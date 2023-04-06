using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    private List<GameObject> enemys_list = new List<GameObject>();    //�@�o��������G�����Ă���
    [SerializeField] GameObject[] popPoints;�@�@�@�@�@�@�@�@�@�@�@�@�@//�@�G�̏o���ꏊ
    public GameObject bossPopPoints;�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@//  �{�X�̏o���ꏊ
    [SerializeField] float appearNextTime;   �@�@�@�@�@�@�@�@�@�@�@�@ //�@���ɓG���o������܂ł̎���
    private int numberOfEnemys;    �@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@//�@�����l�̓G���o�����������i�����j
    private float elapsedTime;    �@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@//�@�҂����Ԍv���t�B�[���h
    public bool isBorn = false;�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@//�@�{�X���o��������
    public GameObject zombie;
    public GameObject dog;
    public GameObject bossZombie;
    public  Round round;
    public Battle battle;

    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemys = 0;
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfEnemys >= round.enemyNum) 
        {
            return;
        }
        //�@�o�ߎ��Ԃ𑫂�
        elapsedTime += Time.deltaTime;

        //�@�o�ߎ��Ԃ��o������
        if (elapsedTime > appearNextTime)
        {
            elapsedTime = 0f;

            AppearEnemy();
        }
    }
    void AppearEnemy()
    {
        if (Enemy.bossType == Enemy.BossType.Boss2nd)
        {
            if (isBorn == false)
            {
                var RotationY = Random.value * 360f;
                GameObject.Instantiate(bossZombie, bossPopPoints.transform.position, Quaternion.Euler(0f, RotationY, 0f));
                numberOfEnemys++;
                elapsedTime = 0f;
                isBorn = true;
                return;
            }
            else
            {
                SetUp();
                //�@�o��������G�������_���ɑI��
                var randomValue = Random.Range(0, enemys_list.Count);
                //�@�o��������ꏊ�������_���ɑI��
                var randomPoint = Random.Range(0, popPoints.Length);
                //�@�G�̌����������_���Ɍ���
                var randomRotationY = Random.value * 360f;

                GameObject.Instantiate(enemys_list[randomValue], popPoints[randomPoint].transform.position, Quaternion.Euler(0f, randomRotationY, 0f));
            }
        }
        else
        {
            //�@�o��������G�������_���ɑI��
            var randomValue = Random.Range(0, enemys_list.Count);
            //�@�o��������ꏊ�������_���ɑI��
            var randomPoint = Random.Range(0, popPoints.Length);
            //�@�G�̌����������_���Ɍ���
            var randomRotationY = Random.value * 360f;

            GameObject.Instantiate(enemys_list[randomValue], popPoints[randomPoint].transform.position, Quaternion.Euler(0f, randomRotationY, 0f));
        }


        numberOfEnemys++;
        elapsedTime = 0f;
    }
    public void SetUp()
    {
        numberOfEnemys = 0;
        elapsedTime = 3.0f;
        enemys_list.Clear();
        enemys_list.Add(zombie); // �]���r				
        if (round.roundNum > 15)
        {
            enemys_list.Add(dog);
        }
    }
    public void BossSetUp()
    {
        if(Enemy.bossType == Enemy.BossType.Boss1st)
        {
            numberOfEnemys = 0;
            elapsedTime = 3.0f;
            enemys_list.Clear();
            enemys_list.Add(dog);
        }
        if(Enemy.bossType == Enemy.BossType.Boss2nd)
        {
            numberOfEnemys = 0;
            elapsedTime = 3.0f;
            enemys_list.Clear();
            isBorn = false;
            if (round.isBossEnemy == true)
            {
                enemys_list.Add(zombie);
            }
        }
    }
}

