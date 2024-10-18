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

    private void Start()
    {
        if (_deaths.NumOfDeathes >= 1)
        {
            Instantiate(_deadPrisoner, transform.position, Quaternion.identity);
        }
    }
    public void ChangeScene()
    {
        _deaths.NumOfDeathes++;
        if(_deaths.NumOfDeathes == 1)
        {
            SceneManager.LoadScene("BlackHeartNormalScene");
        }
        else if(_deaths.NumOfDeathes == 2)
        {
            SceneManager.LoadScene("BlackHeartHalfInsanity");
        }
        else if(_deaths.NumOfDeathes >= 3)
        {
            SceneManager.LoadScene("BlackHeartFullInsanity");
        }
    }
}
