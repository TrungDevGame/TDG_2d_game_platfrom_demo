using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string name = "abc";
    public int money;
    public int health;
    public int exp;
    public int level;
    public List<InventoryItem> listItem;

    private void Start()
    {
        ReadData();
    }
    void ReadData()
    {
        string datassave = PlayerPrefs.GetString("datasave", "");
        Debug.Log("get data save " + datassave);
        JsonUtility.FromJsonOverwrite(datassave, this);
    }
    void SaveData()
    {
        string savedata = JsonUtility.ToJson(this);
        Debug.Log(savedata);
        PlayerPrefs.SetString("datasave", savedata);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
           
        }
    }
    public void OnApplicationQuit()
    {
        SaveData();
    }
}

[System.Serializable]
public class InventoryItem
{
    public string id = "";
    public string iconId;
}