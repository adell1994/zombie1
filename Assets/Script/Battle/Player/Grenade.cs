using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public AudioClip grenadeSE;
    AudioSource audioSource;

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
        yield return new WaitForSeconds(15.0f);
        Destroy(gameObject);		// �������g�����ł�����B
    }



    void Explode()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, 0.7f);   // �������g�𒆐S�ɁA���a0.7�ȓ��ɂ���Collider��T���A�z��Ɋi�[.
        foreach (Collider obj in targets)
        {       // targets�z������Ԃɏ��� (���̎��ɉ�����obj�Ƃ���)
            if (obj.tag == "Enemy")
            {               // �^�O����Enemy�Ȃ�
                Destroy(obj.gameObject);        // ���̃Q�[���I�u�W�F�N�g�����ł�����B
            }
        }
        Battle.grenadeState = Battle.GrenadeState.Redy;
    }
}