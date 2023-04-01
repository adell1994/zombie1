using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //　出現させる敵を入れておく
    private List<GameObject> enemys_list = new List<GameObject>();
    [SerializeField] GameObject[] popPoints;
    public GameObject bossPopPoints;
    //　次に敵が出現するまでの時間
    [SerializeField] float appearNextTime;
    //　今何人の敵を出現させたか（総数）
    private int numberOfEnemys;
    //　待ち時間計測フィールド
    private float elapsedTime;
    public bool isBorn = false;
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
        //　経過時間を足す
        elapsedTime += Time.deltaTime;

        //　経過時間が経ったら
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
                //　敵の向きをランダムに決定
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
                //　出現させる敵をランダムに選ぶ
                var randomValue = Random.Range(0, enemys_list.Count);
                //　出現させる場所をランダムに選ぶ
                var randomPoint = Random.Range(0, popPoints.Length);
                //　敵の向きをランダムに決定
                var randomRotationY = Random.value * 360f;

                GameObject.Instantiate(enemys_list[randomValue], popPoints[randomPoint].transform.position, Quaternion.Euler(0f, randomRotationY, 0f));
            }
        }
        else
        {
            //　出現させる敵をランダムに選ぶ
            var randomValue = Random.Range(0, enemys_list.Count);
            //　出現させる場所をランダムに選ぶ
            var randomPoint = Random.Range(0, popPoints.Length);
            //　敵の向きをランダムに決定
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
        enemys_list.Add(zombie); // ゾンビ				
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

