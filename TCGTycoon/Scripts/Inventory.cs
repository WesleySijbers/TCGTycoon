using Godot;
using System;

[GlobalClass]
public partial class Inventory : Node
{
	[Export] protected PackedScene InventoryScreen;
	[Export] public PackedScene cardScene;
	[Export] public Godot.Collections.Array<CardResource> cards;

	public InventoryScreen InventoryScreenToAdd;

	bool m_isInventoryOpen = false;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void ToggleInventory()
	{
		if (m_isInventoryOpen)
		{
			HideInventory();
			m_isInventoryOpen = false;
		}
		else
		{
			DrawInventory();
			m_isInventoryOpen = true;
		}
	}

	virtual protected void DrawInventory()
	{
		InventoryScreenToAdd = InventoryScreen.Instantiate() as InventoryScreen;
		//log if inv screen is null or not
		AddChild(InventoryScreenToAdd);

		int i = 0;
		foreach (CardResource card in cards)
		{
			Card CardToSpawn = cardScene.Instantiate() as Card;
			CardToSpawn.SetCardinfo(card);
			CardToSpawn.CardIndex = i;
			InventoryScreenToAdd.InventoryGrid.AddChild(CardToSpawn);
			CardToSpawn.OnCardClicked += DisplayCardClicked;
			i++;
		}
	}

	public void refreshInventory()
	{
		InventoryScreenToAdd.QueueFree();
		DrawInventory();
	}

	virtual protected void DisplayCardClicked(Card card)
	{
		GD.Print("Card Clicked" + card.CardIndex);
	}

	private void HideInventory()
	{
		InventoryScreenToAdd.QueueFree();
	}
}

