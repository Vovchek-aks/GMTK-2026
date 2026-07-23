using System;
using UnityEngine;

public static class Extensions
{
    public static Vector2 Rotate(this Vector2 vector, float angle) => 
        new Vector2(
            vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle),
            vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle)
        );

    public static Vector3 Lerp(this Vector3 vector, Vector3 target, float progress)
    {
        progress.Validate(0, 1, nameof(progress));
        return target * progress + vector * (1 - progress);
    }
    public static float Validate(this float value, float min, float max, string name = "value")
    {
        if (value < min || value > max)
            throw new ArgumentException($"{name} can only be in [{min}, {max}], not {value}");

        return value;
    }

    public static float Limit(this float value, float min, float max) => Math.Min(Math.Max(value, min), max);
    
    public static float Lerp(this float value, float target, float progress)
    {
        progress.Validate(0, 1, nameof(progress));
        return target * progress + value * (1 - progress);
    }
}