using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUIController : MonoBehaviour
{
    [SerializeField]
    private ValueUI timeUI;

    public void Init(float time)
    {
        gameObject.SetActive(true);
        timeUI.SetValue(time);
    }

    public void ResetButtonClicked()
    {

    }

    public void ExitButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
