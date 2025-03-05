# VR Avionics Simulations


# Project Overview
* Each functionality has it's own MonoBehaviour component following the Composition Programming Pattern.
* Inter-Script communication is done via public Inspector references for maximum code optimisation.
* Scene Hierarchy is clean (without unnecesary, unused objects) and objects are named properly.
* Maximum things are done via scripts and thus very limited editor/inspector dependency.

Thus, the above ensures butter-smooth, error-free scalibility and maintainability.


# Creative/Innovative Solutions
* Hand and Controller tracked Control UI (this keeps UI accessable even when camera view changes)
* Modern aesthetic UI
* UI tooltips for each mechanism in the scene
* Use of joints to limit movement for switches and levers
* UI Audio feedback


# Design Decisions, Implementation Details, and Challenges Faced

## 1. Detecting Lever/Switch Fully Moved to On/Off Position

- **Challenge:** Unable to use `Update()` to track rotation due to performance concerns.
- **Solution:** Used triggers to detect when the lever or switch reached the desired position.

## 2. On/Off Triggers Implementation

- **Challenge:** Rigidbody with hinge handles was not working correctly.
- **Initial Consideration:** Using on/off colliders as trigger detectors, but this introduced redundancy and dispersed logic.
- **Final Solution:** Created a child GameObject of the handle with a Rigidbody, allowing a singular and cleaner implementation.

## 3. Handling VR Movement During Camera View Switch

- **Challenge:** The user can move around in VR, which affects switching between different camera views.
- **Solution:** Assuming a seated experience, locomotion is turned off, and camera switching is toggled via button press.

## 4. Landing Gear Animation Playback

- **Challenge:** Playing animation by name is not scalable, as animation names can change.
- **Solution:** Assigned the animation clip in the inspector and used `.name` to play it dynamically from the Animator.

## 5. Making AudioManager a Singleton

- **Reasoning:** While the project currently has a limited number of audio clips, ensuring scalability from the start is a best practice.
- **Implementation:** Converted `AudioManager` into a Singleton to manage audio playback efficiently.

## 6. TrackedPoseDriver Preventing Rotation Adjustments

- **Issue:** TrackedPoseDriver on the camera was preventing manual setting of rotation to Third-Person View (TPV).
- **Todo:** Need further testing to find a way out.

## 7. Keeping Control-Tracked UI Always in View

- **Problem:** UI elements were not always visible when the user changed their view.
- **Solution:** Implemented a control-tracked control UI that remains in view regardless of camera view changes.
