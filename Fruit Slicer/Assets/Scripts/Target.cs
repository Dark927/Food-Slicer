using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    
    Rigidbody rb;
    Vector2 startPosition = new Vector3(0, -4f);
    [SerializeField] float horizontalSpread = 4f;

    [SerializeField] float torqueSpread = 10f;
    [SerializeField] Vector2 forceSpread = new Vector2(12,19);
    float verticalForce = 1f;
    Vector3 torqueForce;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();


        // Vertical force 

        verticalForce = Random.Range(forceSpread.x, forceSpread.y);
        rb.AddForce(Vector3.up * verticalForce, ForceMode.Impulse);

        
        // Torque 

        torqueForce = new Vector3(
            Random.Range(-torqueSpread, torqueSpread), 
            Random.Range(-torqueSpread, torqueSpread), 
            Random.Range(-torqueSpread, torqueSpread)
            );

        rb.AddTorque(torqueForce, ForceMode.Impulse);


        // Position

        startPosition.x = Random.Range(-horizontalSpread, horizontalSpread);

        transform.position = startPosition;
    }

   
}
