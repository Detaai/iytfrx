public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Problem 1: Insert a value into the tree.
    /// Only unique values are added (no duplicates allowed)
    /// </summary>
    public void Insert(int value)
    {
        if (value == Data)
        {
            // Ignore duplicates
            return;
        }
        else if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Problem 2: Check if a value exists in the tree
    /// </summary>
    public bool Contains(int value)
    {
        if (value == Data)
            return true;
        else if (value < Data)
            return Left != null && Left.Contains(value);
        else
            return Right != null && Right.Contains(value);
    }

    /// <summary>
    /// Problem 4: Get the height of this node/subtree
    /// </summary>
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
