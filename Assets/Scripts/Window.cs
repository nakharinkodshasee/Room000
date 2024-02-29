using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    private float startTime;
    private float duration = 180 * 1; 
    private float hangedmanDuration = 187;
    private float elapsedTime;
    private bool hangedManSpawnable = true;
    private bool hangedmanSpawn = false;
    private bool reelingPlayed = false;
    public GameObject hangedMan;

    public GameObject bed;
    private Bed bedScript;
    public Animator animator;

    private AudioSource windowAudio;
    public AudioClip hangingAudioClip;
    public AudioClip reelingAudioClip;
    public AudioClip fallingAudioClip;
    public AudioClip ropePullingAudioClip;
    public AudioClip ropeBreakAudioClip;

    void Start()
    {
        startTime = Time.time;

        bedScript = bed.GetComponent<Bed>();
        windowAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        elapsedTime = Time.time - startTime;
        //Debug.Log(elapsedTime);
        animator.SetFloat("elapsedTime", elapsedTime);

        if (elapsedTime >= duration && hangedManSpawnable == true)
        {
            hangedManSpawnable = false;
        }

        if( hangedManSpawnable == false && bedScript.hid == false && hangedmanSpawn == false)
        {
            hangedmanSpawn = true;
            animator.SetBool("hangedman_out", true);
        }

        if (elapsedTime >= hangedmanDuration && hangedManSpawnable == false && hangedmanSpawn == false)
        {
            restart();
        }
    }

    public void restart()
    {
        startTime = Time.time;
        //Debug.Log("elapsed Time" + elapsedTime);
        hangedManSpawnable = true;
    }

    public void hangingSoundPlaying()
    {
        if(windowAudio.clip.name != "hang_man_rope")
        {
            windowAudio.clip = hangingAudioClip;
            reelingPlayed = false;
        }
        windowAudio.Play();
    }

    public void reelingSoundPlaying()
    {
        
        if (windowAudio.clip.name != "rope_reeling" && reelingPlayed == false)
        {
            reelingPlayed = true;
            windowAudio.clip = reelingAudioClip;
            windowAudio.Play();
        }
    }

    public void fallingSoundPlaying()
    {
        windowAudio.clip = fallingAudioClip;
        windowAudio.Play();
    }

    public void pullingSoundPlaying()
    {
        windowAudio.clip = ropePullingAudioClip;
        windowAudio.Play();
    }

    public void breakingSoundPlaying()
    {
        windowAudio.clip = ropeBreakAudioClip;
        windowAudio.Play();
    }

    public void instantiateHangedman()
    {
        Instantiate(hangedMan , transform.position, transform.rotation);
    }

    public void stopAudio()
    {
        windowAudio.Stop();
    }
}
