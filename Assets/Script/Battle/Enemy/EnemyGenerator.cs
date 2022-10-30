using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //�@�o��������G�����Ă���
    [SerializeField] GameObject[] enemys;
    [SerializeField] GameObject[] popPoints;
    //�@���ɓG���o������܂ł̎���
    [SerializeField] float appearNextTime;
    //�@���̏ꏊ����o������G�̐�
    [SerializeField] int maxNumOfEnemys;
    //�@�����l�̓G���o�����������i�����j
    private int numberOfEnemys;
    //�@�҂����Ԍv���t�B�[���h
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemys = 0;
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfEnemys >= maxNumOfEnemys)
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
        var randomValue = Random.Range(0, enemys.Length);
        var randomPoint = Random.Range(0, popPoints.Length);
        //�@�G�̌����������_���Ɍ���
        var randomRotationY = Random.value * 360f;

        GameObject.Instantiate(enemys[randomValue],popPoints[randomPoint].transform.position, Quaternion.Euler(0f, randomRotationY, 0f));

        numberOfEnemys++;
        elapsedTime = 0f;
    }
}

