using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject scenecam;
    public GameObject menucam;

    public GameObject health;
    public GameObject healthUI;

    // Start is called before the first frame update
    void Start()
    {
        menucam.SetActive(true);
        scenecam.SetActive(false);
        health.SetActive(false);
        healthUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Startbutton() {
        menucam.SetActive(false);
        scenecam.SetActive(true);
        health.SetActive(true);
        healthUI.SetActive(true);
    }

    public void Quitbutton()
    {
        Application.Quit();
    }

}
