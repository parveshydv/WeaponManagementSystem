using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon System/Weapon Definition")]
// ScriptableObject that stores all stats and settings for a weapon
public class WeaponDefinition : ScriptableObject
{
    public string weaponName = "New Weapon";

    public enum FireMode { Single, Auto }  // firing type
    public FireMode fireMode = FireMode.Single;

    public int damage = 20;
    public float fireRate = 5f; // shots per second

    public int magazineSize = 30;
    public int maxReserveAmmo = 120;

    public float reloadTime = 1.2f;  // time to reload

    public bool isHitscan = true;    // true = instant bullets
    public float spreadAngle = 2f;

    public float verticalRecoil = 2f;
    public float horizontalRecoil = 1f;
    
    
}
