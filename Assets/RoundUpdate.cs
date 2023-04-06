using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RoundUp()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("RoundUpdate", true);
        Invoke("EndOfAnimation", 2.0f);
    }
    void EndOfAnimation()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("RoundUpdate", false);
    }
}
