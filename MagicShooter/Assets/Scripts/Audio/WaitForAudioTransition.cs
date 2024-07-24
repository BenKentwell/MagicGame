
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitForAudioTransition : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private bool isEndGame = false;

    private void Start()
    {
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            if (isEndGame)
                Application.Quit();

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
