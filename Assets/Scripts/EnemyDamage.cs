using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int HP = 50;
    public bool gotIt = false;
    //public void TakeDamage(int amount)
    //{
    //    Debug.Log(HP);
    //    if (gotIt) 
    //    {
    //        HP -= amount; 
    //    }
    //    //else
    //    //    return;
    //    if (HP <= 0)
    //    {
    //        Death();
    //    }
    //}
    public void Death()
    {       
            Destroy(gameObject);        
    }
    //public void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("CollisionEnemy");
    //    gotIt = true;
    //}
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("PlayerPotron"))
        {
            HP -= 10;
        }
        if (HP <= 0)
        {
            Death();
        }
    }
}
