using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;
    public Renderer[] shirtRenderers;
    public Slider hueSlider;
    public Slider satSlider;
    public Slider valSlider;

    private Material activeShirtMaterial;

    void Start()
    {
        hueSlider.value = 1f;
        satSlider.value = 1f;
        valSlider.value = 1f;
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
                    activeShirtMaterial = shirtRenderers[i].material;

                    UpdateCharacterColor();
                }
            }
        }
    }

    public void UpdateCharacterColor()
    {
        if (activeShirtMaterial == null) return;

        Color newColor = Color.HSVToRGB(hueSlider.value, satSlider.value, valSlider.value);

        activeShirtMaterial.color = newColor;

    }
}