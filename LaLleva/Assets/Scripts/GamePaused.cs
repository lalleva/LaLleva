using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePaused : MonoBehaviour {

    GameObject canvasPaused;

    private void Awake()
    {
        canvasPaused = GameObject.Find("CanvasPaused");

        canvasPaused.SetActive(false);
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvasPaused.activeInHierarchy == false)
            {
                canvasPaused.SetActive(true);
            }
            else
            {
                canvasPaused.SetActive(false);
            }
        }
	}

    public void Resume() {

        if (canvasPaused.activeInHierarchy == true)
        {
            canvasPaused.SetActive(false);
        }
    }
}
