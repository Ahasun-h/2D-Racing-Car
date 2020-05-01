using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstraclCarMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ObstraclCar")
        {

            ObstraclCar obstraclCar = collision.GetComponent<ObstraclCar>();
            GiveRandomSpeed(obstraclCar);
        }
    }

    public void GiveRandomSpeed(ObstraclCar _obstaclCar)
    {
        float randomSpeed = Random.Range(2f, 10f);
        if (_obstaclCar.moveSpeed == 0f)
        {
            _obstaclCar.moveSpeed = randomSpeed;
        }
    }
}
