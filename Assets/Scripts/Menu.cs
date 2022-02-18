using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject scenecam;
    public GameObject menucam;

    public GameObject health;
    public GameObject healthUI;

    public playerMovement playerCS;

    // Start is called before the first frame update
    void Start()
    {
        startUp();
        //healthUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Startbutton() {
        startButton();
        //healthUI.SetActive(true);
    }

    public void startUp()
    {
        playerCS.paused = true;
        menucam.SetActive(true);
        scenecam.SetActive(false);
        health.SetActive(false);
        playerCS.pause();
    }

    public void startButton()
    {
        menucam.SetActive(false);
        scenecam.SetActive(true);
        playerCS.resume();
        playerCS.paused = false;
        health.SetActive(true);
    }

    public void Quitbutton()
    {
        Application.Quit();
    }

}
