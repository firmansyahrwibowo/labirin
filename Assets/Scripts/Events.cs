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

public class LevelSelectButtonEvent : GameEvent
{
    public LevelSelectButtonType Type;

    public LevelSelectButtonEvent(LevelSelectButtonType type)
    {
        Type = type;
    }

}

public class ObstacleEvent : GameEvent { }

public class SaveDBLocalEvent : GameEvent
{
    public LevelData LevelData;

    public SaveDBLocalEvent(LevelData levelData)
    {
        this.LevelData = levelData;
    }
}
public class CheckDBLocalEvent : GameEvent
{
    public LevelData highScore;

    public CheckDBLocalEvent(LevelData highScore)
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

public class SFXPlayEvent : GameEvent {
    public SfxType Sfx;
    public bool IsEnd;

    public SFXPlayEvent(SfxType sfx, bool isEnd)
    {
        Sfx = sfx;
        IsEnd = isEnd;
    }
}


public class BGMEvent : GameEvent {
    public PlayType Type;

    public BGMEvent(PlayType type)
    {
        Type = type;
    }
}

public class SetDataLevelEvent : GameEvent {
    public LevelData Data;

    public SetDataLevelEvent(LevelData data)
    {
        Data = data;
    }
}
public class InitButtonEvent : GameEvent { }
public class ShowLeaderboardEvent : GameEvent { }
public class ShowAchievementEvent : GameEvent { }

public class LeaderboardAddEvent : GameEvent {
    public int Score;

    public LeaderboardAddEvent(int score)
    {
        Score = score;
    }
}
public class AchievementUnlockEvent : GameEvent
{
    public int Id;

    public AchievementUnlockEvent(int id)
    {
        Id = id;
    }
}

public class BlockSpamEvent : GameEvent {
    public bool IsTrue;

    public BlockSpamEvent(bool isTrue)
    {
        IsTrue = isTrue;
    }
}

public class AnalyticsGameEvent : GameEvent {
    public string Type;

    public AnalyticsGameEvent(AnalyticsType type)
    {
        Type = type.ToString();
    }
    public AnalyticsGameEvent(string type)
    {
        Type = type;
    }
}

public class Tutorial1GameEvent : GameEvent
{

    public bool IsActive;

    public Tutorial1GameEvent(bool isActive)
    {
        IsActive = isActive;
    }
}

public class Tutorial2GameEvent : GameEvent
{

    public bool IsActive;

    public Tutorial2GameEvent(bool isActive)
    {
        IsActive = isActive;
    }
}
