// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyScreen : MonoBehaviour
{
    private GameObject Kamera;

    public GameObject startButtonB;
    private StartButton startButtonS;

    private GameObject Player;
    private CarCollider carCollider;

    private GameObject MenuController;
    private MenuNavigation menuNavigation;

    private GameObject moneyScreen;
    private GameObject MoneyBackground;
    private GameObject MoneyBackground2;
    private Image MoneyBackground_Image;
    private Image MoneyBackground2_Image;
    private GameObject MoneyText_Image;
    private TextMeshProUGUI MoneyText_Image_Text;
    private GameObject MoneyText_Image_Image;
    private Image MoneyText_Image_Image_Image;

    private GameObject Safe_money;

    private GameObject MoneyAddedText;
    public GameObject MoneyAddedT_Money_Image;
    private Text MoneyAddedText_Text;
    private Image MoneyAddedT_Money_Image_Image;

    private GameObject DownPanel;

    private GameObject ScoreNumText;
    public GameObject ScoreNumText2;
    public GameObject ScoreNum_Money_Image;
    private Text ScoreNumText_Text;
    private Text ScoreNumText2_Text;
    private Image ScoreNum_Money_Image_Image;

    private GameObject MoneyAddedScoreText;
    private Text MoneyAddedScoreText_Text;

    private Vector3 targetPos;
    private Vector3 originalPos;

    [SerializeField]
    private float ScoreNumTextSpeed = 250f;

    public GameObject SpeedUpButton;


    private bool ScoreNumTextOnTargetPos = false;


    private bool setUp = true;

    public float time = 0f;
    public float timeDelay = 3f;
    public float timeDelay2 = 2f;
    public float timeDelay3 = 2f;

    public bool activateMoneyT = false;
    public bool activateMoneyST = false;
    public bool disableMoneyST = false;
    private bool pickScoreNum = true;

    private bool moneyScreenActivated = false;

    [HideInInspector]
    public bool CloseScreen = false;

    void Start()        ///Starttisetup
    {
        Kamera = GameObject.Find("Main Camera");
        Safe_money = GameObject.Find("Safe_money");

        //startButtonB = GameObject.Find("StartButton");
        startButtonS = startButtonB.GetComponent<StartButton>();

        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();

        MenuController = GameObject.Find("MenuController");
        menuNavigation = MenuController.GetComponent<MenuNavigation>();

        Safe_money.SetActive(false);

        //1007.9f - x 766f - y
        targetPos = new Vector3((Screen.width / 2) - 100, (Screen.height / 2) + 100f, 0f);
        //140f - x 1035f - y
        originalPos = new Vector3(0f, Screen.height, 0f);
    }

    void Update()
    {
        Safe_money.transform.position = new Vector3(Kamera.transform.position.x, Kamera.transform.position.y - 1.5f, Kamera.transform.position.z + 1f);

        if (startButtonS.IsGameStarted == true && setUp == true)        ///Starttinapin painamisen j�lkeen tuleva setup. Samankaltainen kuin Starttisetup, mutta alkaa vaan starttinapin painamisen j�lkeen.
        {
            moneyScreen = GameObject.Find("MoneyScreen");
            MoneyBackground = GameObject.Find("MoneyBackground");
            MoneyBackground2 = GameObject.Find("MoneyBackground2");
            MoneyText_Image = GameObject.Find("MoneyText_Image");
            MoneyText_Image_Image = GameObject.Find("MoneyText_Image_Image");
            MoneyAddedText = GameObject.Find("MoneyAddedText");
            //MoneyAddedScoreText = GameObject.Find("MoneyAddedScoreText");
            DownPanel = GameObject.Find("DownPanel");

            ScoreNumText = GameObject.Find("ScoreNumText");

            DownPanel.SetActive(false);

            MoneyBackground_Image = MoneyBackground.GetComponent<Image>();
            MoneyBackground2_Image = MoneyBackground2.GetComponent<Image>();
            MoneyText_Image_Text = MoneyText_Image.GetComponent<TextMeshProUGUI>();
            MoneyText_Image_Image_Image = MoneyText_Image_Image.GetComponent<Image>();
            MoneyAddedText_Text = MoneyAddedText.GetComponent<Text>();
            MoneyAddedT_Money_Image_Image = MoneyAddedT_Money_Image.GetComponent<Image>();
            //MoneyAddedScoreText_Text = MoneyAddedScoreText.GetComponent<Text>();

            ScoreNumText_Text = ScoreNumText.GetComponent<Text>();
            ScoreNumText2_Text = ScoreNumText2.GetComponent<Text>();
            ScoreNum_Money_Image_Image = ScoreNum_Money_Image.GetComponent<Image>();

            ScoreNumText2_Text.text = ScoreNumText_Text.text;

            setUp = false;
        }

        MoneyText_Image_Text.text = carCollider.money.ToString();

        if (carCollider.isPlayerDead && moneyScreenActivated == false)          ///Mit� tapahtuu, kun pelaaja kuolee ja rahanantoruutua ei olla viel� aktivoitu.
        {
            if (pickScoreNum == true)           ///Taas pient� "setuppausta", jotta saadaan oikeat arvot tietylle muuttujille sek� aktivoitua muutama objecti/componentti.
            {
                ScoreNumText2_Text.alignment = TextAnchor.MiddleRight;
                ScoreNumText2_Text.text = ScoreNumText_Text.text;
                ScoreNumText2_Text.enabled = true;
                activateMoneyT = false;
                activateMoneyST = false;
                disableMoneyST = false;
                ScoreNumTextOnTargetPos = false;
                ScoreNumTextSpeed = 250f;
                SpeedUpButton.SetActive(true);
                menuNavigation.PlayerDead();
                pickScoreNum = false;
            }

            moneyScreen.SetActive(true);
            MoneyBackground.SetActive(true);
            MoneyBackground2.SetActive(true);
            MoneyText_Image.SetActive(true);
            MoneyText_Image_Image.SetActive(true);
            MoneyAddedText.SetActive(true);
            //MoneyAddedScoreText.SetActive(true);
            ScoreNumText2.SetActive(true);


            if (!ScoreNumTextOnTargetPos)
            {
                MoneyBackground2_Image.enabled = true;
                ScoreNumText2.transform.position = Vector3.MoveTowards(ScoreNumText2.transform.position, targetPos, ScoreNumTextSpeed * Time.deltaTime);
                if (ScoreNumText2.transform.position == targetPos)          ///T�ss� odotetaan liikkuvaa scorenumeroa. Odotetaan niin kauan, kunnes se on saapunut "p��tepys�kille"
                {
                    time = time + 1f * Time.deltaTime;

                    //MoneyAddedScoreText_Text.text = carCollider.moneyPerRound2.ToString();


                    if (time >= timeDelay3 && activateMoneyST == false)         ///T�ss� odotetaan pieni delay, jonka j�lkeen scorenumeron teksti muuttuu raham��r�ksi, jonka saat scorem��r�st�.
                    {

                        MoneyText_Image_Text.enabled = true;
                        MoneyText_Image_Image_Image.enabled = true;

                        ScoreNumText2_Text.alignment = TextAnchor.MiddleRight;

                        ScoreNumText2_Text.text = carCollider.moneyPerRound2.ToString();

                        ScoreNum_Money_Image_Image.enabled = true;

                        //MoneyAddedScoreText_Text.enabled = true;

                        carCollider.AddScoreMoney();

                        //carCollider.money += carCollider.moneyPerRound2;

                        activateMoneyST = true;
                        time = 0;
                    }

                    if (time >= timeDelay2 && disableMoneyST == false)          ///T�ss� odotetaan pieni delay, jonka j�lkeen scorem��r�st� siirryt��n rahaboksien kimppuun.
                    {

                        ScoreNumText2_Text.enabled = false;
                        ScoreNum_Money_Image_Image.enabled = false;

                        MoneyBackground2_Image.enabled = false;
                        SpeedUpButton.SetActive(false);

                        disableMoneyST = true;
                        time = 0;
                        ScoreNumTextOnTargetPos = true;
                    }
                }
            }


            if (ScoreNumTextOnTargetPos)
            {
                MoneyBackground_Image.enabled = true;

                Safe_money.SetActive(true);
                time = time + 1f * Time.deltaTime;

                MoneyAddedText_Text.text = carCollider.moneyPerRound.ToString();

                if (time >= timeDelay && activateMoneyT == false)       ///T�ss� odotetaan pieni delay, koska kassakaapin avausanimaatio ei ole viel� loppunut. Delayn j�lkeen kerrotaan rahabokseista saatu summa.
                {
                    MoneyAddedText_Text.enabled = true;
                    MoneyAddedT_Money_Image_Image.enabled = true;
                    //Debug.Log("KEKE");

                    carCollider.AddSafeMoney();

                    DownPanel.SetActive(true);

                    menuNavigation.SpeedUPMoneyGive();

                    //carCollider.money += carCollider.moneyPerRound;

                    moneyScreenActivated = true;
                    pickScoreNum = true;
                    carCollider.index = 0;
                    carCollider.safesPicked = 0;
                    ScoreNumText2.transform.position = new Vector3(originalPos.x, originalPos.y, originalPos.z);
                    ScoreNumText2.SetActive(false);

                    activateMoneyT = true;
                    time = 0;
                }
            }

        }

    }


    public void M_ScreenOpen()
    {
        moneyScreen.SetActive(true);
        MoneyBackground.SetActive(true);
        MoneyText_Image.SetActive(true);
        MoneyText_Image_Image.SetActive(true);
        MoneyAddedText.SetActive(true);

        MoneyBackground_Image.enabled = true;
        MoneyText_Image_Text.enabled = true;
        MoneyText_Image_Image_Image.enabled = true;

        Safe_money.SetActive(true);
        for (int i = 0; i < carCollider.safesPicked; i++)
        {
            time = time + 1f * Time.deltaTime;
            if (time >= timeDelay)      //!
            {
                MoneyAddedText_Text.enabled = true;
                //Debug.Log("KEKE");
            }

            time = 0;
            time = time + 1f * Time.deltaTime;
            if (time >= timeDelay)
            {
                MoneyAddedText_Text.enabled = false;
                //Debug.Log("KAKA");
            }
        }
        //StartCoroutine(SafeOpen());
        carCollider.index = 0;
        carCollider.safesPicked = 0;
    }

    IEnumerator SafeOpen()
    {
        for (int i = 0; i < carCollider.safesPicked; i++)
        {
            //Safe_money.SetActive(true);
            time = time + 1f * Time.deltaTime;
            yield return new WaitForSeconds(2);
            if (time >= timeDelay)
            {
                MoneyAddedText_Text.enabled = true;
            }
        }
    }

    public void M_ScreenClose()
    {
        MoneyBackground_Image.enabled = false;
        MoneyText_Image_Text.enabled = false;
        MoneyText_Image_Image_Image.enabled = false;
        MoneyAddedText_Text.enabled = false;
        MoneyAddedT_Money_Image_Image.enabled = false;
        SpeedUpButton.SetActive(false);
        Safe_money.SetActive(false);
        DownPanel.SetActive(false);

        CloseScreen = true;
        moneyScreenActivated = false;

    }

    public void M_ScreenSpeedUp()
    {
        ScoreNumText2.transform.position = new Vector3(targetPos.x, targetPos.y, targetPos.z);
        time += 2f;
    }
}
