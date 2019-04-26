using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEnemyController : MonoBehaviour
{
    public float speed;
    public Transform player;
    private Transform target;
    private bool mRight = false;
    public Animator animator;
    public Transform groundDetection;
    private float timeBShots;
    public float startTimeBShots;

    public GameObject projectile;
    

    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundInfo.collider == false)
        {
            if (mRight == false)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                mRight = true;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                mRight = false;
            }
        }
        if (target != null && timeBShots <= 0)
        {
            speed = 0;
            animator.SetTrigger("Shoot");
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBShots = startTimeBShots;
        }
        else
        {
            timeBShots -= Time.deltaTime;

        }
    }
   


   
}
