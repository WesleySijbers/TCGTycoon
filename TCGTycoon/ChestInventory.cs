using Godot;
using System;

public partial class ChestInventory : AspectRatioContainer
{
	public Chest chest;
	GridContainer grid;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		grid = GetNode<GridContainer>("ItemGrid");
		GenCardlist();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void GenCardlist()
	{
		foreach (Card card in chest.cards)
		{
			GD.Print("Card Name: " + card.Name);
			SetCardDetails SceneToSpawn = chest.cardScene.Instantiate() as SetCardDetails;
			SceneToSpawn.SetCardinfo(card);
			grid.AddChild(SceneToSpawn);
			SceneToSpawn.Scale = new Vector2(0.01f, 0.01f);
			
		}
	}
}
