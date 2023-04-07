using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public AudioClip startSE;
    public AudioSource audioSource;
    public GameObject text;

    public bool isButtonPush = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        PlayerPrefs.DeleteKey("Bullets_auto");
        PlayerPrefs.DeleteKey("bulletsInTheGun_auto");
        PlayerPrefs.DeleteKey("Bullets_semi");
        PlayerPrefs.DeleteKey("bulletsInTheGun_semi");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChengeScene()
    {
        SceneManager.LoadScene("SelectScene");
    }
    public void PushStartButton()
    {
        if (isButtonPush == true)
        {
            return;
        }
        Animator anim = text.GetComponent<Animator>();
        anim.SetBool("PushButton",true);
        isButtonPush = true;
        audioSource.PlayOneShot(startSE);
        Invoke("ChengeScene", 2.5f);
    }
}
