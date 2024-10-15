using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DeathCountSO : ScriptableObject
{
    [SerializeField]
    private float _numOfDeaths;

    public float NumOfDeathes
    {
        get { return _numOfDeaths; }
        set { _numOfDeaths = value; }
    }
}
