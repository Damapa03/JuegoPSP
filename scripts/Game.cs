using Godot;
using System;

public partial class Game : Node2D
{
	[Export]Label label;
	public static int snails;
	public override void _Ready()
	{
		foreach (var child in GetChildren())
		{

			if (child is Snail snail)
			{
				snails += 1; 

				if(snails > 3) snails = 3;
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		label.Text = "X " + snails;

		if (snails == 0)
		{
			GetTree().ChangeSceneToFile("res://scenes/UI/Finish.tscn");
		}
	}
}
