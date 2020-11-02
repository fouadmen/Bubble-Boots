using System.Collections;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    #region Public Instances
    public GameObject mEntity;
    public GameObject DeathParticle;

    public TextMeshProUGUI NumOfHappyPower;
    public TextMeshProUGUI NumOfSadPower;
    #endregion

    #region HapAndSad System Variables
    public int entitySadnessPower;
    public int entityHappinessPower;
    [HideInInspector] public int currentHappinessPower;
    [HideInInspector] public int currentSadnessPower;
    #endregion

    #region HapAndSad States
    private bool isHappy = false;
    private bool isSad = true;
    #endregion

    //constuctor

    public Health(GameObject entity){
        mEntity = entity;
    }

    void Start()
    {
        currentSadnessPower = entitySadnessPower;
        currentHappinessPower = playerHappinessPower;
        NumOfHappyPower.enabled = false;
    }

    void Update()
    {
        HapAndSadPowerSystem();
        StartCoroutine(CheckThePlayerSadState());
    }

    void HapAndSadPowerSystem()
    {
        /*
            la method ad tga mmkhtalfa (logic kibhal bhal), donc landark 2 solutions :
            1- ataft kran tarig9a masatn tsmont hla method ad
            2- atskhdemt Polymorphism, ratjt la fonctionad ghid mais player & enemy adarsn tiri tinsn wahdot

        */
    }

    IEnumerator CheckThePlayerSadState()
    {
        if (isSad == false && isHappy == true)
        {
            yield return new WaitForSeconds(2f);
            GameObject PlayerDeath_particle_prefab = Instantiate(DeathParticle, mEntity.transform.position, Quaternion.identity);

            Destroy(PlayerDeath_particle_prefab.gameObject, 1f);
            Destroy(mEntity.gameObject);
        }
    }
}
