<p align="center">
  <img src="Assets/Eksplorimba_Logo.png" alt="Eksplorimba logo" width="420">
</p>

<h1 align="center">Eksplorimba</h1>

<p align="center">
  <strong>Explore. Learn. Conserve.</strong><br>
  A marker-based Augmented Reality experience that brings Indonesia's biodiversity to life.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Unity-6000.0.39f1-000000?logo=unity" alt="Unity 6000.0.39f1">
  <img src="https://img.shields.io/badge/C%23-Gameplay-512BD4?logo=csharp" alt="C#">
  <img src="https://img.shields.io/badge/Vuforia-11.2.4-5C2D91" alt="Vuforia 11.2.4">
  <img src="https://img.shields.io/badge/Platform-Android-3DDC84?logo=android&logoColor=white" alt="Android">
</p>

## About the Project

**Eksplorimba** is a gamified educational application that introduces Indonesia's native flora and fauna through Augmented Reality (AR). Players scan collectible image-marker cards to reveal 3D species, read conservation information, and test their knowledge through interactive quizzes.

The project combines exploration, education, and gamification to make biodiversity learning more engaging for students, educators, families, and nature enthusiasts.

## How It Works

1. **Collect** a physical Eksplorimba flora or fauna card.
2. **Scan** the card using the device camera.
3. **Explore** the 3D model and learn about the species, habitat, behavior, and conservation status.
4. **Take a quiz** to test what you learned.

## Key Features

- **Marker-based AR scanning** powered by Vuforia Engine
- **Interactive 3D species models** displayed on collectible cards
- **Educational species profiles** covering characteristics, habitat, behavior, threats, and conservation
- **Species-based quizzes** with multiple-choice questions and result feedback
- **Touch interaction** for rotating and scaling 3D models
- **Guided onboarding** with an automatic tutorial carousel
- **Audio feedback** for species, background music, and interface interactions
- **Mobile-friendly interface** designed for an accessible learning experience

## Featured Species

The current prototype includes Indonesian flora and fauna such as:

- Badak Jawa
- Beruang Madu
- Anjing Ajag
- Rusa Bawean
- Komodo
- Burung Cenderawasih
- Kantong Semar
- Acung Jangkung
- Padma Raksasa
- Bunga Bangkai Raksasa

## Tech Stack

| Technology | Purpose |
| --- | --- |
| Unity `6000.0.39f1` | Game engine and application development |
| C# | Gameplay, UI, quiz, and AR interaction logic |
| Vuforia Engine `11.2.4` | Image-target detection and marker-based AR |
| ARCore / XR Plug-in Management | Android AR support |
| Universal Render Pipeline | Mobile rendering pipeline |
| TextMesh Pro | User-interface text rendering |
| Blender | 3D asset creation and preparation |

## Getting Started

### Prerequisites

- [Unity Hub](https://unity.com/download)
- Unity Editor `6000.0.39f1` with **Android Build Support**
- An ARCore-compatible Android device with a camera
- [Vuforia Engine `11.2.4`](https://developer.vuforia.com/downloads/sdk)
- A Vuforia developer license key

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/MSATRIAD/Explorimba-AR-Project-APP.git
   cd Explorimba-AR-Project-APP
   ```

2. Download `com.ptc.vuforia.engine-11.2.4.tgz` from the Vuforia Developer Portal and place it inside the `Packages/` directory.

   > The package archive is not stored in this repository because `.tgz` files are excluded by `.gitignore`. The project manifest expects the package at `Packages/com.ptc.vuforia.engine-11.2.4.tgz`.

3. Open the project through Unity Hub using Unity `6000.0.39f1`.

4. Open the main scene:

   ```text
   Assets/Scenes/SampleScene.unity
   ```

5. In **Vuforia Engine Configuration**, add your own Vuforia license key if one is not already configured locally.

6. Switch the build target to **Android**, connect a compatible physical device, then build and run the project.

### Testing the AR Markers

Marker reference images are available in:

```text
Assets/Editor/Vuforia/ImageTargetTextures/exploreRimba/
```

Print a marker or display it on a separate screen, open the scanning feature, and point the device camera at the marker. Testing on a physical device is recommended because the main experience depends on camera-based image tracking.

## Project Structure

```text
Explorimba-AR-Project-APP/
├── Assets/
│   ├── Editor/Vuforia/ImageTargetTextures/  # Marker reference images
│   ├── Resources/                           # UI, audio, and configuration assets
│   ├── Scenes/                              # Main Unity scene
│   ├── StreamingAssets/Vuforia/             # Vuforia target database
│   ├── script/                              # Gameplay and interface scripts
│   └── *.fbx                                # 3D species models
├── Packages/                                # Unity package configuration
└── ProjectSettings/                         # Unity project settings
```

## Project Status

Eksplorimba is an academic prototype. The current project includes marker tracking, 3D model presentation, species information, model interaction, tutorial and navigation panels, quiz content, and audio feedback. The collection and EXP progression described in the game design are areas for further development.

## Team

Developed by **Group 5B**:

- Muhammad Nefrit Mahardika
- Gerald Christopher Andreas
- Rafa Agustant
- Muhamad Rumi Rifai
- Muhammad Satria Dharma
- Rio Irawan

## License

This repository does not currently include an open-source license. Please contact the project maintainers before reusing the source code or project assets.
