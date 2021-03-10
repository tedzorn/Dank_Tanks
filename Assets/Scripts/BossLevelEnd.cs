using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossLevelEnd : MonoBehaviour
{
    private AudioSource levelSource;
    public AudioClip nextLevelClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && GameObject.FindGameObjectsWithTag("Boss").Length <= 0)
        {
	    GetComponent<AudioSource>().PlayOneShot(nextLevelClip, .3f);
            SceneManager.LoadScene("You won the game");
        }
    }
}
