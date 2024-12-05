using Godot;
using System;

public partial class ButtonExit : Godot.Button
{
	public void _on_pressed()
	{
		GetTree().Quit();
	}
}
