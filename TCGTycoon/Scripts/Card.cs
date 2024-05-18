using Godot;
using System;

public partial class Card : TextureRect
{
	[Export] public CardResource m_card;

	public Inventory m_inventory;

	public int CardIndex;

	[Signal]
	public delegate void OnCardClickedEventHandler(Card card);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	public void SetCardinfo(CardResource card)
	{
		//log card name
		m_card = card;

		TextureRect cardimage = GetNode<TextureRect>("CardArt");
		cardimage.Texture = card.Image;

		RichTextLabel cardname = GetNode<RichTextLabel>("CardName");
		cardname.Text = card.Name;

		RichTextLabel CardText = GetNode<RichTextLabel>("CardText");
		CardText.Text = card.Description;	


	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _GuiInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton mbe && mbe.ButtonIndex == MouseButton.Left && mbe.Pressed)
		{
			EmitSignal(SignalName.OnCardClicked, this);
		}
	}
}
