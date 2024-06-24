using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Blade : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Parameters
    // -------------------------------------------------------------------------

    #region Parameters

    GameManager gameManager;
    Rigidbody rb;
    Collider coll;
    TrailRenderer trail;

    bool isActive = false;

    #endregion


    // -------------------------------------------------------------------------
    // Private Methods
    // -------------------------------------------------------------------------

    #region Private Methods

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        trail = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        UpdateBladeState();
    }

    private void UpdateBladeState()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                isActive = true;
                UpdateComponents();
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                isActive = false;
                UpdateComponents();
            }

            BladeFollowsMouse();
        }
    }

    private void UpdateComponents()
    {
        coll.enabled = isActive;
        trail.enabled = isActive;
    }

    private void BladeFollowsMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    #endregion
}
