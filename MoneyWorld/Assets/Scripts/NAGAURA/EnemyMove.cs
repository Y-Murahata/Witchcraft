using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    // エージェント
    private NavMeshAgent m_Agent;
    // アニメーター
    private Animator m_Animator;
    // 到着したか判定用
    private bool m_isArrived;
    // 目的地リスト
    private Vector3[] m_DestinationList;
    // 次の目的地リスト
    private List<int>[] m_NextDestinationList;
    // 要素番号
    private int m_Iterator;
    // Use this for initialization
    void Start()
    {
        // 最初の要素番号
        m_Iterator = 0;
        // 目的地リストを設定
        m_DestinationList = new Vector3[20]
            {
                new Vector3(0.2f, 0.0f, 0.3f),
                new Vector3(1.8f, 0.0f, 0.3f),
                new Vector3(0.2f, 0.0f, 3.9f),
                new Vector3(4.2f, 0.0f, 0.3f),
                new Vector3(1.8f, 0.0f, 2.3f),
                new Vector3(1.8f, 0.0f, 3.9f),
                new Vector3(0.2f, 0.0f, 6.3f),
                new Vector3(6.8f, 0.0f, 0.3f),
                new Vector3(4.1f, 0.0f, 2.3f),
                new Vector3(1.8f, 0.0f, 3.4f),
                new Vector3(1.8f, 0.0f, 4.6f),
                new Vector3(1.8f, 0.0f, 6.3f),
                new Vector3(6.8f, 0.0f, 2.3f),
                new Vector3(5.5f, 0.0f, 2.3f),
                new Vector3(5.5f, 0.0f, 3.4f),
                new Vector3(4.7f, 0.0f, 4.7f),
                new Vector3(4.7f, 0.0f, 6.3f),
                new Vector3(5.5f, 0.0f, 4.6f),
                new Vector3(6.8f, 0.0f, 4.7f),
                new Vector3(6.8f, 0.0f, 6.3f)
            };
        // 次の目的地リストを設定
        m_NextDestinationList = new List<int>[20]
            {
                new List<int> { 1, 2 },
                new List<int> { 3, 4 },
                new List<int> { 5, 6 },
                new List<int> { 7, 8 },
                new List<int> { 8, 9 },
                new List<int> { 10 },
                new List<int> { 11 },
                new List<int> { 12 },
                new List<int> { 13 },
                new List<int> { 5, 14 },
                new List<int> { 11, 15 },
                new List<int> { 16 },
                new List<int> { 18 },
                new List<int> { 12, 14 },
                new List<int> { 17 },
                new List<int> { 16, 17 },
                new List<int> { 19 },
                new List<int> { 18 },
                new List<int> { 19 },
                new List<int> { 99 },
            };
        // エージェントを取得する
        m_Agent = GetComponent<NavMeshAgent>();
        // アニメーターを取得する
        m_Animator = GetComponent<Animator>();
        // 到着したかの判定用
        m_isArrived = false;
        // 目的地を設定する
        SetDestination();
        // エージェントの目的地を設定する
        if (m_Agent.pathStatus != NavMeshPathStatus.PathInvalid) { m_Agent.SetDestination(m_DestinationList[m_Iterator]); }
    }

    // Update is called once per frame
    void Update()
    {
        // 到着していたらなにもしない
        if (m_isArrived)
            return;
        // アニメーターのSpeedの値を設定する
        m_Animator.SetFloat("Speed", m_Agent.speed);
        // 目的地から現在の位置までの距離が1未満か判定する
        if (Vector3.Distance(m_DestinationList[m_Iterator], transform.position) < 0.1f)
        {
            // アニメーターのSpeedの値に0を設定する
            m_Animator.SetFloat("Speed", 0.0f);
            // 目的地を設定する
            SetDestination();
            // 次の目的地があるならエージェントの目的地を設定する
            if (m_Iterator != 99){ m_Agent.SetDestination(m_DestinationList[m_Iterator]); }
            // そうでないなら到着フラグをtrueにする
            else{ m_isArrived = true; }
        }
    }

    void SetDestination()
    {
        // 次の目的地    
        int nextDestination = Random.Range(0, m_NextDestinationList[m_Iterator].Count);
        // 要素番号を設定
        m_Iterator = m_NextDestinationList[m_Iterator][nextDestination];
    }
}
