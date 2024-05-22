using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GridManager gridManager;
    public List<Card> cardTypes;

    public int rows;
    public int columns;
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
}