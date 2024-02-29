using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HomeworkStatus : MonoBehaviour
{
    public GameObject homeworkTable;
    private HomeworkTable Hwtb;
    public Animator animator;
    private TextMeshPro textMesh;

    void Start()
    {
        Hwtb = homeworkTable.GetComponent<HomeworkTable>();
        textMesh = this.gameObject.GetComponentInChildren<TextMeshPro>();
    }

    void Update()
    {
        textMesh.text = "Homework finished " + Hwtb.finishedHomework + " out of 6";
        animator.SetFloat("HomeworkStatus", (float)Hwtb.homework);
     
    }
}
