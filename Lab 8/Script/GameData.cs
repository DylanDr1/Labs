using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{

    public Vector3 playerPosition;

    public SeralizableTypes<string, bool> coinCollected;

    public GameData()
    {
        playerPosition = new Vector3(1405, 1199, 64);
        coinCollected = new SeralizableTypes<string, bool>();
    }
}