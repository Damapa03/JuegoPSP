using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class CharacterStateMachine : Node
{
    [Export]
    State currentState;
    
    ArrayList states;

    public override void _Ready()
    {
        foreach (var child in GetChildren())
        {
            if (child is State)
            {
                states.Add(child);
                
            }
        }
    }

    public Boolean check_if_can_move(){
        return currentState.can_move;
    }
}
