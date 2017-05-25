using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //  生成されたときのポジション
    //private Transform m_oldTrans;

    private Vector3 m_oldPos;

    //  攻撃力
    public float m_power;

    //  飛ぶ距離
    public float m_range;

    //  属性
    int attribution;

    //  自殺タイマー
    [SerializeField]
    float m_deathTime;
    float m_deathTimer;

    // Use this for initialization
    void Start()
    {
        //  現在のポジションを取得する
        m_oldPos = transform.position;

        m_deathTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //距離の絶対値を取得する
        float distance = Vector3.Distance(m_oldPos, transform.position);
        distance = fabsf(distance);

        //  一定距離飛んだら自身を破壊する
        if (distance >= m_range)
        {
            Destroy(gameObject);
        }


        //  タイマーを進める
        m_deathTimer += Time.deltaTime;

        //  タイマーが既定値を超えたら自殺する
        if (m_deathTimer >= m_deathTime)
        {
            Destroy(gameObject);
        }
    }

    //  衝突した時
    void OnCollisionEnter(Collision other)
    {

        //  衝突した相手が敵だったらHPを減らす
        if (other.gameObject.CompareTag("Enemy"))
        {
            //  自身を破壊する
            Destroy(gameObject);
            other.gameObject.GetComponent<Enemy>().m_Hp -= m_power;
        }
    }


    public float fabsf(float i)
    {
        //  絶対値を返す
        return (i >= 0) ? i : -i;
    }

    //  親の射程距離を取得する
    public void GetRange(float range)
    {
        m_range = range;
    }

    //  属性値を計算して属性を変える
    public void SetAttribution(int a,int b)
    {
        Debug.Log("右の属性"+a);
        Debug.Log("左の属性"+b);
    }

}
