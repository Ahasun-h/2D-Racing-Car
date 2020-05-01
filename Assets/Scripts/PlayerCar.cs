using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    public bool carChangingLang;
    public bool isPlayerCarGoingLeft;
    public bool isPlayerCarRotating;
    public bool clearPlayerCarRotation;

    public float moveSpeed = 5f;
    public float carTargetPosition;


    public float xPos = 0f;
    public float zRotation = 0f;

    public Road road;

    public UIManager uIManager;


    
 



    void Start()
    {
        
    }

   
    void Update()
    {
        // This code for contorlling player from PC  kebord
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartRightMove();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartLeftMove();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            StopMove();
        }
        // This code for contorlling player from PC  kebord------------



        //This code  for android mobile player controller

        if (Input.GetMouseButton(0)){

            Vector3 mousePos = Input.mousePosition;

            if(mousePos.x < Screen.width / 2f)
            {
                StartLeftMove();
            }
            if(mousePos.x > Screen.width / 2f)
            {
                StartRightMove();
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            StopMove();
        }



        if (GameManager.instante.gameStates == GameManager.GameStates.gmaePlaying)
        {
            changingCarLang();
        }

        
    }

    private void StopMove()
    {
        carChangingLang = false;
        clearPlayerCarRotation = true;
    }

    private void StartLeftMove()
    {
        carChangingLang = true;
        isPlayerCarGoingLeft = true;
        clearPlayerCarRotation = false;
    }

    private void StartRightMove()
    {
        carChangingLang = true;
        isPlayerCarGoingLeft = false;
        clearPlayerCarRotation = false;
    }

    public void changingCarLang()
    {
       

        if (carChangingLang && !clearPlayerCarRotation)
        {
            if (isPlayerCarGoingLeft)
            {
                if (xPos >= -7f)
                {
                    xPos -= Time.deltaTime * moveSpeed * 2f;
                }

                if(zRotation < 12f)
                {
                    zRotation += Time.deltaTime * moveSpeed * 2f;
                }
            }
            else if (!isPlayerCarGoingLeft)
            {
                if (xPos <= 7f)
                {
                    xPos += Time.deltaTime * moveSpeed * 2f ;
                }

                if (zRotation > -12)
                {
                    zRotation -= Time.deltaTime * moveSpeed * 2f;
                }
            }


           /* Vector3 currentPosition = transform.position;
            float xPosition = Mathf.Lerp(currentPosition.x, carTargetPosition,Time.deltaTime*moveSpeed);

            this.transform.position = new Vector3(xPosition, transform.position.y,transform.position.z);

            if(Mathf.Abs(currentPosition.x - carTargetPosition) < 0.0F )
            {
                carChangingLang = false;
            } */
        }

        
            if (clearPlayerCarRotation)
            {

                zRotation = Mathf.Lerp(zRotation, 0f, Time.deltaTime * moveSpeed * 2f);

                

            if (zRotation == 0f)
            {
                clearPlayerCarRotation = false;
            }
        }

        this.transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        this.transform.rotation = Quaternion.Euler(0f, 0f, zRotation);


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ObstraclCar")
        {
            Destroy(collision.gameObject);
            GameManager.instante.gameStates = GameManager.GameStates.playerDied;
            this.gameObject.SetActive(false);
            road.speed = 0f;
            uIManager.SaveGameData();
            uIManager.ActivateRestartUI();
            uIManager.CarCrashSound();
           
        }

        if(collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            uIManager.IncreaseCoins();
        }
    }
}
