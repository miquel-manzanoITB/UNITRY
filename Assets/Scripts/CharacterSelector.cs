using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;

    public Slider hueSlider;
    public Slider satSlider;
    public Slider valSlider;

    private Material activeMaterial;

    void Start()
    {
    }

    public void SelectCharacter(int index)
    {
        PlayerPrefs.SetInt("SelectedCharacter", index);

        for (int i = 0; i < characters.Length; i++)
        {
            bool isActive = (i == index);
            characters[i].SetActive(isActive);

            if (isActive)
            {
                Renderer rend = characters[i].GetComponentInChildren<Renderer>();

                if (rend != null)
                {
                    activeMaterial = rend.material;

                    UpdateCharacterColor();
                }
            }
        }
    }

    public void UpdateCharacterColor()
    {
        if (activeMaterial == null) return;

        Color newColor = Color.HSVToRGB(hueSlider.value, satSlider.value, valSlider.value);

        activeMaterial.color = newColor;

    }
}