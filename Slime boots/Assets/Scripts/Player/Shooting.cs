using UnityEngine;
using System.Collections;
using System;

public class Shooting : MonoBehaviour
{
    #region Public Instances
    public PlayerProjectile playerBubble;
    public PlayerHealth playerHealth;
    public GameObject BulletPrefab;
    public Animator PlayerAnimator;
    #endregion

    #region AttackSytemFloats
    public int bulletSpeed;

    public float maxTimeDuration = 5f;
    private float maxPower;
    private float minPower = 1f;
    float currentTimeDuration = 0f;
    #endregion

    #region AttackSystemBools
    [HideInInspector] public bool isCharging = false;
    [HideInInspector] public bool isReleased = true;
    #endregion

    void Update()
    {
        maxPower = playerHealth.currentHappinessPower;

        if (Input.GetMouseButtonDown(0) && isReleased)
        {
            isCharging = true;
            isReleased = false;
        }

        else if (isCharging && (Input.GetMouseButtonUp(0) || currentTimeDuration >= maxTimeDuration))
        {
            PowerInterpolation();
            //print("Bubble Power:" + bulletPower);
            DecreaseTheHapPower();

            PlayerAnimator.SetTrigger("Shoot");

            Shoot(bulletSpeed);

            Reset();
        }

        if (isCharging)
        {
            currentTimeDuration += Time.deltaTime;
        }

        if (!isReleased)
        {
            isReleased = Input.GetMouseButtonUp(0);
        }
    }
    
    void Shoot(float shotSpeed)
    {

        GameObject SpawnedBullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        SpawnedBullet.GetComponent<PlayerProjectile>().bubbleSpeed = shotSpeed;

        Destroy(SpawnedBullet, 4f);
    }

    void Reset()
    {
        currentTimeDuration = 0f;
        isCharging = false;
    }

    void DecreaseTheHapPower()
    {
        playerHealth.currentHappinessPower -= playerBubble.bubbleDamage / 2;
    }

    void PowerInterpolation()
    {
        // SmouthStep calculation
        float timeDuration = currentTimeDuration / maxTimeDuration;
        timeDuration = timeDuration * timeDuration * (3f - 2f * timeDuration);
        float bulletPower = Mathf.Lerp(minPower, maxPower - 1, timeDuration);

        playerBubble.bubbleDamage = (int)bulletPower;
    }
}
