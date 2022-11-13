using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
public class LocalizationControlerUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text textt;
    private IEnumerator Start()
    {
        yield return LocalizationSettings.InitializationOperation;
        textt.SetText(LocalizationSettings.SelectedLocale.ToString());
    }

    public void OnLocalizationButtonClicked(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        textt.SetText(LocalizationSettings.SelectedLocale.ToString());
    }

}
