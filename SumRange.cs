// LeetCode 303 - Range Sum Query - Immutable
// https://leetcode.com/problems/range-sum-query-immutable/

// Problem:
// Given an integer array nums, handle multiple queries of the form:
// sumRange(left, right) → return the sum of elements between indices left and right (inclusive).

// Approach: Prefix Sum
// 1. Build a prefix sum array where
//    prefix[i] = sum of elements from index 0 to i
// 2. To get range sum:
//    - If left == 0 → prefix[right]
//    - Else → prefix[right] - prefix[left - 1]

// Time Complexity:
// Constructor → O(n)
// Each SumRange query → O(1)

// Space Complexity: O(n)

public class NumArray {

    int[] prefix;

    public NumArray(int[] nums) {
        int n = nums.Length;
        prefix = new int[n];

        // Build prefix sum array
        prefix[0] = nums[0];
        for (int i = 1; i < n; i++) {
            prefix[i] = prefix[i - 1] + nums[i];
        }
    }

    public int SumRange(int left, int right) {
        if (left == 0) {
            return prefix[right];
        }
        return prefix[right] - prefix[left - 1];
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left, right);
 */
