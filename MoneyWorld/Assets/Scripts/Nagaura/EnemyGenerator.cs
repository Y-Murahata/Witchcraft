using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject m_EnemyPrefab;
    float span = 1.0f;
    private float m_Delta = 0.0f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // 経過秒数を数える
        m_Delta += Time.deltaTime;
        // 経過秒数が生成スパンより多いか判定
        if (m_Delta > span)
        {
            // 経過秒数の初期化
            m_Delta = 0.0f;
            // エネミーの生成
            GameObject enemy = Instantiate(m_EnemyPrefab) as GameObject;
            // エネミーの座標の初期化
            enemy.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }

    }
}
