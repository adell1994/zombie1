using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum BossType
    {
        None,
        Boss1st,        //中ボス	
        Boss2nd     //ボス	
    }
    public static BossType bossType = BossType.None;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
