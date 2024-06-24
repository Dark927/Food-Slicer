using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Parameters
    // -------------------------------------------------------------------------

    #region Parameters 

    [Range(1,3)]
    [SerializeField] int difficulty = 1;
    Button btn;
    GameManager gameManager;

    #endregion

    // -------------------------------------------------------------------------
    // Private Methods
    // -------------------------------------------------------------------------

    #region Private Methods

    // Start is called before the first frame update
    private void Start()
    {
        btn = GetComponent<Button>();
        gameManager = FindObjectOfType<GameManager>();

        btn.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }

    #endregion
}
