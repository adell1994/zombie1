using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AmmoShop: MonoBehaviour
{
    public AudioClip ammoRefillSE;         //弾薬補充SE
    AudioSource audioSource;
    public GameObject shopText;
    PlayerParameter playerParameter;
    private bool isStartShopping = false;  //弾薬ショップが利用できるか
    private bool isPushFlag = false;　　　//ボタンを押してフラグを実行したか　
    public enum AmmoShopState
    {
        Redy,
        Buy,
        End
    }
    public static AmmoShopState ammoShopState = AmmoShopState.Redy;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        playerParameter = GameObject.Find("Player").GetComponent<PlayerParameter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && isStartShopping && playerParameter.havePoints >= 500)
        {
            if(isPushFlag == false)
            {
                isPushFlag = true;
                audioSource.PlayOneShot(ammoRefillSE);
                playerParameter.havePoints -= 500;
                ammoShopState = AmmoShopState.Buy;
            }
        }
        else
        {
            isPushFlag = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopText.SetActive(true);
            isStartShopping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopText.SetActive(false);
            isStartShopping = false;
        }
    }
}
