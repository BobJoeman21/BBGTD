using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{


    public TMP_Text grudgesCounter;
    private bool grudgesChanged;
    private int GrudgesGoal = 0;
    private int currentGrudges = 0;


    public void UpdateGrudges(int TotalGrudges)
    {
        GrudgesGoal = TotalGrudges;
        grudgesChanged = true;

    }

    void FixedUpdate()
    {
        if (grudgesChanged)
        {
            if (currentGrudges < GrudgesGoal)
            {
                currentGrudges += 1;
                grudgesCounter.text = currentGrudges.ToString();
            }else if(currentGrudges > GrudgesGoal)
            {
                currentGrudges -= 1;
                grudgesCounter.text = currentGrudges.ToString();
            }
            else
            {
                grudgesChanged = false;
            }
        }
    }
}
