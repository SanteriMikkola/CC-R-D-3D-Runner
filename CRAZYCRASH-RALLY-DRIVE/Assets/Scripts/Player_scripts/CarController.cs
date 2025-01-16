// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private GameObject Sphere;
    private Rigidbody rB;

    private GameObject Player;
    private GameObject Kamera;
    private CarCollider carCollider;
    private GameObject startButtonB;
    private StartButton startButtonS;
    public GameObject ScoreNumText;
    private ScoreControll scoreControll;

    private GameObject playerRotateF;
    private GameObject playerRotateF_A;
    private GameObject frontCcollider;
    private MapControll mapControll;

    public GameObject MoneyScreen;
    private MoneyScreen moneyScreenS;

    public GameObject FuelMeter;
    private Fuel_Controll fuelControll;

    private GameObject fuelHelper;

    public GameObject HealthBar;
    private HP_Controll hpControll;

    private GameObject startTreeDestroyer;
    private StartTrees startTreesS;

    private GameObject MenuController;
    private MenuController menuController;
    private MenuNavigation menuNavigation;
    private GameObject Cars;

    public GameObject Garage;
    private GarageControll garageControll;

    private GameObject[] InCreaseSpeed;
    private BoxCollider[] speedInCreaseCol;

    public float forwardSpeed = 2f;   //2f
    public float targetSpeed = 2f;    //2f
    //public float maxSpeed = 50f;
    public float turnStrenght = 90f;
    public float turnInput;

    [HideInInspector]
    public bool changeCarSpeed = false;

    private GameObject leftFrontWheelGameOb, rightFrontWheelGameOb;
    private Transform leftFrontWheel, rightFrontWheel;
    public float wheelTurn = 30f;

    public bool maxTurn = false;
    public bool IsThatFirstStart = true;
    //[HideInInspector]
    public bool IsTutorialEnded = false;
    //[HideInInspector]
    public bool PposChanget = true;
    public bool turnLock = false;
    public bool resetPposChanget = false;


    [HideInInspector]
    public bool wheelsReady = false;

    private float maxinumRotationL;
    private float maxinumRotationR;

    private float moveSpeed;

    private Vector3 aloitusTienLoppu;
    private Vector3 aavikonLoppu;

    public float targetPosz = 0.25f;

    private bool loadData = true;

    // Start is called before the first frame update
    void Start()
    {

        playerRotateF = GameObject.Find("playerRotationF");
        playerRotateF_A = GameObject.Find("playerRotationF_A");
        Kamera = GameObject.Find("Main Camera");
        Player = GameObject.Find("Player");
        Sphere = GameObject.Find("Sphere");
        fuelHelper = GameObject.FindGameObjectWithTag("fuelHelper");
        rB = Sphere.GetComponent<Rigidbody>();
        startButtonB = GameObject.Find("StartButton");
        startButtonS = startButtonB.GetComponent<StartButton>();
        carCollider = Player.GetComponent<CarCollider>();
        scoreControll = ScoreNumText.GetComponent<ScoreControll>();
        fuelControll = FuelMeter.GetComponent<Fuel_Controll>();
        hpControll = HealthBar.GetComponent<HP_Controll>();
        //MoneyScreen = GameObject.Find("MoneyScreen");
        moneyScreenS = MoneyScreen.GetComponent<MoneyScreen>();

        frontCcollider = GameObject.Find("FrontCollider");
        mapControll = frontCcollider.GetComponent<MapControll>();
        startTreeDestroyer = GameObject.Find("StarTreeDestroyer");
        startTreesS = startTreeDestroyer.GetComponent<StartTrees>();
        MenuController = GameObject.Find("MenuController");
        menuController = MenuController.GetComponent<MenuController>();
        menuNavigation = MenuController.GetComponent<MenuNavigation>();
        garageControll = Garage.GetComponent<GarageControll>();

        InCreaseSpeed = GameObject.FindGameObjectsWithTag("InCreaseSpeed");
        speedInCreaseCol = new BoxCollider[InCreaseSpeed.Length];
        for (int i = 0; i < InCreaseSpeed.Length; i++)
        {
            speedInCreaseCol[i] = InCreaseSpeed[i].GetComponent<BoxCollider>();
        }

        rB.transform.parent = null;

        aloitusTienLoppu = new Vector3(0f, 0f, 17.5f);
        aavikonLoppu = new Vector3(0f, 400f, 125.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (loadData == true)
        {
            carCollider.LoadData();
            loadData = false;
        }
        if (garageControll.changeCarColor == false && wheelsReady == false)
        {

            leftFrontWheelGameOb = GameObject.Find("LeftFrontWheel");
            rightFrontWheelGameOb = GameObject.Find("RightFrontWheel");
            leftFrontWheel = leftFrontWheelGameOb.GetComponent<Transform>();
            rightFrontWheel = rightFrontWheelGameOb.GetComponent<Transform>();
            wheelsReady = true;
        }

        forwardSpeed = targetSpeed;
        Kamera.transform.position = new Vector3(rB.position.x, rB.position.y + 5.310003f, rB.position.z - 8.23f);
        //Kamera.transform.Translate(Vector3.forward * Time.deltaTime * 3.6f, Space.World);
        maxinumRotationL = 322f;
        maxinumRotationR = 38f;

        if (carCollider.isPlayerDead)
        {
            carCollider.playersBoxCollider.enabled = false;
            targetSpeed = 2f;
            turnInput = 0f;
            forwardSpeed = 0f;
            IsTutorialEnded = false;
            //moneyScreenS.M_ScreenOpen();

            if (moneyScreenS.CloseScreen == true)
            {
                mapControll.PressedGiveUp();
                //turnInput = 0f;
                carCollider.isEstePosRandomized = false;
                carCollider.reback_Obs = true;
                carCollider.isThatLevel2 = false;
                carCollider.isThatMT = false;
                //Debug.Log("toimiiko?");

                carCollider.start_ObsCarsMove = false;
                //carCollider.activateObs = true;

                PposChanget = false;
                var boxCol = fuelHelper.GetComponent<BoxCollider>();
                boxCol.enabled = true;
                Player.transform.position = new Vector3(0f, 0.6529999f, -1.024994f);
                carCollider.playersBoxCollider.enabled = true;

                /*Vector3 targetPoint = (playerRotateF.transform.position);
                Player.transform.LookAt(targetPoint);*/
                rB.transform.position = new Vector3(0f, 0.6059999f, 0.4799957f);
                Kamera.transform.position = new Vector3(rB.position.x, rB.position.y + 5.310003f, rB.position.z - 8.23f);

                targetPosz = -0.774994f;

                fuelControll.decreaseValue = 0.32f;

                for (int i = 0; i < InCreaseSpeed.Length; i++)
                {
                    InCreaseSpeed[i].SetActive(true);
                }
                for (int i = 0; i < speedInCreaseCol.Length; i++)
                {
                    speedInCreaseCol[i].enabled = true;
                }

                if (transform.localRotation.eulerAngles.y != 0f)
                {

                    Player.transform.Rotate(0, (transform.localRotation.eulerAngles.y * -1), 0f);
                    //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, (transform.localRotation.eulerAngles.y * -1) * Time.deltaTime, 0f));
                }
                Vector3 targetPoint = (playerRotateF.transform.position);
                Player.transform.LookAt(targetPoint);

                carCollider.F_forceL = 800f;
                carCollider.F_forceR = -800f;
                carCollider.F_forceBack = -550f;
                carCollider.A_forceL = 1250f;
                carCollider.A_forceBack = -1000f;

                //startButtonS.GameStartForMapControll = true;
                resetPposChanget = true;
                startTreesS.ActiveS_Rocks();
                startTreesS.ActiveS_Trees();
                scoreControll.numBer = 0;
                StartCoroutine(fuelControll.JerryCanReverseFullHealth());
                hpControll.HealthPointsScrollBar.value = 0f;
                //carCollider.osuma = 0;
                startButtonS.GiveUp();
                mapControll.isGiveUp = false;
                //carCollider.isPlayerDead = false;
                carCollider.AfterPlayerDead();
                moneyScreenS.CloseScreen = false;
            }

        }

        if (mapControll.isGamePaused == true)
        {
            carCollider.playersBoxCollider.enabled = false;
            forwardSpeed = 0f;
            turnInput = 0f;
        }

        if (mapControll.isGiveUp == true)
        {
            turnInput = 0f;
            targetSpeed = 2f;
            carCollider.isEstePosRandomized = false;
            carCollider.reback_Obs = true;
            carCollider.isThatLevel2 = false;
            carCollider.isThatMT = false;
            mapControll.CposChanget = true;
            carCollider.start_ObsCarsMove = false;
            //carCollider.activateObs = true;
            //mapControll.GiveUpMapController();
            //Debug.Log("toimiiko?");
            PposChanget = false;
            var boxCol = fuelHelper.GetComponent<BoxCollider>();
            boxCol.enabled = true;
            Player.transform.position = new Vector3(0f, 0.6529999f, -1.024994f);
            carCollider.playersBoxCollider.enabled = true;
            IsTutorialEnded = false;
            /*Vector3 targetPoint = (playerRotateF.transform.position);
            Player.transform.LookAt(targetPoint);*/
            rB.transform.position = new Vector3(0f, 0.6059999f, 0.4799957f);
            Kamera.transform.position = new Vector3(rB.position.x, rB.position.y + 5.310003f, rB.position.z - 8.23f);

            changeCarSpeed = true;

            targetPosz = -0.774994f;

            fuelControll.decreaseValue = 0.32f;

            for (int i = 0; i < InCreaseSpeed.Length; i++)
            {
                InCreaseSpeed[i].SetActive(true);
            }
            for (int i = 0; i < speedInCreaseCol.Length; i++)
            {
                speedInCreaseCol[i].enabled = true;
            }

            if (transform.localRotation.eulerAngles.y != 0f)
            {
                /*if (convertedTinput == false)
                {
                    turnInput = turnInput * -1f;
                    convertedTinput = true;
                }*/

                Player.transform.Rotate(0, (transform.localRotation.eulerAngles.y * -1), 0f);
                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, (transform.localRotation.eulerAngles.y * -1) * Time.deltaTime, 0f));
            }
            Vector3 targetPoint = (playerRotateF.transform.position);
            Player.transform.LookAt(targetPoint);

            carCollider.F_forceL = 800f;
            carCollider.F_forceR = -800f;
            carCollider.F_forceBack = -550f;
            carCollider.A_forceL = 1250f;
            carCollider.A_forceBack = -1000f;


            //startButtonS.GameStartForMapControll = true;
            resetPposChanget = true;
            startTreesS.ActiveS_Rocks();
            startTreesS.ActiveS_Trees();
            scoreControll.numBer = 0;
            StartCoroutine(fuelControll.JerryCanReverseFullHealth());
            hpControll.HealthPointsScrollBar.value = 0f;
            carCollider.osuma = 0;
            carCollider.safesPicked = 0;
            startButtonS.GiveUp();
            mapControll.isGiveUp = false;
        }

        if (carCollider.isThatMT == true && PposChanget == true && carCollider.isThatLevel2 == false && carCollider.reback_Obs == false)
        {
            Player.transform.position = new Vector3(0f, 800.986f, -264.6f);     //-212.5f -264.6f
            rB.transform.position = new Vector3(0f, 800.948f, -112f);        //-31f -83.1f
            Kamera.transform.position = new Vector3(rB.position.x, rB.position.y + 5.310003f, rB.position.z - 8.23f);

            targetPosz = -112.55f;

            //startButtonS.GameStartForMapControll = true;
            PposChanget = false;
            resetPposChanget = false;
            startTreesS.reseted = false;
        }

        if (carCollider.isThatLevel2 == true && PposChanget == false && carCollider.isThatMT == false && carCollider.reback_Obs == false)
        {
            Player.transform.position = new Vector3(0f, 400.633f, -1.024994f);
            rB.transform.position = new Vector3(0f, 400.595f, 0.4799957f);
            Kamera.transform.position = new Vector3(rB.position.x, rB.position.y + 5.310003f, rB.position.z - 8.23f);

            targetPosz = -0.774994f;

            //startButtonS.GameStartForMapControll = true;
            PposChanget = true;
        }
        if (carCollider.isThatLevel2 == false && PposChanget == true && carCollider.isThatMT == false && carCollider.reback_Obs == true && resetPposChanget == false)
        {
            //Debug.Log("toimiiko?");
            PposChanget = false;
            Player.transform.position = new Vector3(0f, 0.6529999f, -1.024994f);
            IsTutorialEnded = false;
            /*Vector3 targetPoint = (playerRotateF.transform.position);
            Player.transform.LookAt(targetPoint);*/
            rB.transform.position = new Vector3(0f, 0.6059999f, 0.4799957f);
            Kamera.transform.position = new Vector3(rB.position.x, rB.position.y + 5.310003f, rB.position.z - 8.23f);

            targetPosz = -0.774994f;

            if (transform.localRotation.eulerAngles.y != 0f)
            {

                Player.transform.Rotate(0, (transform.localRotation.eulerAngles.y * -1), 0f);
                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, (transform.localRotation.eulerAngles.y * -1) * Time.deltaTime, 0f));
            }

            //startButtonS.GameStartForMapControll = true;
            resetPposChanget = true;
        }
        if (resetPposChanget == true)
        {
            PposChanget = true;
        }

        if (carCollider.playerCollide == true && carCollider.isPlayerDead == false)
        {
            carCollider.isPlayerMoving = false;
            //playerGotL = true;
            forwardSpeed = forwardSpeed / 2f;
            //rb.AddForce(stuckForce, ForceMode.Impulse);
        }

        if (/*turnLock == true &&*/ IsTutorialEnded == false)
        {
            turnInput = 0;
            
        }

        if (IsTutorialEnded == true && turnLock == false && mapControll.isGamePaused == false)
        {
            turnInput = Input.GetAxis("Horizontal");
        }


        if (maxTurn == false)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrenght * Time.deltaTime, 0f));
            if (transform.localRotation.eulerAngles.y > maxinumRotationR && transform.localRotation.eulerAngles.y < maxinumRotationL)
            {
                maxTurn = true;
            }
        }
        if (maxTurn == true)
        {
            if (transform.localRotation.eulerAngles.y < 180f && transform.localRotation.eulerAngles.y > 38f)
            {
                
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, -90f * Time.deltaTime, 0f));
                maxTurn = false;
            }
            if (transform.localRotation.eulerAngles.y > 180f && transform.localRotation.eulerAngles.y < 322f)
            {
                
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 90f * Time.deltaTime, 0f));
                maxTurn = false;
            }
        
        }

        if (carCollider.c_isThatOldCar == false && carCollider.c_isThatCar3 == false && carCollider.c_isThatCar4 == false)      ///Defaultcar valittuna. 
        {
            leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * wheelTurn), leftFrontWheel.localRotation.eulerAngles.z);
            rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, (turnInput * wheelTurn), rightFrontWheel.localRotation.eulerAngles.z);

            var defaultSize = new Vector3(0.821897f, 0.70895f, 2.362946f);
            carCollider.playersBoxCollider.size = new Vector3(defaultSize.x, defaultSize.y, defaultSize.z);

            var defaultCenter = new Vector3(-0.0004236996f, 0.5091288f, 0.3891389f);
            carCollider.playersBoxCollider.center = new Vector3(defaultCenter.x, defaultCenter.y, defaultCenter.z);

                    ///Pelaajan collider mukautetaan defaultauton kokoon.^

            if (changeCarSpeed)     ///Muutetaan pelaajan nopeutta ja maksimi osumam��r�� auton mukaan.
            {
                targetSpeed = 2f;

                fuelControll.decreaseFuel = 0.1976f;

                carCollider.maxOsumat = 4;

                Debug.Log(targetSpeed);

                changeCarSpeed = false;
            }
        }
        if (carCollider.c_isThatOldCar == true && carCollider.c_isThatCar3 == false && carCollider.c_isThatCar4 == false)       ///Car2 valittuna.
        {
            leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * wheelTurn), leftFrontWheel.localRotation.eulerAngles.z);
            rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, (turnInput * wheelTurn), rightFrontWheel.localRotation.eulerAngles.z);

            var car2Size = new Vector3(0.8775805f, 0.6829547f, 2.346515f);
            carCollider.playersBoxCollider.size = new Vector3(car2Size.x, car2Size.y, car2Size.z);

            var car2Center = new Vector3(-0.001453549f, 0.5221265f, 0.2798442f);
            carCollider.playersBoxCollider.center = new Vector3(car2Center.x, car2Center.y, car2Center.z);

            ///Pelaajan collider mukautetaan auto2 kokoon.^

            if (changeCarSpeed)     ///Muutetaan pelaajan nopeutta ja maksimi osumam��r�� auton mukaan.
            {
                targetSpeed = 1.875f;

                fuelControll.decreaseFuel = 0.1976f;

                carCollider.maxOsumat = 5;

                Debug.Log(targetSpeed);

                changeCarSpeed = false;
            }
        }
        if (carCollider.c_isThatOldCar == false && carCollider.c_isThatCar3 == true && carCollider.c_isThatCar4 == false)       ///Car3 valittuna.
        {
            leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * wheelTurn), leftFrontWheel.localRotation.eulerAngles.z);
            rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, (turnInput * wheelTurn), rightFrontWheel.localRotation.eulerAngles.z);

            var car3Size = new Vector3(0.693659f, 0.6496553f, 1.504125f);
            carCollider.playersBoxCollider.size = new Vector3(car3Size.x, car3Size.y, car3Size.z);

            var car3Center = new Vector3(-0.003561765f, 0.4514288f, 0.6327262f);
            carCollider.playersBoxCollider.center = new Vector3(car3Center.x, car3Center.y, car3Center.z);

            ///Pelaajan collider mukautetaan auto3 kokoon.^

            if (changeCarSpeed)     ///Muutetaan pelaajan nopeutta ja maksimi osumam��r�� auton mukaan.
            {
                targetSpeed = 2.4f;

                fuelControll.decreaseFuel = 0.1715f;

                carCollider.maxOsumat = 3;

                Debug.Log(targetSpeed);

                changeCarSpeed = false;
            }
        }
        if (carCollider.c_isThatOldCar == false && carCollider.c_isThatCar3 == false && carCollider.c_isThatCar4 == true)       ///Car4 valittuna.
        {
            leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * wheelTurn), leftFrontWheel.localRotation.eulerAngles.z);
            rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, (turnInput * wheelTurn), rightFrontWheel.localRotation.eulerAngles.z);

            var car4Size = new Vector3(1.047885f, 0.6944381f, 2.745308f);
            carCollider.playersBoxCollider.size = new Vector3(car4Size.x, car4Size.y, car4Size.z);

            var car4Center = new Vector3(-0.002982616f, 0.543448f, 0.2052773f);
            carCollider.playersBoxCollider.center = new Vector3(car4Center.x, car4Center.y, car4Center.z);

            ///Pelaajan collider mukautetaan auto4 kokoon.^

            if (changeCarSpeed)     ///Muutetaan pelaajan nopeutta ja maksimi osumam��r�� auton mukaan.
            {
                targetSpeed = 1.912f;

                fuelControll.decreaseFuel = 0.1976f;

                carCollider.maxOsumat = 10;

                Debug.Log(targetSpeed);

                changeCarSpeed = false;
            }
        }


    }

    private void FixedUpdate()
    {
        if (startButtonS.IsGameStarted == true)
        {
            rB.AddForce(transform.forward * forwardSpeed * 1000f);
            transform.position = rB.transform.position;
            PlayerPosCheck();
            if (Player.transform.position.z >= aloitusTienLoppu.z && Player.transform.position.y < aavikonLoppu.y)
            {
                IsTutorialEnded = true;
                turnLock = false;
            }
            if (Player.transform.position.z >= aavikonLoppu.z && Player.transform.position.y >= aavikonLoppu.y)
            {
                //turnLock = true;
                //Vector3 targetPoint = (playerRotateF_A.transform.position);
                //Player.transform.LookAt(targetPoint);
            }
        }
    }

    private void PlayerPosCheck()
    {
        if (Player.transform.position.z >= targetPosz && mapControll.isGamePaused == false && carCollider.isPlayerDead == false)
        {
            //Debug.Log("");
            scoreControll.IncreaseScore();
            if (IsTutorialEnded == true && carCollider.isPlayerDead == false && carCollider.jerryCanPicked == false && carCollider.isThatMT == false)
            {
                if (fuelControll.rotationZ < 83f)
                {
                    StartCoroutine(fuelControll.DecreaseFuel());
                }
                else
                {
                    carCollider.fuel = 0;
                }
            }
            targetPosz += 0.25f;
        }
    }
}
