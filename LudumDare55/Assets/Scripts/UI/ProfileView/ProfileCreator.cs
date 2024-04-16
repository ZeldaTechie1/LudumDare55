using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ProfileCreator
{
    public static Action<int> ProfileCreatedEvent;
    public Profile CurrentProfile { get; private set; }
    [SerializeField]List<Sprite> _profileImages;
    List<string> _firstNames = new List<string>() 
    {
        "America",
        "Amanda",
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
        "FirstName",
        "Garglon",
        "Deez",
        "Chris",
        "Link",
        "Midna",
        "Ophelia",
        "Sally",
        "Teresa",
        "Chad",
        "Itsame"
    };
    List<string> _lastNames = new List<string>()
    {
        "Aaaaaaaaaaa",
        "Hugenkiss",
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
        "Zanetti",
        "Loompa",
        "Deez",
        "P'Bacon",
        "Pain",
        "Crowd",
        "LastName"
    };
    List<string> _backgroundSnippets = new List<string>()
    {
        "Example Background",
        "Example Background2",
        "Example Background3"
    };
    List<string> _otherSnippets = new List<string>()
    {
        "Voted best suited for Jury Duty in High School.",
        "Record of being emotionally unstable",
        "Likes cheese and cheese related products"
    };

    CrimeCreator _crimeCreator = new CrimeCreator();

    public void CreateNewProfile()
    {
        int profileIndex = Random.Range(0, _profileImages.Count());
        Profile newProfile = new Profile
        {
            //get random photo
            ProfilePicture = _profileImages[profileIndex],
            Name = $"{_firstNames[Random.Range(0, _firstNames.Count)]} {_lastNames[Random.Range(0, _lastNames.Count)]}",
            Race = (Race)Random.Range(0, Enum.GetNames(typeof(Race)).Length),
            Age = Random.Range(18, 95),
            Occupation = (Occupation)Random.Range(0, Enum.GetNames(typeof(Occupation)).Count()),
            Background = GetGeneratedBackground(),
            Other = _otherSnippets[Random.Range(0, _otherSnippets.Count)]
        };
        CurrentProfile = newProfile;
        ProfileCreatedEvent?.Invoke(profileIndex);
    }

    string GetGeneratedBackground()
    {
        string newBackground = "";
        List<string> currentSnippets;
        string[] temp = new string[_backgroundSnippets.Count];
        _backgroundSnippets.CopyTo(temp);
        currentSnippets = temp.ToList();

        for(int count = 0; count < 3; count++)
        {
            if(Random.Range(0,100) < 5)
            {
                newBackground += _crimeCreator.GenerateCrime();
            }
            else
            {
                int randSnippetIndex = Random.Range(0, currentSnippets.Count);
                newBackground += currentSnippets[randSnippetIndex];
                currentSnippets.RemoveAt(randSnippetIndex);
            }
            if (count != 2)
                newBackground += "\n";
        }

        return newBackground;
    }
}
