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
        float cellWidth = (gridRectTransform.rect.width - gridLayoutGroup.padding.left - gridLayoutGroup.padding.right - (columns - 1) * gridLayoutGroup.spacing.x) / columns;
        float cellHeight = (gridRectTransform.rect.height - gridLayoutGroup.padding.top - gridLayoutGroup.padding.bottom - (rows - 1) * gridLayoutGroup.spacing.y) / rows;
        gridLayoutGroup.cellSize = new Vector2(cellWidth, cellHeight);


        // Set constraints to ensure the layout fits the rows and columns
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = columns;
    }
}