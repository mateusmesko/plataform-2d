using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public SOint coins;
    public SOint redBalls;
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
        coins.value = 0;
        redBalls.value = 0;
    }

    public void AddCoins(int amount = 1) { 
        coins.value += amount;

    }
    public void RedBallsAdd(int amount = 1)
    {
        redBalls.value += amount;

    }
    public void UpdateCoins(int value)
    {
     
    }
}
