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
        if (_deaths.NumOfDeathes == 1)
        {
            Instantiate(_deadPrisoner, transform.position, Quaternion.identity);
        }
    }
    public void ChangeScene()
    {
        _deaths.NumOfDeathes++;
        SceneManager.LoadScene("BlackHeartNormalScene");
        switch (_deaths.NumOfDeathes)
        {
            case 1:
                Debug.Log("Scene1");
                break;
            case 2:
                Debug.Log("Scene1");
                break;
            case 3:
                Debug.Log("Scene2");
                break;
            case 4:
                Debug.Log("Scene3");
                break;
        }
    }
}
