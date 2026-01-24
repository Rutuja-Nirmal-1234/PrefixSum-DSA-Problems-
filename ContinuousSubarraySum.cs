// LeetCode 523 - Continuous Subarray Sum
// https://leetcode.com/problems/continuous-subarray-sum/

// Approach:
// Use Prefix Sum + HashMap (remainder → index)
//
// Key idea:
// If (prefixSum[i] % k) == (prefixSum[j] % k)
// then sum of subarray (i+1 to j) is divisible by k
//
// Store the FIRST occurrence of each remainder.
// Ensure subarray length >= 2.

// Time Complexity: O(n)
// Space Complexity: O(n)

public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        map[0] = -1; // remainder 0 at index -1

        int sum = 0;

        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];

            int mod = (k == 0) ? sum : sum % k;

            if (map.ContainsKey(mod)) {
                if (i - map[mod] >= 2) {
                    return true;
                }
            } else {
                // store first occurrence only
                map[mod] = i;
            }
        }

        return false;
    }
}
