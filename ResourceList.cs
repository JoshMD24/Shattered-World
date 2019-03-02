using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceList : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject resourceList;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("ResourceList"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    void Resume()
    {
        GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

}
