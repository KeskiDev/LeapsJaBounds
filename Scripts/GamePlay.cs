using Godot;
using System;

public class GamePlay : Node
{
    [Export]
	private PackedScene openGate, shutGate;
	public bool canOpen = true;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
       PlaceGate();
    }
	
	public void PlaceGate(){
		GateScript closedGate = null;
		closedGate = shutGate.Instance() as GateScript;
		float position_x = 2595f;
		float position_y = 960f;
		
		Vector2 closedGateLocation = new Vector2(position_x, position_y);
		closedGate.SetPosition(closedGateLocation);
		AddChild(closedGate);
	}

	public void OpenGate(){
		GateScript wayIsOpen = null;
		wayIsOpen = openGate.Instance() as GateScript;
		float position_x = 2525f;
		float position_y = 928f;
		
		Vector2 openGateLocation = new Vector2(position_x, position_y);
		wayIsOpen.SetPosition(openGateLocation);
		if(canOpen){
			var gatewayNode = GetNode("Gateway");
			RemoveChild(gatewayNode);
			AddChild(wayIsOpen);
			//TODO call the UI KingKeyAcquired method
			canOpen = false;
		}
		
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
