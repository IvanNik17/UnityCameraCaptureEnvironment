# UnityCameraCaptureEnvironment
A DSLR camera image capture environment used for approximating real life photo capturing. The project approximates how each of the main camera settings changes the output images - aperture, shutter speed, ISO, focal length, camera focus.

The repository contains an older version of the application presented in the paper [Interactive Environment for Testing SfM Image Capture Configurations](https://www.scitepress.org/Papers/2019/75667/75667.pdf)

# Requirements

- The project requires Unity 2019.3.7f1 or higher to run
- The project uses an old way of visualizing screen space effects which is now obsolute compared to the new URP rendering pipeline, but still workable.
- The project contains a number of free PBS Metallic assets from [Yughues Free Metal Materials](https://assetstore.unity.com/packages/2d/textures-materials/metals/yughues-free-metal-materials-12949), which are there for testing purposes, but are not used in the main body of the testing. So they can be ignored for working with the testing environment



# Overview

The environment consists of a first person controller, as well as a number of scripts for controlling the camera, lights and materials. All the scripts are attached to the FPS controller by default. 

For controlling the in-game camera first the view needs to be switched from walking to camera. This is done using the Tab key. Once in camera mode using the different sliders, a number of camera functions can be changed:

  - The camera zoom level
  - The camera focus
  - The aperture
  - The shutter speed
  - The ISO
Each of these effects the final brightness of the shot of the scene, as well as adding additional screen space effects like chaning focus, adding noise, introduction of blur, etc.
Right mouse click captures an image from the environment as a screenshot.

The 1 and 2 keys switch the ceiling and studio lights on and off. The mouse scroll changes the intensity of the lights.
The turntable that the object is placed on can be rotated using the E key and can be set to start position using the number 3 key.

By pressing the Escape, the environment menu is show. There the green screen can be switched on and off and its color can be changed. In the same menu the material of the captured object can be also changed to test out different image captures. This option has not been developed further.

Initial camera settings can be changed in the script Real World Cam Settings


