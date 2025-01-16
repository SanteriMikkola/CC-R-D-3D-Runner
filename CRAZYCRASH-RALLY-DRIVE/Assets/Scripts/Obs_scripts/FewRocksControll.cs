// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FewRocksControll : MonoBehaviour
{
    private Este esteS;
    private MeshRenderer[] meshRenderer;

    private int i = 0;
    private int ii = 0;
    private int iii = 0;
    // Start is called before the first frame update
    void Start()
    {
        esteS = gameObject.GetComponent<Este>();
        meshRenderer = gameObject.GetComponentsInChildren<MeshRenderer>();

        while (i != meshRenderer.Length)
        {
            meshRenderer[i].enabled = false;

            i++;
        }
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Mesh Renderin pituus: " + meshRenderer.Length);
        if (esteS.activateMesh == true && esteS.disableMesh == false)
        {
            gameObject.SetActive(true);

            while (i != meshRenderer.Length)
            {
                meshRenderer[i].enabled = true;

                i++;
            }

            /*meshRenderer[1].enabled = true;
            meshRenderer[2].enabled = true;
            meshRenderer[3].enabled = true;
            meshRenderer[4].enabled = true;*/
            return;
        }
        if (esteS.activateMesh == false && esteS.disableMesh == true)
        {
            gameObject.SetActive(false);

            while (iii != meshRenderer.Length)
            {
                meshRenderer[iii].enabled = false;

                iii++;
            }

            /*meshRenderer[1].enabled = true;
            meshRenderer[2].enabled = true;
            meshRenderer[3].enabled = true;
            meshRenderer[4].enabled = true;
            return;*/
        }
        if (esteS.reActivate == true)
        {
            gameObject.SetActive(true);

            while (ii != meshRenderer.Length)
            {
                meshRenderer[ii].enabled = false;

                ii++;
            }

            esteS.reActivate = false;
            /*meshRenderer[1].enabled = true;
            meshRenderer[2].enabled = true;
            meshRenderer[3].enabled = true;
            meshRenderer[4].enabled = true;*/
            return;
        }
        return;
    }
}
