using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public enum BattleState
    {
        Redy,
        Battle,
        End
    }
    public static  BattleState state = BattleState.Redy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}