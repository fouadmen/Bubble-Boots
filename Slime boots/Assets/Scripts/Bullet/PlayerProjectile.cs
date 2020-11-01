using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    #region Private Instances
    EnemyHealth enemyHealth;
    Vector2 Target;
    #endregion

    #region Public Instances
    public Animator BulletAnimator;
    public GameObject bulletParticle;
    public GameObject enemDeathParticle;
    #endregion

    #region Bubble Variables
    public float bubbleSpeed;
    public int bubbleDamage;
    #endregion

    void Start()
    {
        enemyHealth = FindObjectOfType<EnemyHealth>();

        Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Update()
    {
        GoTowardsCursor();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            CheckTheEnemyState();

            GameObject Bullet_particle_prefab = Instantiate(bulletParticle, other.collider.transform.position, Quaternion.identity);
            Destroy(Bullet_particle_prefab, 1f);

            Destroy(gameObject);
        }
    }

    void GoTowardsCursor()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target, bubbleSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, Target) < 0.2f)
        {
            BulletAnimator.SetTrigger("Destroyed");
            Destroy(gameObject);
        }
    }

    void CheckTheEnemyState()
    {
        if (enemyHealth.currentSadnesPower >= 0)
        {
            enemyHealth.currentSadnesPower -= bubbleDamage;
        }

        if (enemyHealth.currentHappinessPower > 0)
        {
            enemyHealth.currentHappinessPower += bubbleDamage;
        }
    }
}
