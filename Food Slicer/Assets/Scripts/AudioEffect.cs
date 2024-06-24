using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffect : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Parameters
    // -------------------------------------------------------------------------

    #region Parameters

    [SerializeField] AudioClip touchSound;
    [SerializeField] AudioClip fallDownSound;

    AudioManager audioManager;

    #endregion

    // -------------------------------------------------------------------------
    // Private Methods
    // -------------------------------------------------------------------------

    #region Private Methods

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods
    // -------------------------------------------------------------------------

    #region Public Methods

    public void PlayTouchSound()
    {
        audioManager.PlaySound(touchSound);
    }

    public void PlayFallDownSound()
    {
        audioManager.PlaySound(fallDownSound);
    }

    #endregion
}
