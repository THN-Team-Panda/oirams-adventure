using Godot;
using System;

namespace Interactives {
	
	public partial class Player : CharacterBody2D
	{
		public Direction Direction { get; set; } = Direction.Right;

		[Export]
		public PackedScene Bullet { get; set; }

		[Export]
		public int Ammo { get; set; } = 2;

		[Export]
		public float Speed { get; set; } = 200.0f;
		
		[Export]
		public float JumpVelocity { get; set; } = -400.0f;
		
		[Export]
		public bool Hat { get; set; } = false;
		
		private AnimatedSprite2D defaultSprite2D;

		public override void _Input(InputEvent handler)
		{
			if (handler.IsActionPressed("shoot")) Shoot();
		}

        public override void _PhysicsProcess(double delta)
		{
			Move(delta);
		}

		private void Move(double delta)
		{
			Vector2 velocity = Velocity;

			if (!IsOnFloor())
				velocity += GetGravity() * (float)delta;

			if (Input.IsActionJustPressed("jump") && IsOnFloor())
				velocity.Y = JumpVelocity;
			
			defaultSprite2D = GetNode<AnimatedSprite2D>("MovementAnimation2D");
			
			if (Hat) defaultSprite2D.Animation = "movement_cap";
			else defaultSprite2D.Animation = "movement_normal";
				
			Vector2 direction = Input.GetVector("move_left", "move_right", "empty", "empty");
			if (direction != Vector2.Zero)
			{
				defaultSprite2D.Play();
				velocity.X = direction.X * Speed;
				
				if (velocity.X < 0)
				{ 
					defaultSprite2D.FlipH = true;
					Direction = Direction.Left;
				}
				else
				{
					 defaultSprite2D.FlipH = false;
					 Direction = Direction.Right;
				}
			}
			else
			{
				velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
				defaultSprite2D.Stop();
			}

			Velocity = velocity;
			MoveAndSlide();
		}

		private void Shoot()
		{
			if(Ammo < 1)
				return;

			// Spawn bullet in the scene
			Bullet bulletInstance = (Bullet)Bullet.Instantiate();
			bulletInstance.Position = Position;
			bulletInstance.Direction = Direction;
			GetParent().AddChild(bulletInstance);

			Ammo -= 1;
		}

		public bool PassCap() 
		{
			if(Hat)
				return false;

			Hat = true;

			return true;
		}

		public bool PassNote()
		{
			return true;
		}
	}
}
