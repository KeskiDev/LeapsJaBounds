using Godot;
using System;

public class Player : KinematicBody2D
{
    private Vector2 movement = Vector2.Zero;
	private float move_speed = 400f;
	private float gravity = 30f;
	private float jump_force = -750f;
	private float extra_jump = -970f;
	private Vector2 up_direction = Vector2.Up;
	private bool moving = false;
	private bool jumping = false;
	private bool moveRight = true;
	public bool hasPickupYksi = false;
	public bool hasPickupKaksi = false;
	public bool hasPickupKolme = false;
	
	private AnimatedSprite animation;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animation = GetNode<AnimatedSprite>("Animation");
    }

	public override void _PhysicsProcess(float delta){
		movement.y += gravity;
		PlayerMovement(delta);
		
		if(hasPickupKolme && hasPickupKaksi && hasPickupYksi){
			//todo open gate to the next level
			//GetParent<GamePlay>().OpenGate();
		}
	}
	
	
	void PlayerMovement(float delta){
		animation.Play("idle");
		if(Input.IsActionPressed("jump")){
			if(IsOnFloor())
			{
				if(hasPickupYksi){
					movement.y = extra_jump;
				}
				else{
					movement.y = jump_force;	
				}
			}	
		}
		else if(Input.IsActionPressed("jump") && Input.IsActionPressed("move_right") ){
			if(IsOnFloor())
			{
				if(hasPickupYksi){
					movement.y = extra_jump;
				}
				else{
					movement.y = jump_force;	
				}
			}	
			
			if(!hasPickupKaksi){
				if(!IsOnFloor()){
					movement.x = move_speed;	
				}	
			}
			else{
				movement.x = move_speed;
			}
		}
		else if(Input.IsActionPressed("jump") && Input.IsActionPressed("move_left")){
			if(IsOnFloor()){
				if(hasPickupYksi){
					movement.y = extra_jump;
				}
				else{
					movement.y = jump_force;	
				}
			}
			
			if(!hasPickupKaksi){
				if(!IsOnFloor())
				{
					movement.x = -move_speed;
				}	
			}
			else{
				movement.x = -move_speed;
			}
		}
		else if(Input.IsActionPressed("move_left")){
			if(!hasPickupKaksi){
				if(!IsOnFloor())
				{
					movement.x = -move_speed;
				}	
			}
			else{
				movement.x = -move_speed;
			}
		}
		else if(Input.IsActionPressed("move_right")){
			if(!hasPickupKaksi){
				if(!IsOnFloor()){
					movement.x = move_speed;	
				}	
			}
			else{
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
			if(body.Name.Contains("Key1")){
				hasPickupYksi = true;
			}
			else if(body.Name.Contains("Key2")){
				hasPickupKaksi = true;
			}
			else if(body.Name.Contains("KingKey")){
				hasPickupKolme = true;
			}
		}
		else if(body.IsInGroup("openGate")){
			//fade out?
			//load the second level
		}
	}
}



