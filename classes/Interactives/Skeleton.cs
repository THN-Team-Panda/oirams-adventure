using Godot;
using System;

namespace Interactives {

	public partial class Skeleton : CharacterBody2D
	{
		public Direction Direction { get; set; } = Direction.Right;

		[Export]
		public float Speed { get; set; } = 150.0f;

		private AnimatedSprite2D defaultSprite2D;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			defaultSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
			defaultSprite2D.Play();
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			Vector2 velocity = Velocity;

			if (!IsOnFloor())
				velocity += GetGravity() * (float)delta;

			velocity.X = (Direction == Direction.Right ? 1 : -1) * Speed;
				
			if (velocity.X < 0)
				defaultSprite2D.FlipH = true;
			else
				defaultSprite2D.FlipH = false;

			Velocity = velocity;
			MoveAndSlide();

			for (int i = 0; i < GetSlideCollisionCount(); i++)
			{
				KinematicCollision2D col = GetSlideCollision(i);

				if (col.GetNormal() == Vector2.Left)
					Direction = Direction.Left;
				else if (col.GetNormal() == Vector2.Right)
					Direction = Direction.Right;
			}
		}
	}
}
