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
    GameManager gameManager;

    #endregion


    // -------------------------------------------------------------------------
    // Private Methods
    // -------------------------------------------------------------------------

    #region Private Methods

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();

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
        if (!gameManager.isGameActive)
        {
            return;
        }


        ApplyScore(points);

        if(points < 0)
        {

            gameManager.GameOver();
        }

        ExplodeTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!gameManager.isGameActive)
        {
            return;
        }

        // Check negative values for bad props

        if (points > 0)
        {
            ApplyScore(-points);
        }

        Destroy(gameObject);
    }

    private void ExplodeTarget()
    {
        Destroy(gameObject);

        Explosion explosion = GetComponent<Explosion>();
        explosion.Explode();
    }

    private void ApplyScore(int points)
    {
        gameManager.AddScore(points);
    }


    #endregion

}
