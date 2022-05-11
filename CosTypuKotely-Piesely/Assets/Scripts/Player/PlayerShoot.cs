using UnityEngine;

[System.Serializable]
public class PlayerShoot
{
    [SerializeField]
    private Weapon weapon;
    public void Shoot(Vector2 direction)
    {
        weapon.Shoot(direction);
    }
}
