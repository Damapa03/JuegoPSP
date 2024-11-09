using Godot;
using System;

public partial class State : Node
{
    [Export]
    public Boolean can_move = true;
    public CharacterBody2D character;
    public State next_state;

    public void state_input(InputEvent @event){
        
    }

    public void on_enter(){}

    public void on_exit(){}
}
