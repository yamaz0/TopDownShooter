using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatementTextUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text statementText;

    public void ShowText(string text)
    {
        gameObject.SetActive(true);
        statementText.SetText(text);
        statementText.alpha = 1f;

        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        while (statementText.alpha > 0.1f)
        {
            statementText.alpha -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }

        gameObject.SetActive(false);
    }
}
