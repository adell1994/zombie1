using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenadeScript : MonoBehaviour
{
 
    public float thrust = 20f;
    public GameObject grenade;
    Rigidbody rb_grenade;
    public int throwGrenade = 2;
    bool isThrow;
    // Start is called before the first frame update
    void Start()
    {
        rb_grenade = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q)) // キーボードのQを押したとき
        {
            if(throwGrenade == 0)
            {
                return;
            }
            if(isThrow == true)
            {
                return;
            }
            Vector3 pos = transform.position + transform.TransformDirection(Vector3.forward);       // プレイヤー位置　+　プレイヤー正面にむけて１進んだ距離
            GameObject bom = Instantiate(grenade, pos, Quaternion.identity) as GameObject;       // 手榴弾を作成

            Vector3 bom_speed = transform.TransformDirection(Vector3.forward) * 5;      // 手榴弾の移動速度。『プレイヤー正面に向けての速度ベクトル』を５。
            bom_speed += Vector3.up * 5;            // 手榴弾の『高さ方向の速度』を加算
            bom.GetComponent<Rigidbody>().velocity = bom_speed;     // 手榴弾の速度を代入

            bom.GetComponent<Rigidbody>().angularVelocity = Vector3.forward * 7;	// 手榴弾を回転速度を代入.
            isThrow = true;
            throwGrenade--;
            StartCoroutine("ThrowInterval");
        }

    }
    IEnumerator ThrowInterval()
    {
        yield return new WaitForSeconds(1.0f);
        isThrow = false;
    }
}
