
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeath : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Start()
    {
        
    }

    public void StartCinematic()
    {
        Camera.main.enabled = false;

        animator.Play("BossDeathTemp");
    }

    public void LoadOutro()
    {
        SceneManager.LoadScene("DOutrotext");
    }
}
