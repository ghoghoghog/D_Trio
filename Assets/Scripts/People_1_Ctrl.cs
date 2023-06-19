using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class People_1_Ctrl : MonoBehaviour
{
    public GameObject Castle;
    public GameObject Snowball1;
    public GameObject Pos;
    public string People_1_Name;

    public int Current_Hp;
    public int Hp;

    public int Attack;
    public Text _Name;
    public Text _Hp;

    public float cooltime;
    private float curtime;
    public float speed;
    public Rigidbody2D target;

    bool isLive = true;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    private Animator anim;

    private void Start()
    {
        _Name.text = People_1_Name;
        Castle = GameObject.FindGameObjectWithTag("Castle");
        curtime = cooltime;
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _Hp.text = Current_Hp + " / " + Hp;

        if(Current_Hp <= 0)
        {
            Pos.GetComponent<Soldiers_1_Attack>().People_1 = null;

            _Name.gameObject.SetActive(false);
            _Hp.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        
        _Name.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.35f, 0));
        _Hp.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0));
    }

    void FixedUpdate()
    {
        if (!isLive)
            return;

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        if (!isLive)
            return;

        spriter.flipX = target.position.x < rigid.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Snowball_1")
        {
            Current_Hp -= Snowball1.GetComponent<Snowball_1>().Attack;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Castle")
        {
            speed = 0;
            if (curtime <= 0)
            {
                anim.SetBool("isAttack", true);
                collision.gameObject.GetComponent<Castle_Ctrl>().Current_Hp -= Attack;
                curtime = cooltime;
            }
            curtime -= Time.deltaTime;
        }
    }
}
