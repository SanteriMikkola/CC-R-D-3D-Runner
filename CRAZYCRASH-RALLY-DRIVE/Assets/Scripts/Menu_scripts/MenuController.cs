// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject StartCamera;
    public GameObject GarageCamera;
    public GameObject MainMenu;
    public GameObject StartMenu;
    public GameObject GarageMenu;
    public GameObject scoreCanvas;

    [HideInInspector]
    public bool isThatGarage = false;

    public void Start()
    {
    }

    public void StartM()
    {
        MainMenu.SetActive(false);
        MainCamera.SetActive(false);
        StartCamera.SetActive(true);
        StartMenu.SetActive(true);
        GarageCamera.SetActive(false);
        GarageMenu.SetActive(false);
        scoreCanvas.SetActive(false);
        isThatGarage = false;
    }
    public void MainM()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        /*MainMenu.SetActive(true);
        MainCamera.SetActive(true);
        StartCamera.SetActive(false);*/
        StartMenu.SetActive(false);
        GarageCamera.SetActive(false);
        GarageMenu.SetActive(false);
        isThatGarage = false;
    }
    public void Garage()
    {
        MainMenu.SetActive(false);
        MainCamera.SetActive(false);
        StartCamera.SetActive(false);
        StartMenu.SetActive(false);
        GarageCamera.SetActive(true);
        GarageMenu.SetActive(true);
        scoreCanvas.SetActive(false);
        isThatGarage = true;
    }
    
    public void ScoreCanvas()
    {
        scoreCanvas.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    } 
}
