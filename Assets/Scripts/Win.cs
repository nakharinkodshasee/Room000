using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    private float startTime;
    private float elapsedTime;
    public string sceneName = "MainMenu";

    public Animator animator;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "OpeningScene" || SceneManager.GetActiveScene().name == "WinScene")
        {
            elapsedTime = Time.time - startTime;
            if(elapsedTime > 5)
            {
                animator.SetBool("ToNextScene", true);
            }
        }
        
    }

    public void toNextScene(string NewSceneName)
    {
        SceneManager.LoadScene(NewSceneName);
    }
}
