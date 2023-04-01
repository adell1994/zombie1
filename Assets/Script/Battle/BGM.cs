using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] clips;
    public Round round;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = clips[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetUp()
    {
        if ((round.num == 5) || (round.num == 10))
        {
            if (round.num == 5)
            {
                audioSource.clip = clips[1];
                audioSource.Play();
            }
            if (round.num == 10)
            {
                audioSource.clip = clips[2];
                audioSource.Play();
            }
        }
        else
        {
            audioSource.clip = clips[0];
            audioSource.Play();
        }
    }
}
