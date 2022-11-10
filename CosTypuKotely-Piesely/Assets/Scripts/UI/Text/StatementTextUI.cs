using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatementTextUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text statementText;

    public void ShowText()
    {
        gameObject.SetActive(true);
        statementText.alpha = 1f;

        StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        while (statementText.alpha > 0.1f)
        {
            statementText.alpha -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }

        gameObject.SetActive(false);
    }
}
