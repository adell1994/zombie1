using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowGrenadeScript : MonoBehaviour
{
 
    public float thrust = 20f;
    public GameObject grenade;
    public GameObject grenade1;
    public GameObject grenade2;
    AudioSource audioSource;
    public AudioClip grenadeChargeSE;
    bool isCharge;
    Rigidbody rb_grenade;
    public int throwGrenade = 2;�@�@�@�@�@�@//�O���l�[�h������
    public Round round;
    bool isThrow;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        rb_grenade = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q)) // �L�[�{�[�h��Q���������Ƃ�
        {
            if(throwGrenade == 0)
            {
                return;
            }
            if(isThrow == true)
            {
                return;
            }
            Vector3 pos = transform.position + transform.TransformDirection(Vector3.forward);       // �v���C���[�ʒu�@+�@�v���C���[���ʂɂނ��ĂP�i�񂾋���
            GameObject bom = Instantiate(grenade, pos, Quaternion.identity) as GameObject;       // ��֒e���쐬

            Vector3 bom_speed = transform.TransformDirection(Vector3.forward) * 5;      // ��֒e�̈ړ����x�B�w�v���C���[���ʂɌ����Ă̑��x�x�N�g���x���T�B
            bom_speed += Vector3.up * 5;            // ��֒e�́w���������̑��x�x�����Z
            bom.GetComponent<Rigidbody>().velocity = bom_speed;     // ��֒e�̑��x����

            bom.GetComponent<Rigidbody>().angularVelocity = Vector3.forward * 7;	// ��֒e����]���x����.
            isThrow = true;
            throwGrenade --;
            StartCoroutine("ThrowInterval");
        }

        if(round.num == 6)�@//���E���h����6���ɃO���l�[�h�̐����񕜂���
        {
            if(isCharge == false)
            {
                audioSource.PlayOneShot(grenadeChargeSE);
                throwGrenade = 2;
                isCharge = true;
            }
        }
        else
        {
            isCharge = false;
        }

        if (throwGrenade < 2)
        {
            if(throwGrenade == 1)
            {
                grenade1.SetActive(false);
            }
            else if(throwGrenade == 0)
            {
                grenade2.SetActive(false);
            }
        }
        else
        {
            grenade1.SetActive(true);
            grenade2.SetActive(true);
        }

    }
    IEnumerator ThrowInterval()
    {
        yield return new WaitForSeconds(1.0f);
        isThrow = false;
    }
}
