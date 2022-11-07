using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 10.0f); // �O���l�[�h������Ă���10�b��ɔ���������
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Explode()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube"); //�uCube�v�^�O�̂����I�u�W�F�N�g��S�Č������Ĕz��ɂ����

        if (cubes.Length == 0) return; // �uCube�v�^�O�������I�u�W�F�N�g���Ȃ���Ή������Ȃ��B

        foreach (GameObject cube in cubes) // �z��ɓ��ꂽ��ЂƂ̃I�u�W�F�N�g
        {
            if (cube.GetComponent<Rigidbody>()) // Rigidbody������΁A�O���l�[�h�𒆐S�Ƃ��������̗͂�������
            {
                cube.GetComponent<Rigidbody>().AddExplosionForce(100f, transform.position, 30f, 5f, ForceMode.Impulse);
            }
        }
    }
}
