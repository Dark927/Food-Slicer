using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Parameters
    // -------------------------------------------------------------------------

    #region Parameters

    [SerializeField] GameObject GamePausePanel;
    bool isGamePaused = false;

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods
    // -------------------------------------------------------------------------

    #region Public Methods

    public void PauseGame()
    {
        GamePausePanel.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void UnPauseGame()
    {
        GamePausePanel.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    public void SwitchPause()
    {
        if(isGamePaused)
        {
            UnPauseGame();
        }
        else
        {
            PauseGame();
        }
    }

    public bool IsPaused()
    {
        return isGamePaused;
    }

    #endregion
}
