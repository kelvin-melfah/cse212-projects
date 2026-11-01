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
        // Plan:
        // 1. We already know exactly how many values we need (length), so a fixed-size
        //    array is the natural fit. No need for a List that grows as we go.
        // 2. Walk through each index from 0 up to length - 1.
        // 3. The first multiple is number * 1, the second is number * 2, and so on, so
        //    the value at index i is number * (i + 1). The "+ 1" is there because the
        //    indexes start at 0 but the multiples start at 1. Without it we would
        //    begin the array with 0 instead of the starting number.
        // 4. Return the finished array.

        // Step 1: make the array at the size the caller asked for.
        double[] multiples = new double[length];

        // Step 2 and 3: fill each slot with the matching multiple.
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        // Step 4: hand the result back.
        return multiples;
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
        // Plan:
        // 1. Rotating right by 'amount' really just means the last 'amount' items jump
        //    to the front, and everything else slides over behind them. So instead of
        //    shifting items one at a time, I can think of it as cutting the list in
        //    two pieces and swapping their order.
        // 2. Work out where the cut goes. The tail starts at data.Count - amount.
        //    For {1..9} with amount 3 that is index 6, which is where 7, 8, 9 begin.
        // 3. Copy the tail out with GetRange. I copy it before removing anything,
        //    because once the items are removed I can't read them anymore.
        // 4. Remove that same tail from the end of the original list using RemoveRange.
        // 5. Insert the saved tail at index 0 with InsertRange. The remaining items
        //    get pushed back automatically, which gives us the rotated order.
        // 6. Edge case: amount can equal data.Count. Then the "tail" is the whole list,
        //    we remove everything and put it straight back, so the list comes out
        //    unchanged. That is correct, since a full rotation lands where it started,
        //    and it means we don't need a special case or modulo.

        // Step 2: find where the tail begins.
        int startOfTail = data.Count - amount;

        // Step 3: copy out the items that will move to the front.
        List<int> tail = data.GetRange(startOfTail, amount);

        // Step 4: take those items off the end of the original list.
        data.RemoveRange(startOfTail, amount);

        // Step 5: put them at the front. The list is changed in place, so nothing is returned.
        data.InsertRange(0, tail);
    }
}