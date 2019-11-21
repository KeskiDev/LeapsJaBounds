using Godot;
using System;

public class LevelKaksi : Node
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
		float position_x = 2935f;
		float position_y = 444f;
			
		Vector2 closedGateLocation = new Vector2(position_x, position_y);
		closedGate.SetPosition(closedGateLocation);
		AddChild(closedGate);
	}

	public void OpenGate(){
		GateScript wayIsOpen = null;
		wayIsOpen = openGate.Instance() as GateScript;
		float position_x = 2864f;
		float position_y = 411f;
		
		Vector2 openGateLocation = new Vector2(position_x, position_y);
		wayIsOpen.SetPosition(openGateLocation);
		if(canOpen){
			var gatewayNode = GetNode("Gateway");
			RemoveChild(gatewayNode);
			AddChild(wayIsOpen);
			canOpen = false;
		}
		
	} 
}
