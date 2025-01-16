// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Este : MonoBehaviour
{
    /*public void Destroy()
    {
        gameObject.SetActive(false);
    }*/

    private GameObject Player;
    private CarCollider carCollider;

    private BoxCollider boxCollider;
    private SphereCollider sphereCollider;

    public bool isColliderUnActive = false;
    public bool activateMesh = false;
    public bool reActivate = false;

    public bool disableMesh = false;

    private GameObject[] Esteet;


    private void Start()
    {
        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();
    }

    private void Update()
    {
        Esteet = GameObject.FindGameObjectsWithTag("Este");

        if (activateMesh == true && disableMesh == false)
        {
            gameObject.SetActive(true);
            isColliderUnActive = false;
        }

        if (disableMesh == true && activateMesh == false)
        {
            gameObject.SetActive(false);
            isColliderUnActive = true;
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.CompareTag("Player"))
        {

            this.sphereCollider.enabled = false;
            this.boxCollider.enabled = false;
            //gameObject.SetActive(false);
            
        }*/

        if (collision.gameObject.CompareTag("MapCback") && isColliderUnActive == false)
        {
            gameObject.SetActive(false);
            isColliderUnActive = true;
            activateMesh = false;
        }
        /*if (collision.gameObject.CompareTag("MapCfront") && activateMesh == false)
        {
            gameObject.SetActive(true);
            activateMesh = true;
            isColliderUnActive = false;
        }*/
    }

    /*public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            this.sphereCollider.enabled = enabled;
            this.boxCollider.enabled = enabled;
            //gameObject.SetActive(false);

        }

        if (collision.gameObject.CompareTag("MapCfront"))
        {
            gameObject.SetActive(true);
            activateMesh = true;
        }
    }*/
}