using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup; 
    public RectTransform gridRectTransform;
    public List<GameObject> allCards = new List<GameObject>();

    // This method sets up the grid based on the provided rows and columns
    public void SetUpGrid(int rows, int columns)
    {
        float width = gridRectTransform.rect.width / columns - gridLayoutGroup.spacing.x * (columns - 1) / columns;
        float height = gridRectTransform.rect.height / rows - gridLayoutGroup.spacing.y * (rows - 1) / rows;
        gridLayoutGroup.cellSize = new Vector2(width, height);

        // Set constraints to ensure the layout fits the rows and columns
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = columns;
    }
}
