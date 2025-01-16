// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockControll : MonoBehaviour
{
    private Este esteS;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        esteS = gameObject.GetComponent<Este>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();

        meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (esteS.activateMesh == true && esteS.disableMesh == false)
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = true;
            //Destroy(gameObject);
        }
        if (esteS.activateMesh == false && esteS.disableMesh == true)
        {
            gameObject.SetActive(false);
            meshRenderer.enabled = false;
            //Destroy(gameObject);
        }

        if (esteS.reActivate == true)
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = false;
            esteS.reActivate = false;
            //Destroy(gameObject);
        }
    }
}
