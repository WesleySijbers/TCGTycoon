using Godot;
using System;

public partial class Chest : Sprite2D
{
	[Export] PackedScene InventoryScreen;
	[Export] public PackedScene cardScene;
	[Export] public Card[] cards;

	[Export] Node2D Player;

	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Godot.Vector2 playerPos = Player.Position;
		float Distance = playerPos.DistanceTo(Position);	
		if(Distance <= 25 && Input.IsActionJustPressed("Interact"))
		{
			GD.Print("Interacted with chest");
			Spawninventory();
		}
	}

	private void Spawninventory()
	{
		ChestInventory SceneToSpawn = InventoryScreen.Instantiate() as ChestInventory;
		SceneToSpawn.chest = this;
		Player.AddChild(SceneToSpawn);
	}
}
