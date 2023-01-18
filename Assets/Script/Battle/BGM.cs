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
        if ((round.roundNum == 5) || (round.roundNum == 10))
        {
            if (round.roundNum == 5)
            {
                audioSource.clip = clips[1];
                audioSource.Play();
            }
            if (round.roundNum == 10)
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
