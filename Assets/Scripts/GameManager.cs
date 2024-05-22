using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GridManager gridManager;
    public List<Card> cardTypes;

    public int rows;
    public int columns;

    public static GameManager instance;

    private List<Card> flippedCards = new List<Card>();

    public Text scoreText;
    private int score;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    void Start()
    {
        SetUpCards(rows, columns);
    }

    public void SetUpCards(int rows, int columns)
    {
        int totalCards = rows * columns;
        if (totalCards % 2 != 0)
        {
            Debug.LogError("The number of grid spaces must be even.");
            return;
        }

        List<Card> selectedCards = new List<Card>();
        int neededPairs = totalCards / 2;

        // Fill the selectedCards list with pairs
        while (selectedCards.Count < totalCards)
        {
            Card card = cardTypes[Random.Range(0, cardTypes.Count)];
            selectedCards.Add(card);
            selectedCards.Add(card); // Add two of each type
        }

        Shuffle(selectedCards); // Shuffle the list to randomize pair locations

        // Instantiate new cards and set up the grid
        foreach (Card card in selectedCards)
        {
            GameObject newCard = Instantiate(card.gameObject, gridManager.transform);

            gridManager.allCards.Add(newCard);
        }

        gridManager.SetUpGrid(rows, columns); // Adjust the grid size appropriately
    }

    void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void CardFlipped(Card card)
    {
        flippedCards.Add(card);

        // Check for matches every two cards
        if (flippedCards.Count == 2)
        {
            StartCoroutine(CheckMatch(flippedCards[0], flippedCards[1]));
            flippedCards.Clear(); // Clear the list to wait for the next pair of cards
        }
    }


    private IEnumerator CheckMatch(Card firstCard, Card secondCard)
    {
        yield return new WaitForSeconds(1f); // Delay to allow visualization of both cards

        if (firstCard.name == secondCard.name)
        {
            // If there's a match
            firstCard.RemoveCard();
            secondCard.RemoveCard();

            score++;
            scoreText.text = score.ToString();
        }
        else
        {
            // If there isn't a match
            firstCard.ResetCard();
            secondCard.ResetCard();
        }
    }
}