using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatherAndCraft : MonoBehaviour {

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
    int _meat;
    public Text meatText;
    int _hide;
    public Text hideText;

    int _woodFoundation;
    public Text woodFoundationText;
    int _woodWall;
    public Text woodWallText;
    int _woodRoof;
    public Text woodRoofText;
    int _stoneFoundation;
    public Text stoneFoundationText;
    int _stoneWall;
    public Text stoneWallText;
    int _stoneRoof;
    public Text stoneRoofText;

    public GameObject GatherWood;
    public GameObject GatherThatch;
    public GameObject GatherStone;
    public GameObject GatherFlint;
    public GameObject GatherFiber;
    public GameObject GatherBerry;
    public GameObject GatherMeat;
    public GameObject GatherHide;

     bool canCraftWoodFoundation = false;
     bool canCraftWoodWall = false;
     bool canCraftWoodRoof = false;
     bool canCraftStoneFoundation = false;
     bool canCraftStoneWall = false;
     bool canCraftStoneRoof = false;

    public static GatherAndCraft instance;

    void Awake()
    {
        instance = this;
    }


    void Start() //We are going to gather by making a trigger appear in front of the player whenever you click
        //So at the start we are going to put this trigger to 0 size and in the middle of the player so it never gets hit
    {
        GetComponent<BoxCollider>().size = new Vector3(0.0f, 0.0f, 0.0f); //size
        GetComponent<BoxCollider>().center = new Vector3(0.0f, 0.0f, 0.0f); //location

        wood = 1000;
        stone = 1000;
        thatch = 1000;
        fiber = 1000;

        woodFoundation = 0;
        woodWall = 0;
        woodRoof = 0;
        stoneFoundation = 0;
        stoneWall = 0;
        stoneRoof = 0;
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
        if (wood >= 16 && thatch >= 24 && fiber >= 20)
        {
            canCraftWoodFoundation = true;
        }
        if (wood >= 4 && thatch >= 8 && fiber >= 6)
        {
            canCraftWoodWall = true;
        }
        if (wood >= 8 && thatch >= 16 && fiber >= 12)
        {
            canCraftWoodRoof = true;
        }
        if (stone >= 24 && wood >= 20 && thatch >= 16)
        {
            canCraftStoneFoundation = true;
        }
        if (stone >= 8 && wood >= 6 && thatch >= 4)
        {
            canCraftStoneWall = true;
        }
        if (stone >= 16 && wood >= 12 && thatch >= 8)
        {
            canCraftStoneRoof = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        float randValue = Random.value; //get a random number from 0-1

        if (collision.gameObject.tag == "Bush" && randValue <= 0.50f) //if the trigger hits a bush and the random value is less or equal to 0.50
        {
            fiber += 1; //add one fiber
            ApplyStats.instance.weight = ApplyStats.instance.weight + 0.1f;
            GatherFiber.SetActive(true);
            StartCoroutine(gatherFiberText());
            Debug.Log(fiber);
        }
        if (collision.gameObject.tag == "Bush" && randValue >= 0.51) //if the trigger hits a bush and the random value is greater or equal to 0.51
        {
            berry += 1; //add one berry
            ApplyStats.instance.weight = ApplyStats.instance.weight + 0.1f;
            GatherBerry.SetActive(true);
            StartCoroutine(gatherBerryText());
            Debug.Log(berry);
        }
        if (collision.gameObject.tag == "Tree" && randValue <= 0.30f) //if the trigger hits a tree and the random number is equal or less than 0.30
        {
            wood += 1; //add one wood
            ApplyStats.instance.weight = ApplyStats.instance.weight + 0.5f;
            GatherWood.SetActive(true); //Activate the WoodGather text
            StartCoroutine(gatherWoodText());
            Debug.Log(wood); 
        }
        if(collision.gameObject.tag == "Tree" && randValue >= 0.31f) //if the trigger hits a tree and the random number is greater or equal to 0.31
        {
            thatch += 1;
            ApplyStats.instance.weight = ApplyStats.instance.weight + 0.1f;
            GatherThatch.SetActive(true);
            StartCoroutine(gatherThatchText());
            Debug.Log(thatch);
        }
        if (collision.gameObject.tag == "Rock" && randValue >= 0.50f) //if the trigger hits a rock
        {
            stone += 1; //add one stone
            ApplyStats.instance.weight = ApplyStats.instance.weight + 0.5f;
            GatherStone.SetActive(true);
            StartCoroutine(gatherStoneText());
            Debug.Log(stone);
        }
        if (collision.gameObject.tag == "Rock" && randValue <= 0.51f)
        {
            flint += 1;
            ApplyStats.instance.weight = ApplyStats.instance.weight + 0.2f;
            GatherFlint.SetActive(true);
            StartCoroutine(gatherFlintText());
            Debug.Log(flint);
        }
        if(collision.gameObject.tag == "DeadRabbit" && randValue <= 0.50f)
        {
            meat += 1;
            ApplyStats.instance.weight = ApplyStats.instance.weight + 0.3f;
            GatherMeat.SetActive(true);
            StartCoroutine(gatherMeatText());
            Debug.Log(meat);
        }
        if (collision.gameObject.tag == "DeadRabbit" && randValue >= 0.51f)
        {
            hide += 1;
            ApplyStats.instance.weight = ApplyStats.instance.weight + 0.3f;
            GatherHide.SetActive(true);
            StartCoroutine(gatherHideText());
            Debug.Log(hide);
        }
        if (collision.gameObject.tag == "DeadTiger" && randValue <= 0.50f)
        {
            meat += 1;
            ApplyStats.instance.weight = ApplyStats.instance.weight + 0.3f;
            GatherMeat.SetActive(true);
            StartCoroutine(gatherMeatText());
            Debug.Log(meat);
        }
        if (collision.gameObject.tag == "DeadTiger" && randValue >= 0.51f)
        {
            hide += 1;
            ApplyStats.instance.weight = ApplyStats.instance.weight + 0.3f;
            GatherHide.SetActive(true);
            StartCoroutine(gatherHideText());
            Debug.Log(hide);
        }
    }

    public void WoodFoundation()
    {
        if (canCraftWoodFoundation == true)
        {
            Debug.Log("Wood foundation crafted");
            wood = wood - 16;
            thatch = thatch - 24;
            fiber = fiber - 12;
            woodFoundation += 1;
            Debug.Log(woodFoundation);
        }
    }

    public void WoodWall()
    {
        if (canCraftWoodWall == true)
        {
            Debug.Log("Wood wall crafted");
            wood = wood - 4;
            thatch = thatch - 8;
            fiber = fiber - 6;
            woodWall += 1;
            Debug.Log(woodWall);
        }
    }

    public void WoodRoof()
    {
        if (canCraftWoodRoof == true)
        {
            Debug.Log("Wood roof crafted");
            wood = wood - 8;
            thatch = thatch - 16;
            fiber = fiber - 12;
            woodRoof += 1;
            Debug.Log(woodRoof);
        }
    }

    public void StoneFoundation()
    {
        if (canCraftStoneFoundation == true)
        {
            Debug.Log("Stone foundation crafted");
            stone = stone - 24;
            wood = wood - 20;
            thatch = thatch - 16;
            stoneFoundation += 1;
        }
    }

    public void StoneWall()
    {
        if (canCraftStoneWall == true)
        {
            Debug.Log("Stone wall crafted");
            stone = stone - 8;
            wood = wood - 6;
            thatch = thatch - 4;
            stoneWall += 1;
        }
    }

    public void StoneRoof()
    {
        if (canCraftStoneRoof == true)
        {
            Debug.Log("Stone roof crafted");
            stone = stone - 16;
            wood = wood - 12;
            thatch = thatch - 8;
            stoneRoof += 1;
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

    public int meat //this is how we will add up how much fiber we have
    {
        get //get current amount
        {
            return _meat;
        }

        set //set new amount
        {
            _meat = value;
            if (meatText)
                meatText.text = "Meat: " + meat; //change the fiber text to display new amount
        }
    }

    public int hide //this is how we will add up how much hide we have
    {
        get //get current amount
        {
            return _hide;
        }

        set //set new amount
        {
            _hide = value;
            if (hideText)
                hideText.text = "Hide: " + hide; //change the fiber text to display new amount
        }
    }

    public int woodFoundation 
    {
        get //get current amount
        {
            return _woodFoundation;
        }

        set //set new amount
        {
            _woodFoundation = value;
            if (woodFoundationText)
                woodFoundationText.text = "Wood Foundations: " + woodFoundation;
        }
    }

    public int woodWall
    {
        get //get current amount
        {
            return _woodWall;
        }

        set //set new amount
        {
            _woodWall = value;
            if (woodWallText)
                woodWallText.text = "Wood Walls: " + woodWall; //change stone text to display new amount
        }
    }

    public int woodRoof
    {
        get //get current amount
        {
            return _woodRoof;
        }

        set //set new amount
        {
            _woodRoof = value;
            if (woodRoofText)
                woodRoofText.text = "Wood Roofs: " + woodRoof; //change stone text to display new amount
        }
    }

    public int stoneFoundation 
    {
        get //get current amount
        {
            return _stoneFoundation;
        }

        set //set new amount
        {
            _stoneFoundation = value;
            if (stoneFoundationText)
                stoneFoundationText.text = "Stone Foundations: " + stoneFoundation; //change stone text to display new amount
        }
    }

    public int stoneWall 
    {
        get //get current amount
        {
            return _stoneWall;
        }

        set //set new amount
        {
            _stoneWall = value;
            if (stoneWallText)
                stoneWallText.text = "Stone Walls: " + stoneWall; //change stone text to display new amount
        }
    }

    public int stoneRoof 
    {
        get //get current amount
        {
            return _stoneRoof;
        }

        set //set new amount
        {
            _stoneRoof = value;
            if (stoneRoofText)
                stoneRoofText.text = "Stone Roofs: " + stoneRoof; //change stone text to display new amount
        }
    }

    IEnumerator gatherWoodText()
    {
        yield return new WaitForSeconds(0.4f); //Set the time before the code is used
        Debug.Log("Wood text gone");
        GatherWood.SetActive(false);
    }
    
    IEnumerator gatherThatchText()
    {
        yield return new WaitForSeconds(0.4f); //Set the time before the code is used
        Debug.Log("Thatch text gone");
        GatherThatch.SetActive(false);
    }

    IEnumerator gatherStoneText()
    {
        yield return new WaitForSeconds(0.4f);
        Debug.Log("Stone text gone");
        GatherStone.SetActive(false);
    }

    IEnumerator gatherFlintText()
    {
        yield return new WaitForSeconds(0.4f);
        Debug.Log("Flint text gone");
        GatherFlint.SetActive(false);
    }

    IEnumerator gatherFiberText()
    {
        yield return new WaitForSeconds(0.4f);
        Debug.Log("Fiber text gone");
        GatherFiber.SetActive(false);
    }

    IEnumerator gatherBerryText()
    {
        yield return new WaitForSeconds(0.4f);
        Debug.Log("Berry text gone");
        GatherBerry.SetActive(false);
    }

    IEnumerator gatherMeatText()
    {
        yield return new WaitForSeconds(0.4f);
        Debug.Log("Meat text gone");
        GatherMeat.SetActive(false);
    }
    
    IEnumerator gatherHideText()
    {
        yield return new WaitForSeconds(0.4f);
        Debug.Log("Hide text gone");
        GatherHide.SetActive(false);
    }

}
