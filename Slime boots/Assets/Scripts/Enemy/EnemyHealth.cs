using System.Collections;
using UnityEngine;
using TMPro;
using Health;

public class EnemyHealth : Health
{
    void HapAndSadPowerSystem()
    {
        if (entitySadnessPower > 0)
        {
            NumOfSadPower.text = entitySadnessPower.ToString();
        }

        else if (entitySadnessPower == 0)
        {
            NumOfHappyPower.enabled = true;
            NumOfSadPower.enabled = false;

        }

        else if (entitySadnessPower < 0 && currentHappinessPower == 0)
        {
            isHappy = true; isSad = false;
            currentHappinessPower = entitySadnessPower * -1;
            NumOfHappyPower.enabled = true;
            NumOfSadPower.enabled = false;
            NumOfHappyPower.text = currentHappinessPower.ToString();
        }

        else if (currentHappinessPower > 0)
        {
            NumOfHappyPower.text = currentHappinessPower.ToString();
        }
    }

}
