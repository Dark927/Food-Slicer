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

    [Header("UI Settings")]
    [Space]

    [SerializeField] GameObject gameStartPanel;
    [SerializeField] GameObject gameOverPanel;

    [Space]

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;


    [Space]
    [Header("Game Settings")]
    [Space]

    [SerializeField] List<GameObject> targetPrefabs;
    [SerializeField] float spawnRate = 1.5f;

    int lives = 6;
    float score = 0;
    public bool isGameActive = false;

    PauseManager pauseManager;

    #endregion

    // -------------------------------------------------------------------------
    // Private Methods
    // -------------------------------------------------------------------------

    #region Private Methods 

    private void Start()
    {
        pauseManager = FindObjectOfType<PauseManager>();
    }

    private void Update()
    {
        if (lives == 0)
        {
            GameOver();
        }

        ManagePause();
    }

    private void ManagePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !IsAnyPanelActive())
        {
            pauseManager.SwitchPause();

            isGameActive = pauseManager.IsPaused() ? false : true;
        }
    }

    private bool IsAnyPanelActive()
    {
        if(gameStartPanel.activeInHierarchy || gameOverPanel.activeInHierarchy)
        {
            return true;
        }
        return false;
    }

    IEnumerator SpawnTargets(float spawnRate)
    {
        while (isGameActive)
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

    private void UpdateLivesUI()
    {
        livesText.text = "Lives : " + lives.ToString();
    }

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods
    // -------------------------------------------------------------------------

    #region Public Methods

    public void AddScore(int points = 1)
    {
        score += points;

        if (score < 0)
        {
            score = 0;
        }

        UpdateScoreUI();
    }

    public void CutLives(int amount = 1)
    {
        lives -= amount;

        UpdateLivesUI();
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
        lives -= difficulty;

        gameStartPanel.SetActive(false);

        isGameActive = true;
        StartCoroutine(SpawnTargets(spawnRate));

        UpdateLivesUI();
        UpdateScoreUI();
    }

    #endregion

}
