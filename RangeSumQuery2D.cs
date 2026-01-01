// LeetCode 304 - Range Sum Query 2D – Immutable
// https://leetcode.com/problems/range-sum-query-2d-immutable/

// Problem:
// Given a 2D matrix, handle multiple queries of the form:
// sum of elements inside the rectangle defined by
// (row1, col1) to (row2, col2), inclusive.

// Approach: 2D Prefix Sum
// prefix[r][c] stores sum of elements from (0,0) to (r-1,c-1)
//
// Formula to build prefix:
// prefix[r][c] = matrix[r-1][c-1]
//                + prefix[r-1][c]
//                + prefix[r][c-1]
//                - prefix[r-1][c-1]
//
// Formula to query sum region:
// sum = prefix[row2+1][col2+1]
//       - prefix[row1][col2+1]
//       - prefix[row2+1][col1]
//       + prefix[row1][col1]

// Time Complexity:
// Constructor → O(rows * cols)
// SumRegion  → O(1)
//
// Space Complexity: O(rows * cols)

public class NumMatrix {

    private int[,] prefix;

    public NumMatrix(int[][] matrix) {

        int rows = matrix.Length;
        int cols = matrix[0].Length;

        // Extra row and column for easy boundary handling
        prefix = new int[rows + 1, cols + 1];

        for (int r = 1; r <= rows; r++) {
            for (int c = 1; c <= cols; c++) {
                prefix[r, c] =
                    matrix[r - 1][c - 1]
                    + prefix[r - 1, c]
                    + prefix[r, c - 1]
                    - prefix[r - 1, c - 1];
            }
        }
    }

    public int SumRegion(int row1, int col1, int row2, int col2) {

        return prefix[row2 + 1, col2 + 1]
             - prefix[row1, col2 + 1]
             - prefix[row2 + 1, col1]
             + prefix[row1, col1];
    }
}

/*
Usage:
NumMatrix obj = new NumMatrix(matrix);
int sum = obj.SumRegion(row1, col1, row2, col2);
*/
