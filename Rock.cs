using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    public int stoneLeft;
    public bool isMined;

    void Start()
    {
        isMined = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player") //what happens if the tree gets hit by a trigger tagged Player
        {
            stoneLeft--; //take away one stone
        }
        if (stoneLeft <= 0) //what happens if there is no stone left
        {
            mined(); //use void mined
        }
    }
    
    void mined() //what happens when the rock is out of stone
    {
        Debug.Log("Rock out of stone");
        GetComponent<MeshRenderer>().enabled = false; //disable the mesh renderer
        GetComponent<MeshCollider>().enabled = false; //disable the mesh collider
        isMined = true; //change isMined state to true
        StartCoroutine(reGrowRock()); //start the reGrowRock Coroutine
    }

    IEnumerator reGrowRock() //the reGrowRock Coroutine
    {
        yield return new WaitForSeconds(5); //wait x amount of seconds before the code below is executed
        Debug.Log("Stone regrown");
        GetComponent<MeshRenderer>().enabled = true; //turn on the mesh renderer
        GetComponent<MeshCollider>().enabled = true; //turn on the mesh collider
        isMined = false; //change the isMined state to false
        stoneLeft = 15; //change the total amount of stone left
    }

}
