
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().StopBackground();
    }
}
