using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstraclCarGenerator : MonoBehaviour
{

    public GameObject[] obstracolCars;

    void Start()
    {
        InvokeRepeating("GenerateObstracleCar", 1f, Random.Range(1f,3f));
    }

    void Update()
    {
        
    }


    private void GenerateObstracleCar()
    {
        if(GameManager.instante.gameStates == GameManager.GameStates.gmaePlaying)
        {
            float carGeneratioPoint = GameManager.instante.gmaePlayRelated.transform.position.y + 30.8f;

            int randomVumber = Random.Range(0, 4);

            if (randomVumber == 0)
            {
                Instantiate(obstracolCars[Random.Range(0, obstracolCars.Length)], new Vector3(6.5f, carGeneratioPoint, 0f), Quaternion.identity);
            }
            else if (randomVumber == 1)
            {
                Instantiate(obstracolCars[Random.Range(0, obstracolCars.Length)], new Vector3(2.4f, carGeneratioPoint, 0f), Quaternion.identity);
            }
            else if (randomVumber == 2)
            {
                Instantiate(obstracolCars[Random.Range(0, obstracolCars.Length)], new Vector3(-2.4f, carGeneratioPoint, 0f), Quaternion.identity);
            }
            else if (randomVumber == 3)
            {
                Instantiate(obstracolCars[Random.Range(0, obstracolCars.Length)], new Vector3(-6.5f, carGeneratioPoint, 0f), Quaternion.identity);
            }
        }
    }
}
