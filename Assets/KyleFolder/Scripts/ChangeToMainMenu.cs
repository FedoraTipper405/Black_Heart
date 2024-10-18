using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToMainMenu : MonoBehaviour
{
    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 5)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
