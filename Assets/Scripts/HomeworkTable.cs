using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeworkTable : MonoBehaviour
{
    private bool interactable = false;
    private bool doHomeWorkable = false;
    public bool doingHomework = false;
    public double homework = 0;
    public int finishedHomework = 0;
    private Vector3 otherPos;
    private GameObject obj;

    private AudioSource hwtAudio;
    public AudioClip doingHomeworkAudioClip;

    void Start()
    {
        hwtAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        interact();
        doHomework();
        if(homework >= 100 && finishedHomework != 6)
        {
            finishedHomework = finishedHomework + 1;
            homework = 0;
        }

        if (otherPos != this.gameObject.transform.position)
        {
            doHomeWorkable = false;
            doingHomework = false;
            stopPlayingAudio();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Enter Homework");
            interactable = true;
            obj = other.gameObject;
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            otherPos = other.transform.position;
        }
            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Exit Homework");
            interactable = false;
        }
            
    }


    void interact()
    {
         if(Input.GetKeyDown(KeyCode.E) && interactable == true)
                        {
                            doHomeWorkable = true;
                            obj.transform.position = this.gameObject.transform.position;
                            otherPos = obj.transform.position;
                            doingHomeworkSoundPlaying();
                        }
    }

    void doHomework()
    {
        if(doHomeWorkable == true && homework <= 100 )
        {
            homework = homework + 0.01;
            doingHomework = true;
            Debug.Log(homework);
        }
    }

    public void doingHomeworkSoundPlaying()
    {
        hwtAudio.Play();
    }

    public void stopPlayingAudio()
    {
        hwtAudio.Stop();
    }
}
