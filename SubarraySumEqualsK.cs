// LeetCode 560 - Subarray Sum Equals K
// https://leetcode.com/problems/subarray-sum-equals-k/

// Problem:
// Given an integer array nums and an integer k,
// return the total number of continuous subarrays whose sum equals k.

// Approach: Prefix Sum + HashMap
// 1. Maintain a running prefix sum
// 2. Use a dictionary to store frequency of prefix sums
// 3. If (currentSum - k) exists in map,
//    then there exists a subarray ending at current index with sum = k

// Time Complexity: O(n)
// Space Complexity: O(n)

public class Solution {
    public int SubarraySum(int[] nums, int k) {

        int sum = 0;
        int count = 0;

        // prefixSum -> frequency
        Dictionary<int, int> map = new Dictionary<int, int>();

        // Base case: prefix sum 0 exists once
        map[0] = 1;

        foreach (int num in nums) {
            sum += num;

            // Check if there is a prefix sum such that sum - k exists
            if (map.ContainsKey(sum - k)) {
                count += map[sum - k];
            }

            // Store current prefix sum frequency
            if (!map.ContainsKey(sum)) {
                map[sum] = 0;
            }
            map[sum]++;
        }

        return count;
    }
}
