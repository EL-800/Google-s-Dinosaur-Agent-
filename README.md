# Google Dinosaur Game with Reinforcement Learning in Unity
This project involves recreating the Google Dinosaur game and developing a Machine Learning agent using Reinforcement Learning techniques. To achieve this, two training algorithms were implemented: PPO and SAC.

# PPO Algorithm
The PPO agent takes as input a set of rays that allow it to detect objects and the dinosaur's y position. In addition, 5 of these inputs are stacked to detect the speed at which it is going.

# SAC Algorithm
The SAC agent uses as input the current image captured by the game's camera. This image is processed by several convolutional layers of a ResNet network.

# Results
The SAC agent obtained better results after several tests compared to a simple convolutional network.
