using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightManager : Singleton<LightManager>
{
    [SerializeField]
    private bool isDay;
    [SerializeField]
    private float globalIntensity;
    [SerializeField]
    private Color globalAmbientColor;
    [SerializeField]
    private Light2D lightscr;

    public void SetLightSettings()
    {
        lightscr.intensity = globalIntensity;
        lightscr.color = globalAmbientColor;
    }

    public void Init()
    {
        SetDayLight(MapManager.Instance.Options.IsDay);

        Player.Instance.PlayerLight.AreaLightSize.OnValueChanged += Player.Instance.PlayerLight.SetAreaLightSize;
        Player.Instance.PlayerLight.FlashlightStrenght.OnValueChanged += Player.Instance.PlayerLight.SetFlashlightStrenght;
        Player.Instance.PlayerLight.FlashlightLenght.OnValueChanged += Player.Instance.PlayerLight.SetFlashlightLenght;
    }

    public void SetDayLight(bool state)
    {
        if (state == true)
            SetDay();
        else
            SetNight();
        SetLightSettings();
    }

    private void SetDay()
    {
        isDay = true;
        globalIntensity = 1;
        globalAmbientColor = Color.white;
        Player.Instance.PlayerLight.SetPlayerLightAccesories(false);
    }

    private void SetNight()
    {
        isDay = false;
        globalIntensity = 0.07f;
        globalAmbientColor = Color.red;
        Player.Instance.PlayerLight.SetPlayerLightAccesories(true);
    }
}
