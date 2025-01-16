using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAccelerating : MonoBehaviour
{
    private BoxCollider collider;

    private GameObject Player;
    private CarController carController;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<BoxCollider>();
        Player = GameObject.Find("Player");
        carController = Player.GetComponent<CarController>();

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            carController.targetSpeed += 0.1f;
            collider.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
