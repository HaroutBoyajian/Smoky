using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Card : MonoBehaviour
{
    public Button button;
    public Sprite backSprite;
    public Sprite frontSprite;
    public GameObject cardBackText;
    public GameObject cardFrontText;
    private bool isShowingFront = false;
    private Image cardImage;

    private void Start()
    {
        cardImage = GetComponent<Image>();
        cardImage.sprite = backSprite;
    }

    public void FlipCard()
    {
        StartCoroutine(Flip());
    }

    IEnumerator Flip()
    {
        bool flipToFront = !isShowingFront;

        // Scale down width to zero
        for (float i = 1f; i >= 0f; i -= Time.deltaTime * 2)
        {
            cardImage.rectTransform.localScale = new Vector3(i, 1, 1);
            if (i < 0.5f && cardImage.sprite == (flipToFront ? backSprite : frontSprite))
                cardImage.sprite = flipToFront ? frontSprite : backSprite;
            yield return null;
        }

        // Scale up width back to one
        for (float i = 0f; i <= 1f; i += Time.deltaTime * 2)
        {
            cardImage.rectTransform.localScale = new Vector3(i, 1, 1);
            yield return null;
        }

        cardImage.rectTransform.localScale = Vector3.one; // Ensure it ends properly scaled
        isShowingFront = flipToFront;

        cardBackText.gameObject.SetActive(!flipToFront);
        cardFrontText.gameObject.SetActive(flipToFront);
    }
}