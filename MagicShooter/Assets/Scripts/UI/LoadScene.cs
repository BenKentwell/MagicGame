using System;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene: MonoBehaviour
{

    public String SceneToChangeTo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeToScene()
    {
        SceneManager.LoadScene(SceneToChangeTo, LoadSceneMode.Single);

    }
}