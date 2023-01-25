![](/img/mainmenu.png)

This prototype, called Delivery, consists of carrying the souls of fallen heroes to their destiny, so that they can be at peace. 

If you want to see a gameplay video, watch it here: https://www.youtube.com/watch?v=vjoZtKMVdJE

### Sprites

The sprites used (background, cloud, surrounding clouds) were all created using Krita and then saving them as images.

### Camera set-up

Using cinemachine I made it so that the camera follows and looks at the player.

### Main Menu scene set-up

#### Sky background

![](/img/skybackground.png)

For the background, a canvas with an image children object was used. The canvas has its render mode set to Screen Space - Camera, so that the background fits perfectly to the camera without worrying about offsets nor scales. For this to take effect, though, in the image we had to set its rect transform to stretch everything and the paddings to 0.

### Tutorial scene set-up

#### Sky background

Same as before.

#### Level limits

![](/img/levellimits.png)

As we can see, I added the parallax effect to the clouds surrounding the level. Both the foreground and the background are the same image, and are also just canvases and images for each limit. However, a script was developed, which consisted on modifying the X offset of the texture of the image by (speed * Time.time), speed being a value determined by the designer (0.005 for the back limits, and 0.015 for the foreground ones). The order of the layers for the foreground and the background are different.

To make them actual limits, various colliders were created around the edges, and they were tagged as "Limits". We will see how this plays a role later on.

#### Player

![](/img/player.png)

The player is a gameobject with has a 2D dynamic rigidbody, a collider, a customized controller script, and its children a gameobject which has a sprite renderer, and a script that manages the different animations.

The character controller script manages the movement of the cloud. That is, to only move the cloud to the mouse's position if the cloud is being clicked on. We also play an animation here which gives feedback to the player that he cloud has been clicked on and can be moved.

The animation script simply has a reference to the different sprites of the animation (win, game over, idle), and changes the sprite of the cloud to the corresponding one based on events.

#### Souls

![](/img/souls.png)

Our fallen heroes. They are just a circle that has a 2D dynamic rigidbody with a custom 2D physics material which controls the friction and the bounciness they have, and they have two scripts: one that clamps the maximum and minimum velocity the object can get, and one that controls its behaviour.

What I mean by controlling its behaviour is the following: the souls will have no gravity until the cloud touches them, and different events will be called if the soul is either saved, or destroyed. If the soul touches the gate, it is saved - if it goes off-limits, it is destroyed.

#### Gate

![](/img/gate.png)

Where our souls meet their destiny. Where they are delivered for their freedom. Where they get their peace. A gate is a gameobject that has a collider and a static rigidbody. A children of this gameobject has the text, that informs the player on how many souls are needed to win the level. 

#### Obstacles

![](/img/obstacle.png)

A square sprite renderer with a collider.

### Event Manager

The big boy in charge of events. It is the one that specifies how many score is needed in order to win, score being the amount of souls saved. It triggers the _game over_ event when there are more souls to be saved than those that exist on the map, and triggers the _win_ event when you have saved enough souls. Whenever a soul is saved, the gate text is updated through an event. 

The _game over_ event changes the sprite of the cloud and after a delay, reloads the level. The _win_ event, in the order hand, changes the sprite of the cloud and after a delay, returns you to the main menu. 

In close relation with the Game Manager.

### Game Manager

Manages the state of the game - whether when in the main menu or in a level.

### UI Manager

The one in charge of showing up the title, click to start message, or the credits in the main menu, and the one in charge to show the tutorial banner in the level. The messages themselves are just items inside a canvas (an image or a text). This guy right here manages the animations of these items through tweens, and checks whether the player can click the screen or not in order to start playing the game.
