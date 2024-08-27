using Godot;
using System;

public partial class TextureButtonLevel1 : Godot.TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += ButtonPressed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void ButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://game_scene.tscn");
		Hide();
	}
	
}
