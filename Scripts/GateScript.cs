using Godot;
using System;

public class GateScript : Node2D
{
    private Vector2 GateLocation;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }
	
	private void _on_Gate_entered(PhysicsBody2D body)
	{
		if(body.IsInGroup("Player")){
			//have to change this to be more reusable
			GetTree().ChangeScene("res://Scenes/LevelKaksi.tscn");
		}
		else if(body.IsInGroup("LevelTwoPlayer")){
			GetTree().ChangeScene("res://Scenes/LevelKolme.tscn");
		}
	}

}



