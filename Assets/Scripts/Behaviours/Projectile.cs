using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 30f;//defalut projectile speed
    public int damage = 20;//default damage applied to object

    public void Launch()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, 3f);
    }
    // Runs automatically when the projectile collides with something
    void OnCollisionEnter(Collision collision)
    {
        IDamageable dmg = collision.collider.GetComponent<IDamageable>();
        if (dmg != null)
            dmg.TakeDamage(damage);

        Disable();
    }
    // Disables the projectile instead of destroying it 
    void Disable()
    {
        gameObject.SetActive(false);
    }
}
