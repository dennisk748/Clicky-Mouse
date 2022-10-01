using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjects;
    private float spawnRate = 1f;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOver;
    [SerializeField] private GameObject[] lifes;
    [SerializeField] private ParticleSystem lossLifeEffect;
    [SerializeField] private int score;

    public int life = 5;

    public GameObject titleScreen;

    public bool isGameActive;

    void Start()
    {
        
    }

    IEnumerator SpawnActors()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index  = Random.Range(0, gameObjects.Count);
            Instantiate(gameObjects[index]);
        }
    }

    public void UpdateScore(int score1)
    {
        score += score1;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        isGameActive=false;
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(float difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnActors());

        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }

    public void UpdateLives(int value)
    {
        life -= 1;
        Destroy(lifes[value]);
        if (life == 0)
        {
            GameOver();
        }
    }
}
