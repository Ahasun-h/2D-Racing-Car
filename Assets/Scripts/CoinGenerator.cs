using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coinPrefab;

    public void Start()
    {
        GeneraterCoinsPattern();
    }

    private void GeneraterCoinsPattern()
    {
        int noOfCoins = Random.Range(3, 9);
        int yPos = 0;

        for (int i = 0; i < noOfCoins; i++)
        {
      
            Transform coin = Instantiate(coinPrefab).transform;
            coin.parent = this.transform;
            coin.localPosition = new Vector2(0f, yPos);
            yPos += 3;
        }
    }

 

}
