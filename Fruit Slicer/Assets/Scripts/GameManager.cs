using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Parameters
    // -------------------------------------------------------------------------

    #region Parameters 

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] List<GameObject> targetPrefabs;
    [SerializeField] float spawnRate = 1f;

    float score = 0;

    #endregion


    // -------------------------------------------------------------------------
    // Private Methods
    // -------------------------------------------------------------------------

    #region Private Methods 

    private void Start()
    {
        StartCoroutine(SpawnTargets(spawnRate));
        UpdateScoreUI();
    }


    IEnumerator SpawnTargets(float spawnRate)
    {
        while(true)
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
        UpdateScoreUI();
    }

    #endregion

}
