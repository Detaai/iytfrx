public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person
        // 
        // PLAN
        // 1. Create an array to store the multiples.
        // 2. Use a loop to go through each position of the array.
        // 3. Multiply the number by (index + 1).
        // 4. Store the result in the array.
        // 5. Return the array when finished..

    double[] result = new double[length];

    for (int i = 0; i < length; i++)
    {
        result[i] = number * (i + 1);
    }

    return result;
}

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    // PLAN
    // 1. Find where to split the list.
    // 2. Get the last 'amount' items.
    // 3. Get the first part of the list.
    // 4. Clear the list.
    // 5. Add the last items first.
    // 6. Add the first items after.

    int splitIndex = data.Count - amount;

    List<int> lastPart = data.GetRange(splitIndex, amount);
    List<int> firstPart = data.GetRange(0, splitIndex);

    data.Clear();
    data.AddRange(lastPart);
    data.AddRange(firstPart);
}
    }

