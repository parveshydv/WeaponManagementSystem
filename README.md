# Weapon Management System (Unity)

A modular Weapon Management System built in Unity for a first-person shooter (FPS) environment.  
This project focuses on core weapon interactions such as firing, swapping, picking up, and dropping weapons, with an emphasis on clean structure and extensibility.

---

## Overview

This system demonstrates how common FPS weapon mechanics can be implemented in a reusable and beginner-friendly way.  
The project is not a full game; instead, it provides a technical system that can be integrated into other Unity projects.

The player starts with a single weapon and can pick up additional weapons from the environment. Weapons can be swapped using the mouse scroll wheel and dropped back into the world.

---

## Features

- Weapon firing using left mouse button
- Weapon swapping using mouse scroll wheel
- Weapon pickup using the **E** key
- Weapon dropping using the **G** key
- UI feedback for current weapon and pickup prompts
- Simple recoil applied to the camera
- Hitscan shooting using raycasting
- Modular weapon data using ScriptableObjects

---

## Controls

| Action | Input |
|------|------|
| Fire weapon | Left Click |
| Swap weapon | Mouse Scroll Wheel |
| Pick up weapon | E |
| Drop weapon | G |

---

## Demo Scene

The demo scene includes:
- A first-person player controller
- One default weapon equipped at start
- A pistol pickup represented by a black cube
- Simple cube targets for testing weapon firing
- UI elements displaying weapon name and pickup prompts

The demo showcases:
- Shooting and recoil
- Picking up a new weapon
- Swapping between weapons
- Dropping and re-picking weapons

---

## System Components

- **WeaponController**  
  Handles firing, swapping, pickups, drops, and UI updates.

- **WeaponDefinition (ScriptableObject)**  
  Stores weapon data such as damage, fire rate, recoil, and firing type.

- **HitScanBehaviour**  
  Implements instant raycast-based weapon firing.

- **SimpleRecoilModel**  
  Applies camera movement to simulate recoil.

- **WeaponPickup**  
  Allows weapons to be picked up from the world.

- **LegacyInputProvider**  
  Centralizes all player input handling.

---

## Extending the System

New weapons can be added without modifying core logic:

1. Create a new **WeaponDefinition** asset.
2. Configure weapon stats (damage, fire rate, recoil).
3. Add the weapon to the player’s weapon list or place it in the scene as a pickup.
4. The existing system automatically supports firing, swapping, and dropping.

Possible extensions include:
- Multiple fire modes
- Ammo UI
- Sound effects and animations
- Projectile-based weapons
- Advanced recoil models

---

## Notes

- The project uses simple prefabs (cube and sphere) to keep the focus on system design.
- TextMeshPro is used for UI text.
- Designed for educational and technical demonstration purposes.

---

## Author

**Parvesh Yadav**

---

## License

This project is intended for educational use.
