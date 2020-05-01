using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


public class UIManager : MonoBehaviour
{
    public GameObject gameName;
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject restartButton;
    public GameObject scoreUI;
    public GameObject coinUI;
    public GameObject pauseButtonUI;
    public GameObject HighestScoreAndCoinUI;
    public Text scroreText;
    public Text coinText;
    public Text highScoreText;
    public Text totalCoinText;

    private int scoreInt;
    private int coinInt;

    private int highScore;
    private int totalCoin;


    AudioSource audioSource;


    public void Awake()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        if (PlayerPrefs.HasKey("totalCoin"))
        {
            totalCoin = PlayerPrefs.GetInt("totalCoin");
        }

        totalCoinText.text = totalCoin.ToString();
        highScoreText.text = highScore.ToString();

    }


    public void Start()
    {
        scoreInt = 0;
        scroreText.text = scoreInt.ToString();

        coinInt = 0;
        coinText.text = coinInt.ToString();

        restartButton.SetActive(false);
        ToggleUI(false);

        

    }

    public void PlayGame()
    {
        gameName.SetActive(false);
        playButton.SetActive(false);
        quitButton.SetActive(false);
        HighestScoreAndCoinUI.SetActive(false);
        GameManager.instante.gameStates = GameManager.GameStates.gmaePlaying;
        StartCoroutine("IncreaseScore");
        ToggleUI(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
       
    }

    public void ActivateRestartUI()
    {
        gameName.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif

        Application.Quit();
        Debug.Log("Game Quit");
    }

    IEnumerator IncreaseScore()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            if(GameManager.instante.gameStates == GameManager.GameStates.gmaePlaying)
            {
                scoreInt += 1;
                scroreText.text = scoreInt.ToString();
            }
            yield return new WaitForSeconds(0.2f);

        }
          
    }

    public void ToggleUI(bool isActive)
    {
        scoreUI.SetActive(isActive);
        coinUI.SetActive(isActive);
        pauseButtonUI.SetActive(isActive);
       
    }

    public void IncreaseCoins()
    {
        coinInt += 1;
        coinText.text = coinInt.ToString();
    } 

    public void SaveGameData()
    {
        if (scoreInt > highScore)
        {
            highScore = scoreInt;
        }

        totalCoin += coinInt;

        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.SetInt("totalCoin", totalCoin);
         
    }

    public void CarCrashSound()
    {
        audioSource = GetComponent<AudioSource>();

        if (GameManager.instante.gameStates == GameManager.GameStates.playerDied)
        {
            audioSource.Play();
            
        }
        
    }

}
