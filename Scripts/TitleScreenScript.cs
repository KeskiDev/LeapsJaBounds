using Godot;
using System;

public class TitleScreenScript : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

	private void _on_PlayButton_pressed()
	{
	    GetTree().ChangeScene("res://Scenes/LevelYksi.tscn");
	}
	
	private void _on_AboutButton_pressed()
	{
	    GetTree().ChangeScene("res://Scenes/AboutScreen.tscn");
	}
	
	private void _on_AboutBackButton_pressed()
	{
	    GetTree().ChangeScene("res://Scenes/TitleScreen.tscn");
	}
}









