using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject CanvasA;
    public Scene m_Scene;
    string sceneName;
    public static bool GameIsPaused = false;
    
    public Button mainButton,resumeButton,restartButton ;
    // Start is called before the first frame update
    void Start()
    {
        
        mainButton.onClick.AddListener(mainmenucall);
        resumeButton.onClick.AddListener(resumecall);
        restartButton.onClick.AddListener(restartcall);
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        Time.timeScale = 1;
        CanvasA.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.P))
        {
            if (NextLevel.nlamon == false && LossManager.amon == false)
            {
                pausefunction();
            }
            
        }
        
    }
    public void mainmenucall()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
        
    }

    public void resumecall()
    {
        Time.timeScale = 1;
        CanvasA.SetActive(false);
        GameIsPaused = false;
    }

    public void restartcall()
    {
        Time.timeScale = 1;
        GameIsPaused = false;
        SceneManager.LoadScene(sceneName);
    }

    public void pausefunction()
    {
        Time.timeScale = 0;
        CanvasA.SetActive(true);
        GameIsPaused = true;
    }
}

