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

    Rigidbody rb;
    Vector2 startPosition = new Vector3(0, -4f);
    [SerializeField] float horizontalSpread = 4f;

    [SerializeField] float torqueSpread = 10f;
    [SerializeField] Vector2 forceSpread = new Vector2(12, 18);

    #endregion


    // -------------------------------------------------------------------------
    // Private Methods
    // -------------------------------------------------------------------------

    #region Private Methods

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Force 

        ConfigureForces();

        // Position

        ConfigurePosition();
    }


    private void ConfigurePosition()
    {
        startPosition.x = RandomPositionX(horizontalSpread);
        transform.position = startPosition;
    }

    private void ConfigureForces()
    {
        // Vertical Force

        rb.AddForce(Vector3.up * RandomForce(forceSpread.x, forceSpread.y), ForceMode.Impulse);


        // Torque 

        rb.AddTorque(RandomRotation(torqueSpread), ForceMode.Impulse);
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

    #endregion

}
