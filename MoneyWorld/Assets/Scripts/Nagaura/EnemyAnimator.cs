using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    // アニメーター
    private Animator m_Animator;

    // Use this for initialization
    void Start ()
    {
        // アニメーターを取得する
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        // アニメーターのSpeedの値を設定する
        m_Animator.SetFloat("Speed", 1.0f);
    }
}
