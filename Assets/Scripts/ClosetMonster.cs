using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetMonster : MonoBehaviour
{
    public GameObject target;
    private Transform targetTransform;
    public float followSpeed = 5f;
    public Animator animator;
    private bool chaseable = true;
    private AudioSource closetMonsterAudio;
    private Collider2D closetMonsterCollider;

    public AudioClip killingAudioClip;

    void Start()
    {
        target = ObjectManager.staticPlayer;
        targetTransform = target.GetComponent<Transform>();
        animator = GetComponent<Animator>();
        closetMonsterAudio = GetComponent<AudioSource>();
        closetMonsterCollider = GetComponent<Collider2D>();
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

        float horizontalDistance = target.transform.position.x - transform.position.x;
        float verticalDistance = target.transform.position.y - transform.position.y;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            closetMonsterCollider.enabled = false;
            Vector3 killPosition = new Vector3(target.transform.position.x, target.transform.position.y +2, target.transform.position.z);
            transform.position = killPosition;
            Destroy(target);
            animator.SetBool("Killable", true);
            chaseable = false;
        }

    }

    public void killingSoundPlaing()
    {
        closetMonsterAudio.clip = killingAudioClip;
        closetMonsterAudio.Play();
    }
}
