using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ProfileCreator
{
    public Profile CurrentProfile { get; private set; }
    List<string> _firstNames = new List<string>() 
    {
        "America",
        "Bobbi",
        "Caesar",
        "Demarcus",
        "Eclaire",
        "Felicity",
        "Garfield",
        "Hercules",
        "Ignatius",
        "Jesús",
        "Kiki",
        "Lego",
        "Mario",
        "Nzinga",
        "Oolek",
        "Oompa",
        "Penelope",
        "Quimberton",
        "Raymundo",
        "Sonic",
        "Thor",
        "Unity",
        "Victoria",
        "Wagyu",
        "Xample",
        "Ya'rah",
        "Zennifer",
    };
    List<string> _lastNames = new List<string>()
    {
        "Aaaaaaaaaaa",
        "Bulletpoint",
        "Cupcake",
        "Dingledongle",
        "Ekström",
        "Flimflam",
        "Glop",
        "Hullaballoo",
        "Ittybitty",
        "Jones",
        "Kahoot",
        "Ludumdare",
        "Miyazaki",
        "Nugget",
        "Octothorpe",
        "Pecadillo",
        "Quack",
        "Rex",
        "Stanislavski",
        "Tacobell",
        "Ukulele",
        "Vamoose",
        "Wyrzyk",
        "Xiao",
        "Yancy",
        "Zanetti"
    };

    public void CreateNewProfile()
    {
        Profile newProfile = new Profile
        {
            //get random photo
            Name = $"{_firstNames[Random.Range(0, _firstNames.Count)]} {_lastNames[Random.Range(0, _lastNames.Count)]}",//eventually change this randomly get a name
            Race = (Race)Random.Range(0, Enum.GetNames(typeof(Race)).Length),
            Age = Random.Range(18, 95),
            Occupation = (Occupation)Random.Range(0,Enum.GetNames(typeof(Occupation)).Count())
        };
        CurrentProfile = newProfile;
    }

}
