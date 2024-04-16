using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProfileDisplay : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]GameObject ProfileViewCanvas;
    [SerializeField]ProfileCreator _profileCreator;
    [SerializeField]Image _profilePicture;
    [SerializeField]TextMeshProUGUI _nameText;
    [SerializeField]TextMeshProUGUI _raceText;
    [SerializeField]TextMeshProUGUI _occupationText;
    [SerializeField]TextMeshProUGUI _ageText;
    [SerializeField]TextMeshProUGUI _backgroundText;
    [SerializeField]TextMeshProUGUI _otherText;

    // Start is called before the first frame update
    void Start()
    {
        MakeNewProfileAndUpdate();
        ProfileViewCanvas.SetActive(false);
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
        _backgroundText.text = $"Background:\n{currentProfile.Background}";
        _otherText.text = $"Other:\n{currentProfile.Other}";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ProfileViewCanvas.SetActive(!ProfileViewCanvas.gameObject.activeSelf);
    }
}
