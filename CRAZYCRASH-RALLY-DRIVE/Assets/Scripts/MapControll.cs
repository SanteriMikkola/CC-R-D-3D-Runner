// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapControll : MonoBehaviour
{
    private GameObject Player;

    public GameObject[] Esteet;
    public GameObject[] AavikonEsteet;
    public GameObject[] HighwayEsteet;

    public GameObject[] ObsCar_L;
    public GameObject[] ObsCar_R;

    public GameObject[] Reback_Obs;
    public GameObject[] Reback_A_Obs;
    public GameObject[] Reback_H_Obs;

    public GameObject[] Reback_ObsCar_L;
    public GameObject[] Reback_ObsCar_R;

    private GameObject[] ToolBoxes;
    private GameObject[] A_ToolBoxes;
    private GameObject[] H_ToolBoxes;

    public GameObject[] Reback_ToolBoxes;
    public GameObject[] Reback_A_ToolBoxes;
    public GameObject[] Reback_H_ToolBoxes;

    private GameObject[] JerryCans;
    private GameObject[] A_JerryCans;

    public GameObject[] Reback_JerryCans;
    public GameObject[] Reback_A_JerryCans;

    private GameObject[] Grass;
    private GameObject[] A_Grass;

    private GameObject[] Reback_Grass;
    private GameObject[] Reback_A_Grass;

    private GameObject[] Safe;
    private GameObject[] A_Safe;
    private GameObject[] H_Safe;

    private GameObject[] Reback_Safe;
    private GameObject[] Reback_A_Safe;
    private GameObject[] Reback_H_Safe;


    public GameObject[] Trees;
    private GameObject[] startTrees;
    //public Este[] estes;

    //public GameObject[] frontColliders;
    private GameObject fCollider;
    private GameObject bCollider;

    private BoxCollider fBoxCollider;
    //private BoxCollider bBoxCollider;
    private GameObject PauseMenu;
    private GameObject PM_bg;
    private Image PM_bg_image;
    private GameObject PM_fg;
    private Image PM_fg_image;
    private GameObject PM_pauseT;
    private Image PM_pauseT_image;
    private GameObject PM_resumeT;
    private Image PM_resumeT_image;
    private Button PM_resumeT_Button;
    private GameObject PM_optionsT;
    private Image PM_optionsT_image;
    private Button PM_optionsT_Button;
    private GameObject PM_giveupT;
    private Image PM_giveupT_image;
    private Button PM_giveupT_Button;
    private GameObject PAUSE;
    private Image[] PAUSE_images;
    private GameObject Resume;
    private Image[] Resume_images;
    private GameObject Options;
    private Image[] Options_images;
    private GameObject GiveUp;
    private Image[] GiveUp_images;
    private GameObject CountDown;
    private Text CountDownText;

    public bool pauseSetup = true;
    public bool isGamePaused = false;
    public bool isGiveUp = false;

    private GameObject MenuControll;
    private MenuNavigation menuNavigation;


    private int i = 0, ii = 0, iii = 0;

    private GameObject startButtonB;
    private StartButton startButtonS;

    private CarCollider carCollider;

    //public float[] vectorsF; 

    //public Vector3[] vector3s;

    public bool pressedR = false;
    public float time = 0f;
    private float timeDelay = 3f;
    private float countfloat = 4f;

    private Vector3[] Obs_vectors;
    private Vector3[] TB_vectors;
    private Vector3[] Jerry_vectors;
    private Vector3[] Grass_vectors;
    private Vector3[] Safe_vectors;

    public Vector3[] A_Obs_vectors;
    public Vector3[] A_TB_vectors;
    public Vector3[] A_Jerry_vectors;
    public Vector3[] A_Grass_vectors;
    public Vector3[] A_Safe_vectors;

    public Vector3[] H_Obs_vectors;
    public Vector3[] H_TB_vectors;
    public Vector3[] H_Safe_vectors;

    public Vector3[] ObsCar_L_vectors;
    public Vector3[] ObsCar_R_vectors;

    //public GameObject[] PickedObjects;

    //public GameObject[] Testi;

    public Vector3 AreaVector1 = new Vector3(0f, 3.18f, 5f);
    public Vector3 AreaVector2 = new Vector3(0f, 3.18f, 63f);

    public Vector3 A_AreaVector1 = new Vector3(0f, 3.18f, 5f);
    public Vector3 A_AreaVector2 = new Vector3(0f, 3.18f, 63f);

    public Vector3 AreaVectorKesk = new Vector3(0f, 3.18f, 31.5f);

    private bool isObjectsPicked = false;

    public bool playerCollidedFcollider = false;
    private bool spawnObs = false;

    //[HideInInspector]
    public bool CposChanget = false;
    //[HideInInspector]
    public bool highwayIdentifier = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        bCollider = GameObject.Find("BackCollider");
        fCollider = GameObject.Find("FrontCollider");
        startButtonB = GameObject.Find("StartButton");
        startButtonS = startButtonB.GetComponent<StartButton>();
        carCollider = Player.GetComponent<CarCollider>();

        MenuControll = GameObject.Find("MenuController");
        menuNavigation = MenuControll.GetComponent<MenuNavigation>();

        fBoxCollider = fCollider.GetComponent<BoxCollider>();
        //bBoxCollider = bCollider.GetComponent<BoxCollider

        Reback_Obs = GameObject.FindGameObjectsWithTag("Este");
        Reback_A_Obs = GameObject.FindGameObjectsWithTag("AavikonEste");
        Reback_H_Obs = GameObject.FindGameObjectsWithTag("HighwayEste");

        Reback_ObsCar_L = GameObject.FindGameObjectsWithTag("ObsCar_L");
        Reback_ObsCar_R = GameObject.FindGameObjectsWithTag("ObsCar_R");

        Reback_ToolBoxes = GameObject.FindGameObjectsWithTag("ToolBox");
        Reback_A_ToolBoxes = GameObject.FindGameObjectsWithTag("A_ToolBox");
        Reback_H_ToolBoxes = GameObject.FindGameObjectsWithTag("H_ToolBox");

        Reback_JerryCans = GameObject.FindGameObjectsWithTag("JerryCan");
        Reback_A_JerryCans = GameObject.FindGameObjectsWithTag("A_JerryCan");

        Reback_Grass = GameObject.FindGameObjectsWithTag("Grass");
        Reback_A_Grass = GameObject.FindGameObjectsWithTag("A_Crass");

        Reback_Safe = GameObject.FindGameObjectsWithTag("Safe");
        Reback_A_Safe = GameObject.FindGameObjectsWithTag("A_Safe");
        Reback_H_Safe = GameObject.FindGameObjectsWithTag("H_Safe");

        Trees = GameObject.FindGameObjectsWithTag("TreeWithMesh");
        startTrees = GameObject.FindGameObjectsWithTag("StartTrees");

        Esteet = GameObject.FindGameObjectsWithTag("Este");
        AavikonEsteet = GameObject.FindGameObjectsWithTag("AavikonEste");
        HighwayEsteet = GameObject.FindGameObjectsWithTag("HighwayEste");
        ObsCar_L = GameObject.FindGameObjectsWithTag("ObsCar_L");
        ObsCar_R = GameObject.FindGameObjectsWithTag("ObsCar_R");
        ToolBoxes = GameObject.FindGameObjectsWithTag("ToolBox");
        A_ToolBoxes = GameObject.FindGameObjectsWithTag("A_ToolBox");
        H_ToolBoxes = GameObject.FindGameObjectsWithTag("H_ToolBox");
        JerryCans = GameObject.FindGameObjectsWithTag("JerryCan");
        A_JerryCans = GameObject.FindGameObjectsWithTag("A_JerryCan");
        Grass = GameObject.FindGameObjectsWithTag("Grass");
        A_Grass = GameObject.FindGameObjectsWithTag("A_Crass");
        Safe = GameObject.FindGameObjectsWithTag("Safe");
        A_Safe = GameObject.FindGameObjectsWithTag("A_Safe");
        H_Safe = GameObject.FindGameObjectsWithTag("H_Safe");
        //PositionCheck();
        for (int i = 0; i < Esteet.Length; i++)
        {
            var esteComponent = Esteet[i].gameObject.GetComponent<Este>();

            esteComponent.activateMesh = false;
            esteComponent.disableMesh = true;
        }
        for (int i = 0; i < ToolBoxes.Length; i++)
        {
            var Component = ToolBoxes[i].gameObject.GetComponent<ToolBox>();

            Component.activeToolBox = false;
            Component.disableToolBox = true;
        }
        for (int i = 0; i < JerryCans.Length; i++)
        {
            var Component = JerryCans[i].gameObject.GetComponent<JerryCan>();

            Component.activeJerryCan = false;
            Component.disableJerryCan = true;
        }
        /*for (int i = 0; i < Trees.Length; i++)
        {
            var Component = Trees[i].gameObject.GetComponent<TreeControll>();

            Component.DisableTrees();
        }*/
        for (int i = 0; i < Grass.Length; i++)
        {
            var Component = Grass[i].gameObject.GetComponent<CrassControll>();

            Component.activeGrass = false;
            Component.disableGrass = true;
        }
        for (int i = 0; i < Safe.Length; i++)
        {
            var Component = Safe[i].gameObject.GetComponent<Safe>();

            Component.activeSafe = false;
            Component.disableSafe = true;
        }

        for (int i = 0; i < AavikonEsteet.Length; i++)
        {
            var esteComponent = AavikonEsteet[i].gameObject.GetComponent<Este>();

            esteComponent.activateMesh = false;
            esteComponent.disableMesh = true;
        }
        for (int i = 0; i < A_ToolBoxes.Length; i++)
        {
            var Component = A_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

            Component.activeToolBox = false;
            Component.disableToolBox = true;
        }
        for (int i = 0; i < A_JerryCans.Length; i++)
        {
            var Component = A_JerryCans[i].gameObject.GetComponent<JerryCan>();

            Component.activeJerryCan = false;
            Component.disableJerryCan = true;
        }
        for (int i = 0; i < A_Grass.Length; i++)
        {
            var Component = A_Grass[i].gameObject.GetComponent<CrassControll>();

            Component.activeGrass = false;
            Component.disableGrass = true;
        }
        for (int i = 0; i < A_Safe.Length; i++)
        {
            var Component = A_Safe[i].gameObject.GetComponent<Safe>();

            Component.activeSafe = false;
            Component.disableSafe = true;
        }

        for (int i = 0; i < HighwayEsteet.Length; i++)
        {
            var esteComponent = HighwayEsteet[i].gameObject.GetComponent<Este>();

            esteComponent.activateMesh = false;
            esteComponent.disableMesh = true;
        }
        for (int i = 0; i < H_ToolBoxes.Length; i++)
        {
            var Component = H_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

            Component.activeToolBox = false;
            Component.disableToolBox = true;
        }
        for (int i = 0; i < H_Safe.Length; i++)
        {
            var Component = H_Safe[i].gameObject.GetComponent<Safe>();

            Component.activeSafe = false;
            Component.disableSafe = true;
        }

        for (int i = 0; i < ObsCar_L.Length; i++)
        {
            var Component = ObsCar_L[i].gameObject.GetComponent<ObsCarMoving>();

            Component.activateMesh = false;
            Component.disableMesh = true;
        }
        for (int i = 0; i < ObsCar_R.Length; i++)
        {
            var Component = ObsCar_R[i].gameObject.GetComponent<ObsCarMoving>();

            Component.activateMesh = false;
            Component.disableMesh = true;
        }

        bCollider.transform.parent = null;
        fCollider.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (startButtonS.IsGameStarted == true && pauseSetup == true)
        {
            SetUpPause();

            pauseSetup = false;
        }

        if (isGamePaused == true && pressedR == true)
        {
            PM_fg_image.enabled = false;
            PM_pauseT_image.enabled = false;
            PM_resumeT_image.enabled = false;
            PM_optionsT_image.enabled = false;
            PM_giveupT_image.enabled = false;
            for (int i = 0; i < PAUSE_images.Length; i++)
            {
                PAUSE_images[i].enabled = false;
            }
            for (int i = 0; i < Resume_images.Length; i++)
            {
                Resume_images[i].enabled = false;
            }
            for (int i = 0; i < Options_images.Length; i++)
            {
                Options_images[i].enabled = false;
            }
            for (int i = 0; i < GiveUp_images.Length; i++)
            {
                GiveUp_images[i].enabled = false;
            }

            CountDownText.enabled = true;

            int countInt;

            countInt = (int)countfloat;

            CountDownText.text = countInt.ToString();

            countfloat = countfloat - 1f * Time.deltaTime;
            time = time + 1f * Time.deltaTime;


            if (time >= timeDelay)
            {
                PM_bg_image.enabled = false;
                CountDownText.enabled = false;

                menuNavigation.PressingResumeB();

                isGamePaused = false;
                carCollider.playersBoxCollider.enabled = true;
                time = 0f;
                countfloat = 4f;
                pressedR = false;
            }
        }

        /*if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7)) && isGamePaused == false && pauseSetup == false && carCollider.playerCollide == false)
        {
            GamePaused();
        }*/

        if (carCollider.reback_Obs == false && carCollider.isThatLevel2 == false && CposChanget == false && carCollider.isThatMT == true && highwayIdentifier == true)
        {
            //fBoxCollider.enabled = false;
            bCollider.transform.position = new Vector3(0, 802.6f, -121.06f);     //-40.06f -92.16f
            fCollider.transform.position = new Vector3(0, 802.6f, 5f);      //0, 802.6f, 5f
            AreaVector1 = new Vector3(0f, 802.6f, 5f);      //0f, 802.6f, 5f
            AreaVector2 = new Vector3(0f, 802.6f, 63f);     //0f, 802.6f, 63f
            AreaVectorKesk = new Vector3(0f, 802.6f, 31.5f);    //0f, 802.6f, 31.5f    -42.5

            /*var test = new Vector3(0f, 802.6f, 31.5f);
            AreaVectorKesk.Set(test.x, test.y, test.z);*/

            //startButtonS.GameStartForMapControll = true;
            CposChanget = false;
            highwayIdentifier = false;

            for (int i = 0; i < Reback_H_Obs.Length; i++)
            {
                Reback_H_Obs[i].SetActive(true);

                var esteComponent = Reback_H_Obs[i].gameObject.GetComponent<Este>();

                //esteComponent.activateMesh = true;
                esteComponent.isColliderUnActive = false;
                esteComponent.reActivate = true;
            }
            for (int i = 0; i < Trees.Length; i++)
            {
                Trees[i].SetActive(true);

                var treeControlComponent = Trees[i].gameObject.GetComponent<TreeControll>();

                //esteComponent.activateMesh = true;
                treeControlComponent.ActiveTrees();
            }
            for (int i = 0; i < Reback_H_ToolBoxes.Length; i++)
            {
                Reback_H_ToolBoxes[i].SetActive(true);

                var TBComponent = Reback_H_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                //esteComponent.activateMesh = true;
                TBComponent.reBackTB = true;
            }
            for (int i = 0; i < Reback_H_Safe.Length; i++)
            {
                Reback_H_Safe[i].SetActive(true);

                var SafeComponent = Reback_H_Safe[i].gameObject.GetComponent<Safe>();

                //esteComponent.activateMesh = true;
                SafeComponent.reBackSafe = true;
            }

            for (int i = 0; i < Reback_ObsCar_L.Length; i++)
            {
                Reback_ObsCar_L[i].SetActive(true);

                var esteComponent = Reback_ObsCar_L[i].gameObject.GetComponent<ObsCarMoving>();

                //esteComponent.activateMesh = true;
                esteComponent.isColliderUnActive = false;
                esteComponent.reActivate = true;
            }
            for (int i = 0; i < Reback_ObsCar_R.Length; i++)
            {
                Reback_ObsCar_R[i].SetActive(true);

                var esteComponent = Reback_ObsCar_R[i].gameObject.GetComponent<ObsCarMoving>();

                //esteComponent.activateMesh = true;
                esteComponent.isColliderUnActive = false;
                esteComponent.reActivate = true;
            }

            HighwayEsteet = GameObject.FindGameObjectsWithTag("HighwayEste");
            H_ToolBoxes = GameObject.FindGameObjectsWithTag("H_ToolBox");
            H_Safe = GameObject.FindGameObjectsWithTag("H_Safe");

            ObsCar_L = GameObject.FindGameObjectsWithTag("ObsCar_L");
            ObsCar_R = GameObject.FindGameObjectsWithTag("ObsCar_R");

            isObjectsPicked = false;
            Reback_M_Esteet();


            //carCollider.reback_Obs = false;
            //return;
        }


        if (carCollider.reback_Obs == true && carCollider.isThatLevel2 == false && CposChanget == true && carCollider.isThatMT == false)
        {
            fBoxCollider.enabled = true;
            bCollider.transform.position = new Vector3(0, 0, -8.069992f);
            fCollider.transform.position = new Vector3(0, 3.18f, 5f);
            AreaVector1 = new Vector3(0f, 3.18f, 5f);
            AreaVector2 = new Vector3(0f, 3.18f, 63f);
            AreaVectorKesk = new Vector3(0f, 3.18f, 31.5f);
            //startButtonS.GameStartForMapControll = true;
            CposChanget = false;

            for (int i = 0; i < Reback_Obs.Length; i++)
            {
                Reback_Obs[i].SetActive(true);

                var esteComponent = Reback_Obs[i].gameObject.GetComponent<Este>();

                //esteComponent.activateMesh = true;
                esteComponent.isColliderUnActive = false;
                esteComponent.reActivate = true;
            }
            for (int i = 0; i < Reback_ToolBoxes.Length; i++)
            {
                Reback_ToolBoxes[i].SetActive(true);

                var TBComponent = Reback_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                //esteComponent.activateMesh = true;
                TBComponent.reBackTB = true;
            }
            for (int i = 0; i < Reback_JerryCans.Length; i++)
            {
                Reback_JerryCans[i].SetActive(true);

                var JerryComponent = Reback_JerryCans[i].gameObject.GetComponent<JerryCan>();

                //esteComponent.activateMesh = true;
                JerryComponent.rebackJerry = true;
            }
            for (int i = 0; i < Trees.Length; i++)
            {
                Trees[i].SetActive(true);

                var treeControlComponent = Trees[i].gameObject.GetComponent<TreeControll>();

                //esteComponent.activateMesh = true;
                treeControlComponent.ActiveTrees();
            }
            for (int i = 0; i < Reback_Grass.Length; i++)
            {
                Reback_Grass[i].SetActive(true);

                var GrassComponent = Reback_Grass[i].gameObject.GetComponent<CrassControll>();

                //esteComponent.activateMesh = true;
                GrassComponent.rebackGrass = true;
            }
            for (int i = 0; i < Reback_Safe.Length; i++)
            {
                Reback_Safe[i].SetActive(true);

                var SafeComponent = Reback_Safe[i].gameObject.GetComponent<Safe>();

                //esteComponent.activateMesh = true;
                SafeComponent.reBackSafe = true;
            }
            
            Esteet = GameObject.FindGameObjectsWithTag("Este");
            JerryCans = GameObject.FindGameObjectsWithTag("JerryCan");
            ToolBoxes = GameObject.FindGameObjectsWithTag("ToolBox");
            Grass = GameObject.FindGameObjectsWithTag("Grass");
            Safe = GameObject.FindGameObjectsWithTag("Safe");


            isObjectsPicked = false;
            RebackEsteet();

            //carCollider.reback_Obs = false;
            //return;
        }

        if (carCollider.isThatLevel2 == true && carCollider.reback_Obs == false && CposChanget == false && carCollider.isThatMT == false)
        {
            fBoxCollider.enabled = true;
            bCollider.transform.position = new Vector3(0, 402.06f, -8.069992f);
            fCollider.transform.position = new Vector3(0, 402.81f, 5f);
            AreaVector1 = new Vector3(0f, 402.81f, 5f);
            AreaVector2 = new Vector3(0f, 402.81f, 63f);
            AreaVectorKesk = new Vector3(0f, 402.81f, 31.5f);
            A_AreaVector1 = new Vector3(0f, 3.18f, 5f);
            A_AreaVector2 = new Vector3(0f, 3.18f, 63f);
            //startButtonS.GameStartForMapControll = true;
            CposChanget = true;

            for (int i = 0; i < Reback_A_Obs.Length; i++)
            {
                Reback_A_Obs[i].SetActive(true);

                var esteComponent = Reback_A_Obs[i].gameObject.GetComponent<Este>();

                //esteComponent.activateMesh = true;
                esteComponent.isColliderUnActive = false;
                esteComponent.reActivate = true;
            }
            for (int i = 0; i < Reback_A_ToolBoxes.Length; i++)
            {
                Reback_A_ToolBoxes[i].SetActive(true);

                var TBComponent = Reback_A_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                //esteComponent.activateMesh = true;
                TBComponent.reBackTB = true;
            }
            for (int i = 0; i < Reback_A_JerryCans.Length; i++)
            {
                Reback_A_JerryCans[i].SetActive(true);

                var JerryComponent = Reback_A_JerryCans[i].gameObject.GetComponent<JerryCan>();

                //esteComponent.activateMesh = true;
                JerryComponent.rebackJerry = true;
            }
            for (int i = 0; i < Trees.Length; i++)
            {
                Trees[i].SetActive(true);

                var treeControlComponent = Trees[i].gameObject.GetComponent<TreeControll>();

                //esteComponent.activateMesh = true;
                treeControlComponent.ActiveTrees();
            }
            for (int i = 0; i < Reback_A_Grass.Length; i++)
            {
                Reback_A_Grass[i].SetActive(true);

                var GrassComponent = Reback_A_Grass[i].gameObject.GetComponent<CrassControll>();

                //esteComponent.activateMesh = true;
                GrassComponent.rebackGrass = true;
            }
            for (int i = 0; i < Reback_A_Safe.Length; i++)
            {
                Reback_A_Safe[i].SetActive(true);

                var SafeComponent = Reback_A_Safe[i].gameObject.GetComponent<Safe>();

                //esteComponent.activateMesh = true;
                SafeComponent.reBackSafe = true;
            }
            AavikonEsteet = GameObject.FindGameObjectsWithTag("AavikonEste");
            A_JerryCans = GameObject.FindGameObjectsWithTag("A_JerryCan");
            A_ToolBoxes = GameObject.FindGameObjectsWithTag("A_ToolBox");
            A_Grass = GameObject.FindGameObjectsWithTag("A_Crass");
            A_Safe = GameObject.FindGameObjectsWithTag("A_Safe");
            //carCollider.reback_Obs = false;

            isObjectsPicked = false;
            Reback_A_Esteet();


        }

        //StartThings();

        bCollider.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1f, Player.transform.position.z - 8.07f);
        //Debug.Log(frontColliders.Length);
        if (startButtonS.GameStartForMapControll == true && carCollider.isThatLevel2 == false && carCollider.isThatMT == true || playerCollidedFcollider == true && carCollider.isThatLevel2 == false && carCollider.isThatMT == true)
        {
            for (int i = 0; i < Reback_H_Obs.Length; i++)
            {
                Reback_H_Obs[i].SetActive(true);

                var esteComponent = Reback_H_Obs[i].gameObject.GetComponent<Este>();

                esteComponent.disableMesh = false;
                esteComponent.isColliderUnActive = false;
                esteComponent.activateMesh = true;
            }
            for (int i = 0; i < Trees.Length; i++)
            {
                Trees[i].SetActive(true);

                var treeControlComponent = Trees[i].gameObject.GetComponent<TreeControll>();

                //esteComponent.activateMesh = true;
                treeControlComponent.ActiveTrees();
            }
            for (int i = 0; i < Reback_H_ToolBoxes.Length; i++)
            {
                Reback_H_ToolBoxes[i].SetActive(true);

                var TBComponent = Reback_H_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                //esteComponent.activateMesh = true;
                TBComponent.reBackTB = true;
            }
            for (int i = 0; i < Reback_H_Safe.Length; i++)
            {
                Reback_H_Safe[i].SetActive(true);

                var SafeComponent = Reback_H_Safe[i].gameObject.GetComponent<Safe>();

                //esteComponent.activateMesh = true;
                SafeComponent.reBackSafe = true;
            }

            for (int i = 0; i < Reback_ObsCar_L.Length; i++)
            {
                Reback_ObsCar_L[i].SetActive(true);

                var esteComponent = Reback_ObsCar_L[i].gameObject.GetComponent<ObsCarMoving>();

                esteComponent.disableMesh = false;
                esteComponent.isColliderUnActive = false;
                esteComponent.activateMesh = true;
            }
            for (int i = 0; i < Reback_ObsCar_R.Length; i++)
            {
                Reback_ObsCar_R[i].SetActive(true);

                var esteComponent = Reback_ObsCar_R[i].gameObject.GetComponent<ObsCarMoving>();

                esteComponent.disableMesh = false;
                esteComponent.isColliderUnActive = false;
                esteComponent.activateMesh = true;
            }

            Esteet = GameObject.FindGameObjectsWithTag("Este");
            AavikonEsteet = GameObject.FindGameObjectsWithTag("AavikonEste");
            HighwayEsteet = GameObject.FindGameObjectsWithTag("HighwayEste");
            ObsCar_L = GameObject.FindGameObjectsWithTag("ObsCar_L");
            ObsCar_R = GameObject.FindGameObjectsWithTag("ObsCar_R");
            ToolBoxes = GameObject.FindGameObjectsWithTag("ToolBox");
            A_ToolBoxes = GameObject.FindGameObjectsWithTag("A_ToolBox");
            H_ToolBoxes = GameObject.FindGameObjectsWithTag("H_ToolBox");
            JerryCans = GameObject.FindGameObjectsWithTag("JerryCan");
            A_JerryCans = GameObject.FindGameObjectsWithTag("A_JerryCan");
            Grass = GameObject.FindGameObjectsWithTag("Grass");
            A_Grass = GameObject.FindGameObjectsWithTag("A_Crass");
            Safe = GameObject.FindGameObjectsWithTag("Safe");
            A_Safe = GameObject.FindGameObjectsWithTag("A_Safe");
            H_Safe = GameObject.FindGameObjectsWithTag("H_Safe");
            isObjectsPicked = false;
            MoottoriTiePositionCheck();
            startButtonS.GameStartForMapControll = false;
        }

        if (startButtonS.GameStartForMapControll == true && carCollider.isThatLevel2 == false && carCollider.isThatMT == false || playerCollidedFcollider == true && carCollider.isThatLevel2 == false && carCollider.isThatMT == false)
        {
            //Debug.Log("#");
            for (int i = 0; i < Reback_Obs.Length; i++)
            {
                Reback_Obs[i].SetActive(true);

                var esteComponent = Reback_Obs[i].gameObject.GetComponent<Este>();

                esteComponent.disableMesh = false;
                esteComponent.isColliderUnActive = false;
                esteComponent.activateMesh = true;
            }
            for (int i = 0; i < Reback_ToolBoxes.Length; i++)
            {
                Reback_ToolBoxes[i].SetActive(true);

                var TBComponent = Reback_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                //esteComponent.activateMesh = true;
                TBComponent.reBackTB = true;
            }
            for (int i = 0; i < Reback_JerryCans.Length; i++)
            {
                Reback_JerryCans[i].SetActive(true);

                var JerryComponent = Reback_JerryCans[i].gameObject.GetComponent<JerryCan>();

                //esteComponent.activateMesh = true;
                JerryComponent.rebackJerry = true;
            }
            for (int i = 0; i < Trees.Length; i++)
            {
                Trees[i].SetActive(true);

                var treeControlComponent = Trees[i].gameObject.GetComponent<TreeControll>();

                //esteComponent.activateMesh = true;
                treeControlComponent.ActiveTrees();
            }
            for (int i = 0; i < Reback_Grass.Length; i++)
            {
                Reback_Grass[i].SetActive(true);

                var GrassComponent = Reback_Grass[i].gameObject.GetComponent<CrassControll>();

                //esteComponent.activateMesh = true;
                GrassComponent.rebackGrass = true;
            }
            for (int i = 0; i < Reback_Safe.Length; i++)
            {
                Reback_Safe[i].SetActive(true);

                var SafeComponent = Reback_Safe[i].gameObject.GetComponent<Safe>();

                //esteComponent.activateMesh = true;
                SafeComponent.reBackSafe = true;
            }

            Esteet = GameObject.FindGameObjectsWithTag("Este");
            AavikonEsteet = GameObject.FindGameObjectsWithTag("AavikonEste");
            HighwayEsteet = GameObject.FindGameObjectsWithTag("HighwayEste");
            ObsCar_L = GameObject.FindGameObjectsWithTag("ObsCar_L");
            ObsCar_R = GameObject.FindGameObjectsWithTag("ObsCar_R");
            ToolBoxes = GameObject.FindGameObjectsWithTag("ToolBox");
            A_ToolBoxes = GameObject.FindGameObjectsWithTag("A_ToolBox");
            H_ToolBoxes = GameObject.FindGameObjectsWithTag("H_ToolBox");
            JerryCans = GameObject.FindGameObjectsWithTag("JerryCan");
            A_JerryCans = GameObject.FindGameObjectsWithTag("A_JerryCan");
            Grass = GameObject.FindGameObjectsWithTag("Grass");
            A_Grass = GameObject.FindGameObjectsWithTag("A_Crass");
            Safe = GameObject.FindGameObjectsWithTag("Safe");
            A_Safe = GameObject.FindGameObjectsWithTag("A_Safe");
            H_Safe = GameObject.FindGameObjectsWithTag("H_Safe");
            isObjectsPicked = false;
            PositionCheck();
            startButtonS.GameStartForMapControll = false;
        }

        if (startButtonS.GameStartForMapControll == true && carCollider.isThatLevel2 == true && carCollider.isThatMT == false || playerCollidedFcollider == true && carCollider.isThatLevel2 == true && carCollider.isThatMT == false)
        {
            for (int i = 0; i < Reback_A_Obs.Length; i++)
            {
                Reback_A_Obs[i].SetActive(true);

                var esteComponent = Reback_A_Obs[i].gameObject.GetComponent<Este>();

                esteComponent.disableMesh = false;
                esteComponent.isColliderUnActive = false;
                esteComponent.activateMesh = true;
            }
            for (int i = 0; i < Reback_A_ToolBoxes.Length; i++)
            {
                Reback_A_ToolBoxes[i].SetActive(true);

                var TBComponent = Reback_A_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                //esteComponent.activateMesh = true;
                TBComponent.reBackTB = true;
            }
            for (int i = 0; i < Reback_A_JerryCans.Length; i++)
            {
                Reback_A_JerryCans[i].SetActive(true);

                var JerryComponent = Reback_A_JerryCans[i].gameObject.GetComponent<JerryCan>();

                //esteComponent.activateMesh = true;
                JerryComponent.rebackJerry = true;
            }
            for (int i = 0; i < Trees.Length; i++)
            {
                Trees[i].SetActive(true);

                var treeControlComponent = Trees[i].gameObject.GetComponent<TreeControll>();

                //esteComponent.activateMesh = true;
                treeControlComponent.ActiveTrees();
            }
            for (int i = 0; i < Reback_A_Grass.Length; i++)
            {
                Reback_A_Grass[i].SetActive(true);

                var GrassComponent = Reback_A_Grass[i].gameObject.GetComponent<CrassControll>();

                //esteComponent.activateMesh = true;
                GrassComponent.rebackGrass = true;
            }
            for (int i = 0; i < Reback_A_Safe.Length; i++)
            {
                Reback_A_Safe[i].SetActive(true);

                var SafeComponent = Reback_A_Safe[i].gameObject.GetComponent<Safe>();

                //esteComponent.activateMesh = true;
                SafeComponent.reBackSafe = true;
            }

            Esteet = GameObject.FindGameObjectsWithTag("Este");
            AavikonEsteet = GameObject.FindGameObjectsWithTag("AavikonEste");
            HighwayEsteet = GameObject.FindGameObjectsWithTag("HighwayEste");
            ObsCar_L = GameObject.FindGameObjectsWithTag("ObsCar_L");
            ObsCar_R = GameObject.FindGameObjectsWithTag("ObsCar_R");
            ToolBoxes = GameObject.FindGameObjectsWithTag("ToolBox");
            A_ToolBoxes = GameObject.FindGameObjectsWithTag("A_ToolBox");
            H_ToolBoxes = GameObject.FindGameObjectsWithTag("H_ToolBox");
            JerryCans = GameObject.FindGameObjectsWithTag("JerryCan");
            A_JerryCans = GameObject.FindGameObjectsWithTag("A_JerryCan");
            Grass = GameObject.FindGameObjectsWithTag("Grass");
            A_Grass = GameObject.FindGameObjectsWithTag("A_Crass");
            Safe = GameObject.FindGameObjectsWithTag("Safe");
            A_Safe = GameObject.FindGameObjectsWithTag("A_Safe");
            H_Safe = GameObject.FindGameObjectsWithTag("H_Safe");
            isObjectsPicked = false;
            AavikkoPositionCheck();
            startButtonS.GameStartForMapControll = false;
        }
        //ObsActive();
        //fCollider.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1f, Player.transform.position.z + 48.5f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Testi");
            playerCollidedFcollider = true;
            //gameObject.SetActive(false)

            fCollider.transform.position = new Vector3(AreaVectorKesk.x, AreaVectorKesk.y, AreaVectorKesk.z);
        }
    }


    private void PositionCheck()
    {
        Obs_vectors = new Vector3[Esteet.Length];
        TB_vectors = new Vector3[ToolBoxes.Length];
        Jerry_vectors = new Vector3[JerryCans.Length];
        Grass_vectors = new Vector3[Grass.Length];
        Safe_vectors = new Vector3[Safe.Length];

        //Debug.Log("GameStartForMapControll!");

        if (!isObjectsPicked)
        {
            for (int i = 0; i < Esteet.Length; i++)
            {
                Obs_vectors[i].Set(Esteet[i].transform.position.x, Esteet[i].transform.position.y, Esteet[i].transform.position.z);

                if (Obs_vectors[i].z > AreaVector1.z && Obs_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var esteComponent = Esteet[i].gameObject.GetComponent<Este>();

                    esteComponent.activateMesh = true;
                    esteComponent.disableMesh = false;
                }
                else
                {
                    var esteComponent = Esteet[i].gameObject.GetComponent<Este>();

                    esteComponent.activateMesh = false;
                    esteComponent.disableMesh = true;
                }
            }

            for (int i = 0; i < ToolBoxes.Length; i++)
            {
                TB_vectors[i].Set(ToolBoxes[i].transform.position.x, ToolBoxes[i].transform.position.y, ToolBoxes[i].transform.position.z);

                if (TB_vectors[i].z > AreaVector1.z && TB_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                    Component.activeToolBox = true;
                    Component.disableToolBox = false;

                }
                else
                {
                    var Component = ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                    Component.activeToolBox = false;
                    Component.disableToolBox = true;
                }
            }

            for (int i = 0; i < JerryCans.Length; i++)
            {
                Jerry_vectors[i].Set(JerryCans[i].transform.position.x, JerryCans[i].transform.position.y, JerryCans[i].transform.position.z);

                if (Jerry_vectors[i].z > AreaVector1.z && Jerry_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = JerryCans[i].gameObject.GetComponent<JerryCan>();

                    Component.activeJerryCan = true;
                    Component.disableJerryCan = false;

                }
                else
                {
                    var Component = JerryCans[i].gameObject.GetComponent<JerryCan>();

                    Component.activeJerryCan = false;
                    Component.disableJerryCan = true;
                }
            }

            for (int i = 0; i < Grass.Length; i++)
            {
                Grass_vectors[i].Set(Grass[i].transform.position.x, Grass[i].transform.position.y, Grass[i].transform.position.z);

                if (Grass_vectors[i].z > AreaVector1.z && Grass_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = Grass[i].gameObject.GetComponent<CrassControll>();

                    Component.activeGrass = true;
                    Component.disableGrass = false;

                }
                else
                {
                    var Component = Grass[i].gameObject.GetComponent<CrassControll>();

                    Component.activeGrass = false;
                    Component.disableGrass = true;
                }
            }

            for (int i = 0; i < Safe.Length; i++)
            {
                Safe_vectors[i].Set(Safe[i].transform.position.x, Safe[i].transform.position.y, Safe[i].transform.position.z);

                if (Safe_vectors[i].z > AreaVector1.z && Safe_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = Safe[i].gameObject.GetComponent<Safe>();

                    Component.activeSafe = true;
                    Component.disableSafe = false;
                }
                else
                {
                    var Component = Safe[i].gameObject.GetComponent<Safe>();

                    Component.activeSafe = false;
                    Component.disableSafe = true;
                }
            }

            isObjectsPicked = true;
        }
        playerCollidedFcollider = false;
        AreaVector1.z = AreaVector1.z + 13f;
        AreaVector2.z = AreaVector2.z + 13f;
        AreaVectorKesk.z = AreaVectorKesk.z + 13f;
    }

    private void AavikkoPositionCheck()
    {
        A_Obs_vectors = new Vector3[AavikonEsteet.Length];
        A_TB_vectors = new Vector3[A_ToolBoxes.Length];
        A_Jerry_vectors = new Vector3[A_JerryCans.Length];
        A_Grass_vectors = new Vector3[A_Grass.Length];
        A_Safe_vectors = new Vector3[A_Safe.Length];

        //Debug.Log(A_Obs_vectors.Length);

        if (!isObjectsPicked)
        {
            for (int i = 0; i < AavikonEsteet.Length; i++)
            {
                A_Obs_vectors[i].Set(AavikonEsteet[i].transform.position.x, AavikonEsteet[i].transform.position.y, AavikonEsteet[i].transform.position.z);

                if (A_Obs_vectors[i].z > A_AreaVector1.z && A_Obs_vectors[i].z < A_AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var esteComponent = AavikonEsteet[i].gameObject.GetComponent<Este>();

                    esteComponent.activateMesh = true;
                    esteComponent.disableMesh = false;
  
                }
                else
                {
                    var esteComponent = AavikonEsteet[i].gameObject.GetComponent<Este>();

                    esteComponent.activateMesh = false;
                    esteComponent.disableMesh = true;
                }
            }

            for (int i = 0; i < A_ToolBoxes.Length; i++)
            {
                A_TB_vectors[i].Set(A_ToolBoxes[i].transform.position.x, A_ToolBoxes[i].transform.position.y, A_ToolBoxes[i].transform.position.z);

                if (A_TB_vectors[i].z > A_AreaVector1.z && A_TB_vectors[i].z < A_AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = A_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                    Component.activeToolBox = true;
                    Component.disableToolBox = false;
                }
                else
                {
                    var Component = A_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                    Component.activeToolBox = false;
                    Component.disableToolBox = true;
                }
            }

            for (int i = 0; i < A_JerryCans.Length; i++)
            {
                A_Jerry_vectors[i].Set(A_JerryCans[i].transform.position.x, A_JerryCans[i].transform.position.y, A_JerryCans[i].transform.position.z);

                if (A_Jerry_vectors[i].z > A_AreaVector1.z && A_Jerry_vectors[i].z < A_AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = A_JerryCans[i].gameObject.GetComponent<JerryCan>();

                    Component.activeJerryCan = true;
                    Component.disableJerryCan = false;

                }
                else
                {
                    var Component = A_JerryCans[i].gameObject.GetComponent<JerryCan>();

                    Component.activeJerryCan = false;
                    Component.disableJerryCan = true;
                }
            }

            for (int i = 0; i < A_Grass.Length; i++)
            {
                A_Grass_vectors[i].Set(A_Grass[i].transform.position.x, A_Grass[i].transform.position.y, A_Grass[i].transform.position.z);

                if (A_Grass_vectors[i].z > A_AreaVector1.z && A_Grass_vectors[i].z < A_AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = A_Grass[i].gameObject.GetComponent<CrassControll>();

                    Component.activeGrass = true;
                    Component.disableGrass = false;

                }
                else
                {
                    var Component = A_Grass[i].gameObject.GetComponent<CrassControll>();

                    Component.activeGrass = false;
                    Component.disableGrass = true;
                }
            }

            for (int i = 0; i < A_Safe.Length; i++)
            {
                A_Safe_vectors[i].Set(A_Safe[i].transform.position.x, A_Safe[i].transform.position.y, A_Safe[i].transform.position.z);

                if (A_Safe_vectors[i].z > A_AreaVector1.z && A_Safe_vectors[i].z < A_AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = A_Safe[i].gameObject.GetComponent<Safe>();

                    Component.activeSafe = true;
                    Component.disableSafe = false;

                }
                else
                {
                    var Component = A_Safe[i].gameObject.GetComponent<Safe>();

                    Component.activeSafe = false;
                    Component.disableSafe = true;
                }
            }

            isObjectsPicked = true;
        }
        playerCollidedFcollider = false;
        AreaVector1.z = AreaVector1.z + 13f;
        AreaVector2.z = AreaVector2.z + 13f;
        A_AreaVector1.z = A_AreaVector1.z + 13f;
        A_AreaVector2.z = A_AreaVector2.z + 13f;
        AreaVectorKesk.z = AreaVectorKesk.z + 13f;
    }

    private void MoottoriTiePositionCheck()
    {
        H_Obs_vectors = new Vector3[HighwayEsteet.Length];
        H_TB_vectors = new Vector3[H_ToolBoxes.Length];
        H_Safe_vectors = new Vector3[H_Safe.Length];
        ObsCar_L_vectors = new Vector3[ObsCar_L.Length];
        ObsCar_R_vectors = new Vector3[ObsCar_R.Length];

        if (!isObjectsPicked)
        {
            for (int i = 0; i < HighwayEsteet.Length; i++)
            {
                H_Obs_vectors[i].Set(HighwayEsteet[i].transform.position.x, HighwayEsteet[i].transform.position.y, HighwayEsteet[i].transform.position.z);

                if (H_Obs_vectors[i].z > AreaVector1.z && H_Obs_vectors[i].z < AreaVector2.z)
                {

                    var esteComponent = HighwayEsteet[i].gameObject.GetComponent<Este>();

                    esteComponent.activateMesh = true;
                    esteComponent.disableMesh = false;

                }
                else
                {
                    var esteComponent = HighwayEsteet[i].gameObject.GetComponent<Este>();

                    esteComponent.activateMesh = false;
                    esteComponent.disableMesh = true;
                }
            }

            for (int i = 0; i < H_ToolBoxes.Length; i++)
            {
                H_TB_vectors[i].Set(H_ToolBoxes[i].transform.position.x, H_ToolBoxes[i].transform.position.y, H_ToolBoxes[i].transform.position.z);

                if (H_TB_vectors[i].z > AreaVector1.z && H_TB_vectors[i].z < AreaVector2.z)
                {

                    var Component = H_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                    Component.activeToolBox = true;
                    Component.disableToolBox = false;

                }
                else
                {
                    var Component = H_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                    Component.activeToolBox = false;
                    Component.disableToolBox = true;
                }
            }

            for (int i = 0; i < H_Safe.Length; i++)
            {
                H_Safe_vectors[i].Set(H_Safe[i].transform.position.x, H_Safe[i].transform.position.y, H_Safe[i].transform.position.z);

                if (H_Safe_vectors[i].z > AreaVector1.z && H_Safe_vectors[i].z < AreaVector2.z)
                {

                    var Component = H_Safe[i].gameObject.GetComponent<Safe>();

                    Component.activeSafe = true;
                    Component.disableSafe = false;

                }
                else
                {
                    var Component = H_Safe[i].gameObject.GetComponent<Safe>();

                    Component.activeSafe = false;
                    Component.disableSafe = true;
                }
            }



            for (int i = 0; i < ObsCar_L.Length; i++)
            {
                ObsCar_L_vectors[i].Set(ObsCar_L[i].transform.position.x, ObsCar_L[i].transform.position.y, ObsCar_L[i].transform.position.z);

                if (ObsCar_L_vectors[i].z > AreaVector1.z && ObsCar_L_vectors[i].z < AreaVector2.z)
                {

                    var esteComponent = ObsCar_L[i].gameObject.GetComponent<ObsCarMoving>();

                    esteComponent.activateMesh = true;
                    esteComponent.disableMesh = false;

                }
                else
                {
                    var esteComponent = ObsCar_L[i].gameObject.GetComponent<ObsCarMoving>();

                    esteComponent.activateMesh = false;
                    esteComponent.disableMesh = true;
                }
            }
            for (int i = 0; i < ObsCar_R.Length; i++)
            {
                ObsCar_R_vectors[i].Set(ObsCar_R[i].transform.position.x, ObsCar_R[i].transform.position.y, ObsCar_R[i].transform.position.z);

                if (ObsCar_R_vectors[i].z > AreaVector1.z && ObsCar_R_vectors[i].z < AreaVector2.z)
                {

                    var esteComponent = ObsCar_R[i].gameObject.GetComponent<ObsCarMoving>();

                    esteComponent.activateMesh = true;
                    esteComponent.disableMesh = false;

                }
                else
                {
                    var esteComponent = ObsCar_R[i].gameObject.GetComponent<ObsCarMoving>();

                    esteComponent.activateMesh = false;
                    esteComponent.disableMesh = true;
                }
            }

            isObjectsPicked = true;
        }
        playerCollidedFcollider = false;
        AreaVector1.z = AreaVector1.z + 13f;
        AreaVector2.z = AreaVector2.z + 13f;
        AreaVectorKesk.z = AreaVectorKesk.z + 13f;
    }

    public void PressedResume()
    {
        pressedR = true;
    }

    public void PressedGiveUp()
    {
        if (isGamePaused == true)
        {
            PM_bg_image.enabled = false;
            PM_fg_image.enabled = false;
            PM_pauseT_image.enabled = false;
            PM_resumeT_image.enabled = false;
            PM_optionsT_image.enabled = false;
            PM_giveupT_image.enabled = false;
            for (int i = 0; i < PAUSE_images.Length; i++)
            {
                PAUSE_images[i].enabled = false;
            }
            for (int i = 0; i < Resume_images.Length; i++)
            {
                Resume_images[i].enabled = false;
            }
            for (int i = 0; i < Options_images.Length; i++)
            {
                Options_images[i].enabled = false;
            }
            for (int i = 0; i < GiveUp_images.Length; i++)
            {
                GiveUp_images[i].enabled = false;
            }
        }

        menuNavigation.PressingGiveUP();

        CposChanget = true;

        isGamePaused = false;
        isGiveUp = true;
    }

    private void SetUpPause()
    {
        PauseMenu = GameObject.Find("PauseMenu");
        PM_bg = GameObject.Find("PauseBackground");
        PM_fg = GameObject.Find("PauseForeground");
        PM_pauseT = GameObject.Find("pauseText");
        PM_resumeT = GameObject.Find("resumeText");
        PM_optionsT = GameObject.Find("optionsText");
        PM_giveupT = GameObject.Find("giveupText");
        PAUSE = GameObject.Find("PAUSE");
        Resume = GameObject.Find("Resume");
        Options = GameObject.Find("Options");
        GiveUp = GameObject.Find("GiveUp");
        CountDown = GameObject.Find("CountDown");

        PM_bg_image = PM_bg.GetComponent<Image>();
        PM_fg_image = PM_fg.GetComponent<Image>();
        PM_pauseT_image = PM_pauseT.GetComponent<Image>();
        PM_resumeT_image = PM_resumeT.GetComponent<Image>();
        PM_resumeT_Button = PM_resumeT.GetComponent<Button>();
        PM_optionsT_image = PM_optionsT.GetComponent<Image>();
        PM_optionsT_Button = PM_optionsT.GetComponent<Button>();
        PM_giveupT_image = PM_giveupT.GetComponent<Image>();
        PM_giveupT_Button = PM_giveupT.GetComponent<Button>();
        PAUSE_images = PAUSE.GetComponentsInChildren<Image>();
        Resume_images = Resume.GetComponentsInChildren<Image>();
        Options_images = Options.GetComponentsInChildren<Image>();
        GiveUp_images = GiveUp.GetComponentsInChildren<Image>();
        CountDownText = CountDown.GetComponent<Text>();
    }

    public void GamePaused()
    {
        isGamePaused = true;
        PM_bg_image.enabled = true;
        PM_fg_image.enabled = true;
        PM_pauseT_image.enabled = true;
        PM_resumeT_image.enabled = true;
        PM_optionsT_image.enabled = true;
        PM_giveupT_image.enabled = true;
        for (int i = 0; i < PAUSE_images.Length; i++)
        {
            PAUSE_images[i].enabled = true;
        }
        for (int i = 0; i < Resume_images.Length; i++)
        {
            Resume_images[i].enabled = true;
        }
        for (int i = 0; i < Options_images.Length; i++)
        {
            Options_images[i].enabled = true;
        }
        for (int i = 0; i < GiveUp_images.Length; i++)
        {
            GiveUp_images[i].enabled = true;
        }
    }

    public void GiveUpMapController()
    {
        for (int i = 0; i < Esteet.Length; i++)
        {
            var esteComponent = Esteet[i].gameObject.GetComponent<Este>();

            esteComponent.activateMesh = true;
            esteComponent.disableMesh = false;
        }
        for (int i = 0; i < ToolBoxes.Length; i++)
        {
            var Component = ToolBoxes[i].gameObject.GetComponent<ToolBox>();

            Component.activeToolBox = true;
            Component.disableToolBox = false;
        }
        for (int i = 0; i < JerryCans.Length; i++)
        {
            var Component = JerryCans[i].gameObject.GetComponent<JerryCan>();

            Component.activeJerryCan = true;
            Component.disableJerryCan = false;
        }
        /*for (int i = 0; i < Trees.Length; i++)
        {
            var Component = Trees[i].gameObject.GetComponent<TreeControll>();

            Component.DisableTrees();
        }*/
        for (int i = 0; i < Grass.Length; i++)
        {
            var Component = Grass[i].gameObject.GetComponent<CrassControll>();

            Component.activeGrass = true;
            Component.disableGrass = false;
        }
        for (int i = 0; i < Safe.Length; i++)
        {
            var Component = Safe[i].gameObject.GetComponent<Safe>();

            Component.activeSafe = true;
            Component.disableSafe = false;
        }

        for (int i = 0; i < AavikonEsteet.Length; i++)
        {
            var esteComponent = AavikonEsteet[i].gameObject.GetComponent<Este>();

            esteComponent.activateMesh = true;
            esteComponent.disableMesh = false;
        }
        for (int i = 0; i < A_ToolBoxes.Length; i++)
        {
            var Component = A_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

            Component.activeToolBox = true;
            Component.disableToolBox = false;
        }
        for (int i = 0; i < A_JerryCans.Length; i++)
        {
            var Component = A_JerryCans[i].gameObject.GetComponent<JerryCan>();

            Component.activeJerryCan = true;
            Component.disableJerryCan = false;
        }
        for (int i = 0; i < A_Grass.Length; i++)
        {
            var Component = A_Grass[i].gameObject.GetComponent<CrassControll>();

            Component.activeGrass = true;
            Component.disableGrass = false;
        }
        for (int i = 0; i < A_Safe.Length; i++)
        {
            var Component = A_Safe[i].gameObject.GetComponent<Safe>();

            Component.activeSafe = true;
            Component.disableSafe = false;
        }

        for (int i = 0; i < HighwayEsteet.Length; i++)
        {
            var esteComponent = HighwayEsteet[i].gameObject.GetComponent<Este>();

            esteComponent.activateMesh = true;
            esteComponent.disableMesh = false;
        }
        for (int i = 0; i < H_ToolBoxes.Length; i++)
        {
            var Component = H_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

            Component.activeToolBox = true;
            Component.disableToolBox = false;
        }
        for (int i = 0; i < H_Safe.Length; i++)
        {
            var Component = H_Safe[i].gameObject.GetComponent<Safe>();

            Component.activeSafe = true;
            Component.disableSafe = false;
        }


        for (int i = 0; i < ObsCar_L.Length; i++)
        {
            var esteComponent = ObsCar_L[i].gameObject.GetComponent<ObsCarMoving>();

            esteComponent.activateMesh = true;
            esteComponent.disableMesh = false;
        }
        for (int i = 0; i < ObsCar_R.Length; i++)
        {
            var esteComponent = ObsCar_R[i].gameObject.GetComponent<ObsCarMoving>();

            esteComponent.activateMesh = true;
            esteComponent.disableMesh = false;
        }

        fCollider.transform.position = new Vector3(0, 3.18f, 5f);
        AreaVector1 = new Vector3(0f, 3.18f, 5f);
        AreaVector2 = new Vector3(0f, 3.18f, 63f);
        AreaVectorKesk = new Vector3(0f, 3.18f, 31.5f);

        Esteet = GameObject.FindGameObjectsWithTag("Este");
        AavikonEsteet = GameObject.FindGameObjectsWithTag("AavikonEste");
        HighwayEsteet = GameObject.FindGameObjectsWithTag("HighwayEste");
        ObsCar_L = GameObject.FindGameObjectsWithTag("ObsCar_L");
        ObsCar_R = GameObject.FindGameObjectsWithTag("ObsCar_R");
        ToolBoxes = GameObject.FindGameObjectsWithTag("ToolBox");
        A_ToolBoxes = GameObject.FindGameObjectsWithTag("A_ToolBox");
        H_ToolBoxes = GameObject.FindGameObjectsWithTag("H_ToolBox");
        JerryCans = GameObject.FindGameObjectsWithTag("JerryCan");
        A_JerryCans = GameObject.FindGameObjectsWithTag("A_JerryCan");
        Grass = GameObject.FindGameObjectsWithTag("Grass");
        A_Grass = GameObject.FindGameObjectsWithTag("A_Crass");
        Safe = GameObject.FindGameObjectsWithTag("Safe");
        A_Safe = GameObject.FindGameObjectsWithTag("A_Safe");
        H_Safe = GameObject.FindGameObjectsWithTag("H_Safe");


        for (int i = 0; i < Esteet.Length; i++)
        {
            var esteComponent = Esteet[i].gameObject.GetComponent<Este>();

            esteComponent.activateMesh = false;
            esteComponent.disableMesh = true;
        }
        for (int i = 0; i < ToolBoxes.Length; i++)
        {
            var Component = ToolBoxes[i].gameObject.GetComponent<ToolBox>();

            Component.activeToolBox = false;
            Component.disableToolBox = true;
        }
        for (int i = 0; i < JerryCans.Length; i++)
        {
            var Component = JerryCans[i].gameObject.GetComponent<JerryCan>();

            Component.activeJerryCan = false;
            Component.disableJerryCan = true;
        }

        for (int i = 0; i < Grass.Length; i++)
        {
            var Component = Grass[i].gameObject.GetComponent<CrassControll>();

            Component.activeGrass = false;
            Component.disableGrass = true;
        }
        for (int i = 0; i < Safe.Length; i++)
        {
            var Component = Safe[i].gameObject.GetComponent<Safe>();

            Component.activeSafe = false;
            Component.disableSafe = true;
        }

        for (int i = 0; i < AavikonEsteet.Length; i++)
        {
            var esteComponent = AavikonEsteet[i].gameObject.GetComponent<Este>();

            esteComponent.activateMesh = false;
            esteComponent.disableMesh = true;
        }
        for (int i = 0; i < A_ToolBoxes.Length; i++)
        {
            var Component = A_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

            Component.activeToolBox = false;
            Component.disableToolBox = true;
        }
        for (int i = 0; i < A_JerryCans.Length; i++)
        {
            var Component = A_JerryCans[i].gameObject.GetComponent<JerryCan>();

            Component.activeJerryCan = false;
            Component.disableJerryCan = true;
        }
        for (int i = 0; i < A_Grass.Length; i++)
        {
            var Component = A_Grass[i].gameObject.GetComponent<CrassControll>();

            Component.activeGrass = false;
            Component.disableGrass = true;
        }
        for (int i = 0; i < A_Safe.Length; i++)
        {
            var Component = A_Safe[i].gameObject.GetComponent<Safe>();

            Component.activeSafe = false;
            Component.disableSafe = true;
        }

        for (int i = 0; i < HighwayEsteet.Length; i++)
        {
            var esteComponent = HighwayEsteet[i].gameObject.GetComponent<Este>();

            esteComponent.activateMesh = false;
            esteComponent.disableMesh = true;
        }
        for (int i = 0; i < H_ToolBoxes.Length; i++)
        {
            var Component = H_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

            Component.activeToolBox = false;
            Component.disableToolBox = true;
        }
        for (int i = 0; i < H_Safe.Length; i++)
        {
            var Component = H_Safe[i].gameObject.GetComponent<Safe>();

            Component.activeSafe = false;
            Component.disableSafe = true;
        }


        for (int i = 0; i < ObsCar_L.Length; i++)
        {
            var esteComponent = ObsCar_L[i].gameObject.GetComponent<ObsCarMoving>();

            esteComponent.activateMesh = false;
            esteComponent.disableMesh = true;
        }
        for (int i = 0; i < ObsCar_R.Length; i++)
        {
            var esteComponent = ObsCar_R[i].gameObject.GetComponent<ObsCarMoving>();

            esteComponent.activateMesh = false;
            esteComponent.disableMesh = true;
        }
    }

    private void RebackEsteet()
    {
        Obs_vectors = new Vector3[Esteet.Length];
        TB_vectors = new Vector3[ToolBoxes.Length];
        Jerry_vectors = new Vector3[JerryCans.Length];
        Grass_vectors = new Vector3[Grass.Length];
        Safe_vectors = new Vector3[Safe.Length];

        //Debug.Log("GameStartForMapControll!");

        if (!isObjectsPicked)
        {
            for (int i = 0; i < Esteet.Length; i++)
            {
                Obs_vectors[i].Set(Esteet[i].transform.position.x, Esteet[i].transform.position.y, Esteet[i].transform.position.z);

                if (Obs_vectors[i].z > AreaVector1.z && Obs_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var esteComponent = Esteet[i].gameObject.GetComponent<Este>();

                    esteComponent.activateMesh = true;
                    esteComponent.disableMesh = false;

                }
                else
                {
                    var esteComponent = Esteet[i].gameObject.GetComponent<Este>();

                    esteComponent.activateMesh = false;
                    esteComponent.disableMesh = true;
                }
            }

            for (int i = 0; i < ToolBoxes.Length; i++)
            {
                TB_vectors[i].Set(ToolBoxes[i].transform.position.x, ToolBoxes[i].transform.position.y, ToolBoxes[i].transform.position.z);

                if (TB_vectors[i].z > AreaVector1.z && TB_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                    Component.activeToolBox = true;
                    Component.disableToolBox = false;

                }
                else
                {
                    var Component = ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                    Component.activeToolBox = false;
                    Component.disableToolBox = true;
                }
            }

            for (int i = 0; i < JerryCans.Length; i++)
            {
                Jerry_vectors[i].Set(JerryCans[i].transform.position.x, JerryCans[i].transform.position.y, JerryCans[i].transform.position.z);

                if (Jerry_vectors[i].z > AreaVector1.z && Jerry_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = JerryCans[i].gameObject.GetComponent<JerryCan>();

                    Component.activeJerryCan = true;
                    Component.disableJerryCan = false;
                }
                else
                {
                    var Component = JerryCans[i].gameObject.GetComponent<JerryCan>();

                    Component.activeJerryCan = false;
                    Component.disableJerryCan = true;
                }
            }

            for (int i = 0; i < Grass.Length; i++)
            {
                Grass_vectors[i].Set(Grass[i].transform.position.x, Grass[i].transform.position.y, Grass[i].transform.position.z);

                if (Grass_vectors[i].z > AreaVector1.z && Grass_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = Grass[i].gameObject.GetComponent<CrassControll>();

                    Component.activeGrass = true;
                    Component.disableGrass = false;

                }
                else
                {
                    var Component = Grass[i].gameObject.GetComponent<CrassControll>();

                    Component.activeGrass = false;
                    Component.disableGrass = true;
                }
            }

            for (int i = 0; i < Safe.Length; i++)
            {
                Safe_vectors[i].Set(Safe[i].transform.position.x, Safe[i].transform.position.y, Safe[i].transform.position.z);

                if (Safe_vectors[i].z > AreaVector1.z && Safe_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = Safe[i].gameObject.GetComponent<Safe>();

                    Component.activeSafe = true;
                    Component.disableSafe = false;
                }
                else
                {
                    var Component = Safe[i].gameObject.GetComponent<Safe>();

                    Component.activeSafe = false;
                    Component.disableSafe = true;
                }
            }

            isObjectsPicked = true;
        }
    }

    private void Reback_A_Esteet()
    {
        A_Obs_vectors = new Vector3[AavikonEsteet.Length];
        A_TB_vectors = new Vector3[A_ToolBoxes.Length];
        A_Jerry_vectors = new Vector3[A_JerryCans.Length];
        A_Grass_vectors = new Vector3[A_Grass.Length];
        A_Safe_vectors = new Vector3[A_Safe.Length];

        //Debug.Log(A_Obs_vectors.Length);

        if (!isObjectsPicked)
        {
            for (int i = 0; i < AavikonEsteet.Length; i++)
            {
                A_Obs_vectors[i].Set(AavikonEsteet[i].transform.position.x, AavikonEsteet[i].transform.position.y, AavikonEsteet[i].transform.position.z);

                if (A_Obs_vectors[i].z > A_AreaVector1.z && A_Obs_vectors[i].z < A_AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var esteComponent = AavikonEsteet[i].gameObject.GetComponent<Este>();

                    esteComponent.activateMesh = true;
                    esteComponent.disableMesh = false;

                }
                else
                {
                    var esteComponent = AavikonEsteet[i].gameObject.GetComponent<Este>();

                    esteComponent.activateMesh = false;
                    esteComponent.disableMesh = true;
                }
            }

            for (int i = 0; i < A_ToolBoxes.Length; i++)
            {
                A_TB_vectors[i].Set(A_ToolBoxes[i].transform.position.x, A_ToolBoxes[i].transform.position.y, A_ToolBoxes[i].transform.position.z);

                if (A_TB_vectors[i].z > A_AreaVector1.z && A_TB_vectors[i].z < A_AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = A_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                    Component.activeToolBox = true;
                    Component.disableToolBox = false;
                }
                else
                {
                    var Component = A_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                    Component.activeToolBox = false;
                    Component.disableToolBox = true;
                }
            }

            for (int i = 0; i < A_JerryCans.Length; i++)
            {
                A_Jerry_vectors[i].Set(A_JerryCans[i].transform.position.x, A_JerryCans[i].transform.position.y, A_JerryCans[i].transform.position.z);

                if (A_Jerry_vectors[i].z > A_AreaVector1.z && A_Jerry_vectors[i].z < A_AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = A_JerryCans[i].gameObject.GetComponent<JerryCan>();

                    Component.activeJerryCan = true;
                    Component.disableJerryCan = false;
                }
                else
                {
                    var Component = A_JerryCans[i].gameObject.GetComponent<JerryCan>();

                    Component.activeJerryCan = false;
                    Component.disableJerryCan = true;
                }
            }

            for (int i = 0; i < A_Grass.Length; i++)
            {
                A_Grass_vectors[i].Set(A_Grass[i].transform.position.x, A_Grass[i].transform.position.y, A_Grass[i].transform.position.z);

                if (A_Grass_vectors[i].z > A_AreaVector1.z && A_Grass_vectors[i].z < A_AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = A_Grass[i].gameObject.GetComponent<CrassControll>();

                    Component.activeGrass = true;
                    Component.disableGrass = false;

                }
                else
                {
                    var Component = A_Grass[i].gameObject.GetComponent<CrassControll>();

                    Component.activeGrass = false;
                    Component.disableGrass = true;
                }
            }

            for (int i = 0; i < A_Safe.Length; i++)
            {
                A_Safe_vectors[i].Set(A_Safe[i].transform.position.x, A_Safe[i].transform.position.y, A_Safe[i].transform.position.z);

                if (A_Safe_vectors[i].z > A_AreaVector1.z && A_Safe_vectors[i].z < A_AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = A_Safe[i].gameObject.GetComponent<Safe>();

                    Component.activeSafe = true;
                    Component.disableSafe = false;

                }
                else
                {
                    var Component = A_Safe[i].gameObject.GetComponent<Safe>();

                    Component.activeSafe = false;
                    Component.disableSafe = true;
                }
            }

            isObjectsPicked = true;
        }
    }

    private void Reback_M_Esteet()
    {
        H_Obs_vectors = new Vector3[HighwayEsteet.Length];
        H_TB_vectors = new Vector3[H_ToolBoxes.Length];
        H_Safe_vectors = new Vector3[H_Safe.Length];
        ObsCar_L_vectors = new Vector3[ObsCar_L.Length];
        ObsCar_R_vectors = new Vector3[ObsCar_R.Length];

        if (!isObjectsPicked)
        {
            for (int i = 0; i < HighwayEsteet.Length; i++)
            {
                H_Obs_vectors[i].Set(HighwayEsteet[i].transform.position.x, HighwayEsteet[i].transform.position.y, HighwayEsteet[i].transform.position.z);

                if (H_Obs_vectors[i].z > AreaVector1.z && H_Obs_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var esteComponent = HighwayEsteet[i].gameObject.GetComponent<Este>();

                    esteComponent.activateMesh = true;
                    esteComponent.disableMesh = false;
                }
                else
                {
                    var esteComponent = HighwayEsteet[i].gameObject.GetComponent<Este>();

                    esteComponent.activateMesh = false;
                    esteComponent.disableMesh = true;
                }
            }

            for (int i = 0; i < H_ToolBoxes.Length; i++)
            {
                H_TB_vectors[i].Set(H_ToolBoxes[i].transform.position.x, H_ToolBoxes[i].transform.position.y, H_ToolBoxes[i].transform.position.z);

                if (H_TB_vectors[i].z > AreaVector1.z && H_TB_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = H_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                    Component.activeToolBox = true;
                    Component.disableToolBox = false;

                }
                else
                {
                    var Component = H_ToolBoxes[i].gameObject.GetComponent<ToolBox>();

                    Component.activeToolBox = false;
                    Component.disableToolBox = true;
                }
            }

            for (int i = 0; i < H_Safe.Length; i++)
            {
                H_Safe_vectors[i].Set(H_Safe[i].transform.position.x, H_Safe[i].transform.position.y, H_Safe[i].transform.position.z);

                if (H_Safe_vectors[i].z > AreaVector1.z && H_Safe_vectors[i].z < AreaVector2.z)
                {
                    //ii++;
                    //PickedObjects = new GameObject[ii];

                    var Component = H_Safe[i].gameObject.GetComponent<Safe>();

                    Component.activeSafe = true;
                    Component.disableSafe = false;

                }
                else
                {
                    var Component = H_Safe[i].gameObject.GetComponent<Safe>();

                    Component.activeSafe = false;
                    Component.disableSafe = true;
                }
            }


            for (int i = 0; i < ObsCar_L.Length; i++)
            {
                ObsCar_L_vectors[i].Set(ObsCar_L[i].transform.position.x, ObsCar_L[i].transform.position.y, ObsCar_L[i].transform.position.z);

                if (ObsCar_L_vectors[i].z > AreaVector1.z && ObsCar_L_vectors[i].z < AreaVector2.z)
                {

                    var esteComponent = ObsCar_L[i].gameObject.GetComponent<ObsCarMoving>();

                    esteComponent.activateMesh = true;
                    esteComponent.disableMesh = false;

                }
                else
                {
                    var esteComponent = ObsCar_L[i].gameObject.GetComponent<ObsCarMoving>();

                    esteComponent.activateMesh = false;
                    esteComponent.disableMesh = true;
                }
            }
            for (int i = 0; i < ObsCar_R.Length; i++)
            {
                ObsCar_R_vectors[i].Set(ObsCar_R[i].transform.position.x, ObsCar_R[i].transform.position.y, ObsCar_R[i].transform.position.z);

                if (ObsCar_R_vectors[i].z > AreaVector1.z && ObsCar_R_vectors[i].z < AreaVector2.z)
                {

                    var esteComponent = ObsCar_R[i].gameObject.GetComponent<ObsCarMoving>();

                    esteComponent.activateMesh = true;
                    esteComponent.disableMesh = false;

                }
                else
                {
                    var esteComponent = ObsCar_R[i].gameObject.GetComponent<ObsCarMoving>();

                    esteComponent.activateMesh = false;
                    esteComponent.disableMesh = true;
                }
            }

            isObjectsPicked = true;
        }
    }
}
