using Godot;
using System;

[GlobalClass]
public partial class CardResource : Resource
{
	[Export] public string Name = "Card";
	[Export] public string Description = "This is a card.";
	[Export] public Texture2D Image = null;


}
