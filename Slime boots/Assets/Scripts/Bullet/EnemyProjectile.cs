using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    #region Private Instances
    PlayerHealth playerHealth;
    Transform Player;
    Vector2 target;
    #endregion

    #region Bubble Variables
    public int bubbleSpeed;
    public int bubbleDamage;
    #endregion

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();

        Player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(Player.position.x, Player.position.y);
    }

    void Update()
    {
        ShootAtPlayer();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CheckThePlayerState();
            Destroy(gameObject);
        }
    }

    void CheckThePlayerState()
    {
        if (playerHealth.currentHappinessPower >= 0)
        {
            playerHealth.currentHappinessPower -= bubbleDamage;
        }


        if (playerHealth.currentSadnesPower > 0)
        {
            playerHealth.currentSadnesPower += bubbleDamage;
        }
    }

    void ShootAtPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, bubbleSpeed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }
}
