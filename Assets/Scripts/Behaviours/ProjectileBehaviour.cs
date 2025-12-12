using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public GameObject projectilePrefab;
    // Creates and launches a projectile from the gun muzzle
    public void Fire(Transform muzzle, WeaponDefinition def)
    {
        GameObject p = Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
        Projectile proj = p.GetComponent<Projectile>();
        proj.damage = def.damage;
        proj.Launch();
    }
}
