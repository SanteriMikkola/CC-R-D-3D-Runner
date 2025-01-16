// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeControll : MonoBehaviour
{
    private Este esteS;
    private TrunkControll trunks;
    private MeshRenderer meshRenderer;

    void Start()
    {
        esteS = gameObject.GetComponentInChildren<Este>();
        //trunks = gameObject.GetComponentInChildren<TrunkControll>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();

        meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (esteS.reActivate == true)
        {
            //Debug.Log("Lol");   
            gameObject.SetActive(true);
            meshRenderer.enabled = true;
            //trunks.SetTrunkActive();
        }

        if (esteS.isColliderUnActive == true && esteS.reActivate == false)
        {
            gameObject.SetActive(false);
            //trunks.SetTrunkInActive();
            //Destroy(gameObject);
        }
        if (esteS.activateMesh == true)
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = true;
            //trunks.SetTrunkActive();
        }
    }


    public void ActiveTrees()
    {
        gameObject.SetActive(true);
        meshRenderer.enabled = false;
        //trunks.TrunkReset();
        esteS.reActivate = false;
    }

    public void DisableTrees()
    {
        gameObject.SetActive(false);
        //meshRenderer.enabled = false;
        //trunks.TrunkReset();
    }

    public void ActiveSTrees()
    {
        gameObject.SetActive(true);
        meshRenderer.enabled = true;
        //trunks.SetTrunkActive();
    }
}
