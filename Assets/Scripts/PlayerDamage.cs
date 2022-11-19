using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int HP = 50;
    public bool gotIt = false;
    public void TakeDamage(int amount)
    {
        Debug.Log(HP);
        if (gotIt)
        {
            HP -= amount;
        }
        //else
        //    return;
        if (HP <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("CollisionPlayer");
        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("EnemyBullet"))
        {
            gotIt = true;
        }
    }
}
