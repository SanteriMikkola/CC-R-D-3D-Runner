// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    private GameObject MapCfrontCollider;
    private MapControll mapControll;
    private GameObject Player;
    private CarCollider carCollider;
    private GameObject Garage;
    private CarBuySystem carBuySystem;
    private GameObject startButtonB;
    private StartButton startButtonS;

    private bool setUp = true;


    public GameObject PauseMenu, GarageMenu, OptionsMenu;
    private GameObject StartMenu, startFbutton;

    public GameObject garageFbutton, pauseFbutton, optionsFbutton, customizeFbutton, infoFbutton, moneyScreenFbutton;
    public GameObject garageCbutton, pauseCbutton, optionsCbutton, infoCbutton, moneyScreenCbutton;


    private bool pauseMenuReady;


    private GameObject[] BuyButtons;
    private Button[] BB_Buttons;

    public GameObject[] CarArrowButtons;
    private Button[] CAB_Buttons;

    public GameObject[] CarColorArrowButtons;
    private Button[] CCAB_Buttons;

    public GameObject CarButton;
    private Button CB_Button;

    public GameObject BackButton;
    private Button BackB_Button;

    void Start()
    {
        StartMenu = GameObject.Find("StartMenu");
        startFbutton = GameObject.Find("StartButton");

        MapCfrontCollider = GameObject.FindGameObjectWithTag("MapCfront");
        mapControll = MapCfrontCollider.GetComponent<MapControll>();
        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();
        Garage = GameObject.Find("Garage");
        carBuySystem = Garage.GetComponent<CarBuySystem>();
        startButtonB = GameObject.Find("StartButton");
        startButtonS = startButtonB.GetComponent<StartButton>();


        BuyButtons = new GameObject[carBuySystem.BuyButtons.Length];
        BB_Buttons = new Button[carBuySystem.BuyButtons.Length];

        CAB_Buttons = new Button[CarArrowButtons.Length];
        CCAB_Buttons = new Button[CarColorArrowButtons.Length];

        CB_Button = CarButton.GetComponent<Button>();
        BackB_Button = BackButton.GetComponent<Button>();
    }

    void Update()
    {
        if (setUp == true)
        {
            for (int i = 0; i < BuyButtons.Length; i++)
            {
                BuyButtons[i] = carBuySystem.BuyButtons[i];
                BB_Buttons[i] = BuyButtons[i].GetComponent<Button>();
            }
            for (int i = 0; i < CAB_Buttons.Length; i++)
            {
                CAB_Buttons[i] = CarArrowButtons[i].GetComponent<Button>();
            }
            for (int i = 0; i < CCAB_Buttons.Length; i++)
            {
                CCAB_Buttons[i] = CarColorArrowButtons[i].GetComponent<Button>();
            }

            setUp = false;
        }

        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7)) && mapControll.isGamePaused == false && mapControll.pauseSetup == false && carCollider.playerCollide == false && pauseMenuReady == false && startButtonS.IsGameStarted == true)
        {
            
            pauseMenuReady = false;
            mapControll.GamePaused();

            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(pauseFbutton);

            pauseMenuReady = true;
            
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7)) && mapControll.isGamePaused == true && mapControll.pauseSetup == false && carCollider.playerCollide == false && pauseMenuReady == true && startButtonS.IsGameStarted == true)
        {
            mapControll.PressedResume();

            pauseMenuReady = false;
        }
    }

    public void PressingGiveUP()
    {
        pauseMenuReady = false;

        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(pauseCbutton);
    }
    public void PressingResumeB()
    {
        pauseMenuReady = false;

        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(pauseCbutton);
    }



    public void OpenGarageMenu()
    {

        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(garageFbutton);
    }
    public void CloseGarageMenu()
    {
        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(garageCbutton);
    }

    public void OpenOptionsMenu()
    {
        pauseMenuReady = false;

        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(optionsFbutton);
    }
    public void CloseOptionsMenu()
    {
        pauseMenuReady = true;

        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(optionsCbutton);
    }

    public void OpenGarageCustom()
    {

        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(customizeFbutton);
    }

    public void OpenInfoScreen()
    {

        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(infoFbutton);
    }
    public void CloseInfoScreen()
    {

        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(infoCbutton);
    }


    public void PlayerDead()
    {

        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(moneyScreenFbutton);
    }
    public void SpeedUPMoneyGive()
    {

        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(moneyScreenCbutton);
    }
    public void CloseMoneyScreen()
    {
        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(startFbutton);
    }





    public void ChangeCar1()
    {
        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(CarButton);
    }
    public void ChangeCar2()
    {
        if (!carCollider.c2_unlocked)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(BuyButtons[0]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = BB_Buttons[0];

            CAB_Buttons[2].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = BB_Buttons[0];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CAB_Buttons[3].navigation = navigation2;
        }
        else
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarButton);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CAB_Buttons[3];
            navigation.selectOnUp = carBuySystem.CB_buttons[1];

            CAB_Buttons[2].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CAB_Buttons[2];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CAB_Buttons[3].navigation = navigation2;
        }
    }
    public void ChangeCar3()
    {
        if (!carCollider.c3_unlocked)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(BuyButtons[1]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = BB_Buttons[1];

            CAB_Buttons[4].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = BB_Buttons[1];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CAB_Buttons[5].navigation = navigation2;
        }
        else
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarButton);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CAB_Buttons[5];
            navigation.selectOnUp = carBuySystem.CB_buttons[2];

            CAB_Buttons[4].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CAB_Buttons[4];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CAB_Buttons[5].navigation = navigation2;
        }
    }
    public void ChangeCar4()
    {
        if (!carCollider.c4_unlocked)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(BuyButtons[2]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = BB_Buttons[2];

            CAB_Buttons[6].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = BB_Buttons[2];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CAB_Buttons[7].navigation = navigation2;
        }
        else
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarButton);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CAB_Buttons[7];
            navigation.selectOnUp = carBuySystem.CB_buttons[3];

            CAB_Buttons[6].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CAB_Buttons[6];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CAB_Buttons[7].navigation = navigation2;
        }
    }




    public void Car2Bought()
    {
        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(CarButton);
    }
    public void Car3Bought()
    {
        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(CarButton);
    }
    public void Car4Bought()
    {
        //tyhjennet��n EventSysteemiin valikoitu objekti
        EventSystem.current.SetSelectedGameObject(null);

        //lis�t��n EventSysteemiin uusi valikoitu objekti
        EventSystem.current.SetSelectedGameObject(CarButton);
    }






    public void ChangeColorCar1()
    {
        carCollider.LoadData();
        if (carCollider.colorIndexOfCar1 == 0)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[0]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[1];
            navigation.selectOnUp = carBuySystem.CB_buttons[0];

            CCAB_Buttons[0].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[0];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[1].navigation = navigation2;
        }
        else if (carCollider.colorIndexOfCar1 == 1)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[2]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[3];
            navigation.selectOnUp = carBuySystem.CB_buttons[0];

            CCAB_Buttons[2].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[2];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[3].navigation = navigation2;
        }
        else if (carCollider.colorIndexOfCar1 == 2)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[4]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[5];
            navigation.selectOnUp = carBuySystem.CB_buttons[0];

            CCAB_Buttons[4].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[4];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[5].navigation = navigation2;
        }
        else if (carCollider.colorIndexOfCar1 == 3)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[7]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[7];
            navigation.selectOnUp = carBuySystem.CB_buttons[0];

            CCAB_Buttons[6].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[6];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[7].navigation = navigation2;
        }

    }

    public void ChangeColorCar2()
    {
        carCollider.LoadData();
        if (carCollider.colorIndexOfCar2 == 4)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[8]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[9];
            navigation.selectOnUp = carBuySystem.CB_buttons[1];

            CCAB_Buttons[8].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[8];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[9].navigation = navigation2;
        }
        else if (carCollider.colorIndexOfCar2 == 5)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[10]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[11];
            navigation.selectOnUp = carBuySystem.CB_buttons[1];

            CCAB_Buttons[10].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[10];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[11].navigation = navigation2;
        }
        else if (carCollider.colorIndexOfCar2 == 6)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[12]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[13];
            navigation.selectOnUp = carBuySystem.CB_buttons[1];

            CCAB_Buttons[12].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[12];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[13].navigation = navigation2;
        }
        else if (carCollider.colorIndexOfCar2 == 7)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[15]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[15];
            navigation.selectOnUp = carBuySystem.CB_buttons[1];

            CCAB_Buttons[14].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[14];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[15].navigation = navigation2;
        }

    }

    public void ChangeColorCar3()
    {
        carCollider.LoadData();
        if (carCollider.colorIndexOfCar3 == 8)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[16]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[17];
            navigation.selectOnUp = carBuySystem.CB_buttons[2];

            CCAB_Buttons[16].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[16];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[17].navigation = navigation2;
        }
        else if (carCollider.colorIndexOfCar3 == 9)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[18]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[19];
            navigation.selectOnUp = carBuySystem.CB_buttons[2];

            CCAB_Buttons[18].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[18];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[19].navigation = navigation2;
        }
        else if (carCollider.colorIndexOfCar3 == 10)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[20]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[21];
            navigation.selectOnUp = carBuySystem.CB_buttons[2];

            CCAB_Buttons[20].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[20];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[21].navigation = navigation2;
        }
        else if (carCollider.colorIndexOfCar3 == 11)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[23]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[23];
            navigation.selectOnUp = carBuySystem.CB_buttons[2];

            CCAB_Buttons[22].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[22];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[23].navigation = navigation2;
        }

    }

    public void ChangeColorCar4()
    {
        carCollider.LoadData();
        if (carCollider.colorIndexOfCar4 == 12)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[24]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[25];
            navigation.selectOnUp = carBuySystem.CB_buttons[3];

            CCAB_Buttons[24].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[24];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[25].navigation = navigation2;
        }
        else if (carCollider.colorIndexOfCar4 == 13)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[26]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[27];
            navigation.selectOnUp = carBuySystem.CB_buttons[3];

            CCAB_Buttons[26].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[26];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[27].navigation = navigation2;
        }
        else if (carCollider.colorIndexOfCar4 == 14)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[28]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[29];
            navigation.selectOnUp = carBuySystem.CB_buttons[3];

            CCAB_Buttons[28].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[28];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[29].navigation = navigation2;
        }
        else if (carCollider.colorIndexOfCar4 == 15)
        {
            //tyhjennet��n EventSysteemiin valikoitu objekti
            EventSystem.current.SetSelectedGameObject(null);

            //lis�t��n EventSysteemiin uusi valikoitu objekti
            EventSystem.current.SetSelectedGameObject(CarColorArrowButtons[31]);

            Navigation navigation = new Navigation();
            navigation.mode = Navigation.Mode.Explicit;
            navigation.selectOnLeft = CCAB_Buttons[31];
            navigation.selectOnUp = carBuySystem.CB_buttons[3];

            CCAB_Buttons[30].navigation = navigation;

            Navigation navigation2 = new Navigation();
            navigation2.mode = Navigation.Mode.Explicit;
            navigation2.selectOnRight = CCAB_Buttons[30];
            navigation2.selectOnUp = CB_Button;
            navigation2.selectOnLeft = BackB_Button;

            CCAB_Buttons[31].navigation = navigation2;
        }

    }
}
