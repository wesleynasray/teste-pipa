using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private TextMesh letterText;
    [SerializeField] private TextMesh numberText;
    
    public void SetBall(int number)
    {
        numberText.text = number.ToString();

        if (number > 60)
        {
            meshRenderer.material.color = new Color32(165, 44, 121, 255);
            letterText.text = "O";
        }
        else if (number > 45)
        {
            meshRenderer.material.color = new Color32(41, 65, 148, 255);
            letterText.text = "G";
        }
        else if (number > 30)
        {
            meshRenderer.material.color = new Color32(55, 147, 66, 255);
            letterText.text = "N";
        }
        else if (number > 15)
        {
            meshRenderer.material.color = new Color32(247, 112, 22, 255);
            letterText.text = "I";
        }
        else
        {
            meshRenderer.material.color = new Color32(209, 37, 13, 255);
            letterText.text = "B";
        }
    }
}
