using Godot;

public class Sprites {
    public Sprite getJumpSprite(KinematicBody2D player) {
        return player.GetNode<Sprite>("JumpSprite");
    }

    public Sprite getRunSprite(KinematicBody2D player) {
        return player.GetNode<Sprite>("RunSprite");
    }

    public Sprite getSprite(KinematicBody2D player) {
        return player.GetNode<Sprite>("Sprite");
    }
}