// LeetCode 525 - Contiguous Array
// https://leetcode.com/problems/contiguous-array/

// Problem:
// Given a binary array nums, return the maximum length of a contiguous subarray
// with an equal number of 0s and 1s.

// Approach: Prefix Sum + HashMap
// 1. Treat 0 as -1 and 1 as +1
// 2. Maintain a running sum
// 3. If the same sum occurs again, the subarray between indices
//    has equal number of 0s and 1s

// Time Complexity: O(n)
// Space Complexity: O(n)

public class Solution {
    public int FindMaxLength(int[] nums) {

        Dictionary<int, int> map = new Dictionary<int, int>();

        // Base case: sum 0 occurs before array starts
        map[0] = -1;

        int sum = 0;
        int maxLen = 0;

        for (int i = 0; i < nums.Length; i++) {

            // Convert 0 to -1, 1 stays as 1
            sum += (nums[i] == 0) ? -1 : 1;

            if (map.ContainsKey(sum)) {
                maxLen = Math.Max(maxLen, i - map[sum]);
            } else {
                // Store first occurrence of this sum
                map[sum] = i;
            }
        }

        return maxLen;
    }
}
