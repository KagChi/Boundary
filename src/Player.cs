using Godot;

public class Player : KinematicBody2D
{
	public Movement movement;
	Sprite sprite;
    Sprite runSprite;
    Sprite jumpSprite;

    AnimationPlayer animationPlayer;

    Camera2D Camera;

    AudioStreamPlayer2D jumpPlayer;


    public override void _Ready()
	{
        movement = new Movement();
        Camera = GetNode<Camera2D>("Camera2D");
        
	}

    public override void _Input(InputEvent @event) 
    {
        if (@event is InputEventMouseButton) {
            if (@event.IsPressed()) {
                if (@event.IsActionPressed("wheel_down") && Camera.Zoom.x < 1.5f) {
                    Camera.Zoom = new Vector2(Camera.Zoom.x + 0.1f, Camera.Zoom.y + 0.1f);
                } else if (@event.IsActionPressed("wheel_up") && Camera.Zoom.x > 0.5f) {
                    Camera.Zoom = new Vector2(Camera.Zoom.x - 0.1f, Camera.Zoom.y - 0.1f); 
                }
            }
        }
    }

	public override void _PhysicsProcess(float delta) 
    {
		movement.move(delta, this);
	}
}
