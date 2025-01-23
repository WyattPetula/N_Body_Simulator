using UnityEngine;

public static class Rigidbody2DExt
{
    // Modified from someone's code on Reddit or Stack Overflow.
    public static void AddExplosionForce2D(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float explosionRadius, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force)
    {
        Vector2 explosionDir = rb.position - explosionPosition;
        float explosionDistance = explosionDir.magnitude;

        // Ensure the explosion only affects objects within the radius
        if (explosionDistance > explosionRadius)
            return;

        // Normalize the direction and apply upwardsModifier if specified
        if (upwardsModifier == 0)
        {
            explosionDir /= explosionDistance;
        }
        else
        {
            explosionDir.y += upwardsModifier;
            explosionDir.Normalize();
        }

        // Scale the force based on the distance from the explosion center
        float distanceFactor = 1 - (explosionDistance / explosionRadius);
        float force = explosionForce * distanceFactor;

        // Apply the force
        rb.AddForce(force * explosionDir, mode);
    }
}