using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    const float SPAN = 1.0f;
    const float WAVE_SPAN = 15.0f;
    const int SPAWN_ENEMY_NUM = 10;

    public GameObject m_EnemyPrefab;
    private float m_Delta = 0.0f;
    private int m_RemainEnemy = SPAWN_ENEMY_NUM;
    private bool m_isAssult = true;
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
        if (!m_isAssult)
        {
            if (m_Delta > WAVE_SPAN)
            {
                m_Delta = 0.0f;
                m_isAssult = true;
                m_RemainEnemy = SPAWN_ENEMY_NUM;
            }
            return;
        }
        if (m_Delta > SPAN)
        {
            // 経過秒数の初期化
            m_Delta = 0.0f;
            // エネミーの生成
            GameObject enemy = Instantiate(m_EnemyPrefab) as GameObject;
            // エネミーの座標の初期化
            enemy.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            // 残りの敵の数を減らす
            m_RemainEnemy--;
            if (m_RemainEnemy <= 0)
            {
                m_isAssult = false;
            }
        }

    }
}
