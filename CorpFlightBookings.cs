// LeetCode 1109 - Corporate Flight Bookings
// https://leetcode.com/problems/corporate-flight-bookings/

// Approach: Difference Array + Prefix Sum
//
// Idea:
// Instead of updating every flight in a range [start, end],
// use a difference array to mark only the boundaries.
//
// Steps:
// 1. For each booking [start, end, seats]:
//    - Add seats at index (start - 1)
//    - Subtract seats at index end (if end < n)
// 2. Build prefix sum to get final seat counts
//
// Time Complexity: O(n + bookings.Length)
// Space Complexity: O(n)

public class Solution {
    public int[] CorpFlightBookings(int[][] bookings, int n) {

        // Step 1: Difference array
        int[] result = new int[n];

        // Step 2: Apply bookings
        foreach (var booking in bookings) {
            int start = booking[0];
            int end = booking[1];
            int seats = booking[2];

            result[start - 1] += seats;

            if (end < n) {
                result[end] -= seats;
            }
        }

        // Step 3: Prefix sum
        for (int i = 1; i < n; i++) {
            result[i] += result[i - 1];
        }

        return result;
    }
}
