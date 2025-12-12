using UnityEngine;
// Pickup object that gives the player a weapon when they walk into it

public class WeaponPickup : MonoBehaviour
{
    public WeaponDefinition weaponData;

    private void OnTriggerEnter(Collider other)
    {
        WeaponController wc = other.GetComponent<WeaponController>();
        if (wc != null)
        {
            wc.ShowPickupMessage(this);
        }
    }
    // Hide the pickup message when the player walks away
    private void OnTriggerExit(Collider other)
    {
        WeaponController wc = other.GetComponent<WeaponController>();
        if (wc != null)
        {
            wc.HidePickupMessage(this);
        }
    }
}
