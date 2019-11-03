using Godot;
using System;

public class Player : KinematicBody2D
{
    private Vector2 movement = Vector2.Zero;
	private float move_speed = 400f;
	private float gravity = 30f;
	private float jump_force = -850f;
	private Vector2 up_direction = Vector2.Up;
	private bool moving = false;
	private bool jumping = false;
	private bool moveRight = true;
	
	private AnimatedSprite animation;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animation = GetNode<AnimatedSprite>("Animation");
    }

	public override void _PhysicsProcess(float delta){
		movement.y += gravity;
		PlayerMovement(delta);
	}
	
	void PlayerMovement(float delta){
		animation.Play("idle");
		if(Input.IsActionPressed("jump")){
			if(IsOnFloor())
			{
				movement.y = jump_force;
			}	
		}
		else if(Input.IsActionPressed("jump") && Input.IsActionPressed("move_right") ){
			if(IsOnFloor())
			{
				movement.y = jump_force;
			}	
			
			if(!IsOnFloor()){
				movement.x = move_speed;	
			}
		}
		else if(Input.IsActionPressed("jump") && Input.IsActionPressed("move_left")){
			if(IsOnFloor()){
				movement.y = jump_force;
			}
			
			if(!IsOnFloor())
			{
				movement.x = -move_speed;
			}	
		}
		else if(Input.IsActionPressed("move_left")){
			if(!IsOnFloor())
			{
				movement.x = -move_speed;
			}	
		}
		else if(Input.IsActionPressed("move_right")){
			if(!IsOnFloor()){
				movement.x = move_speed;	
			}
		}
		else if(Input.IsActionPressed("rotate")){
			if(!IsOnFloor()){
					var currentRotation = GetRotationDegrees();
					var rotate = currentRotation + 1;
					SetRotationDegrees(rotate);
			}
		}
		else if(Input.IsActionPressed("rotate_left")){
			if(!IsOnFloor()){
					var currentRotation = GetRotationDegrees();
					var rotate = currentRotation - 1;
					SetRotationDegrees(rotate);
			}
		}
		else{
			movement.x = 0f;
			if(IsOnFloor()){
				movement.y = 0f;	
			}
			animation.Play("idle");
		}
		
		movement = MoveAndSlide(movement, up_direction);
	}
	
	private void _on_Player_body_entered(PhysicsBody2D body)
	{
	    if(body.IsInGroup("pickup")){
			GD.Print("pickup!!!");
//			GetParent().GetNode<CameraFollow>("Main Camera").playerDied = true;
//			GetParent<GamePlay>().PlayerDied();
//			QueueFree();
		}
	}
}



