using Godot;
using System;

public partial class GroundState : State
{
    [Export] public float JumpVelocity = -400.0f;
    [Export] public State air_state;

    Vector2 velocity;

    public new void state_input(InputEvent @event){
         if (Input.IsActionPressed("jump"))
        {
            jump();
        }
    }

    public void jump(){
        character.Velocity = new Vector2(character.Velocity.X, JumpVelocity);
        next_state = air_state;
    }
}
