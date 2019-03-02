using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gather : MonoBehaviour {

    int _fiber;
    public Text fiberText;
    int _wood;
    public Text woodText;
    int _thatch;
    public Text thatchText;
    int _stone;
    public Text stoneText;
    int _berry;
    public Text berryText;
    int _flint;
    public Text flintText;
    

    void Start() //We are going to gather by making a trigger appear in front of the player whenever you click
        //So at the start we are going to put this trigger to 0 size and in the middle of the player so it never gets hit
    {
        GetComponent<BoxCollider>().size = new Vector3(0.0f, 0.0f, 0.0f); //size
        GetComponent<BoxCollider>().center = new Vector3(0.0f, 0.0f, 0.0f); //location
    }

    void Update() //When we click we will move the trigger in front of the player and when we release we will move it back
    {
        if (Input.GetButtonDown("Fire1")) //when left mouse clicked
        {
            GetComponent<BoxCollider>().size = new Vector3(1.0f, 1.0f, 1.0f); //change size
            GetComponent<BoxCollider>().center = new Vector3(0.0f, 0.0f, 1.0f); //change location
        }
        if (Input.GetButtonUp("Fire1")) //when left mouse released
        {
            GetComponent<BoxCollider>().size = new Vector3(0.0f, 0.0f, 0.0f); //change size back
            GetComponent<BoxCollider>().center = new Vector3(0.0f, 0.0f, 0.0f); //change location back
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        float randValue = Random.value; //get a random number from 0-1

        if (collision.gameObject.tag == "Bush" && randValue <= 0.50f) //if the trigger hits a bush and the random value is less or equal to 0.50
        {
            fiber += 1; //add one fiber
            Debug.Log(fiber);
        }
        if (collision.gameObject.tag == "Bush" && randValue >= 0.51) //if the trigger hits a bush and the random value is greater or equal to 0.51
        {
            berry += 1; //add one berry
            Debug.Log(berry);
        }
        if (collision.gameObject.tag == "Tree" && randValue <= 0.30f) //if the trigger hits a tree and the random number is equal or less than 0.30
        {
            wood += 1; //add one wood
            Debug.Log(wood); 
        }
        if(collision.gameObject.tag == "Tree" && randValue >= 0.31f) //if the trigger hits a tree and the random number is greater or equal to 0.31
        {
            thatch += 1;
            Debug.Log(thatch);
        }
        if (collision.gameObject.tag == "Rock" && randValue >= 0.50f) //if the trigger hits a rock
        {
            stone += 1; //add one stone
            Debug.Log(stone);
        }
        if (collision.gameObject.tag == "Rock" && randValue <= 0.51f)
        {
            flint += 1;
            Debug.Log(flint);
        }
    }

    public int fiber //this is how we will add up how much fiber we have
    {
        get //get current amount
        {
            return _fiber;
        }

        set //set new amount
        {
            _fiber = value;
            if (fiberText)
                fiberText.text = "Fiber: " + fiber; //change the fiber text to display new amount
        }
    }

    public int berry //this is how we will add up how much berries we have
    {
        get //get current amount
        {
            return _berry;
        }

        set //set new amount
        {
            _berry = value;
            if (berryText)
                berryText.text = "Berries: " + berry; //change the fiber text to display new amount
        }
    }

    public int wood //this is how we will add up how much wood we have
    {
        get //get current amount
        {
            return _wood;
        }

        set //set new amount
        {
            _wood = value;

            if (woodText)
                woodText.text = "Wood: " + wood; //change wood text to display new amount
        }
    }

    public int thatch //this is how we will add up how much wood we have
    {
        get //get current amount
        {
            return _thatch;
        }

        set //set new amount
        {
            _thatch = value;

            if (thatchText)
                thatchText.text = "Thatch: " + thatch; //change wood text to display new amount
        }
    }

    public int stone //this is how we will add up how much stone we have
    {
        get //get current amount
        {
            return _stone;
        }

        set //set new amount
        {
            _stone = value;
            if (stoneText)
                stoneText.text = "Stone: " + stone; //change stone text to display new amount
        }
    }

    public int flint //this is how we will add up how much stone we have
    {
        get //get current amount
        {
            return _flint;
        }

        set //set new amount
        {
            _flint = value;
            if (flintText)
                flintText.text = "Flint: " + flint; //change stone text to display new amount
        }
    }
}
