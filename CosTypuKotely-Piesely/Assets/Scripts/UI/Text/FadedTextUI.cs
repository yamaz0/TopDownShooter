using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadedTextUI : MonoBehaviour
{
    private const float MAX_ALPHA = 1f;
    private const float INVISIBILITY_VALUE = 0.01f;
    [SerializeField]
    private TMPro.TMP_Text text;
    [SerializeField]
    private float fadeIntervalTime;
    [SerializeField]
    private float alphaSubtraction;

    public void ShowText(string textToShow, float time, float subtractiveValue)
    {
        gameObject.SetActive(true);
        text.alpha = MAX_ALPHA;
        fadeIntervalTime = time;
        alphaSubtraction = subtractiveValue;
        text.SetText(textToShow);
        StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        while (text.alpha > INVISIBILITY_VALUE)
        {
            text.alpha -= alphaSubtraction;
            yield return new WaitForSeconds(fadeIntervalTime);
        }

        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
