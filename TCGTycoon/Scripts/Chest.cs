using Godot;
using System;

public partial class Chest : Sprite2D
{

	[Export] public PlayerMovement Player;

	ChestInventory inventory;

	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		inventory = GetNode<ChestInventory>("Inventory");
		inventory.Chest = this;
		// printinventory chst value
		GD.Print(inventory.Chest.Player.inventory.cards.Count);

	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("Interact"))
		{
			Godot.Vector2 playerPos = Player.Position;
			float Distance = playerPos.DistanceTo(Position);
			if (Distance <= 40)	inventory.ToggleInventory();
		}
	}



}
