using UnityEngine;

public static class VectorExtensions
{
    public static float SqrDistanceTo(this Vector3 position, Vector3 other)
    {
        return position.DirectionTo(other).sqrMagnitude;
    }

    public static float SqrDistanceTo(this Vector3 position, Transform other)
    {
        return position.DirectionTo(other).sqrMagnitude;
    }

    public static Vector3 DirectionTo(this Vector3 position, Vector3 other)
    {
        return other - position;
    }

    public static Vector3 DirectionTo(this Vector3 position, Transform other)
    {
        return other.position - position;
    }

    public static float Angle(this Vector3 position, Vector3 other)
    {
        Vector3 direction = position.DirectionTo(other);

        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    public static float Angle(this Vector3 position, Transform other)
    {
        Vector3 direction = position.DirectionTo(other);

        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    public static bool WithinDistanceOf(this Vector3 position, Vector3 target, float distance)
    {
        return position.SqrDistanceTo(target) < Mathf.Pow(distance, 2);
    }
}
