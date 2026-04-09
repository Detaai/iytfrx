public static class Trees
{
    /// <summary>
    /// Problem 5: Create a balanced BST from a sorted list
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Problem 5 helper: recursively insert middle values to keep the tree balanced
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: nothing to insert
        if (first > last)
            return;

        // Middle index
        int mid = (first + last) / 2;

        // Insert the middle value
        bst.Insert(sortedNumbers[mid]);

        // Recurse on left half
        InsertMiddle(sortedNumbers, first, mid - 1, bst);

        // Recurse on right half
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}
