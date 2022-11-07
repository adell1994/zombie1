using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenadeScript : MonoBehaviour
{
 
    public float thrust = 20f;
    public GameObject grenade;
    Rigidbody rb_grenade;

    // Start is called before the first frame update
    void Start()
    {
        rb_grenade = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q)) // �}�E�X�̍��N���b�N�������Ƃ�
        {
            rb_grenade = Instantiate(grenade, transform.position, transform.rotation).GetComponent<Rigidbody>(); // �O���l�[�h�𐶐�
            rb_grenade.AddForce(Vector3.Lerp(transform.forward, transform.up, 0.5f) * thrust, ForceMode.Impulse); // �O���l�[�h�ɗ͂���x������
        }
    }
}
