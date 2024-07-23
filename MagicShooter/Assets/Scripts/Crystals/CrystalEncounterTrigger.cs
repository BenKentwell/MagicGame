using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrystalEncounterTrigger : MonoBehaviour
{
    public CrystalBase crystalToActivate; 

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.GetComponent<Character>())
        {
            crystalToActivate.SetActivation();
        }
    }
}
