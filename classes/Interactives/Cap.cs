using Godot;
using System;

namespace Interactives {
	public partial class Cap : Area2D
	{
		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
				var animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
				animation.Play();
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
			{
		}

		public void OnBodyEntered(Node body)
    	{
			if (body is Player player) 
			{
				if (player.PassCap())
				{
					GetParent().RemoveChild(this);
				}
			}
    	}
	}
}
