using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class CharacterStateMachine : Node
{
	[Export] public State currentState;
	[Export] CharacterBody2D character;
	
	List<State> states = new List<State>();

	public override void _Ready()
	{
		foreach (var child in GetChildren())
		{
			if (child is State state)
			{
				states.Add(state);
				
				//Set the states up with what they need to function
				state.character = character;


			} else GD.PushWarning($"Child {child.Name} is not a State for CharacterStateMachine");
		}
	}

	public void _PhysicsProcess(float delta){
		if (currentState.next_state != null)
		{
			switch_states(currentState.next_state);
		}
	}

	public Boolean check_if_can_move(){
		return currentState.can_move;
	}

	public void switch_states(State new_state){
		if (currentState != null)
		{
			currentState.on_exit();
			currentState.next_state = null;
		}

		 currentState = new_state;

		 currentState.on_enter();
	}

	public void _input(InputEvent @event){
		currentState.state_input(@event);
	}
}
