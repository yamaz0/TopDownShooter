using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathUIController : MonoBehaviour
{
    [SerializeField]
    private ValueUI timeUI;
    [SerializeField]
    private GameObject mainCanvas;
    public void Init(float time)
    {
        gameObject.SetActive(true);
        mainCanvas.SetActive(false);
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
