using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Parameters
    // -------------------------------------------------------------------------

    #region Parameters 

    [SerializeField] GameObject gameStartPanel;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] List<GameObject> targetPrefabs;
    [SerializeField] float spawnRate = 1.5f;

    float score = 0;

    #endregion

    public bool isGameActive;


    // -------------------------------------------------------------------------
    // Private Methods
    // -------------------------------------------------------------------------

    #region Private Methods 
    IEnumerator SpawnTargets(float spawnRate)
    {
        while(isGameActive)
        {
            int targetIndex = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[targetIndex]);

            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods
    // -------------------------------------------------------------------------

    #region Public Methods

    public void AddScore(int points = 1)
    {
        score += points;

        if(score < 0)
        {
            score = 0;
        }

        UpdateScoreUI();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;

        gameStartPanel.SetActive(false);

        isGameActive = true;
        StartCoroutine(SpawnTargets(spawnRate));
        UpdateScoreUI();
    }

    #endregion

}
