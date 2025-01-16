// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomizePosOffset : MonoBehaviour
{
    private GameObject Player;
    private CarCollider carCollider;

    public float offsetRange;

    private bool isPosRandomized = false;

    void Start()
    {
        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();

        RandomizePos();
    }

    private void Update()
    {
        if (carCollider.reback_Obs == true && carCollider.isThatLevel2 == false && carCollider.isEstePosRandomized == false)
        {
            RandomizePos();
            carCollider.isEstePosRandomized = true;
        }
    }


    public void RandomizePos()
    {
        if (transform.parent != null)
        {
            transform.position = new Vector3(transform.parent.position.x + Random.Range(-offsetRange, offsetRange), transform.position.y, transform.parent.position.z + Random.Range(-offsetRange, offsetRange));
        }
    }
}
