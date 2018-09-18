using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonEvent : GameEvent
{
    public MainMenuButtonType Type;

    public MainMenuButtonEvent(MainMenuButtonType type)
    {
        Type = type;
    }
}

public class ObstacleEvent : GameEvent { }

public class SaveDBLocalEvent : GameEvent
{
    public HighScore highScore;

    public SaveDBLocalEvent(HighScore highScore)
    {
        this.highScore = highScore;
    }
}
public class CheckDBLocalEvent : GameEvent
{
    public HighScore highScore;

    public CheckDBLocalEvent(HighScore highScore)
    {
        this.highScore = highScore;
    }
}
public class HoldOnEvent : GameEvent {
    public bool IsHold;

    public HoldOnEvent(bool isHold)
    {
        IsHold = isHold;
    }
}

public class ControllerEvent : GameEvent
{
    public bool IsActive;

    public ControllerEvent(bool isActive)
    {
        IsActive = isActive;
    }
}

public class OnNextLevel : GameEvent
{

}

public class StartGameplayEvent : GameEvent
{

}

public class ChangeLabirinControlEvent : GameEvent
{
    public Transform Labirin;

    public ChangeLabirinControlEvent(Transform labirin)
    {
        Labirin = labirin;
    }
}
public class GetStarEvent : GameEvent
{
    public int Number;

    public GetStarEvent(int number)
    {
        Number = number;
    }
}

