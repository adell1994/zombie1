using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public AudioClip grenadeSE;
    AudioSource audioSource;
    ZombieParameter enemyHp;

    // Start is called before the first frame update
    void Start()
    {
        Battle.grenadeState = Battle.GrenadeState.Throw;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(grenadeSE);
        Invoke("Explode", 10.0f); // グレネードが作られてから10秒後に爆発させる
        StartCoroutine("DeleteGrenade");
    }
    IEnumerator DeleteGrenade()
    {
        yield return new WaitForSeconds(13.0f);
        Destroy(gameObject);		// 自分自身を消滅させる。
    }



    void Explode()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, 1.0f);   // 自分自身を中心に、半径1.0以内にいるColliderを探し、配列に格納.
        foreach (Collider obj in targets)
        {       // targets配列を順番に処理 (その時に仮名をobjとする)
            if (obj.tag == "Enemy")
            {               // タグ名がEnemyなら
                ZombieParameter enemy = obj.GetComponent<EnemyPart>().parameter;
                enemy.GrenadeDeath();
            }
        }
        Battle.grenadeState = Battle.GrenadeState.Redy;
    }
}