using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject player;
    private Player playerScript;
    private float startTime;
    private float elapsedTime;
    private bool started = false;

    public Animator fadeAnimator;

    void Start()
    {
        playerScript = player.GetComponent<Player>();
    }

    void Update()
    {
        if(player == null && started == false || playerScript.dead == true && started == false)
        {
            started = true;
            startTime = Time.time;
        }
        else if (started == true)
        {
            elapsedTime = Time.time - startTime;
            if(elapsedTime > 5)
            {
                fadeAnimator.SetBool("ToNextScene",true);
            }
        }
    }
}
