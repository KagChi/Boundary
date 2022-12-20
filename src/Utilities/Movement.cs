using System;
using Godot;

public class Movement {
    public Vector2 direction;
    public float movementSpeed = 200;
    public float gravity = 100;
    public float maxFallSpeed = 1000;
    public float minFallSpeed = 5;
    public float jumpForce = 1000;
    float Jump = 0;

    public void move(float delta, KinematicBody2D player) {
        var sprites = new Sprites();
        var animationPlayer = player.GetNode<AnimationPlayer>("AnimationPlayer");
        var jumpPlayer = player.GetNode<AudioStreamPlayer2D>("JumpPlayer");
        var walkPlayer = player.GetNode<AudioStreamPlayer2D>("WalkPlayer");

        direction.y += gravity;
        if (direction.y > maxFallSpeed) {
            direction.y = maxFallSpeed;
        }

        if (player.IsOnFloor()) {
            direction.y = minFallSpeed;
        }

        direction.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        direction.x *= movementSpeed;

        if (player.IsOnFloor() && Jump != 0) Jump = 0;

        if (Input.IsActionJustPressed("move_jump") && Jump < 2) {
            direction.y =- jumpForce;
            Jump += 1;
            jumpPlayer.Play();
        }

        if (direction.x > 0) {
            sprites.getSprite(player).FlipH = false;
            sprites.getRunSprite(player).FlipH = false;
            sprites.getJumpSprite(player).FlipH = false;
            if (player.IsOnFloor() && !walkPlayer.Playing) walkPlayer.Play();
        } else if (direction.x < 0) {
            sprites.getSprite(player).FlipH = true;
            sprites.getRunSprite(player).FlipH = true;
            sprites.getJumpSprite(player).FlipH = true;
            if (player.IsOnFloor() && !walkPlayer.Playing) walkPlayer.Play();
        }

        if (player.IsOnFloor() && direction.x == 0) {
            if (!sprites.getSprite(player).Visible) sprites.getSprite(player).Show();
            sprites.getRunSprite(player).Hide();
            sprites.getJumpSprite(player).Hide();
            animationPlayer.Play("idle");
        } else if (player.IsOnFloor() && direction.x != 0) {
            animationPlayer.Play("run");
            if (!sprites.getRunSprite(player).Visible) sprites.getRunSprite(player).Show();
            sprites.getSprite(player).Hide();
            sprites.getJumpSprite(player).Hide();
            if (sprites.getSprite(player).Visible) sprites.getSprite(player).Hide();
        } else if (!player.IsOnFloor()) {
            if (sprites.getSprite(player).Visible) sprites.getSprite(player).Hide();
            if (sprites.getRunSprite(player).Visible) sprites.getRunSprite(player).Hide();
            sprites.getJumpSprite(player).Show();
            animationPlayer.Play("jump");
        }

        direction = player.MoveAndSlide(direction, Vector2.Up);
    }
}