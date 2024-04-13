using UnityEngine;

public enum Race
{
    White,
    Black,
    Asian,
    Hispanic
}

public enum Occupation
{
    Clown,
    Barista,
    Clerk
}

public struct Profile
{
    public Sprite ProfilePicture;
    public string Name;
    public Race Race;
    public Occupation Occupation;
    public int Age;
    public string Background;
    public string Other;
}
