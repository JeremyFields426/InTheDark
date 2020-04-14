using UnityEngine;
using UnityEngine.InputSystem;

public static class TransformExtensions
{
    public static float SqrDistanceTo(this Transform transform, Transform other)
    {
        return transform.DirectionTo(other).sqrMagnitude;
    }

    public static float SqrDistanceTo(this Transform transform, Vector3 other)
    {
        return transform.DirectionTo(other).sqrMagnitude;
    }

    public static Vector3 DirectionTo(this Transform transform, Transform other)
    {
        return other.position - transform.position;
    }

    public static Vector3 DirectionTo(this Transform transform, Vector3 other)
    {
        return other - transform.position;
    }

    public static float Angle(this Transform transform, Transform other)
    {
        Vector3 direction = transform.DirectionTo(other);

        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    public static float Angle(this Transform transform, Vector3 other)
    {
        Vector3 direction = transform.DirectionTo(other);

        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    public static bool WithinDistanceOf(this Transform transform, Vector3 target, float distance)
    {
        return transform.SqrDistanceTo(target) < Mathf.Pow(distance, 2);
    }

    public static bool WithinDistanceOf(this Transform transform, Transform target, float distance)
    {
        return transform.SqrDistanceTo(target) < Mathf.Pow(distance, 2);
    }

    public static bool InLineOfSightOf(this Transform transform, Transform target, float distance)
    {
        if (target == null) { return false; }

        RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.DirectionTo(target), distance);
        if (raycast && raycast.collider.transform == target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void SetPositionOnMouse(this Transform transform, Camera camera, Vector3 offset)
    {
        Vector3 newPos = camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        newPos += offset;
        newPos.z = 0f;

        transform.position = newPos;
    }
}
