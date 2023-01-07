using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AmmoShop: MonoBehaviour
{
    public AudioClip ammoRefillSE;
    AudioSource audioSource;
    public GameObject shopText;
    PlayerParameter playerParameter;
    private bool startShopping = false;
    private bool pushFlag = false;
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
        if (Input.GetKey(KeyCode.E) && startShopping && playerParameter.havePoints >= 500)
        {
            if(pushFlag == false)
            {
                pushFlag = true;
                audioSource.PlayOneShot(ammoRefillSE);
                playerParameter.havePoints -= 500;
                ammoShopState = AmmoShopState.Buy;
            }
        }
        else
        {
            pushFlag = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopText.SetActive(true);
            startShopping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopText.SetActive(false);
        }
    }
}
