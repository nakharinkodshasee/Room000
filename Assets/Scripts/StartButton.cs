using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Animator animator;
    
    public void pressStart()
    {
        animator.SetBool("ToGameplayScene", true);
    }
}
