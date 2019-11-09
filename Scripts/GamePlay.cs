using Godot;
using System;

public class GamePlay : Node
{
    [Export]
	private PackedScene openGate, shutGate;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
       // PlaceGate();
    }
	
	
	
	public void PlaceGate(){
		float position_x = 2595f;
		float position_y = 960f;
		
		GateScript closedGate = null;
		closedGate = shutGate.Instance() as GateScript;
		
		Vector2 closedGateLocation = new Vector2(position_x, position_y);
		closedGate.SetPosition(closedGateLocation);
		AddChild(closedGate);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
