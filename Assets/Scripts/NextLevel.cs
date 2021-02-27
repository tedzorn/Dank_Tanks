using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject CanvasB;
    public Scene m_Scene;
    string sceneName;
    
    public Button mainButton,nextButton ;
    // Start is called before the first frame update
    void Start()
    {
        
        mainButton.onClick.AddListener(mainmenucall);
        nextButton.onClick.AddListener(nextcall);

        m_Scene = SceneManager.GetActiveScene();
        CanvasB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            nextlevelfun();

        }
        
        
    }
    public void mainmenucall()
    {
        
        SceneManager.LoadScene("Main Menu");
        
    }

    

    public void nextcall()
    {
        
        SceneManager.LoadScene(m_Scene.buildIndex + 1);
    }

    public void nextlevelfun()
    {
        
        CanvasB.SetActive(true);
    }
    
}