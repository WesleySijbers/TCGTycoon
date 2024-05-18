using Godot;
using System;

public partial class ChestInventory : Inventory
{
	public Chest Chest;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	protected override void DrawInventory()
	{
		GD.Print("Chest Inventory Drawn");
		InventoryScreenToAdd = InventoryScreen.Instantiate() as InventoryScreen;
		//log if inv screen is null or not
		AddChild(InventoryScreenToAdd);

		int i = 0;
		foreach (CardResource card in cards)
		{
			Card CardToSpawn = cardScene.Instantiate() as Card;
			CardToSpawn.SetCardinfo(card);
			CardToSpawn.m_inventory = this;
			CardToSpawn.CardIndex = i;
			InventoryScreenToAdd.InventoryGrid.AddChild(CardToSpawn);
			CardToSpawn.OnCardClicked += DisplayCardClicked;
			i++;
		}

		i=0;
		foreach (CardResource card in Chest.Player.inventory.cards)
		{
			Card CardToSpawn = cardScene.Instantiate() as Card;
			CardToSpawn.SetCardinfo(card);
			CardToSpawn.m_inventory = Chest.Player.inventory;
			CardToSpawn.CardIndex = i;
			// cast to ChestInventoryScreen
			(InventoryScreenToAdd as ChestInventoryScreen).PlayerInventoryGrid.AddChild(CardToSpawn);
			CardToSpawn.OnCardClicked += DisplayCardClicked;
			i++;
		}


	}

	protected override void DisplayCardClicked(Card card)
	{

		if(card.m_inventory == this)
		{
			GD.Print("Card moved to player inventory");
			Chest.Player.inventory.cards.Add(card.m_card);
			cards.RemoveAt(card.CardIndex);

		}
		else
		{
			GD.Print("Card moved to chest inventory");
			cards.Add(card.m_card);
			Chest.Player.inventory.cards.RemoveAt(card.CardIndex);
		}


		refreshInventory();

	}
}
