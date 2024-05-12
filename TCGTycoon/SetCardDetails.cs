using Godot;
using System;

public partial class SetCardDetails : TextureRect
{
	[Export] Card card;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	public void SetCardinfo(Card card)
	{
		TextureRect cardimage =GetNode<TextureRect>("CardArt");
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
}
