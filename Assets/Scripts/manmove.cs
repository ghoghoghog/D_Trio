using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class manmove : MonoBehaviour
{
    public GameObject Castle;
    public float sksdleh=10;
    
    public string People_1_Name;

    public int Current_Hp=20;
    
   
    public int Attack;
  
   

    public float cooltime;
    private float curtime;
    public float speed;
    public Rigidbody2D target;
    public float sksdlehtkdtmd;
    public float dnjsfosksdleh=10;
    bool isLive = true;
    
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    private Animator anim;

    private void Start()
    {
        sksdleh = dnjsfosksdleh + sksdlehtkdtmd;
        Castle = GameObject.FindGameObjectWithTag("Castle");
        curtime = cooltime;
    }
    private void Update()
    {
        sksdleh -= Time.deltaTime;
        transform.Translate(Vector3.left * speed );
        if (Current_Hp <= 0)
        {
            Destroy(gameObject);
        }
        if(sksdleh<=0)
        {
            Current_Hp += 10;
            speed *= 2;
           
            sksdlehtkdtmd += 10;
            sksdleh = dnjsfosksdleh + sksdlehtkdtmd;
        }
    
    
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Snowball_1")
        {
            Current_Hp -= 5;
        }
        if (collision.gameObject.tag == "Snowball_2")
        {
            Current_Hp -= 20;
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
