using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	[Export] public float Speed = 300.0f;

	[Export] public float Damping = 50f;
	

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Damping);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Damping);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
