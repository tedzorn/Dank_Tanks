using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Button instructButton,qButton,startButton ;
    void Start()
    {
        instructButton.onClick.AddListener(instructioncall);
        qButton.onClick.AddListener(quitcall);
        startButton.onClick.AddListener(startcall);
        Time.timeScale = 1;
    }

    
    
    public void instructioncall()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void quitcall()
    {
        Application.Quit();
    }

    public void startcall()
    {
        SceneManager.LoadScene("Level 1");
    }
}
