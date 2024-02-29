using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour
{
    private float startTime;
    private float duration = 200 * 1;
    private float pryDuration = 206;
    private float elapsedTime;
    private bool closetMonsterSpawnable = true;
    private bool closetMonsterSpawn = false;
    public GameObject closetMonster;

    public GameObject bathroomArea;
    private BathroomArea bathroomAreaScript;
    public Animator animator;

    private AudioSource closetAudio;
    public AudioClip[] audioclips;

    void Start()
    {
        startTime = Time.time;

        bathroomAreaScript = bathroomArea.GetComponent<BathroomArea>();
        closetAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        elapsedTime = Time.time - startTime;
        //Debug.Log(elapsedTime);
        animator.SetFloat("elapsedTime", elapsedTime);

        if (elapsedTime >= duration && closetMonsterSpawnable == true)
        {
            closetMonsterSpawnable = false;
        }

        if (closetMonsterSpawnable == false && bathroomAreaScript.hid == false && closetMonsterSpawn == false)
        {
            closetMonsterSpawn = true;
            animator.SetBool("closet_monster_out", true);
        }

        if (elapsedTime >= pryDuration && closetMonsterSpawnable == false && closetMonsterSpawn == false)
        {
            restart();
        }
    }

    public void restart()
    {
        startTime = Time.time;
        closetMonsterSpawnable = true;
    }

    public void instantiateClosetMonster()
    {
        Instantiate(closetMonster, transform.position, transform.rotation);
    }

    public void stopAudio()
    {
        closetAudio.Stop();
    }

    public void openClosetSoundPlaying()
    {
        closetAudio.clip = audioclips[0];
        closetAudio.Play();
    }

    public void closingClosetSoundPlaying()
    {
        closetAudio.clip = audioclips[1];
        closetAudio.Play();
    }
}
