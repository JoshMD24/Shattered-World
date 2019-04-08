using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement instance;
    public float moveSpeed;
    public float moveSpeedOne;
    public float maxMoveSpeed;
    public bool sprint;

    // Use this for initialization
    void Start()
    {
        instance = this;
        maxMoveSpeed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Move on the x axis                              0 is the y axis          //Move on the y axis
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        if (Input.GetButtonDown("Sprint"))
        {
            sprint = true;
            Sprint();     
        }
        if (Input.GetButtonUp("Sprint"))
        {
            sprint = false;
            Sprint();
        }
    }

    void Sprint()
    {
        if (sprint == true)
        {
            moveSpeed = moveSpeed * 1.5f;
        }
        if (sprint == false)
        {
            moveSpeed = moveSpeed / 1.5f;
        }
    }

    public void LevelUpStat()
    {
        if (ApplyStats.instance.hasSkillPoint == true)
        {
            Stats.instance.speedStatLevel = Stats.instance.speedStatLevel + 1;
            moveSpeed = moveSpeed + 0.2f;
            maxMoveSpeed = maxMoveSpeed + 0.2f;
            Experience.instance.skillPoints--;
        }
    }
}
