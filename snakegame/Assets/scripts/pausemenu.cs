using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour
{
    public static bool pause = false;
    public GameObject pausemenuui;
    void Start()
    {
        pausemenuui = gameObject.transform.GetChild(0).gameObject;
        pausemenuui.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                resume();
            }
            else
            {
                pausegame();
            }
        }
    }

   public void resume()
    {
        pausemenuui.SetActive(false);
        Time.timeScale = 1f;
        pause = false;

    }

    void pausegame()
    {
        pausemenuui.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
