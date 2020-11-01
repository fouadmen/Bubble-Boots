using System.Collections;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    #region Public Instances
    public GameObject Enemy;
    public GameObject En_DeathParticle;

    public TextMeshProUGUI NumOfHappyPower;
    public TextMeshProUGUI NumOfSadPower;
    #endregion

    #region HapAndSad System Variables
    public int enemySadnesPower;
    [HideInInspector] public int currentHappinessPower;
    [HideInInspector] public int currentSadnesPower;
    #endregion

    #region HapAndSad States
    private bool isHappy = false;
    private bool isSad = true;
    #endregion

    void Start()
    {
        currentSadnesPower = enemySadnesPower;
        NumOfHappyPower.enabled = false;
    }

    void Update()
    {
        HapAndSadPowerSystem();
        StartCoroutine(CheckThePlayerSadState());
    }

    void HapAndSadPowerSystem()
    {
        if (currentSadnesPower > 0)
        {
            NumOfSadPower.text = currentSadnesPower.ToString();
        }

        else if (currentSadnesPower == 0)
        {
            NumOfHappyPower.enabled = true;
            NumOfSadPower.enabled = false;

        }

        else if (currentSadnesPower < 0 && currentHappinessPower == 0)
        {
            isHappy = true; isSad = false;
            currentHappinessPower = currentSadnesPower * -1;
            NumOfHappyPower.enabled = true;
            NumOfSadPower.enabled = false;
            NumOfHappyPower.text = currentHappinessPower.ToString();
        }

        else if (currentHappinessPower > 0)
        {
            NumOfHappyPower.text = currentHappinessPower.ToString();
        }
    }

    IEnumerator CheckThePlayerSadState()
    {
        if (isSad == false && isHappy == true)
        {
            yield return new WaitForSeconds(2f);
            GameObject PlayerDeath_particle_prefab = Instantiate(En_DeathParticle, Enemy.transform.position, Quaternion.identity);

            Destroy(PlayerDeath_particle_prefab.gameObject, 1f);
            Destroy(Enemy.gameObject);
        }
    }
}
