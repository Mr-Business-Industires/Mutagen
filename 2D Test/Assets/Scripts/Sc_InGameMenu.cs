using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_InGameMenu : MonoBehaviour
{
    public GameObject inGameMenu;
    public bool isShowing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
            ToggleMenuVisibility();
    }

    public void ToggleMenuVisibility()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        isShowing = !isShowing;
        inGameMenu.SetActive(isShowing);
    }


    public void QuitTheGame()
    {
        Application.Quit();
    }
}
