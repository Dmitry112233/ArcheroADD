using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] public float speed = 30f;
    Transform enemy;
    GameObject Enemy;
    Vector3 target;

    private void Start()
    {      
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
    private void Update()
    {        
        if (Enemy != null)
        {
            enemy = Enemy.transform;
            target = new Vector3(enemy.position.x, enemy.position.y, enemy.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);            
        }        
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            Destroy(gameObject,1);
        }        
    }
    void OnCollisionEnter(Collision collision)
    {        
        Destroy(gameObject);        
    }    
}
