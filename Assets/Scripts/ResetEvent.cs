using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetEvent : MonoBehaviour
{
    private Scene _scene;
    void Start()
    {
        this._scene = SceneManager.GetActiveScene();
    }
    private void Update() {
        handleReset();
    }

    private void handleReset()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(_scene.name);
        }
    }
}
