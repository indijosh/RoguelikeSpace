using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameScreen : MonoBehaviour {
    public int GalaxySize;
    public Dropdown GalaxySizeDropdown;
    int GalaxySizeDropdownValue;

    public int CivilizationCount;
    public Dropdown CivCountDropdown;
    int CivSizeDropdownValue;

    public Canvas SelectionItems;
    private CanvasGroup SelectionItemsCG;
    public Canvas Progress;
    private CanvasGroup ProgressCG;

    public string ProgressText;
    public Text TextProgress;

    // Use this for initialization
    void Start () {
        GalaxySize = 1;
        CivilizationCount = 1;

        GalaxySizeDropdown = GalaxySizeDropdown.GetComponent<Dropdown>();
        CivCountDropdown = CivCountDropdown.GetComponent<Dropdown>();

        SelectionItemsCG = SelectionItems.GetComponent<CanvasGroup>();
        ProgressCG = Progress.GetComponent<CanvasGroup>();

        UpdateDropdowns();
    }

    public void UpdateDropdowns()
    {
        //Keep the current index of the Dropdown in a variable
        GalaxySize = GalaxySizeDropdown.value;
        CivilizationCount = CivCountDropdown.value;
    }

    public void HideSelectionShowProgress()
    {
        SelectionItemsCG.alpha = 0;
        SelectionItemsCG.interactable = false;
        ProgressCG.alpha = 1;
    }

    public void UpdateProgressText()
    {
        TextProgress.text = ProgressText;
    }
}
