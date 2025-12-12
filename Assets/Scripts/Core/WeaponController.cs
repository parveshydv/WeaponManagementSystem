using UnityEngine;
using TMPro;
using System.Collections.Generic;

// Main script that handles firing, swapping, reloading, picking up, and dropping weapons
public class WeaponController : MonoBehaviour
{
    public WeaponDefinition[] weapons;
    public Camera cam;
    public Transform muzzle;

    public IInputProvider input;

    public HitScanBehaviour hitscan;
    public ProjectileBehaviour projectile;
    public SimpleRecoilModel recoil;

    public TMP_Text weaponNameText; 
    public GameObject dropPrefab;

    public TMP_Text pickupText;    
    WeaponPickup nearbyPickup;

    int currentIndex = 0;
    WeaponDefinition current;

    float nextFireTime = 0;
    int magAmmo;
    int reserveAmmo;

    void Start()
    {
        // Setup input and equip the first weapon
        input = GetComponent<IInputProvider>();
        EquipWeapon(0);
    }

    void Update()
    {
        // Check fire, reload, swap, drop, and pickup actions
        HandleFire();
        HandleReload();
        HandleSwap();

        if (Input.GetKeyDown(KeyCode.G))
            DropCurrentWeapon();

        if (Input.GetKeyDown(KeyCode.E) && nearbyPickup != null)
        {
            PickupWeapon(nearbyPickup.weaponData);
            Destroy(nearbyPickup.gameObject);
            pickupText.gameObject.SetActive(false);
            nearbyPickup = null;
        }
    }

    void EquipWeapon(int index)
    {
        // Switch to a weapon by index and update ammo + UI
        currentIndex = index;
        current = weapons[index];

        magAmmo = current.magazineSize;
        reserveAmmo = current.maxReserveAmmo;

        if (weaponNameText != null)
            weaponNameText.text = current.weaponName;

        Debug.Log("Equipped weapon: " + current.weaponName);
    }

    void HandleFire()
    {
        // Handles firing logic and rate of fire timing
        if (Time.time < nextFireTime) return;

        bool canFire =
            (current.fireMode == WeaponDefinition.FireMode.Auto && input.FireHeld()) ||
            (current.fireMode == WeaponDefinition.FireMode.Single && input.FirePressed());

        if (!canFire) return;
        if (magAmmo <= 0) return;

        magAmmo--;
        nextFireTime = Time.time + 1f / current.fireRate;

        if (current.isHitscan)
            hitscan.Fire(cam, current);
        else
            projectile.Fire(muzzle, current);

        recoil.ApplyRecoil(cam, current);
    }

    void HandleReload()
    {
        // Refills the magazine using available reserve ammo
        if (!input.ReloadPressed()) return;
        if (magAmmo == current.magazineSize) return;

        int needed = current.magazineSize - magAmmo;
        int amount = Mathf.Min(needed, reserveAmmo);

        reserveAmmo -= amount;
        magAmmo += amount;
    }

    void HandleSwap()
    {
        // Switches weapons using the scroll wheel
        int delta = input.ScrollDelta();
        if (delta == 0) return;

        int newIndex = (currentIndex + delta + weapons.Length) % weapons.Length;
        EquipWeapon(newIndex);
    }

    public void PickupWeapon(WeaponDefinition newWeapon)
    {
        // Adds a new weapon to the list and equips it
        List<WeaponDefinition> list = new List<WeaponDefinition>(weapons);

        if (!list.Contains(newWeapon))
            list.Add(newWeapon);

        weapons = list.ToArray();

        Debug.Log("Picked up weapon: " + newWeapon.weaponName);

        EquipWeapon(list.Count - 1);
    }

    void DropCurrentWeapon()
    {
        // Drops the current weapon into the world
        if (current == null)
            return;

        GameObject dropped = Instantiate(dropPrefab, muzzle.position, muzzle.rotation);

        WeaponPickup pickup = dropped.GetComponent<WeaponPickup>();
        pickup.weaponData = current;

        List<WeaponDefinition> list = new List<WeaponDefinition>(weapons);
        list.RemoveAt(currentIndex);
        weapons = list.ToArray();

        if (weapons.Length > 0)
        {
            currentIndex = 0;
            EquipWeapon(currentIndex);
        }
        else
        {
            current = null;
            weaponNameText.text = "";
            Debug.Log("No weapon equipped!");
        }
    }

    public void ShowPickupMessage(WeaponPickup wp)
    {
        // Shows the "Press E to pick up" message
        nearbyPickup = wp;
        pickupText.text = "Press E to pick up " + wp.weaponData.weaponName;
        pickupText.gameObject.SetActive(true);
    }

    public void HidePickupMessage(WeaponPickup wp)
    {
        // Hides the pickup message when player walks away
        if (nearbyPickup == wp)
        {
            nearbyPickup = null;
            pickupText.gameObject.SetActive(false);
        }
    }
}
