using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public float Speed { get; set; } = 200.0f;
	
	[Export]
	public float JumpVelocity { get; set; } = -400.0f;
	
	[Export]
	public bool Hat { get; set; } = false;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}
		
		var animatedSprite2D = GetNode<AnimatedSprite2D>("MovementAnimation2D");
		
		if (Hat)
			animatedSprite2D.Animation = "movement_cap";
		else
			animatedSprite2D.Animation = "movement_normal";
			
		Vector2 direction = Input.GetVector("move_left", "move_right", "empty", "empty");
		if (direction != Vector2.Zero)
		{
			animatedSprite2D.Play();
			velocity.X = direction.X * Speed;
			
			if (velocity.X < 0) animatedSprite2D.FlipH = true;
			else animatedSprite2D.FlipH = false;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			animatedSprite2D.Stop();
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
