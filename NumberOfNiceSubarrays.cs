// LeetCode 1248 - Count Number of Nice Subarrays
// https://leetcode.com/problems/count-number-of-nice-subarrays/

// Problem:
// Given an array of integers nums and an integer k,
// return the number of subarrays with exactly k odd numbers.

// Approach:
// Exactly(k) = AtMost(k) - AtMost(k - 1)
// Use sliding window to count subarrays with at most k odd numbers.

// Time Complexity: O(n)
// Space Complexity: O(1)

public class Solution {
    public int NumberOfSubarrays(int[] nums, int k) {
        return AtMost(nums, k) - AtMost(nums, k - 1);
    }

    private int AtMost(int[] nums, int k) {
        int left = 0;
        int result = 0;

        for (int right = 0; right < nums.Length; right++) {

            // If current number is odd, reduce k
            if (nums[right] % 2 == 1) {
                k--;
            }

            // Shrink window if odd count exceeds k
            while (k < 0) {
                if (nums[left] % 2 == 1) {
                    k++;
                }
                left++;
            }

            // Count valid subarrays ending at right
            result += right - left + 1;
        }

        return result;
    }
}
