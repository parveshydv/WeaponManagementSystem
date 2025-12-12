using UnityEngine;

// Handles instant-hit shooting
public class HitScanBehaviour : MonoBehaviour
{
    public LayerMask hitMask;

    public void Fire(Camera cam, WeaponDefinition def)
    {
       // Debug.Log("FIRING!");
        Vector3 direction = cam.transform.forward;
        direction = Quaternion.Euler(
            Random.Range(-def.spreadAngle, def.spreadAngle),
            Random.Range(-def.spreadAngle, def.spreadAngle),
            0
        ) * direction;

        if (Physics.Raycast(cam.transform.position, direction, out RaycastHit hit, 200f, hitMask))
        {
            IDamageable dmg = hit.collider.GetComponent<IDamageable>();
            if (dmg != null)//// If it has health, apply damage
                dmg.TakeDamage(def.damage);
        }
    }
}
