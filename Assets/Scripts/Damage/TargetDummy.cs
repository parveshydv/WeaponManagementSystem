using UnityEngine;
using System.Collections;

public class TargetDummy : MonoBehaviour, IDamageable
{
    public int health = 100;

    Renderer rend;
    Color originalColor;
    // Store renderer and original color for the hit flash
    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        //Debug.Log($"{gameObject.name} Health: {health}");

        StartCoroutine(DamageFlash());
        // Remove the target when health reaches zero
        if (health <= 0)
        {
            //Debug.Log($"{gameObject.name} destroyed!");
            Destroy(gameObject);
        }
    }
    // Briefly flash red to show the hit
    IEnumerator DamageFlash()
    {
        rend.material.color = Color.red;   
        yield return new WaitForSeconds(0.1f);
        rend.material.color = originalColor;
    }
}
