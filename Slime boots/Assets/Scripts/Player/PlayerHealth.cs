using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Health;

public class PlayerHealth : Health
{
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

        else if (currentHappinessPower < 0 && entitySadnessPower == 0)
        {
            isHappy = false; isSad = true;                                                   // enemy bubble =10    =5
            entitySadnessPower = currentHappinessPower * -1; //Make the rest of the soubstraction positive  ( o -->  O) = -5 --> 5"SadPower"
            NumOfHappyPower.enabled = false;
            NumOfSadPower.enabled = true;
            NumOfSadPower.text = entitySadnessPower.ToString();
        }

        else if (entitySadnessPower > 0)
        {
            NumOfSadPower.text = entitySadnessPower.ToString();
        }
    }
}
