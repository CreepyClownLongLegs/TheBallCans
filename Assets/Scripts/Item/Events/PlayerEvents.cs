using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class PlayerEvents
{
    public event Action onDisablePlayerMovement;
    public void DisablePlayerMovement()
    {
        if (onDisablePlayerMovement != null) 
        {
            onDisablePlayerMovement();
        }
    }

    public event Action onEnablePlayerMovement;
    public void EnablePlayerMovement()
    {
        if (onEnablePlayerMovement != null) 
        {
            onEnablePlayerMovement();
        }
    }

    public event Action<int> onExperienceGained;
    public void ExperienceGained(int experience) 
    {
        if (onExperienceGained != null) 
        {
            onExperienceGained(experience);
        }
    }

    public event Action wonCookingGame;

    public void WonCookingGame(){
        wonCookingGame?.Invoke();
    }

    public event Action rhytmGamePlayed;

    public void RhytmGamePlayed(){
        rhytmGamePlayed?.Invoke();
    }


    public event Action<int> onPlayerExperienceChange;
    public void PlayerExperienceChange(int experience) 
    {
        if (onPlayerExperienceChange != null) 
        {
            onPlayerExperienceChange(experience);
        }
    }
}