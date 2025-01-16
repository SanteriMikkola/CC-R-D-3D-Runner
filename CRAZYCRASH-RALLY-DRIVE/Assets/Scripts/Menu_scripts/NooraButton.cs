using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.SceneManagement;

public class NooraButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("koodi löytyy");
    }

    public void buttonPress()
    {
        SceneManager.LoadScene("CameplayScene");
    }


    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
