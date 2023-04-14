using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDataPersistance
{
    public bool showWinScreen = false;

    public string lableText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;

    private int _itemsCollected = 0;
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            if (_itemsCollected >= maxItems)
            {
                lableText = "You've found all the items";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                lableText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }


    public void LoadData(GameData data)
    {
        foreach(KeyValuePair<string, bool> pair in data.coinCollected)
        {
            if (pair.Value)
            {
                _itemsCollected++;
            }
        }
    }

    public void SaveData(ref GameData data)
    {

    }
    private int _playerHP = 10;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items collected: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), lableText);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                Screen.height / 2 - 50, 200, 100), "You Won!"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        }
    }
}
