using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMonster : MonoBehaviour
{
    public GameObject target;
    private Transform targetTransform;
    public float followSpeed = 5f;
    public Animator animator;
    private bool chaseable = true;
    private AudioSource mirrorMonsterAudio;

    void Start()
    {
        target = ObjectManager.staticPlayer;
        targetTransform = target.GetComponent<Transform>();
        animator = GetComponent<Animator>();
        mirrorMonsterAudio = GetComponent<AudioSource>();
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
        if (Mathf.Abs(horizontalDistance) > Mathf.Abs(verticalDistance))
        {
            if (horizontalDistance > 0)
            {
                animator.SetInteger("Player_direction", 2);
            }
            else
            {
                animator.SetInteger("Player_direction", 4);
            }
        }
        else
        {
            if (verticalDistance > 0)
            {
                animator.SetInteger("Player_direction", 1);
            }
            else
            {
                animator.SetInteger("Player_direction", 3);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Name =  " + other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            Destroy(target);
            animator.SetBool("Killable", true);
            chaseable = false;
        }

    }
}
