using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    /// <summary>
    /// Insert a new node in the BST.
    /// </summary>
    public void Insert(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the tree is empty, set root
        if (_root is null)
        {
            _root = newNode;
        }
        else
        {
            _root.Insert(value);
        }
    }

    /// <summary>
    /// Check if the tree contains a value
    /// </summary>
    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Forward iterator
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
            yield return number;
    }

    private void TraverseForward(Node? node, List<int> values)
    {
        if (node != null)
        {
            TraverseForward(node.Left, values);   // left subtree first
            values.Add(node.Data);               // then node
            TraverseForward(node.Right, values); // then right subtree
        }
    }

    /// <summary>
    /// Problem 3: Reverse iterator
    /// </summary>
    public IEnumerable Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers)
            yield return number;
    }

    private void TraverseBackward(Node? node, List<int> values)
    {
        // Backward traversal: Right -> Node -> Left
        if (node != null)
        {
            TraverseBackward(node.Right, values); // right subtree first (largest values)
            values.Add(node.Data);                // then node
            TraverseBackward(node.Left, values);  // then left subtree
        }
    }

    /// <summary>
    /// Get the height of the tree
    /// </summary>
    public int GetHeight()
    {
        return _root?.GetHeight() ?? 0;
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
