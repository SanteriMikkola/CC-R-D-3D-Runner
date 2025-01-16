// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel_Controll : MonoBehaviour
{
    private GameObject FuelMeterArrow;
    private GameObject Player;
    private GameObject Kamera;
    private PlayerMovement playerMove;
    private CarCollider carCollider;
    private CarController carController;

    private bool deCreased = false;
    private bool inCreased = false;
    public float decreaseValue = 0.32f;
    [HideInInspector]
    public float decreaseFuel = 0.1976f;
    private float increaseValue = 4f;
    private float increaseFuel = 100f;

    [HideInInspector]
    public float rotationZ = -80.5f;

    public Vector3 fuelDecreaseDelay;

    private bool Reseted = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        FuelMeterArrow = GameObject.Find("Arrow");
        //playerMove = Player.GetComponent<PlayerMovement>();
        carCollider = Player.GetComponent<CarCollider>();
        carController = Player.GetComponent<CarController>();
        Kamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //HitValueCheck();

        if (carCollider.isThatLevel2 && Reseted == false)
        {
            fuelDecreaseDelay.z = 0;
            Reseted = true;
        }
        if (!carCollider.isThatLevel2 && Reseted == true)
        {
            fuelDecreaseDelay.z = 0;
            Reseted = false;
        }

        if (carCollider.fuel <= 0 && rotationZ >= 83f)
        {
            carCollider.isPlayerDead = true;
            /*Player.SetActive(false);
            Kamera.SetActive(false);*/
            carCollider.moneyRandomized = false;
            carCollider.playerCollide = false;
        }

        if (carCollider.jerryCanPicked == true || carCollider.isThatMT == true)
        {
            StartCoroutine(JerryCanReverseFullHealth());
        }
        
        if (carCollider.isPlayerDead == true)
        {
            rotationZ = 82f;
            FuelMeterArrow.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
    }

    public IEnumerator DecreaseFuel()
    {
        carCollider.fuel -= decreaseFuel;

        while (!deCreased)
        {
            rotationZ = (rotationZ + decreaseValue);
            //Debug.Log(rotationZ);
            fuelDecreaseDelay.z = Player.transform.position.z + 0.00002f;
            deCreased = true;
        }

        yield return new WaitUntil(() => Player.transform.position.z >= fuelDecreaseDelay.z);
        //Debug.Log("Hep!");
        FuelMeterArrow.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        deCreased = false;
    }

    public IEnumerator JerryCanReverseFullHealth()
    {
        while (rotationZ > -80.5f)
        {


            while (!inCreased)
            {
                rotationZ = (rotationZ - increaseValue);
                //Debug.Log(rotationZ);
                fuelDecreaseDelay.z = Player.transform.position.z + 0.0001f;
                inCreased = true;

            }

            yield return new WaitUntil(() => Player.transform.position.z >= fuelDecreaseDelay.z);
            //Debug.Log("Hep!");
            carCollider.fuel = increaseFuel;
            FuelMeterArrow.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            inCreased = false;
        }
        carCollider.jerryCanPicked = false;
    }
}
