using UnityEngine;

public class Maze : MonoBehaviour
{
    public void Build(MazeFormFactory mazeFormFactory, MazeFormType mazeFormType, int numberOfCells)
    {
        MazeGridForm gridForm = mazeFormFactory.Get(mazeFormType);

        gridForm.GenerateGridCoordinates(numberOfCells);
    }
}
