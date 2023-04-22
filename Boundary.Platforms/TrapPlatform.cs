using Godot;
using System;

public class TrapPlatform : KinematicBody2D
{

	public void _on_top_checker_body_entered(Node body)
	{
		if (body is MainPlayer)
		{
			Hide();
			SetCollisionLayerBit(1, false);
			SetCollisionMaskBit(0, false);
		}
	}
}
