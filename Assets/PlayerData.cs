using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;

    public PlayerData(LevelManager player)
    {
        level = LevelManager.level;
    }
}
