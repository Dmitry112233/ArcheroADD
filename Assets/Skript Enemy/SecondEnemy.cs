using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondEnemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float timeTimer;
    [SerializeField] GameObject player;
    [SerializeField] GameObject projectile;
    [SerializeField] float speedShot;

    float timer;
    Vector3 endPos;
    float progres;
    bool endPosIsFound = false;
    Animator animator;
    bool isDeath = false;
    float timeForDeath = 1.2f;

    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }

    void Start()
    {
        timer = timeTimer;
        projectile.SetActive(false);
    }

    
    void Update()
    {
        transform.LookAt(player.transform.position);

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            projectile.SetActive(true);

            if (!endPosIsFound)
            {
                endPos = FindingTheStartingPosition();
                endPosIsFound = true;
            }

            projectile.transform.position = Vector3.Lerp(transform.position, endPos, progres);
            progres += speedShot;

            if (progres >= 1)
            {
                projectile.SetActive(false);
                projectile.transform.position = transform.position;
                progres = 0;
                timer = timeTimer;
                endPosIsFound = false;
            }
        }

        if (health<= 0 & !isDeath)
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

    void Shoting()
    {
        projectile.SetActive(true);

        projectile.transform.position = Vector3.Lerp(transform.position, endPos, progres);
        progres += speedShot;

        if (progres >=1)
        {
            projectile.SetActive(false);
            projectile.transform.position = transform.position;
            progres = 0;
        }
    }

    Vector3 FindingTheStartingPosition()
    {
        endPos = player.transform.position;
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
