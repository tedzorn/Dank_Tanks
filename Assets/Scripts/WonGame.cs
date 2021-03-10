using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WonGame : MonoBehaviour
{
	public Button mainButton;
    // Start is called before the first frame update
    void Start()
    {
        mainButton.onClick.AddListener(mainmenucall);
    }

    // Update is called once per frame
    
	public void mainmenucall()
    {
        SceneManager.LoadScene("Main Menu");
        
    }
}
