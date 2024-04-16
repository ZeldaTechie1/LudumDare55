using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _portraits;

    // Start is called before the first frame update
    void Start()
    {
        ResetPortraits();
        ProfileCreator.ProfileCreatedEvent += UpdatePortraits;
    }

    void UpdatePortraits(int profileIndex)
    {
        ResetPortraits();
        StartCoroutine(StupidLoadingFix(profileIndex));
    }

    IEnumerator StupidLoadingFix(int profileIndex)
    {
        yield return new WaitForSeconds(1f);
        _portraits[profileIndex].transform.parent.GetComponent<Image>().color = Color.white;
    }

    void ResetPortraits()
    {
        foreach (GameObject portrait in _portraits)
        {
            if (!portrait) return;

            portrait.transform.parent.GetComponent<Image>().color = Color.clear;
        }
    }

    private void OnDestroy()
    {
        ProfileCreator.ProfileCreatedEvent -= UpdatePortraits;
    }
}
