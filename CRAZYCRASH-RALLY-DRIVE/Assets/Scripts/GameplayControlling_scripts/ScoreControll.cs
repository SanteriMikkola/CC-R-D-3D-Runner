// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControll : MonoBehaviour
{
    [SerializeField]
    private Text ScoreNumText;
    private PlayerMovement playerMove;
    private GameObject Player;
    private GameObject fCfrontCol;
    private MapControll mapControll;
    public int numBer;
    public bool IsThatStart = true;

    private CarCollider carCollider;

    void Start()
    {
        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();
        fCfrontCol = GameObject.Find("FrontCollider");
        mapControll = fCfrontCol.GetComponent<MapControll>();
        numBer = 000;
    }
    void FixedUpdate()
    {
        IsplayerDead();
        
    }

    public void IncreaseScore()
    {

        numBer += 5;
        ScoreNumText.text = numBer.ToString();
    }

    IEnumerator OdotaHetki()
    {
        yield return new WaitForSeconds(20f);
    }

    private void IsplayerDead()
    {
        if (carCollider.isPlayerDead == true)
        {
            carCollider.playerCollide = true;
        }
    }
}
