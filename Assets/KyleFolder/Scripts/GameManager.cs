using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private DeathCountSO _deaths;
    [SerializeField]
    private GameObject _deadPrisoner;

    void Start()
    {
        if (_deaths.NumOfDeathes == 1)
        {
            Instantiate(_deadPrisoner, transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            _deaths.NumOfDeathes++;
            SceneManager.LoadScene("BlackHeartTestScene");
        }
    }
}
