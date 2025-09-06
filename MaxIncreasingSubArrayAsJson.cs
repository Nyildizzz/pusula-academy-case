using System;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

public static class MaxIncreasingSubArray
{
    public static string MaxIncreasingSubArrayAsJson(List<int> numbers)
    {
        if (numbers == null || numbers.Count == 0)
            return JsonSerializer.Serialize(new List<int>());

        List<int> maxSubarray = new List<int>();
        List<int> current = new List<int> { numbers[0] };

        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                current.Add(numbers[i]);
            }
            else
            {
                if (current.Sum() > maxSubarray.Sum())
                    maxSubarray = new List<int>(current);

                current = new List<int> { numbers[i] };
            }
        }

        if (current.Sum() > maxSubarray.Sum())
            maxSubarray = current;

        return JsonSerializer.Serialize(maxSubarray);
    }
}
