using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Parameters
    // -------------------------------------------------------------------------

    #region Parameters

    [SerializeField] ParticleSystem explosionParticle;

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods
    // -------------------------------------------------------------------------

    #region Public Methods

    public void Explode()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
    }

    #endregion
}
