using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Convert("PAYPALISHIRING", 4);
        }
        public int Reverse(int x)
        {
            string
    }

        public static string Convert(string s, int numRows)
        {

            List<List<char>> matrix = new List<List<char>>();
            matrix.Add(new List<char>());   

            bool isdiagonal = true;
            int row = 0;
            foreach (char c in s)
            {
                if (matrix[0].Count() == 0)
                {
                    matrix[row].Add(c);
                    isdiagonal = !isdiagonal;
                    row++;
                    matrix.Add(new List<char>());
                    continue;
                }
                if (numRows == 1)
                {
                    matrix[row].Add( c);
                    continue;
                }
                if (row == 0)
                {
                    isdiagonal = !isdiagonal;

                    row++;
                }
                else if (row == numRows)
                {
                    isdiagonal = !isdiagonal;
                    row = numRows - 1;
                }
                if (isdiagonal)
                {
                    row--; 
                    matrix[row].Add(c);
                }
                else
                {
                    matrix[row].Add(c);
                    row++;
                    if(numRows > matrix.Count)
                    matrix.Add(new List<char>());
                }
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach(List<char> list in matrix)
            {
                foreach(char c in list)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString();

        }
    }
}
