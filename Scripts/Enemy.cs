using Godot;
using System;

public class Enemy : KinematicBody2D
{
    private float gravity = 20f;
	public float jump_force = -300f;
	private Vector2 movement;
	private float moveSpeed = 350f;
	public float something = 0;
	public bool jumping = false;
	
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }
	
	public override void _PhysicsProcess(float delta){
		
		if(IsOnWall()){
			
			if(Position.y <= 900f){
				jumping = false;
			}
			else{
				jumping = true;
				GD.Print("Going up");
				movement.y = jump_force;		
			}
		}
		else{
			if(!jumping){
				GD.Print("Going down");
				movement.y += gravity;
			}
			
		}
		
		
		movement = MoveAndSlide(movement);
	}
}
