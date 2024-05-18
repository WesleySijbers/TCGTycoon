using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	[Export] public float Speed = 300.0f;

	[Export] public float Damping = 50f;

	public Inventory inventory;
	
	bool inventoryOpen = false;

	AnimatedSprite2D sprites;

	public override void _Ready()
	{
		inventory = GetNode<Inventory>("Inventory");
		sprites = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("OpenInventory"))
		{
			inventory.ToggleInventory();
		}
	}

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

			if(direction.Y  < 0)
			{
				//sprites.Animation = "up";
			}
			else if(direction.Y > 0)
			{
				sprites.Play("down");
			}
			else if(direction.X < 0)
			{
				//sprites.Animation = "left";
			}
			else if(direction.X > 0)
			{
				//sprites.Animation = "right";
			}
		}
		else
		{
			sprites.Animation = "idle";
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Damping);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Damping);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
