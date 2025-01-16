// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarageControll : MonoBehaviour
{
    //public GameObject[] Cars;
    public Color[] Colors;
    public GameObject[] Hats;

    private GameObject PlayersChild;
    private GameObject Wheels;
    private GameObject playerRotateF;
    private GameObject garageCar1;
    private GameObject garageCar2;
    private GameObject garageCar3;
    private GameObject garageCar4;

    private GameObject p_Car1;
    private GameObject p_Car2;
    private GameObject p_Car3;
    private GameObject p_Car4;

    public GameObject[] G_carColors;

    public GameObject garageCar1_Color1;
    public GameObject garageCar2_Color1;
    public GameObject garageCar3_Color1;
    public GameObject garageCar4_Color1;

    private GameObject Player;
    private GameObject Level1;
    public MeshRenderer playerRenderer;
    private CarController carController;
    private PlayerColor playerColor;
    private CarCollider carCollider;

    public Material defaultCarMat;
    public Material oldCarMat;
    private Material matChanger;

    public MeshFilter playerMF;
    public Mesh defaultMF;
    public Mesh oldMF;

    public GameObject BuyButtons;
    private CarBuySystem carBuySystem;

    public int index = 0;
    public int colorIndex = 0;
    public int a = 0;

    public bool pressedRight, pressedLeft,
                pressedCarB, pressedPaintB,
                pressedHatB;

    public GameObject[] PaintArrow;
    public GameObject[] CarArrow;
    public GameObject[] ColorButtons;

    public MeshRenderer garageCarMeshRenderer;

    public Color colorOfCar1;
    public Color colorOfCar2;
    public Color colorOfCar3;
    public Color colorOfCar4;

    public bool indexBLock = false;

    private bool matSetUp = true;

    private bool carsFinded = false;

    [HideInInspector]
    public bool isThatOldCar = false;

    [HideInInspector]
    public bool isThatCar3 = false;

    [HideInInspector]
    public bool changeCarColor = false;

    [HideInInspector]
    public bool loadData = true;

    void Start()
    {
        Player = GameObject.Find("Player");
        Level1 = GameObject.Find("Level1");
        garageCar1 = GameObject.Find("G_Car1");
        garageCar2 = GameObject.Find("G_Car2");
        garageCar3 = GameObject.Find("G_Car3");
        garageCar4 = GameObject.Find("G_Car4");

        p_Car1 = GameObject.Find("Car");
        p_Car2 = GameObject.Find("Car2");
        p_Car3 = GameObject.Find("Car3");
        p_Car4 = GameObject.Find("Car4");

        p_Car2.SetActive(false);
        p_Car3.SetActive(false);
        p_Car4.SetActive(false);

        carController = Player.GetComponent<CarController>();
        playerColor = Player.GetComponent<PlayerColor>();
        carCollider = Player.GetComponent<CarCollider>();
        //Cars = GameObject.FindGameObjectsWithTag("Car");

        Wheels = GameObject.FindGameObjectWithTag("Wheel");
        PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");

        playerRenderer = PlayersChild.GetComponent<MeshRenderer>();

        playerRotateF = GameObject.Find("playerRotationF");

        carBuySystem = gameObject.GetComponent<CarBuySystem>();

        pressedRight = false;
        pressedLeft = false;
        pressedCarB = true;
        pressedPaintB = false;
        pressedHatB = false;

        garageCar2.SetActive(false);
        garageCar3.SetActive(false);
        garageCar4.SetActive(false);


        colorOfCar1 = new Color(1, 0, 0, 1);
        colorOfCar2 = new Color(0.03137255f, 0.4117647f, 0.1490196f, 1);
        colorOfCar3 = new Color(0.04313726f, 0.3490196f, 0.4745098f, 1);
        colorOfCar4 = new Color(0.51f, 0.51f, 0.51f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (loadData == true)
        {
            carCollider.LoadData();

            if (carCollider.PickedCar == 0)
            {
                /*p_Car1.SetActive(true);
                p_Car2.SetActive(false);
                p_Car3.SetActive(false);
                p_Car4.SetActive(false);*/

                garageCar1.SetActive(true);
                garageCar2.SetActive(false);
                garageCar3.SetActive(false);
                garageCar4.SetActive(false);

                garageCar1_Color1.SetActive(false);
                garageCar2_Color1.SetActive(false);
                garageCar3_Color1.SetActive(false);
                garageCar4_Color1.SetActive(false);

                CarArrow[0].SetActive(true);
                CarArrow[1].SetActive(true);
                CarArrow[2].SetActive(false);
                CarArrow[3].SetActive(false);
                CarArrow[4].SetActive(false);
                CarArrow[5].SetActive(false);
                CarArrow[6].SetActive(false);
                CarArrow[7].SetActive(false);

                ColorButtons[0].SetActive(true);
                ColorButtons[1].SetActive(false);
                ColorButtons[2].SetActive(false);
                ColorButtons[3].SetActive(false);

                PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
                playerRenderer = PlayersChild.GetComponent<MeshRenderer>();
                changeCarColor = false;
                carController.wheelsReady = false;

                //garageCarMeshRenderer = Cars[0].GetComponent<MeshRenderer>();

                carCollider.c_isThatOldCar = false;
                carCollider.c_isThatCar3 = false;
                carCollider.c_isThatCar4 = false;

                carController.changeCarSpeed = true;

                var block = new MaterialPropertyBlock();

                block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndexOfCar1]);
                playerRenderer.SetPropertyBlock(block);
                //garageCarMeshRenderer.SetPropertyBlock(block);

                G_carColors[carCollider.colorIndexOfCar1].SetActive(true);

                colorOfCar1 = Colors[carCollider.colorIndexOfCar1];
                colorOfCar2 = Colors[carCollider.colorIndexOfCar2];
                colorOfCar3 = Colors[carCollider.colorIndexOfCar3];
                colorOfCar4 = Colors[carCollider.colorIndexOfCar4];
                playerColor.playerNormalColor = colorOfCar1;
            }
            else if (carCollider.PickedCar == 1)
            {
                carBuySystem.CarButton2();

                if (carCollider.c2_unlocked)
                {
                    p_Car1.SetActive(false);
                    p_Car2.SetActive(true);
                    p_Car3.SetActive(false);
                    p_Car4.SetActive(false);
                }

                garageCar1.SetActive(false);
                garageCar2.SetActive(true);
                garageCar3.SetActive(false);
                garageCar4.SetActive(false);

                garageCar1_Color1.SetActive(false);
                garageCar2_Color1.SetActive(false);
                garageCar3_Color1.SetActive(false);
                garageCar4_Color1.SetActive(false);

                CarArrow[0].SetActive(false);
                CarArrow[1].SetActive(false);
                CarArrow[2].SetActive(true);
                CarArrow[3].SetActive(true);
                CarArrow[4].SetActive(false);
                CarArrow[5].SetActive(false);
                CarArrow[6].SetActive(false);
                CarArrow[7].SetActive(false);

                ColorButtons[0].SetActive(false);
                ColorButtons[1].SetActive(true);
                ColorButtons[2].SetActive(false);
                ColorButtons[3].SetActive(false);

                PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
                playerRenderer = PlayersChild.GetComponent<MeshRenderer>();
                changeCarColor = false;
                carController.wheelsReady = false;

                //garageCarMeshRenderer = Cars[1].GetComponent<MeshRenderer>();

                colorOfCar1 = Colors[carCollider.colorIndexOfCar1];
                colorOfCar2 = Colors[carCollider.colorIndexOfCar2];
                colorOfCar3 = Colors[carCollider.colorIndexOfCar3];
                colorOfCar4 = Colors[carCollider.colorIndexOfCar4];

                playerColor.playerNormalColor = colorOfCar1;

                carCollider.c_isThatOldCar = false;
                carCollider.c_isThatCar3 = false;
                carCollider.c_isThatCar4 = false;

                carController.changeCarSpeed = true;

                if (carCollider.c2_unlocked == true)
                {
                    carCollider.c_isThatOldCar = true;
                    carCollider.c_isThatCar3 = false;
                    carCollider.c_isThatCar4 = false;

                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndexOfCar2]);
                    playerRenderer.SetPropertyBlock(block);
                    //garageCarMeshRenderer.SetPropertyBlock(block);

                    //G_carColors[carCollider.colorIndexOfCar2].SetActive(true);

                    playerColor.playerNormalColor = colorOfCar2;
                }

                G_carColors[carCollider.colorIndexOfCar2].SetActive(true);

                /*colorOfCar1 = Colors[carCollider.colorIndexOfCar1];
                colorOfCar2 = Colors[carCollider.colorIndexOfCar2];
                colorOfCar3 = Colors[carCollider.colorIndexOfCar3];
                colorOfCar4 = Colors[carCollider.colorIndexOfCar4];
                playerColor.playerNormalColor = colorOfCar2;*/
            }
            else if (carCollider.PickedCar == 2)
            {
                carBuySystem.CarButton3();

                if (carCollider.c3_unlocked)
                {
                    p_Car1.SetActive(false);
                    p_Car2.SetActive(false);
                    p_Car3.SetActive(true);
                    p_Car4.SetActive(false);
                }


                garageCar1.SetActive(false);
                garageCar2.SetActive(false);
                garageCar3.SetActive(true);
                garageCar4.SetActive(false);

                garageCar1_Color1.SetActive(false);
                garageCar2_Color1.SetActive(false);
                garageCar3_Color1.SetActive(false);
                garageCar4_Color1.SetActive(false);

                CarArrow[0].SetActive(false);
                CarArrow[1].SetActive(false);
                CarArrow[2].SetActive(false);
                CarArrow[3].SetActive(false);
                CarArrow[4].SetActive(true);
                CarArrow[5].SetActive(true);
                CarArrow[6].SetActive(false);
                CarArrow[7].SetActive(false);

                ColorButtons[0].SetActive(false);
                ColorButtons[1].SetActive(false);
                ColorButtons[2].SetActive(true);
                ColorButtons[3].SetActive(false);

                PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
                playerRenderer = PlayersChild.GetComponent<MeshRenderer>();
                changeCarColor = false;
                carController.wheelsReady = false;

                //garageCarMeshRenderer = Cars[2].GetComponent<MeshRenderer>();

                colorOfCar1 = Colors[carCollider.colorIndexOfCar1];
                colorOfCar2 = Colors[carCollider.colorIndexOfCar2];
                colorOfCar3 = Colors[carCollider.colorIndexOfCar3];
                colorOfCar4 = Colors[carCollider.colorIndexOfCar4];

                playerColor.playerNormalColor = colorOfCar1;

                carCollider.c_isThatOldCar = false;
                carCollider.c_isThatCar3 = false;
                carCollider.c_isThatCar4 = false;

                carController.changeCarSpeed = true;

                if (carCollider.c3_unlocked == true)
                {
                    carCollider.c_isThatOldCar = false;
                    carCollider.c_isThatCar3 = true;
                    carCollider.c_isThatCar4 = false;

                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndexOfCar3]);
                    playerRenderer.SetPropertyBlock(block);
                    //garageCarMeshRenderer.SetPropertyBlock(block);

                    //G_carColors[carCollider.colorIndexOfCar3].SetActive(true);

                    playerColor.playerNormalColor = colorOfCar3;
                }

                G_carColors[carCollider.colorIndexOfCar3].SetActive(true);

                /*colorOfCar1 = Colors[carCollider.colorIndexOfCar1];
                colorOfCar2 = Colors[carCollider.colorIndexOfCar2];
                colorOfCar3 = Colors[carCollider.colorIndexOfCar3];
                colorOfCar4 = Colors[carCollider.colorIndexOfCar4];
                playerColor.playerNormalColor = colorOfCar3;*/
            }
            else if (carCollider.PickedCar == 3)
            {
                carBuySystem.CarButton4();

                if (carCollider.c4_unlocked)
                {
                    p_Car1.SetActive(false);
                    p_Car2.SetActive(false);
                    p_Car3.SetActive(false);
                    p_Car4.SetActive(true);
                }


                garageCar1.SetActive(false);
                garageCar2.SetActive(false);
                garageCar3.SetActive(false);
                garageCar4.SetActive(true);

                garageCar1_Color1.SetActive(false);
                garageCar2_Color1.SetActive(false);
                garageCar3_Color1.SetActive(false);
                garageCar4_Color1.SetActive(false);

                CarArrow[0].SetActive(false);
                CarArrow[1].SetActive(false);
                CarArrow[2].SetActive(false);
                CarArrow[3].SetActive(false);
                CarArrow[4].SetActive(false);
                CarArrow[5].SetActive(false);
                CarArrow[6].SetActive(true);
                CarArrow[7].SetActive(true);

                ColorButtons[0].SetActive(false);
                ColorButtons[1].SetActive(false);
                ColorButtons[2].SetActive(false);
                ColorButtons[3].SetActive(true);

                PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
                playerRenderer = PlayersChild.GetComponent<MeshRenderer>();
                changeCarColor = false;
                carController.wheelsReady = false;

                //garageCarMeshRenderer = Cars[2].GetComponent<MeshRenderer>();

                colorOfCar1 = Colors[carCollider.colorIndexOfCar1];
                colorOfCar2 = Colors[carCollider.colorIndexOfCar2];
                colorOfCar3 = Colors[carCollider.colorIndexOfCar3];
                colorOfCar4 = Colors[carCollider.colorIndexOfCar4];

                playerColor.playerNormalColor = colorOfCar1;

                carCollider.c_isThatOldCar = false;
                carCollider.c_isThatCar3 = false;
                carCollider.c_isThatCar4 = false;

                carController.changeCarSpeed = true;

                if (carCollider.c4_unlocked == true)
                {
                    carCollider.c_isThatOldCar = false;
                    carCollider.c_isThatCar3 = false;
                    carCollider.c_isThatCar4 = true;

                    var block = new MaterialPropertyBlock();

                    block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndexOfCar4]);
                    playerRenderer.SetPropertyBlock(block);
                    //garageCarMeshRenderer.SetPropertyBlock(block);


                    //G_carColors[carCollider.colorIndexOfCar4].SetActive(true);

                    playerColor.playerNormalColor = colorOfCar4;
                }

                G_carColors[carCollider.colorIndexOfCar4].SetActive(true);

            }

            carCollider.SaveData();
            carCollider.LoadData();

            loadData = false;
        }


        // Change cars
        if (pressedRight == true && pressedLeft == false && indexBLock == false && pressedCarB == true && pressedPaintB == false && pressedHatB == false)
        {
            if (carCollider.PickedCar >= 0)
            {
                carCollider.PickedCar++;
                //Cars[index].SetActive(true);
                ChangeChoose();
            }

            indexBLock = true;
        }
        if (pressedRight == false && pressedLeft == true && indexBLock == true && pressedCarB == true && pressedPaintB == false && pressedHatB == false)
        {
            if (carCollider.PickedCar >= 1)
            {
                carCollider.PickedCar--;
                //Cars[index].SetActive(true);
                ChangeChoose();
            }

            indexBLock = false;
        }

        // Change colors
        if (pressedRight == true && pressedLeft == false && indexBLock == false && pressedCarB == false && pressedPaintB == true && pressedHatB == false)
        {
            if (colorIndex >= 0 && colorIndex < 11)
            {
                colorIndex++;
                //Cars[index].SetActive(true);

                ChangeChoose();
            }

            indexBLock = true;
        }
        if (pressedRight == false && pressedLeft == true && indexBLock == true && pressedCarB == false && pressedPaintB == true && pressedHatB == false)
        {
            if (colorIndex >= 1)
            {
                colorIndex--;
                //Cars[index].SetActive(true);
                ChangeChoose();
            }

            indexBLock = false;
        }
    }

    private void ChangeChoose()
    {
        if (pressedCarB == true && pressedPaintB == false && pressedHatB == false)
        {
            switch (carCollider.PickedCar)
            {
                case 0: //defaltcar
                    {
                        playerColor.playerNormalColor = colorOfCar1;

                        isThatOldCar = false;
                        isThatCar3 = false;
                        playerColor.changeNcolor = false;
                        changeCarColor = true;

                        carCollider.PickedCar = 0;
                        carCollider.c_isThatOldCar = false;
                        carCollider.c_isThatCar3 = false;
                        carCollider.c_isThatCar4 = false;

                        carController.changeCarSpeed = true;

                        carCollider.SaveData();
                        carCollider.LoadData();

                        PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
                        playerRenderer = PlayersChild.GetComponent<MeshRenderer>();

                        loadData = true;

                        changeCarColor = false;
                        carController.wheelsReady = false;
                    }
                    break;
                case 1: //car2
                    {
                        carCollider.PickedCar = 1;
                        if (carCollider.c2_unlocked)
                        {
                            //playerColor.playerNormalColor = colorOfCar2;

                            isThatOldCar = true;
                            isThatCar3 = false;
                            playerColor.changeNormalcolor = false;
                            changeCarColor = true;

                            
                            carCollider.c_isThatOldCar = true;
                            carCollider.c_isThatCar3 = false;
                            carCollider.c_isThatCar4 = false;

                            carController.changeCarSpeed = true;

                            carCollider.SaveData();
                            carCollider.LoadData();

                            PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
                            playerRenderer = PlayersChild.GetComponent<MeshRenderer>();

                            changeCarColor = false;
                            carController.wheelsReady = false;
                        }

                        loadData = true;
                    }
                    break;
                case 2: //car3
                    {
                        carCollider.PickedCar = 2;
                        if (carCollider.c3_unlocked)
                        {
                            //playerColor.playerNormalColor = colorOfCar3;

                            isThatOldCar = false;
                            isThatCar3 = true;
                            playerColor.changeNormalcolor = false;
                            changeCarColor = true;

                            
                            carCollider.c_isThatOldCar = false;
                            carCollider.c_isThatCar3 = true;
                            carCollider.c_isThatCar4 = false;

                            carController.changeCarSpeed = true;

                            carCollider.SaveData();
                            carCollider.LoadData();


                            PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
                            playerRenderer = PlayersChild.GetComponent<MeshRenderer>();


                            changeCarColor = false;
                            carController.wheelsReady = false;
                        }


                        loadData = true;
                    }
                    break;
                case 3: //car4
                    {
                        carCollider.PickedCar = 3;
                        if (carCollider.c4_unlocked)
                        {
                            //playerColor.playerNormalColor = colorOfCar4;

                            isThatOldCar = false;
                            isThatCar3 = true;
                            playerColor.changeNormalcolor = false;
                            changeCarColor = true;

                            
                            carCollider.c_isThatOldCar = false;
                            carCollider.c_isThatCar3 = false;
                            carCollider.c_isThatCar4 = true;

                            carController.changeCarSpeed = true;

                            carCollider.SaveData();
                            carCollider.LoadData();


                            PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
                            playerRenderer = PlayersChild.GetComponent<MeshRenderer>();


                            changeCarColor = false;
                            carController.wheelsReady = false;
                        }

                        loadData = true;

                    }
                    break;
            }

        }
    }

    public void PressedCarB()
    {
        pressedCarB = true;
        pressedPaintB = false;
        pressedHatB = false;

        PlayersChild = GameObject.FindGameObjectWithTag("EquippedCar");
        playerRenderer = PlayersChild.GetComponent<MeshRenderer>();

        switch (carCollider.PickedCar)
        {
            case 0: //defaltcar
                {

                    CarArrow[0].SetActive(true);
                    CarArrow[1].SetActive(true);

                    CarArrow[2].SetActive(false);
                    CarArrow[3].SetActive(false);
                    CarArrow[4].SetActive(false);
                    CarArrow[5].SetActive(false);
                    CarArrow[6].SetActive(false);
                    CarArrow[7].SetActive(false);
                }
                break;
            case 1: //car2
                {

                    CarArrow[2].SetActive(true);
                    CarArrow[3].SetActive(true);

                    CarArrow[0].SetActive(false);
                    CarArrow[1].SetActive(false);
                    CarArrow[4].SetActive(false);
                    CarArrow[5].SetActive(false);
                    CarArrow[6].SetActive(false);
                    CarArrow[7].SetActive(false);
                }
                break;
            case 2: //car3
                {

                    CarArrow[4].SetActive(true);
                    CarArrow[5].SetActive(true);

                    CarArrow[0].SetActive(false);
                    CarArrow[1].SetActive(false);
                    CarArrow[2].SetActive(false);
                    CarArrow[3].SetActive(false);
                    CarArrow[6].SetActive(false);
                    CarArrow[7].SetActive(false);
                }
                break;
                case 3: //car4
                    {

                        CarArrow[6].SetActive(true);
                        CarArrow[7].SetActive(true);

                        CarArrow[0].SetActive(false);
                        CarArrow[1].SetActive(false);
                        CarArrow[2].SetActive(false);
                        CarArrow[3].SetActive(false);
                        CarArrow[4].SetActive(false);
                        CarArrow[5].SetActive(false);
                    }
                    break;
        }
    }

    public void PressedPaintB()
    {
        pressedPaintB = true;
        pressedCarB = false;
        pressedHatB = false;

        carCollider.LoadData();

        switch (carCollider.PickedCar)
        {
            case 0: //defaltcar
                {
                    if (carCollider.colorIndexOfCar1 == 0)
                    {
                        PaintArrow[0].SetActive(true);
                        PaintArrow[1].SetActive(true);

                        PaintArrow[2].SetActive(false);
                        PaintArrow[3].SetActive(false);
                        PaintArrow[4].SetActive(false);
                        PaintArrow[5].SetActive(false);
                        PaintArrow[6].SetActive(false);
                        PaintArrow[7].SetActive(false);
                    }
                    else if (carCollider.colorIndexOfCar1 == 1)
                    {
                        PaintArrow[2].SetActive(true);
                        PaintArrow[3].SetActive(true);

                        PaintArrow[0].SetActive(false);
                        PaintArrow[1].SetActive(false);
                        PaintArrow[4].SetActive(false);
                        PaintArrow[5].SetActive(false);
                        PaintArrow[6].SetActive(false);
                        PaintArrow[7].SetActive(false);
                    }
                    else if (carCollider.colorIndexOfCar1 == 2)
                    {
                        PaintArrow[4].SetActive(true);
                        PaintArrow[5].SetActive(true);

                        PaintArrow[0].SetActive(false);
                        PaintArrow[1].SetActive(false);
                        PaintArrow[2].SetActive(false);
                        PaintArrow[3].SetActive(false);
                        PaintArrow[6].SetActive(false);
                        PaintArrow[7].SetActive(false);
                    }
                    else if (carCollider.colorIndexOfCar1 == 3)
                    {
                        PaintArrow[6].SetActive(true);
                        PaintArrow[7].SetActive(true);

                        PaintArrow[0].SetActive(false);
                        PaintArrow[1].SetActive(false);
                        PaintArrow[2].SetActive(false);
                        PaintArrow[3].SetActive(false);
                        PaintArrow[4].SetActive(false);
                        PaintArrow[5].SetActive(false);
                    }
                }
                break;
            case 1: //car2
                {
                    if (carCollider.colorIndexOfCar2 == 4)
                    {
                        PaintArrow[8].SetActive(true);
                        PaintArrow[9].SetActive(true);

                        PaintArrow[10].SetActive(false);
                        PaintArrow[11].SetActive(false);
                        PaintArrow[12].SetActive(false);
                        PaintArrow[13].SetActive(false);
                        PaintArrow[14].SetActive(false);
                        PaintArrow[15].SetActive(false);
                    }
                    else if (carCollider.colorIndexOfCar2 == 5)
                    {
                        PaintArrow[10].SetActive(true);
                        PaintArrow[11].SetActive(true);

                        PaintArrow[8].SetActive(false);
                        PaintArrow[9].SetActive(false);
                        PaintArrow[12].SetActive(false);
                        PaintArrow[13].SetActive(false);
                        PaintArrow[14].SetActive(false);
                        PaintArrow[15].SetActive(false);
                    }
                    else if (carCollider.colorIndexOfCar2 == 6)
                    {
                        PaintArrow[12].SetActive(true);
                        PaintArrow[13].SetActive(true);

                        PaintArrow[8].SetActive(false);
                        PaintArrow[9].SetActive(false);
                        PaintArrow[10].SetActive(false);
                        PaintArrow[11].SetActive(false);
                        PaintArrow[14].SetActive(false);
                        PaintArrow[15].SetActive(false);
                    }
                    else if (carCollider.colorIndexOfCar2 == 7)
                    {
                        PaintArrow[14].SetActive(true);
                        PaintArrow[15].SetActive(true);

                        PaintArrow[8].SetActive(false);
                        PaintArrow[9].SetActive(false);
                        PaintArrow[10].SetActive(false);
                        PaintArrow[11].SetActive(false);
                        PaintArrow[12].SetActive(false);
                        PaintArrow[13].SetActive(false);
                    }
                }
                break;
            case 2: //car3
                {
                    if (carCollider.colorIndexOfCar3 == 8)
                    {
                        PaintArrow[16].SetActive(true);
                        PaintArrow[17].SetActive(true);

                        PaintArrow[18].SetActive(false);
                        PaintArrow[19].SetActive(false);
                        PaintArrow[20].SetActive(false);
                        PaintArrow[21].SetActive(false);
                        PaintArrow[22].SetActive(false);
                        PaintArrow[23].SetActive(false);
                    }
                    else if (carCollider.colorIndexOfCar3 == 9)
                    {
                        PaintArrow[18].SetActive(true);
                        PaintArrow[19].SetActive(true);

                        PaintArrow[16].SetActive(false);
                        PaintArrow[17].SetActive(false);
                        PaintArrow[20].SetActive(false);
                        PaintArrow[21].SetActive(false);
                        PaintArrow[22].SetActive(false);
                        PaintArrow[23].SetActive(false);
                    }
                    else if (carCollider.colorIndexOfCar3 == 10)
                    {
                        PaintArrow[20].SetActive(true);
                        PaintArrow[21].SetActive(true);

                        PaintArrow[16].SetActive(false);
                        PaintArrow[17].SetActive(false);
                        PaintArrow[18].SetActive(false);
                        PaintArrow[19].SetActive(false);
                        PaintArrow[22].SetActive(false);
                        PaintArrow[23].SetActive(false);
                    }
                    else if (carCollider.colorIndexOfCar3 == 11)
                    {
                        PaintArrow[22].SetActive(true);
                        PaintArrow[23].SetActive(true);

                        PaintArrow[16].SetActive(false);
                        PaintArrow[17].SetActive(false);
                        PaintArrow[18].SetActive(false);
                        PaintArrow[19].SetActive(false);
                        PaintArrow[20].SetActive(false);
                        PaintArrow[21].SetActive(false);
                    }
                }
                break;
            case 3: //car4
                {
                    if (carCollider.colorIndexOfCar4 == 12)
                    {
                        PaintArrow[24].SetActive(true);
                        PaintArrow[25].SetActive(true);

                        PaintArrow[26].SetActive(false);
                        PaintArrow[27].SetActive(false);
                        PaintArrow[28].SetActive(false);
                        PaintArrow[29].SetActive(false);
                        PaintArrow[30].SetActive(false);
                        PaintArrow[31].SetActive(false);
                    }
                    else if (carCollider.colorIndexOfCar4 == 13)
                    {
                        PaintArrow[26].SetActive(true);
                        PaintArrow[27].SetActive(true);

                        PaintArrow[24].SetActive(false);
                        PaintArrow[25].SetActive(false);
                        PaintArrow[28].SetActive(false);
                        PaintArrow[29].SetActive(false);
                        PaintArrow[30].SetActive(false);
                        PaintArrow[31].SetActive(false);
                    }
                    else if (carCollider.colorIndexOfCar4 == 14)
                    {
                        PaintArrow[28].SetActive(true);
                        PaintArrow[29].SetActive(true);

                        PaintArrow[24].SetActive(false);
                        PaintArrow[25].SetActive(false);
                        PaintArrow[26].SetActive(false);
                        PaintArrow[27].SetActive(false);
                        PaintArrow[30].SetActive(false);
                        PaintArrow[31].SetActive(false);
                    }
                    else if (carCollider.colorIndexOfCar4 == 15)
                    {
                        PaintArrow[30].SetActive(true);
                        PaintArrow[31].SetActive(true);

                        PaintArrow[24].SetActive(false);
                        PaintArrow[25].SetActive(false);
                        PaintArrow[26].SetActive(false);
                        PaintArrow[27].SetActive(false);
                        PaintArrow[28].SetActive(false);
                        PaintArrow[29].SetActive(false);
                    }
                }
                break;
        }
    }

    public void PressedHatB()
    {
        pressedHatB = true;
        pressedCarB = false;
        pressedPaintB = false;
    }

    public void PressedRightACar1()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;
    }

    public void PressedLeftACar2()
    {
        //Cars[index].SetActive(false);
        pressedLeft = true;
        pressedRight = false;
        indexBLock = true;
    }

    public void PressedRightACar2()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;
    }

    public void PressedLeftACar3()
    {
        //Cars[index].SetActive(false);
        pressedLeft = true;
        pressedRight = false;
        indexBLock = true;
    }
    public void PressedRightACar3()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;
    }
    public void PressedLeftACar4()
    {
        //Cars[index].SetActive(false);
        pressedLeft = true;
        pressedRight = false;
        indexBLock = true;
    }

    // ColorArrows
    public void Pressed_R_A_C1_Color1()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 1;
        carCollider.colorIndex = 1;

        //garageCarMeshRenderer = Cars[0].GetComponent<MeshRenderer>();

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);
        //garageCarMeshRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C1_Color1()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 0;
        carCollider.colorIndex = 0;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C1_Color2()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 2;
        carCollider.colorIndex = 2;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C1_Color2()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 0;
        carCollider.colorIndex = 0;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C1_Color3()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 3;
        carCollider.colorIndex = 3;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C1_Color3()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 1;
        carCollider.colorIndex = 1;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C1_Color4()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 4;
        carCollider.colorIndex = 4;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C1_Color4()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 2;
        carCollider.colorIndex = 2;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar1 = colorIndex;

        colorOfCar1 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar1;

        carCollider.SaveData();
        carCollider.LoadData();
    }






    public void Pressed_R_A_C2_Color1()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 5;
        carCollider.colorIndex = 5;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar2 = colorIndex;

        colorOfCar2 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar2;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C2_Color1()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 4;
        carCollider.colorIndex = 4;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar2 = colorIndex;

        colorOfCar2 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar2;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C2_Color2()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 6;
        carCollider.colorIndex = 6;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar2 = colorIndex;

        colorOfCar2 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar2;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C2_Color2()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 4;
        carCollider.colorIndex = 4;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar2 = colorIndex;

        colorOfCar2 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar2;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C2_Color3()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 7;
        carCollider.colorIndex = 7;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar2 = colorIndex;

        colorOfCar2 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar2;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C2_Color3()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 5;
        carCollider.colorIndex = 5;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar2 = colorIndex;

        colorOfCar2 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar2;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C2_Color4()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 6;
        carCollider.colorIndex = 6;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar2 = colorIndex;

        colorOfCar2 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar2;

        carCollider.SaveData();
        carCollider.LoadData();

    }





    public void Pressed_R_A_C3_Color1()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 9;
        carCollider.colorIndex = 9;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C3_Color1()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 8;
        carCollider.colorIndex = 8;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C3_Color2()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 10;
        carCollider.colorIndex = 10;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C3_Color2()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 8;
        carCollider.colorIndex = 8;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C3_Color3()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 11;
        carCollider.colorIndex = 11;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C3_Color3()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 9;
        carCollider.colorIndex = 9;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C3_Color4()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 11;
        carCollider.colorIndex = 11;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C3_Color4()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 10;
        carCollider.colorIndex = 10;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar3 = colorIndex;

        colorOfCar3 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar3;

        carCollider.SaveData();
        carCollider.LoadData();
    }







    public void Pressed_R_A_C4_Color1()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 13;
        carCollider.colorIndex = 13;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar4 = colorIndex;

        colorOfCar4 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar4;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C4_Color1()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 12;
        carCollider.colorIndex = 12;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar4 = colorIndex;

        colorOfCar4 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar4;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C4_Color2()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 14;
        carCollider.colorIndex = 14;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar4 = colorIndex;

        colorOfCar4 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar4;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C4_Color2()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 12;
        carCollider.colorIndex = 12;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar4 = colorIndex;

        colorOfCar4 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar4;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C4_Color3()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 15;
        carCollider.colorIndex = 15;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar4 = colorIndex;

        colorOfCar4 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar4;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C4_Color3()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 13;
        carCollider.colorIndex = 13;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar4 = colorIndex;

        colorOfCar4 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar4;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_R_A_C4_Color4()
    {
        //Cars[index].SetActive(false);
        pressedRight = true;
        pressedLeft = false;
        indexBLock = false;

        colorIndex = 15;
        carCollider.colorIndex = 15;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar4 = colorIndex;

        colorOfCar4 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar4;

        carCollider.SaveData();
        carCollider.LoadData();
    }
    public void Pressed_L_A_C4_Color4()
    {
        //Cars[index].SetActive(false);
        pressedRight = false;
        pressedLeft = true;
        indexBLock = true;

        colorIndex = 14;
        carCollider.colorIndex = 14;

        var block = new MaterialPropertyBlock();

        block.SetColor("Color_845fccdf533d42afac1da2a53c1f0dda", Colors[carCollider.colorIndex]);
        playerRenderer.SetPropertyBlock(block);

        carCollider.colorIndexOfCar4 = colorIndex;

        colorOfCar4 = Colors[colorIndex];
        playerColor.playerNormalColor = colorOfCar4;

        carCollider.SaveData();
        carCollider.LoadData();
    }
}
