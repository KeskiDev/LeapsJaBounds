using Godot;
using System;

public class UIScript : Node
{
	float positionX = 65f;
	float positionY = 45f;
    public override void _Ready()
    {
        
    }
	
	public void KingKeyAcquired(){
		var keyless = GetNode("needKey");
		RemoveChild(keyless);
		AddChild(hasKey);
	}
}
