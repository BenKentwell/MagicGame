
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

        Destroy(this);
    }
}
