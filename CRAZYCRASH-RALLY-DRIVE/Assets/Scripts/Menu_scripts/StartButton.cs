// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody playerRB;
    private CarCollider carCollider;
    private PlayerMovement playerMove;
    private GameObject StartMenuKamera;
    private GameObject startCamera;
    private GameObject StartMenu;

    public GameObject MainCamera;
    public GameObject StartCamera;
    public GameObject scoreCanvas;

    //[HideInInspector]
    public bool IsGameStarted = false;
    //[HideInInspector]
    public bool GameStartForMapControll = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        startCamera = GameObject.Find("StartCamera");
        playerRB = Player.GetComponent<Rigidbody>();
        carCollider = Player.GetComponent<CarCollider>();
        StartMenu = GameObject.Find("StartMenu");
        //StartMenuKamera = GameObject.Find("StartMenuCamera");
        playerMove = Player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        /*if (carCollider.isThatLevel2 == true)
        {
            IsGameStarted = true;
            GameStartForMapControll = true;
            playerRB.isKinematic = false;
            gameObject.SetActive(false);
            startCamera.SetActive(false);
            Kamera.SetActive(true);
        }*/
    }

    public void StartGame()
    {
        IsGameStarted = true;
        GameStartForMapControll = true;
        playerRB.isKinematic = false;
        carCollider.deadOrNot = false;
        carCollider.changeItemsPos = true;
        carCollider.changeObsCarsPos = true;
        //Kamera.SetActive(true);
        //StartMenuKamera.SetActive(false);
    }

    public void GiveUp()
    {
        IsGameStarted = false;
        GameStartForMapControll = false;
        playerRB.isKinematic = true;
        StartMenu.SetActive(true);
        MainCamera.SetActive(false);
        StartCamera.SetActive(true);
        scoreCanvas.SetActive(false);
        //Kamera.SetActive(true);
        //StartMenuKamera.SetActive(false);
    }

    public void StartLevel2()
    {
        IsGameStarted = true;
        GameStartForMapControll = true;
        playerRB.isKinematic = false;
        gameObject.SetActive(false);
        startCamera.SetActive(false);
    }
}