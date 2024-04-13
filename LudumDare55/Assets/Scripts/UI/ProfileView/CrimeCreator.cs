using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrimeCreator
{
    List<string> _crimes = new List<string>()
    {
        "Assaulted a(n)",
        "Stole a(n)",
        "Kidnapped a(n)",
        "Forged a(n)",
        "Fraudulently created a(n)",
        "Burnt down a"
    };
    List<string> _objects = new List<string>()
    {
        "bank",
        "car",
        "house",
        "plot of land",
        "water bottle",
        "loaf of bread",
        "a singular banana"
    };
    List<string> _methods = new List<string>()
    {
        "with a lighter",
        "with a box of crayons",
        "with a pencil",
        "with a glue bottle",
        "with a particular set of skills",
        "under the influence of insomnia",
    };
    
    public string GenerateCrime()
    {
        string crime = $"{_crimes[Random.Range(0, _crimes.Count)]} {_objects[Random.Range(0, _crimes.Count)]} {_methods[Random.Range(0, _crimes.Count)]}";
        return crime;
    }
}
