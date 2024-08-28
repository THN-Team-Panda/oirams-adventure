using Godot;
using System;

namespace Elements {
	public partial class TextureButtonLevel1 : Godot.TextureButton
	{

		[Export]
		public PackedScene RelatedLevel { get; set; }

		public override void _Ready()
		{
			Pressed += ButtonPressed;
		}

		public override void _Process(double delta)
		{
		}
		
		private void ButtonPressed()
		{
			GetTree().ChangeSceneToPacked(RelatedLevel);
			Hide();
		}
	}
}
