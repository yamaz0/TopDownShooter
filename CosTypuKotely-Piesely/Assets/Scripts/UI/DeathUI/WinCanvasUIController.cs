using UnityEngine;

public class WinCanvasUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCanvas;
    [SerializeField]
    private Player player;

    public void Init()
    {
        gameObject.SetActive(true);
        mainCanvas.SetActive(false);
        player.enabled = false;
    }
}
