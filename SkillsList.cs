using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsList : MonoBehaviour {

    public bool skillsList = false;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("SkillsList"))
        {
            if (skillsList)
            {
                NotActive();
            }
            else
            {
                Activate();
            }
        }
    }

    void NotActive()
    {
        GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        skillsList = false;
    }

    void Activate()
    {
        GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        skillsList = true;
    }

}
