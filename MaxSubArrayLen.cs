// LeetCode 325 - Maximum Size Subarray Sum Equals K
// https://leetcode.com/problems/maximum-size-subarray-sum-equals-k/

// Problem:
// Given an integer array nums and an integer k,
// return the maximum length of a subarray that sums to k.

// Approach: Prefix Sum + HashMap
// 1️ Maintain a running prefix sum.
// 2️ Use a dictionary to store the first occurrence of each prefix sum.
// 3️ If (currentSum - k) exists in the map, a subarray with sum = k exists.
// 4️ Track the maximum length found.

// Time Complexity: O(n)
// Space Complexity: O(n)

public class Solution {
    public int MaxSubArrayLen(int[] nums, int k) {

        Dictionary<int, int> map = new Dictionary<int, int>();
        int sum = 0;
        int maxLen = 0;

        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];

            // Case 1: Prefix sum itself equals k
            if (sum == k) {
                maxLen = i + 1;
            }

            // Case 2: (sum - k) already exists
            if (map.ContainsKey(sum - k)) {
                maxLen = Math.Max(maxLen, i - map[sum - k]);
            }

            // Store first occurrence of prefix sum
            if (!map.ContainsKey(sum)) {
                map[sum] = i;
            }
        }

        return maxLen;
    }
}
