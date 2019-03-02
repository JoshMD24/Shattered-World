using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
    
    public int woodLeft;
    public bool isCutDown;

    void Start()
    {
        isCutDown = false;
    }
	
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player") //what happens if the tree gets hit by a trigger tagged Player
        {
            woodLeft--; //take away one wood
        }
        if (woodLeft <= 0) //what happens if there is no wood left
        {
            cutDown();
        }
    }

   void cutDown() //what happen when there is no wood left
    {
        Debug.Log("Tree cut down");
        GetComponent<MeshRenderer>().enabled = false; //disable the mesh renderer 
        GetComponent<BoxCollider>().enabled = false; //disbale the box collider
        isCutDown = true; //change the isCutDown state to true
        StartCoroutine(reGrow()); //start the reGrow coroutine
    }

    IEnumerator reGrow() //reGrow coroutine
    {
        yield return new WaitForSeconds(5); //wait x seconds before executing the code below
        Debug.Log("Tree regrown");
        GetComponent<MeshRenderer>().enabled = true; //enable the mesh renderer
        GetComponent<BoxCollider>().enabled = true; //enable the box collider
        isCutDown = false; //change the isCutDown state to false
        woodLeft = 10; //change the wood left to 10
    }

}
