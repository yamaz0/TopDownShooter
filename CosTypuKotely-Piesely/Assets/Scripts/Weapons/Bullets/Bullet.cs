using System.Collections;
using UnityEngine;

abstract public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damage = 1f;
    [SerializeField]
    private float timeToDeactivate = 2;

    public float Damage { get => damage; set => damage = value; }
    public float TimeToDeactivate { get => timeToDeactivate; set => timeToDeactivate = value; }

    abstract public void Init(Vector2 direction);

    public IEnumerator DestroyCouritune()
    {
        yield return new WaitForSeconds(TimeToDeactivate);
        gameObject.SetActive(false);
    }
}