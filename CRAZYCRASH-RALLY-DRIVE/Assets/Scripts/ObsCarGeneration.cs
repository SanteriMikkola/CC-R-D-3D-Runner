// Author Santeri Mikkola

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsCarGeneration : MonoBehaviour
{
    private GameObject Player;
    private CarCollider carCollider;

    private ObsCarMoving obsCarMoving;

    public Vector3[] Positions;

    public Vector3 targetPos;

    private Vector3 endPos;

    private int randomNum = 0;

    private int i = 0;

    [SerializeField]
    private bool changePosition = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        carCollider = Player.GetComponent<CarCollider>();

        obsCarMoving = gameObject.GetComponent<ObsCarMoving>();

        endPos.Set(obsCarMoving.endPos.x, obsCarMoving.endPos.y, obsCarMoving.endPos.z);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (i >= 32)
        {
            carCollider.changeObsCarsPos = false;
            i = 0;
            obsCarMoving.deactiveObs = true;
        }

        if (carCollider.changeObsCarsPos)
        {
            changePosition = true;
            //carCollider.changeItemsPos = false;
        }

        if (changePosition)
        {
            //Debug.Log(".");
            RandomizePos();
            i++;
        }
    }

    private void RandomizePos()
    {
        switch (Positions.Length)
        {
            case 2:
                {
                    randomNum = Random.Range(0, 101);

                    if (randomNum >= 0 && randomNum <= 50)
                    {
                        targetPos.Set(Positions[0].x, Positions[0].y, Positions[0].z);

                        ChangeCarPos();

                        //Obs_vectors[i].Set(Esteet[i].transform.position.x, Esteet[i].transform.position.y, Esteet[i].transform.position.z);
                    }
                    else
                    {
                        targetPos.Set(Positions[1].x, Positions[1].y, Positions[1].z);

                        ChangeCarPos();
                    }

                    randomNum = 0;
                    changePosition = false;
                }
                break;
            case 3:
                {
                    randomNum = Random.Range(0, 101);

                    if (randomNum >= 0 && randomNum <= 33)
                    {
                        targetPos.Set(Positions[0].x, Positions[0].y, Positions[0].z);

                        ChangeCarPos();

                        //Obs_vectors[i].Set(Esteet[i].transform.position.x, Esteet[i].transform.position.y, Esteet[i].transform.position.z);
                    }
                    else if (randomNum >= 34 && randomNum <= 67)
                    {
                        targetPos.Set(Positions[1].x, Positions[1].y, Positions[1].z);

                        ChangeCarPos();
                    }
                    else
                    {
                        targetPos.Set(Positions[2].x, Positions[2].y, Positions[2].z);

                        ChangeCarPos();
                    }

                    randomNum = 0;
                    changePosition = false;
                }
                break;
        }
    }

    private void ChangeCarPos()
    {
        this.gameObject.transform.position = new Vector3(targetPos.x, targetPos.y, targetPos.z);
        endPos.Set(targetPos.x, targetPos.y, obsCarMoving.endPos.z);
        obsCarMoving.endPos = new Vector3(endPos.x, endPos.y, endPos.z);
        obsCarMoving.startPos = new Vector3(targetPos.x, targetPos.y, targetPos.z);
        obsCarMoving.targetPos = obsCarMoving.endPos;
    }
}
