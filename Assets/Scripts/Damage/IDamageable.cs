using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//// Interface for anything in the game that can take damage
public interface IDamageable
{
    void TakeDamage(int amount);
}
