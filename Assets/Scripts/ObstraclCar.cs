using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstraclCar : MonoBehaviour
{
   
    public float moveSpeed = 0f;

    Rigidbody2D carRb;

    void Start()
    {
        carRb = GetComponent<Rigidbody2D>();


        if (moveSpeed > 0f)
        {
            //transform.Translate(transform.up * Time.deltaTime * moveSpeed);
            carRb.velocity = transform.up * Time.deltaTime * moveSpeed;
        }
    }

    
   /* void Update()
    {

       if (moveSpeed > 0f)
        {
            //transform.Translate(transform.up * Time.deltaTime * moveSpeed);
            carRb.velocity = transform.up * Time.deltaTime * moveSpeed;
        }  
    } */
}
