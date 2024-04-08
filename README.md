# Wpetula's N-Body Simulator
![S1](https://i.imgur.com/Uehcev4.png)

Want to experiment with n-body physics without buying Kerbal Space Program? Try my N-Body Simulator! I made this after tinkering with Brackey's N-body simulation code, which is available on YouTube. Protect a miniature homeworld from asteroids, moons, and yourself. 

# Features
![S2](https://i.imgur.com/MGRMn0n.png)

* N-body physics that supports eccentric orbits, tidal forces, explosive collisions, and more
* Atmospheric drag and reentry effects for debris
* Decent framerate for 60 bodies on mid-range integrated graphics laptops
* Easy-to-use celestial body instantiator
* An easy-to-steer, indestructible ship
* Zoomable game camera
* BOMBS YOU CAN USE TO EXPLODE THINGS
* Particle system explosions

# Controls
![S3](https://i.imgur.com/KYUPgEu.png)

* Left/Right arrow keys to rotate the ship
* Up/Down arrow keys to zoom the camera in and out
* Space to fire ship engine
* B to place a bomb (you get three for each run)
* N to detonate all bombs

# Instantiating Celestial Bodies
![S4](https://i.imgur.com/6yWClkn.png)

All celestial bodies (currently just spheroids) are instantiated via a celestial body instantiator gameobject. Input your desired spheroid sizes, quantities, altitudes, and orbits into the instantiator and start the simulation. To get multiple instantiations, attach multiple instantiation scripts to the instantiator gameobject. Documentation for each parameter in the celestial body instantiator is found in the comments of the instantiator script. 

# Credits
![S5](https://i.imgur.com/a7iySJ8.png)

You may make derivatives of this project, but you cannot profit from my work. I reserved the rights to the graphics and code built atop Brackey's demo.
