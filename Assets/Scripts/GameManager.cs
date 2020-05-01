using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instante;

    public GameObject gmaePlayRelated;
    public GameStates gameStates;
    public float moveSpeed = 8f;

    public enum GameStates
    {
        none,
        mainMenu,
        gmaePlaying,
        paused,
        playerDied,
        gmaeOver
    }

    private void Awake()
    {
        instante = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveGmaePlayObjects();
    }

    public void MoveGmaePlayObjects()
    {
        if(gameStates == GameStates.gmaePlaying)
        {
            gmaePlayRelated.transform.position += Vector3.up * Time.deltaTime * moveSpeed;
        }
    }
}
