using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    #region Public Instances
    public GameObject Player;
    public GameObject Pl_DeathParticle;

    public TextMeshProUGUI NumOfHappyPower;
    public TextMeshProUGUI NumOfSadPower;
    #endregion

    #region HapAndSad System Variables
    public int playerHappinessPower;
    [HideInInspector] public int currentHappinessPower;
    [HideInInspector] public int currentSadnesPower;
    #endregion

    #region HapAndSad States
    private bool isHappy = true;
    private bool isSad = false;
    #endregion

    void Start()
    {
        currentHappinessPower = playerHappinessPower;
        NumOfSadPower.enabled = false;
    }

    void Update()
    {
        HapAndSadPowerSystem();
        StartCoroutine(CheckThePlayerSadState());
    }

    void HapAndSadPowerSystem()
    {
        if (currentHappinessPower > 0)
        {
            NumOfHappyPower.text = currentHappinessPower.ToString();
        }

        else if (currentHappinessPower == 0)
        {
            NumOfHappyPower.enabled = false;
            NumOfSadPower.enabled = true;

        }

        else if (currentHappinessPower < 0 && currentSadnesPower == 0)
        {
            isHappy = false; isSad = true;                                                   // enemy bubble =10    =5
            currentSadnesPower = currentHappinessPower * -1; //Make the rest of the soubstraction positive  ( o -->  O) = -5 --> 5"SadPower"
            NumOfHappyPower.enabled = false;
            NumOfSadPower.enabled = true;
            NumOfSadPower.text = currentSadnesPower.ToString();
        }

        else if (currentSadnesPower > 0)
        {
            NumOfSadPower.text = currentSadnesPower.ToString();
        }
    }

    IEnumerator CheckThePlayerSadState()
    {
        if (isSad == true && isHappy == false )
        {
            yield return new WaitForSeconds(2f);
            GameObject PlayerDeath_particle_prefab = Instantiate(Pl_DeathParticle, Player.transform.position, Quaternion.identity);

            Destroy(PlayerDeath_particle_prefab.gameObject, 1f);
            Destroy(Player.gameObject);
        }
    }
}
