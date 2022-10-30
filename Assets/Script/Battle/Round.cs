using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    public int round = 1;
    public int logic_round = 1;
    public EnemyGenerator enemyGenerator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ForwardRound()
    {
        round++;
        logic_round++;
    }
}
