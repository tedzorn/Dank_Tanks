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
    public static bool nlamon = false;
    public Button mainButton,nextButton ;

    private AudioSource levelSource;
    public AudioClip nextLevelClip;

    private bool playedSound = false;
    // Start is called before the first frame update
    void Start()
    {
        nlamon = false;
        mainButton.onClick.AddListener(mainmenucall);
        nextButton.onClick.AddListener(nextcall);

        m_Scene = SceneManager.GetActiveScene();
        CanvasB.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            
            nextlevelfun();
            nlamon = true;
        }
        
        
    }
    public void mainmenucall()
    {
        nlamon = false;
        SceneManager.LoadScene("Main Menu");
        
    }

    

    public void nextcall()
    {
        nlamon = false;
        SceneManager.LoadScene(m_Scene.buildIndex + 1);
    }

    public void nextlevelfun()
    {
        nlamon = false;
        CanvasB.SetActive(true);
	if (!playedSound) {
            GetComponent<AudioSource>().PlayOneShot(nextLevelClip, .3f);
            playedSound = true;
        }
    }
    
}