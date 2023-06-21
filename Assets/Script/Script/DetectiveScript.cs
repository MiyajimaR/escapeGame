using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiveScript : MonoBehaviour
{
    
    [SerializeField]private AdvEngineController adv;

    public void detectiveButton()
    {
        adv.JumpScenario("Detective_1");
    }
}
