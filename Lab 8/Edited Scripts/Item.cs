using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Item : MonoBehaviour, IDataPersistance
{
    public PlayerHealth gameManager;
    [SerializeField] private string id;
    private bool collected = false;
    private SpriteRenderer visual;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<PlayerHealth>();
    }


    public void LoadData(GameData data)
    {
        data.coinCollected.TryGetValue(id, out collected);   
        if (collected)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.coinCollected.ContainsKey(id))
        {
            data.coinCollected.Remove(id);
        }
        data.coinCollected.Add(id, collected);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collected = true;
            Destroy(gameObject);
            Debug.Log("Item collected!");
            gameManager.Items += 1; // gameManager.Items = gameManager.Items + 1;
        }
    }

}