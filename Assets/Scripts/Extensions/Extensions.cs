using UnityEngine;

public static class Rigidbody2DExt
{
    // Kindly provided by someone on Reddit or Stack Overflow.
    public static void AddExplosionForce2D(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float explosionRadius, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force)
    {
        Vector2 explosionDir = rb.position - explosionPosition;
        float explosionDistance = explosionDir.magnitude;

        if (upwardsModifier == 0)
            explosionDir /= explosionDistance;
        else
        {
            explosionDir.y += upwardsModifier;
            explosionDir.Normalize();
        }

        rb.AddForce(Mathf.Lerp(0, explosionForce, (1 - explosionDistance)) * explosionDir, mode);
    }
}