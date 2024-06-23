using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Parameters
    // -------------------------------------------------------------------------

    #region Parameters 

    [SerializeField] List<GameObject> targetPrefabs;
    [SerializeField] float spawnRate = 1f;

    #endregion


    // -------------------------------------------------------------------------
    // Private Methods
    // -------------------------------------------------------------------------

    #region Private Methods 

    private void Start()
    {
        StartCoroutine(SpawnTargets(spawnRate));
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

    #endregion


}
