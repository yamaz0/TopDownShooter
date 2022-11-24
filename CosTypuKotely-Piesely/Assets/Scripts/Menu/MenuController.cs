using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    [SerializeField]
    private AudioClip menuMusic;

    private void Start()
    {
        SoundManager.Instance.PlayMusic(menuMusic);
    }
}
