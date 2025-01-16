using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryCan : MonoBehaviour
{
    private MeshRenderer[] meshRenderer;
    private GameObject fColliders;

    private MapControll mapControll;

    private BoxCollider col;

    public bool activeJerryCan = false;
    public bool rebackJerry = false;

    public bool disableJerryCan = false;

    private int i = 0;

    private bool enable_ColMesh = true;

    private float time = 0;
    private float timeDelay = 2f;

    private void Start()
    {
        //meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer = gameObject.GetComponentsInChildren<MeshRenderer>();

        fColliders = GameObject.FindGameObjectWithTag("MapCfront");
        mapControll = fColliders.GetComponent<MapControll>();

        col = this.gameObject.GetComponent<BoxCollider>();

        while (i != meshRenderer.Length)
        {
            meshRenderer[i].enabled = false;

            i++;
        }
        i = 0;
    }


    private void Update()
    {
        if (enable_ColMesh == false)        ///Kun pelaaja on osunut jerryCanin collideriin, tulee 2 sekuntin delay. Minkä jälkeen jerryCanin peliobjektin collider aktivoidaan ja meshrenderer aktivoidaan.
        {
            time = time + 1f * Time.deltaTime;

            if (time >= timeDelay)
            {
                col.enabled = true;
                while (i != meshRenderer.Length)
                {
                    meshRenderer[i].enabled = true;

                    i++;
                }
                i = 0;
                enable_ColMesh = true;
                time = 0;
            }
        }

        if (rebackJerry == true)        ///Aktivoi jerryCanin peliobjectin, mutta epäaktivoi meshrendererin
        {
            gameObject.SetActive(true);

            while (i != meshRenderer.Length)
            {
                meshRenderer[i].enabled = false;

                i++;
            }
            i = 0;
            rebackJerry = false;
        }

        if (activeJerryCan == true && disableJerryCan == false)       ///Aktivoi jerryCanin peliobjectin ja sen meshrendererin
        {
            gameObject.SetActive(true);

            if (enable_ColMesh)
            {
                while (i != meshRenderer.Length)
                {
                    meshRenderer[i].enabled = true;

                    i++;
                }
                i = 0;
            }
        }
        if (activeJerryCan == false && disableJerryCan == true)         ///Epäaktivoi jerryCanin peliobjectin ja sen meshrendererin
        {
            gameObject.SetActive(false);

            while (i != meshRenderer.Length)
            {
                meshRenderer[i].enabled = false;

                i++;
            }
            i = 0;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))      ///Jos jerryCanin collider osuu pelaajan collideriin
        {
            while (i != meshRenderer.Length)
            {
                meshRenderer[i].enabled = false;

                i++;
            }
            i = 0;
            col.enabled = false;
            enable_ColMesh = false;
            this.gameObject.SetActive(false);

        }

        if (collision.gameObject.CompareTag("MapCback"))        ///Jos jerryCanin collider osuu MapControllerin BackCollideriin
        {
            while (i != meshRenderer.Length)
            {
                meshRenderer[i].enabled = false;

                i++;
            }

            gameObject.SetActive(false);

            activeJerryCan = false;
            //isColliderUnActive = true;
        }
        /*if (collision.gameObject.CompareTag("MapCfront"))
        {
            gameObject.SetActive(true);
            meshRenderer.enabled = true;
        }*/
    }
}
