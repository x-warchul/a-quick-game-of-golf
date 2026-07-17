# A Quick Game of Golf

A Unity first-person golf game featuring three holes, low-poly aesthetics, and a charge-based shooting mechanic. Navigate courses from the ball's perspective, aim using a directional arrow, and complete each hole in as few strokes as possible.

---

## Overview

`A Quick Game of Golf` is a minimalist golf simulator built with Unity. The player views the course from behind the golf ball, controls the camera freely, charges shots with the spacebar, and progresses through three distinct holes. The game tracks strokes per hole and loads the next level automatically upon reaching the flagpole.

---

## Features

- First-person golf gameplay from the ball's perspective
- Charge-based shot power system with visual feedback
- Freely controllable camera with mouse look
- Stroke counter that persists across holes
- Three low-poly holes using Unity primitive objects
- Automatic level progression on hole completion
- Persistent background music across scenes
- WebGL and Windows standalone builds

---

## Gameplay

**Controls**

| Action | Input |
|--------|-------|
| Move Camera | W / A / S / D |
| Look Around | Mouse movement |
| Charge Shot | Hold Spacebar |
| Release Shot | Release Spacebar |

**Objective**

Complete each hole by getting the ball into the flagpole in the fewest strokes possible. The directional arrow grows in length and scale as you charge your shot, indicating the power of your swing.

**Levels**

- Level 1 - Opening hole
- Level 2 - Intermediate course
- Level 3 - Final hole (returns to main menu after completion)

---

## Technologies Used

- **Engine**: Unity
- **Language**: C#
- **Physics**: Unity's built-in Rigidbody system
- **Audio**: Unity AudioSource components
- **Build Targets**: Windows (.exe), WebGL

---

## Demo

Play on itch.io: *[https://wyoyoman.itch.io/aquickgameofgolf]*

---


## Script Overview

| Script | Purpose |
|--------|---------|
| `Camera.cs` | First-person camera movement and mouse look with Y-axis clamping |
| `Golfball.cs` | Core golf mechanics: shot charging, force application, collision detection, and level loading |
| `Arrow.cs` | Directional arrow positioning and rotation based on shot vector |
| `ScoreManager.cs` | Static stroke counter that persists and updates UI across scenes |
| `MainMenu.cs` | Scene navigation and application quit functionality |
| `Music.cs` | Singleton pattern for persistent background music across level loads |

---

## What I Learned

- First-person camera control with mouse look and movement relative to camera orientation
- Charged shot mechanics using input hold duration
- Directional arrow positioning and rotation using vector math (`Mathf.Atan2`)
- Static managers for cross-scene data persistence
- Rigidbody velocity thresholds for stopping conditions
- Scene management for level progression
- Singleton pattern for persistent audio sources
- Collision detection with tags for hole completion logic
- Maintaining clean state flags (`ableToShoot`, `keyHeld`) for input handling

---


## Author

Xander Warchulski

