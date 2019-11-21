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
		//1000 - 1150
		float speed = 20f;
		if(Position.y == 1000){
			speed = gravity;
		}
		else if(Position.y == 1148){
			speed = jump_force;
		}
		
		movement.y = speed;
		movement = MoveAndSlide(movement);
	}
}
