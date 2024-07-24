
using UnityEngine;

public class CrystalEncounterTrigger : MonoBehaviour
{
    public CrystalBase crystalToActivate;
    private bool hasActivated;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.GetComponent<Character>() && !hasActivated)
        {
            crystalToActivate.SetActivation();
            hasActivated = true;
        }
    }
}
