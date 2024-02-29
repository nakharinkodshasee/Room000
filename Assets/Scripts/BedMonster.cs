using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedMonster : MonoBehaviour
{
    public GameObject target;
    private Transform targetTransform;
    public float followSpeed = 5f;
    public Animator animator;
    private bool chaseable = true;
    private AudioSource bedMonsterAudio;
    private Collider2D bedMonsterCollider;

    public AudioClip killingAudioClip;

    void Start()
    {
        target = ObjectManager.staticPlayer;
        targetTransform = target.GetComponent<Transform>();
        animator = GetComponent<Animator>();
        bedMonsterAudio = GetComponent<AudioSource>();
        bedMonsterCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (chaseable == true && target != null)
        {
            chase();
        }
    }

    void chase()
    {
        Vector3 direction = (targetTransform.position - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * followSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            bedMonsterCollider.enabled = false;
            transform.position = target.transform.position;
            Destroy(target);
            animator.SetBool("Killable", true);
            chaseable = false;
        }

    }

    public void KillingSoundPlaying()
    {
        bedMonsterAudio.clip = killingAudioClip;
        bedMonsterAudio.Play();
    }
}
