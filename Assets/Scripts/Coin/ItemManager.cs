using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public int coins;
    public TextMeshProUGUI coinText;
    private void Awake()
    {
       if(Instance == null){
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Reset();
    }
    private void Reset()
    {
        coins = 0;
    }

    public void AddCoins(int amount = 1) { 
        coins += amount;
        UpdateCoins(coins);

    }
    public void UpdateCoins(int value)
    {
        coinText.text = "x" + value.ToString();
    }
}
