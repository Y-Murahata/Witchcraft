using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaManeger : MonoBehaviour {

    GameObject gd;

	// Use this for initialization
	void Start () {
        gd = GameObject.Find("GameDirector");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //  入ってきたのが敵だったら
        if (collision.gameObject.tag == "Enemy")
        {
            //  拠点の体力を減らす
            //gd.GetComponent<GameDirector>().m_HP = gd.GetComponent<GameDirector>().m_HP - collision.gameObject.GetComponent<Enemy>().m_Attack;
            gd.GetComponent<GameDirector>().m_HP--;
        }
    }

}
