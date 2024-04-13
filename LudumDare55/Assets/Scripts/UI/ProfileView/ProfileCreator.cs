using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ProfileCreator
{
    public Profile CurrentProfile { get; private set; }
    
    public void CreateNewProfile()
    {
        Profile newProfile = new Profile
        {
            //get random photo
            Name = "Steve",//eventually change this randomly get a name
            Race = (Race)Random.Range(0, Enum.GetNames(typeof(Race)).Length),
            Age = Random.Range(18,95)
        };
        CurrentProfile = newProfile;
    }

}
