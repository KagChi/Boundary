using Godot;

public class Main : Node2D {
    public override void _Ready()
    {
        KinematicBody2D Player = GetNode<Player>("Player");
        AudioStreamPlayer2D mainPlayer = GetNode<AudioStreamPlayer2D>("mainPlayer");
        mainPlayer.Play();
    }
}