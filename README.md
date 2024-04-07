# Wpetula's N-Body Simulator
Want to play around with n-body physics without buying Kerbal Space Program? This graphically simple N-Body simulator is for you! I made this after tinkering with Brackey's N-body simulation code, which is available on YouTube. Protect a miniature homeworld from asteroids, moons, and other celestial threats. 

# Features

* N-body physics that supports eccentric orbits, tidal forces, explosive collisions, and more
* Decent framerate for 60 bodies on mid-range integrated graphics laptops
* Easy-to-use celestial body instantiator
* An easy-to-steer, indestructible ship
* Zoomable game camera
* BOMBS YOU CAN USE TO EXPLODE THINGS
* Particle system explosions

# Controls

* Left/Right arrow keys to rotate the ship
* Up/Down arrow keys to zoom the camera in and out
* Space to fire ship engine
* B to place a bomb (you get three for each run)
* N to detonate all bombs

# Instantiating Celestial Bodies

All celestial bodies (currently just spheroids) are instantiated via a celestial body instantiator gameobject. Input your desired spheroid sizes, quantities, altitudes, and orbits into the instantiator and start the simulation. To get multiple instantiations, attach multiple instantiation scripts to the instantiator gameobject. Documentation for each parameter in the celestial body instantiator is found in the comments of the instantiator's script. 

# Credits

You may make derivatives of this project, but not for monetary gain. I reserved the rights to the graphics and code built atop Brackey's work.
