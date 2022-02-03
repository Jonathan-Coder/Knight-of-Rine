using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject scenecam;
    public GameObject menucam;

    // Start is called before the first frame update
    void Start()
    {
        menucam.SetActive(true);
        scenecam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Startbutton() {
        menucam.SetActive(false);
        scenecam.SetActive(true);
    }

    public void Quitbutton()
    {
        Application.Quit();
    }

}
