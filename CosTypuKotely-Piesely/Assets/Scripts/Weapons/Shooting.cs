using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Transform transformObject;
    [SerializeField]
    private ShootEffect shootEffect;

    public Transform TransformObject { get => transformObject; set => transformObject = value; }

    public void StartEffect()
    {
        shootEffect.StartEffect();
    }

}
