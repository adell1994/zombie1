using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieParameter : MonoBehaviour
{
    public int hitPoint = 100;
    public bool isDead = false;
    public GameObject head;
    public AudioClip headShotSE;
    public AudioClip zombieSE;
    public AudioSource audioSource;

    // Update is called once per frame
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(zombieSE);
    }
    void Update()
    {

        if (hitPoint <= 0)
        {
            if(isDead == true)
            {
                return;
            }
            Animator anim = GetComponent<Animator>();
            anim.SetBool("Dead", true);
            isDead = true;
            Invoke("Erase", 3.0f);

        }

    }

    public void Damage(int damage)
    {
        hitPoint -= damage;
    }
    public void Erase()
    {
        Destroy(gameObject);
    }
    public void HeadShot()
    {
        if (isDead == true)
        {
            return;
        }
        head.SetActive(false);
        audioSource.PlayOneShot(headShotSE);
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Dead", true);
        isDead = true;
        Invoke("Erase", 3.0f);
    }
}
