using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemy")]
    public List<GameObject> enemy;

    [Header("References")]
    public Transform startPoint;

    private GameObject _currentPlayer;

    public void Start()
    {
        init();
    }
    public void init()
    {
        SpawnPlayer();
    }
    public void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.localPosition = startPoint.transform.position;
    }
}
