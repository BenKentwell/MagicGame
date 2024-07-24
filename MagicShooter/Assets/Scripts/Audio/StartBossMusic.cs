
using UnityEngine;

public class StartBossMusic : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().PlayBossMusic();
    }
}
