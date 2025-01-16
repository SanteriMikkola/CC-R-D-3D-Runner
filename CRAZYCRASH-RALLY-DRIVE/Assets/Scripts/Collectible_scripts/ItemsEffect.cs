using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsEffect : MonoBehaviour
{

    [HideInInspector]
    public Vector3 targetPos, upperPos,
                    downPos;

    private float speed = 0.15f;
    public float rotSpeed;

    public int randInt;

    // Start is called before the first frame update
    void Start()
    {
        upperPos = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);   //1.15f
        downPos = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);

        targetPos = upperPos;

        randInt = Random.Range(1, 11);

        if (randInt >= 1 && randInt <= 5)
        {
            rotSpeed = -0.25f;
        }
        else
        {
            rotSpeed = 0.25f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position == upperPos)
        {
            targetPos = downPos;
        }
        if (transform.position == downPos)
        {
            targetPos = upperPos;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        transform.Rotate(0f, rotSpeed, 0f);
    }
}
