using Godot;
using System;

public class CameraScript : Node2D
{
	private Node2D playerTarget;
	public bool playerDied;
    
    public override void _Ready()
    {
        playerTarget = GetParent().GetNode<Node2D>("Player");
    }

	public override void _Process(float delta)
  {
      	if(playerDied){
			return;
		}
		
		Position = playerTarget.GetPosition();
  }
}

