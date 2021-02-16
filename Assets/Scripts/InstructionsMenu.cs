using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button instructButton;
    void Start()
    {
        instructButton.onClick.AddListener(mainmenucall);
    }

    public void mainmenucall()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
}
