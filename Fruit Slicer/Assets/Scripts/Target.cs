using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Parameters
    // -------------------------------------------------------------------------

    #region Parameters 

    [Header("Main Settings")]
    [Space]

    [SerializeField] int points = 1;

    [Space]
    [Header("Spawn Settings")]
    [Space]
    
    [SerializeField] Vector2 scaleRange = new Vector2(2, 3.5f);
    [SerializeField] float horizontalSpread = 4f;
    [SerializeField] float torqueSpread = 10f;
    [SerializeField] Vector2 forceRange = new Vector2(12, 18);

    Rigidbody rb;
    Vector2 startPosition = new Vector3(0, -4f);

    #endregion


    // -------------------------------------------------------------------------
    // Private Methods
    // -------------------------------------------------------------------------

    #region Private Methods

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Scale 

        ConfigureScale();

        // Force 

        ConfigureForces();

        // Position

        ConfigurePosition();
    }

    private void ConfigureScale()
    {
        transform.localScale = RandomScale(scaleRange.x, scaleRange.y);
    }

    private void ConfigurePosition()
    {
        startPosition.x = RandomPositionX(horizontalSpread);
        transform.position = startPosition;
    }

    private void ConfigureForces()
    {
        // Vertical Force

        rb.AddForce(Vector3.up * RandomForce(forceRange.x, forceRange.y), ForceMode.Impulse);


        // Torque 

        rb.AddTorque(RandomRotation(torqueSpread), ForceMode.Impulse);
    }


    private Vector3 RandomScale(float min, float max)
    {
        float randomScale = Random.Range(min, max);
        return new Vector3(randomScale, randomScale, randomScale);
    }

    private float RandomPositionX(float spread)
    {
        return Random.Range(-spread, spread);
    }

    private float RandomForce(float min, float max)
    {
        return Random.Range(min, max);
    }

    private Vector3 RandomRotation(float spread)
    {
        return new Vector3(
                    Random.Range(-spread, spread),
                    Random.Range(-spread, spread),
                    Random.Range(-spread, spread)
                    );
    }


    private void OnMouseDown()
    {
        ApplyScore(points);


        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check negative values for bad props

        if (points > 0)
        {
            ApplyScore(-points);
        }


        Destroy(gameObject);
    }

    private void ApplyScore(int points)
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.AddScore(points);
    }


    #endregion

}
