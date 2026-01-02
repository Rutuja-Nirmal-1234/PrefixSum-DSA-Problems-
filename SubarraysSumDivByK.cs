// LeetCode 974 - Subarray Sums Divisible by K
// https://leetcode.com/problems/subarray-sums-divisible-by-k/

// Problem:
// Given an array nums and an integer k,
// find the number of non-empty subarrays
// whose sum is divisible by k.

// Approach:
// Use prefix sums and modulo operation.
// Keep track of counts of prefix sums mod k in a dictionary.
// When the same mod value appears again,
// it means subarray sum between these indices is divisible by k.

// Time Complexity: O(n)
// Space Complexity: O(k)

public class Solution {
    public int SubarraysDivByK(int[] nums, int k) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        map[0] = 1;  // base case: prefix sum mod k == 0

        int count = 0;
        int prefix = 0;

        for (int i = 0; i < nums.Length; i++) {
            prefix += nums[i];

            // Handle negative prefix sums for mod
            int mod = ((prefix % k) + k) % k;

            if (map.ContainsKey(mod)) {
                count += map[mod];
                map[mod]++;
            } else {
                map[mod] = 1;
            }
        }

        return count;
    }
}
