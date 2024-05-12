using Godot;
using System;

public partial class Card : Resource
{
	[Export] public string Name = "Card";
	[Export] public string Description = "This is a card.";
	[Export] public Texture2D Image = null;


}
