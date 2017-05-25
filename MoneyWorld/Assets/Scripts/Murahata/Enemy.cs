using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{

    //  敵のHP
    [SerializeField]
    public float m_Hp;

    //  敵の破壊エフェクト
    GameObject m_expEffect;

    //  敵の攻撃力
    [SerializeField]
    public float m_Attack;

    bool deathFlag = false;




    // Use this for initialization
    void Start()
    {
        m_expEffect = transform.FindChild("Explosion").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
       //transform.DOLocalMove(new Vector3(5, transform.position.y, transform.position.z), 5.0f);

        //  体力が０をしたまわったら自機を破壊
        if (m_Hp <= 0 && deathFlag == false)
        {
            deathFlag = true;

            //  敵の見た目を消す
            transform.FindChild("Body").gameObject.SetActive(false);

            //  死亡時のエフェクトを出す
            m_expEffect.GetComponent<ParticleSystem>().Play();

            //  三秒後に自機が消える
            Destroy(gameObject, 2.0f);

        }

    }
}
