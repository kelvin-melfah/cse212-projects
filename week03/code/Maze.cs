/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // The dictionary is keyed by our current (x, y), so I look up the square
        // we're standing on. The bool array is [left, right, up, down], which makes
        // left index 0. If the square isn't in the map at all, I treat that like a
        // wall rather than letting a KeyNotFoundException leak out.
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Only reached when the way is open. Moving left means x shrinks by one.
        _currX--;
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // Same lookup as MoveLeft, but right lives at index 1 of the array.
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Moving right means x grows by one.
        _currX++;
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // Up is index 2 in the array.
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // This one is easy to get backwards. In the maze picture, y=1 is the TOP
        // row, so going up means heading toward row 1, and y gets smaller.
        _currY--;
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // Down is index 3, the last slot in the array.
        if (!_mazeMap.TryGetValue((_currX, _currY), out var directions) || !directions[3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Mirror image of MoveUp: down heads toward row 6, so y gets bigger.
        _currY++;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}