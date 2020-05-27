using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "Minigolf/LevelData")]

public class LevelData : ScriptableObject, IEquatable<LevelData>
{
    public string SceneName => SceneName;
    [NaughtyAttributes.Scene]
    [SerializeField] private string scenename;

    public int avarageHit;

    public bool Equals(LevelData other)
    {
        if (this == other)
        {
            return true;
        }
        return false;
    }
}

