## 🎥 TPCamera
**TPCamera** is a simple third person camera system for unity project.

<img src="./_Readme/tpcamera_preview.gif" alt="TPCamera Preview"/>

## 🔗 Download
download unity package: 👉 [TPCamera.unitypackage](https://github.com/vianagus/Unity-TPCamera/raw/main/_Unity%20Package/TPCamera.unitypackage) 👈

## ⚙ Installation
1. Download and import the unity package into unity project.
2. Put TPCamera.cs on **_camera object_**.
3. Assign **_object to follow_** into `Follow` attribute.
4. Assign **_object to look at_** into `Look At` attribute.

<img src="./_Readme/tpcamera_installation_demo.gif" alt="TPCamera Installation Demo"/>

## 🧩 Attribute
Adjust the following attributes to affect the camera movement.
| Attribute                 | Type      | Description                                                   |
| ---                       | ---       | ---                                                           |
| **Target**                |           |                                                               |
| `Follow`                  | Transform | Target to follow.                                             |
| `Look At`                 | Transform | Targer to look at.                                            |
| **Look At**               |           |                                                               |
| `Look At Offset`          | float     | `Look At`'s offset position.                                  |
| **Position**              |           |                                                               |
| `Max Distance`            | float     | Maximum distance to target.                                   |
| `Smooth Damp`             | float     | Smooth the movement, set valut to `0` will disable smooth.    |
| **Rotation**              |           |                                                               |
| `Yaw Sensitivity`         | float     | Affect yaw soeed.                                             |
| `Pitch Sensitivity`       | float     | Affect pitch speed.                                           |
| `Min Pitch`               | float     | Minimum pitch rotataion                                       |
| `Max Pitch`               | float     | Maximum pitch rotation                                        |
| **Obstacle Detection**    |           |                                                               |
| `Avoid Obstacle`          | bool      | Enable or disable obstacle detection.                         |
| `Obstacle Layer`          | LayerMask | Specifies layers as obstacle.                                 |
| `Distance to Obstacle`    | float     | Distance to obstacle hit point.                               |
| `Height to Obstacle`      | float     | Distance to obstacle in `y axis`.                             |
