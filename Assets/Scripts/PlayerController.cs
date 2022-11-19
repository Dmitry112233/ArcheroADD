using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, rn_speed, ro_speed;
    public bool walking;
    public int health = 100;
    Transform playerTrans;
    GameObject Enemy;
    Transform enemy;
    private void Start()
    {
        playerTrans = GetComponent<Transform>();                
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigid.velocity = transform.forward * rn_speed * Time.deltaTime;
        }
        else
        {
            playerRigid.velocity = transform.forward * 0;
        }    
        if (Input.GetKey(KeyCode.S))
        {
            playerRigid.velocity = -transform.forward * w_speed * Time.deltaTime;
        }
    }

    void Update()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");    
        
        if (Enemy != null && !Input.anyKey)
        {
            enemy = Enemy.transform;
            transform.LookAt(enemy.position);
            playerAnim.SetTrigger("idleAim");            
        }       
        if (Enemy == null || Input.anyKey)
        {
            playerAnim.SetBool("stop", true);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("run");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("run");
            playerAnim.SetTrigger("idle");
            walking = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("walkback");
            playerAnim.ResetTrigger("idle");
            walking = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("walkback");
            playerAnim.SetTrigger("idle");
            walking = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
            walking = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
            walking = true;
        }              
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("EnemyPotron") || collision.gameObject.tag.Equals("EnemyPotron"))
        {
            health -= 10;
        }
        if (health <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
}
