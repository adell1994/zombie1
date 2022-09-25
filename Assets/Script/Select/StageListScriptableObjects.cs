using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StageListScriptableObject", order = 1)]
public class StageListScriptableObjects : ScriptableObject
{
    public List<StageScriptableObjects> StageList;
}