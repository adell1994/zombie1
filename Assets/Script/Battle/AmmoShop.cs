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
    private float timeReset = 2;
    private float time = 0;

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
        time = 0;
        audioSource = gameObject.GetComponent<AudioSource>();
        playerParameter = GameObject.Find("Player").GetComponent<PlayerParameter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && playerParameter.havePoints >= 500)
            {
                time += Time.deltaTime;
                if (time > timeReset)
                {
                    audioSource.PlayOneShot(ammoRefillSE);
                    playerParameter.havePoints -= 500;
                    ammoShopState = AmmoShopState.Buy;
                    time = 0;
                }

            }
        }
        else
        {
            shopText.SetActive(false);
        }
    }
}
