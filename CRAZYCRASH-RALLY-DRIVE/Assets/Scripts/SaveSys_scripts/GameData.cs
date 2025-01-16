// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int money;
    public bool dataFileCreated;
    public int PickedCar;

    public bool c_isThatOldCar;
    public bool c_isThatCar3;
    public bool c_isThatCar4;
    public int colorIndex;
    public int carIndex;

    public int colorIndexOfCar1;
    public int colorIndexOfCar2;
    public int colorIndexOfCar3;
    public int colorIndexOfCar4;

    public bool c2_unlocked;
    public bool c3_unlocked;
    public bool c4_unlocked;

    public int screenRes;
    public bool fullscreen;
    public int quality;
    public bool shadows;


    public GameData(CarCollider carCollider)
    {
        money = carCollider.money;
        PickedCar = carCollider.PickedCar;
        c_isThatOldCar = carCollider.c_isThatOldCar;
        c_isThatCar3 = carCollider.c_isThatCar3;
        c_isThatCar4 = carCollider.c_isThatCar4;
        colorIndex = carCollider.colorIndex;
        colorIndexOfCar1 = carCollider.colorIndexOfCar1;
        colorIndexOfCar2 = carCollider.colorIndexOfCar2;
        colorIndexOfCar3 = carCollider.colorIndexOfCar3;
        colorIndexOfCar4 = carCollider.colorIndexOfCar4;
        carIndex = carCollider.carIndex;

        c2_unlocked = carCollider.c2_unlocked;
        c3_unlocked = carCollider.c3_unlocked;
        c4_unlocked = carCollider.c4_unlocked;

        screenRes = carCollider.screenRes;
        fullscreen = carCollider.fullscreen;
        quality = carCollider.quality;
        shadows = carCollider.shadows;
    }
}