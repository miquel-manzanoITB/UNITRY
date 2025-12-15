using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;
    public Renderer[] shirtRenderers;
    public Renderer[] pantsRenderers;

    public Slider shirtHue;
    public Slider shirtSat;
    public Slider shirtVal;

    public Slider pantsHue;
    public Slider pantsSat;
    public Slider pantsVal;

    private Material currentShirtMat;
    private Material currentPantsMat;

    void Awake()
    {
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
        }
    }
    
    void Start()
    {
        shirtHue.value = 1f; shirtSat.value = 1f; shirtVal.value = 1f;
        pantsHue.value = 0.7f; pantsSat.value = 1f; pantsVal.value = 1f;
    }

    public void SelectCharacter(int index)
    {
        PlayerPrefs.SetInt("SelectedCharacter", index);

        for (int i = 0; i < characters.Length; i++)
        {
            bool isActive = (i == index);
            if (characters[i] != null) characters[i].SetActive(isActive);

            if (isActive)
            {
                if (i < shirtRenderers.Length && shirtRenderers[i] != null)
                {
                    currentShirtMat = shirtRenderers[i].material;
                    UpdateShirtColor();
                }

                if (i < pantsRenderers.Length && pantsRenderers[i] != null)
                {
                    currentPantsMat = pantsRenderers[i].material;
                    UpdatePantsColor();
                }
            }
        }
    }
    public void UpdateShirtColor()
    {
        if (currentShirtMat == null) return;

        Color newColor = Color.HSVToRGB(shirtHue.value, shirtSat.value, shirtVal.value);
        currentShirtMat.SetColor("_BaseColor", newColor); //.color = newColor;
    }

    public void UpdatePantsColor()
    {
        if (currentPantsMat == null) return;

        Color newColor = Color.HSVToRGB(pantsHue.value, pantsSat.value, pantsVal.value);
        currentPantsMat.SetColor("_BaseColor", newColor);
    }
}