using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //�@�o��������G�����Ă���
    private List<GameObject> enemys_list = new List<GameObject>();
    [SerializeField] GameObject[] popPoints;
    //�@���ɓG���o������܂ł̎���
    [SerializeField] float appearNextTime;
    //�@�����l�̓G���o�����������i�����j
    private int numberOfEnemys;
    //�@�҂����Ԍv���t�B�[���h
    private float elapsedTime;
    public GameObject zombie;
    public GameObject dog;
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
        //�@�o��������G�������_���ɑI��
        var randomValue = Random.Range(0, enemys_list.Count);
        var randomPoint = Random.Range(0, popPoints.Length);
        //�@�G�̌����������_���Ɍ���
        var randomRotationY = Random.value * 360f;

        GameObject.Instantiate(enemys_list[randomValue], popPoints[randomPoint].transform.position, Quaternion.Euler(0f, randomRotationY, 0f));

        numberOfEnemys++;
        elapsedTime = 0f;
    }
    public void SetUp()
    {
        numberOfEnemys = 0;
        elapsedTime = 5.0f;
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
            enemys_list.Clear();
            enemys_list.Add(dog);
        }
        if(Enemy.bossType == Enemy.BossType.Boss2nd)
        {

        }
    }
}

