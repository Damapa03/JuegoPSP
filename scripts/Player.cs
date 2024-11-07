using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public float Speed = 200.0f;
	[Export]
	public float JumpVelocity = -400.0f;
	AnimationTree animationTree;
	Sprite2D sprite2D;
	CharacterStateMachine stateMachine;
	public override void _Ready()
	{
		sprite2D = GetNode<Sprite2D>("Sprite2D");
		animationTree = GetNode<AnimationTree>("AnimationTree");
		animationTree.Active = true;
		stateMachine = GetNode<CharacterStateMachine>("CharacterStateMachine");
		GD.Print(stateMachine.check_if_can_move());
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", null, null);
		if (direction != Vector2.Zero && stateMachine.check_if_can_move())
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		//Change direction
		
		sprite2D.FlipH = direction > Vector2.Zero;
		sprite2D.FlipH = direction < Vector2.Zero;

		//Change animation
		animationTree.Set("parameters/Move/blend_position", direction.X);

			// if(IsOnFloor()){
		// 	if (direction == Vector2.Zero)
		// 	{
		// 		animation.Play("idle");
		// 	}else animation.Play("run");
		// }else animation.Play("jump");

		Velocity = velocity;
		MoveAndSlide();
	}
}