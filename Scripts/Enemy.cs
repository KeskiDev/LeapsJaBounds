using Godot;
using System;

public class Enemy : KinematicBody2D
{
    private float gravity = 20f;
	public float jump_force = -750f;
	private Vector2 movement;
	
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }
	
	public override void _PhysicsProcess(float delta){
		if(IsOnFloor()){
			movement.y = jump_force;
		}
		else{
			movement.y = gravity;
		}
		
		movement = MoveAndSlide(movement);
	}
}
