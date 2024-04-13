using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileDisplay : MonoBehaviour
{
    [SerializeField]ProfileCreator _profileCreator;
    [SerializeField]Image _profilePicture;
    [SerializeField]TextMeshProUGUI _nameText;
    [SerializeField]TextMeshProUGUI _raceText;
    [SerializeField]TextMeshProUGUI _occupationText;
    [SerializeField]TextMeshProUGUI _ageText;
    [SerializeField]TextMeshProUGUI _descriptionText;
    [SerializeField]TextMeshProUGUI _otherText;

    // Start is called before the first frame update
    void Start()
    {
        MakeNewProfileAndUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            MakeNewProfileAndUpdate();
    }

    void MakeNewProfileAndUpdate()
    {
        _profileCreator.CreateNewProfile();
        PopulateDisplay();
    }

    void PopulateDisplay()
    {
        Profile currentProfile = _profileCreator.CurrentProfile;
        _profilePicture.sprite = currentProfile.ProfilePicture;
        _nameText.text = $"Name: {currentProfile.Name}";
        _raceText.text = $"Race: {currentProfile.Race}";
        _occupationText.text = $"Occupation: {currentProfile.Occupation}";
        _ageText.text = $"Age: {currentProfile.Age}";
        _descriptionText.text = $"Description:\n{currentProfile.Description}";
        _otherText.text = $"Other:\n{currentProfile.Other}";
    }
}
