using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float upForce = 200;
    private bool isDead = false;
    private Rigidbody2D rb;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));
            }
        }
    }

    private void OnCollisionEnter2D()
    {
        isDead = true;
        anim.SetTrigger("Die");
        GameController.instance.PlayerDied();
    }
}
