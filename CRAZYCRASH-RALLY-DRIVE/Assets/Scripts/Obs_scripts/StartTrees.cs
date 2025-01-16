// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrees : MonoBehaviour
{
    private GameObject[] startTrees;
    private GameObject[] startRock;

    private BoxCollider boxCollider;

    private GameObject Player;
    private CarCollider carCollider;
    private CarController carController;

    //private StartRocks startRocksS;

    public bool reseted = false;
    public bool ReSet = true;


    int i = 0;
    int ii = 0;

    // Start is called before the first frame update
    void Start()
    {
        startTrees = GameObject.FindGameObjectsWithTag("StartTrees");
        startRock = GameObject.FindGameObjectsWithTag("StartRocks");

        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();
        carController = Player.GetComponent<CarController>();

        //startRocksS = gameObject.GetComponent<StartRocks>();

        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (carCollider.reback_Obs == true && carCollider.isThatLevel2 == false && reseted == false && ReSet == true)
        {
            ActiveS_Rocks();
        }

        if (carCollider.reback_Obs == true && carCollider.isThatLevel2 == false && reseted == false && ReSet == false && carController.resetPposChanget == true)
        {
            ActiveS_Trees();
        }
    }

    public void ActiveS_Rocks()
    {
        while (ii != startRock.Length)
        {
            startRock[ii].SetActive(true);

            /*var trunk = startTrees[ii].gameObject.transform.GetChild(0);

            trunk.gameObject.SetActive(true);*/

            ii++;
        }
        ii = 0;
        //gameObject.SetActive(false);
        //sphereCollider.enabled = true;
        ReSet = false;
    }

    public void ActiveS_Trees()
    {
        while (ii != startTrees.Length)
        {
            startTrees[ii].SetActive(true);

            /*var trunk = startTrees[ii].gameObject.transform.GetChild(0);

            trunk.gameObject.SetActive(true);*/

            ii++;
        }
        ii = 0;
        //gameObject.SetActive(false);
        reseted = true;
        boxCollider.enabled = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boxCollider.enabled = false;
            while (i != startTrees.Length)
            {
                startTrees[i].SetActive(false);

                /*var trunk = startTrees[i].gameObject.transform.GetChild(0);

                trunk.gameObject.SetActive(false);*/

                i++;
            }
            i = 0;
            while (i != startRock.Length)
            {
                startRock[i].SetActive(false);

                /*var trunk = startTrees[i].gameObject.transform.GetChild(0);

                trunk.gameObject.SetActive(false);*/

                i++;
            }
            i = 0;
            //gameObject.SetActive(false);
            ReSet = true;
        }
    }
}
