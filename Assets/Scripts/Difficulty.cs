using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public float spawnRate;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager =GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void SetDifficulty()
    {
        gameManager.StartGame(spawnRate);
    }
}
