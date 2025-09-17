using System.Collections.Generic;
using UnityEngine;
public static class RandomUtils
{

    /// <summary>
    /// Get a random element from a list without repeating the last one
    /// </summary>
    private static int lastIndex = -1;
    public static T GetRandomNonRepeating<T>(List<T> list)
    {
        if (list == null || list.Count == 0)
            throw new System.Exception("List is empty!");

        int index;

        if (list.Count == 1)
        {
            // Only one element, always return it
            index = 0;
        }
        else
        {
            do
            {
                index = Random.Range(0, list.Count);
            }
            while (index == lastIndex);
        }

        lastIndex = index;
        return list[index];
    }



    public class NonRepeatingRandom<T>
    {
        private int lastIndex = -1;

        public T GetRandom(List<T> list)
        {
            if (list == null || list.Count == 0)
                throw new System.Exception("List is empty!");

            int index;

            if (list.Count == 1)
            {
                index = 0;
            }
            else
            {
                do
                {
                    index = Random.Range(0, list.Count);
                }
                while (index == lastIndex);
            }

            lastIndex = index;
            return list[index];
        }
    }




}