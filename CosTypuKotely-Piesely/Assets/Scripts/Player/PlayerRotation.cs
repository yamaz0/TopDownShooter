using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class PlayerRotation
{

    public void Rotate(Transform playerTransform)
    {
        Vector3 worldMousePosition = Utils.MouseScreenToWorldPoint();

        // Vector2 direction = worldMousePosition - new Vector2(playerTransform.position.x, playerTransform.position.y);
        float angle = AngleBetweenTwoPoints(worldMousePosition, playerTransform.position);
        playerTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public float AngleBetweenTwoPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(b.y - a.y, b.x - a.x) * Mathf.Rad2Deg;
    }

}
