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
        Invoke("Explode", 10.0f); // �O���l�[�h������Ă���10�b��ɔ���������
        StartCoroutine("DeleteGrenade");
    }
    IEnumerator DeleteGrenade()
    {
        yield return new WaitForSeconds(13.0f);
        Destroy(gameObject);		// �������g�����ł�����B
    }



    void Explode()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, 1.0f);   // �������g�𒆐S�ɁA���a1.0�ȓ��ɂ���Collider��T���A�z��Ɋi�[.
        foreach (Collider obj in targets)
        {       // targets�z������Ԃɏ��� (���̎��ɉ�����obj�Ƃ���)
            if (obj.tag == "Enemy")
            {               // �^�O����Enemy�Ȃ�
                ZombieParameter enemy = obj.GetComponent<EnemyPart>().parameter;
                enemy.GrenadeDeath();
            }
        }
        Battle.grenadeState = Battle.GrenadeState.Redy;
    }
}