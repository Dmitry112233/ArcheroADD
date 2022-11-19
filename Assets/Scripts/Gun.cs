using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage;
    public float speed = 10f;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float rayRange;
    
    public GameObject arrow;    
    public GameObject Enemy;    
        
    void Update()    
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (Enemy != null && timeBtwShots <= 0 && !Input.anyKey)
        {
            Shot();
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }        
    }
    private void Shot()
    {
        GameObject arrHolder = Instantiate(arrow, transform.position, transform.rotation);
        arrHolder.transform.Rotate(Vector3.right * 90);
        
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.forward, out hit, rayRange))
        //{
        //    if (hit.collider.tag.Equals("Enemy"))
        //    {                
        //        var enemy = hit.transform.GetComponent<EnemyDamage>();                
        //        if (enemy != null)
        //        {
        //            enemy.TakeDamage(damage);
        //            //Debug.Log("Damage");
        //        }               
        //    }
        //}
    }
}
