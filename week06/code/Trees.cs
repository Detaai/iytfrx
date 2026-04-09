private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
{
    // Base case:
    // If the starting index goes past the ending index,
    // there are no elements left to process
    if (first > last)
        return;

    // Find the middle index of the current range
    int mid = (first + last) / 2;

    // Insert the middle value into the BST
    // This helps keep the tree balanced
    bst.Insert(sortedNumbers[mid]);

    // Recursively process the LEFT half of the array
    // (everything before the middle)
    InsertMiddle(sortedNumbers, first, mid - 1, bst);

    // Recursively process the RIGHT half of the array
    // (everything after the middle)
    InsertMiddle(sortedNumbers, mid + 1, last, bst);
}
