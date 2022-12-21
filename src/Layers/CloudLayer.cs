using Godot;
using System;

public class CloudLayer : ParallaxLayer
{
    public override void _Process(float delta)
    {
        this.MotionOffset = new Vector2(this.MotionOffset.x - 15 * delta, this.MotionOffset.y);
    }
}
