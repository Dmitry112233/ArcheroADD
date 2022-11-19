using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] GameObject plaer;
    [SerializeField] float speed;
    [SerializeField] float endPosMinX;
    [SerializeField] float endPosMaxX;
    [SerializeField] float endPosMinZ;
    [SerializeField] float endPosMaxZ;
    [SerializeField] float timeTimer;

    Rigidbody rb;
    Vector3 endPos;
    float timer;
    Animator animator;
    bool isDeath = false;
    float timeForDeath = 1.2f;

    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }

    float progres;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = timeTimer;

        endPos = RondomazerEndPos();
    }

    void Update()
    {
        transform.LookAt(endPos);

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            //StartJump();

            transform.position = Vector3.Lerp(transform.position, endPos, progres);

            progres += speed;

            if (progres >= 1)
            {
                timer = timeTimer;

                progres = 0;

                endPos = RondomazerEndPos();
            }
        }

        if (health <= 0 & !isDeath)
        {
            CharacterAnimator.SetTrigger("Die");
            isDeath = true;
        }

        if (isDeath)
        {
            timeForDeath -= Time.deltaTime;

            if (timeForDeath <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void StartJump()
    {
        endPos = new Vector3 (Random.Range(endPosMinX, endPosMaxX), transform.position.y ,Random.Range(endPosMinZ,endPosMaxZ));

        transform.position = Vector3.Lerp(transform.position, endPos, progres);

        progres += speed;

        timer = timeTimer;
    }
    
    Vector3 RondomazerEndPos()
    {
        endPos = new Vector3(Random.Range(endPosMinX, endPosMaxX), transform.position.y, Random.Range(endPosMinZ, endPosMaxZ));

        return endPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("PlayerPotron"))
        {
            health -= 10;
        }
    }
}
