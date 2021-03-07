using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LossManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CanvasC;
    public static bool amon = false;
    public Button lossmainButton,lossquitButton,lossrestartButton ;
    void Start()
    {
        
        lossmainButton.onClick.AddListener(mainmenucall);
        lossquitButton.onClick.AddListener(quitcall);
        lossrestartButton.onClick.AddListener(restartcall);
        Time.timeScale = 1;
        CanvasC.SetActive(false);
    }
    
    
    
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length <= 0)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0
                | GameObject.FindGameObjectsWithTag("Boss").Length > 0)
            {
                Time.timeScale = 0;
                CanvasC.SetActive(true);
                amon = true;
            }
        }
    }
     void mainmenucall()
     {
         amon = false;
         SceneManager.LoadScene("Main Menu");
        
    }

     void quitcall()
     {
         amon = false;
         Application.Quit();
    }

     void restartcall()
     {
         amon = false;
         SceneManager.LoadScene("Level 1");
    }
}

