using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjects;
    private float spawnRate = 1f;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOver;
    [SerializeField] private int score;

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
}
