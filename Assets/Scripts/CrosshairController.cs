using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    public Color defaultCrosshairColor = Color.white;
    public Color interactableCrosshairColor = Color.green;
    public Image crosshairImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(Color color)
    {
        crosshairImage.color = color;
    }

    public void SetVisible(bool visible)
    {
        crosshairImage.gameObject.SetActive(visible);
    }
    
    public void ResetColor()
    {
        crosshairImage.color = defaultCrosshairColor;
    }
    
    public void SetColorDefault()
    {
        crosshairImage.color = defaultCrosshairColor;
    }
    
    public void SetColorInteractable()
    {
        crosshairImage.color = interactableCrosshairColor;
    }
}
