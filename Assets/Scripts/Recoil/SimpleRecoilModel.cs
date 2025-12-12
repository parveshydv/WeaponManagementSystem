using UnityEngine;
// Adds a small camera kick when the player fires a weapon
public class SimpleRecoilModel : MonoBehaviour
{
    public void ApplyRecoil(Camera cam, WeaponDefinition def)
    {
        cam.transform.localEulerAngles += new Vector3(-def.verticalRecoil, Random.Range(-def.horizontalRecoil, def.horizontalRecoil), 0);
    }
}
