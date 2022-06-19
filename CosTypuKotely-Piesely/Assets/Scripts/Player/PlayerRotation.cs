using UnityEngine;
using UnityEngine.InputSystem;

static public class Rotation
{
    static public void Rotate(Transform transform)
    {
        Vector3 worldMousePosition = Utils.MouseScreenToWorldPoint();
        float angle = AngleBetweenTwoPoints(worldMousePosition, transform.position);

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    static public void QuaternionSlerp(Transform objectTransform, Transform targetTransform, float time)
    {
        Vector3 direction = targetTransform.position - objectTransform.position;
        var targetRotation = Quaternion.LookRotation(direction);

        objectTransform.rotation = Quaternion.Slerp(objectTransform.rotation, targetRotation, time);
    }

    static public float AngleBetweenTwoPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(b.y - a.y, b.x - a.x) * Mathf.Rad2Deg;
    }

}
