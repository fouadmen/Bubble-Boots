using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    #region PublicInstances
    public Transform Player;
    public GameObject Bullet;
    #endregion

    #region Movement And AI Floats
    private float sightRadius;
    public float speed;
    public float stoopingDistance;
    public float retreatDistance;
    #endregion

    #region Shoot Cooldown Variables
    public float startTimeBetwShots;
    private float timeBtwShots;
    public int bulletSpeed;
    #endregion

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBetwShots;
    }

    void Update()
    {
        EnemyAiSystem();
    }

    void EnemyAiSystem()
    {
        if (Player != null)
        {
            sightRadius = Vector2.Distance(transform.position, Player.position);

            if (sightRadius > stoopingDistance)
            {
                FollowPlayer();
            }
            else if (sightRadius < stoopingDistance && sightRadius > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (sightRadius < retreatDistance)
            {
                Retreate();
            }

            ShootsClooldown();
        }
    }

    void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
    }

    void Retreate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, -speed * Time.deltaTime);

    }

    void Shoot()
    {
        Instantiate(Bullet, transform.position, Quaternion.identity);
    }

    void ShootsClooldown()
    {
        if (timeBtwShots <= 0)
        {
            Shoot();
            timeBtwShots = startTimeBetwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

}
