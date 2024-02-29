using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour
{
    private bool interactable = false;
    public bool hid = false;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject homeworkTable;
    private Player playerScript;
    private HomeworkTable Hwtb;

    private float startTime;
    private float duration = 120 * 1;
    private float stayDuration = 126;
    private float elapsedTime;
    private bool bedMonsterSpawnable = true;
    private bool bedMonsterSpawn = false;
    public GameObject bedMonster;

    public Animator animator;
    public Animator fadeAnimator;

    private AudioSource bedAudio;
    public AudioClip[] audioclips;

    void Start()
    {
        playerScript = player.GetComponent<Player>();
        Hwtb = homeworkTable.GetComponent<HomeworkTable>();
        bedAudio = GetComponent<AudioSource>();

        startTime = Time.time;
    }

    void Update()
    {
        interact();

        elapsedTime = Time.time - startTime;
        animator.SetFloat("elapsedTime", elapsedTime);

        if (elapsedTime >= duration && bedMonsterSpawnable == true)
        {
            bedMonsterSpawnable = false;
        }

        if (bedMonsterSpawnable == false && Hwtb.doingHomework == true && bedMonsterSpawn == false)
        {
            bedMonsterSpawn = true;
            animator.SetBool("bed_monster_out", true);
        }

        if (elapsedTime >= stayDuration && bedMonsterSpawnable == false && bedMonsterSpawn == false)
        {
            restart();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        interactable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = false;
    }

    void interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable == true && hid == false)
        {
            playerScript.hide();
            hid = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && interactable == true && hid == true)
        {
            playerScript.unhide();
            hid = false;
        }

        if((Input.GetKeyDown(KeyCode.S) && Hwtb.finishedHomework == 6))
        {
            fadeAnimator.SetBool("ToWinScene",true);
        }
    }

    public void restart()
    {
        startTime = Time.time;
        bedMonsterSpawnable = true;
    }

    public void instantiatebedMonster()
    {
        Instantiate(bedMonster, transform.position, transform.rotation);
    }

    public void bedMonsterInSoundPlaying()
    {
        bedAudio.clip = audioclips[0];
        bedAudio.Play();
    }

    public void bedMonsterOutSoundPlaying()
    {
        bedAudio.clip = audioclips[1];
        bedAudio.Play();
    }
}
