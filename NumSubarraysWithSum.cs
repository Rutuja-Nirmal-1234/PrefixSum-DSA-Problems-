// LeetCode 930 - Binary Subarrays With Sum
// https://leetcode.com/problems/binary-subarrays-with-sum/

// Problem:
// Given a binary array nums and an integer goal,
// return the number of non-empty subarrays with sum equal to goal.

// Approach:
// Exactly(goal) = AtMost(goal) - AtMost(goal - 1)
// Use sliding window since array contains only 0s and 1s.

// Time Complexity: O(n)
// Space Complexity: O(1)

public class Solution {
    public int NumSubarraysWithSum(int[] nums, int goal) {
        return AtMost(nums, goal) - AtMost(nums, goal - 1);
    }

    private int AtMost(int[] nums, int goal) {
        if (goal < 0) return 0;

        int left = 0;
        int sum = 0;
        int result = 0;

        for (int right = 0; right < nums.Length; right++) {
            sum += nums[right];

            // Shrink window if sum exceeds goal
            while (sum > goal) {
                sum -= nums[left];
                left++;
            }

            // Count valid subarrays ending at right
            result += right - left + 1;
        }

        return result;
    }
}
