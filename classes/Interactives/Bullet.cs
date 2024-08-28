using Godot;
using System;

namespace Interactives {

	public partial class Bullet : Area2D
	{
		[Export]
		public float Speed { get; set; } = 200.0f;

		[Export]
		public Direction Direction { get; set; } = Direction.Right;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			if (Direction == Direction.Right)
				Position += Transform.X * Speed * (float)delta;
			else
				Position -= Transform.X * Speed * (float)delta; 
		}
	}
}
