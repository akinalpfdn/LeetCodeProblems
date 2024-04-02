using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
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
            // Reverse(2147483647);
            //LengthOfLastWord("   fly me   to   the moon  ");
            //IsPalindrome(-121);
           // MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
        }
        public bool IsIsomorphic(string s, string t)
        {
            for (int )
    }
        public static int MaxArea(int[] height)
        {
            int maxArea = 0;
            for (int i = 0; i <height.Length;i++)
            {
                int low = 0;
                int high = 0;
                bool lowEnded = false;
                bool highEnded = false;
                for(int j = 1;j<height.Length;)
                {
                    
                    if(i-j>=0 && !lowEnded)
                    {
                        if (height[i] <= height[i-j])
                        {
                            low++;
                        }
                        else
                        {
                            lowEnded = true;
                        }
                    }
                    if(i+j<height.Length && !highEnded)
                    {
                        if (height[i] <= height[i+j])
                        {
                            high++;
                        }
                        else
                        {  highEnded = true;}
                    }
                    j++;
                    if((i - j <= 0 ||lowEnded) &&(i + j >= height.Length && highEnded))
                    {
                        if (maxArea < height[i]*low)
                        {
                            maxArea = height[i]*low;
                        }
                        if(maxArea< height[i] * high)
                        {
                            maxArea = height[i] * high;
                        }
                    }
                }
            }
                return maxArea;
        }
        public static bool IsPalindrome(int x)
        {
            string forward = x.ToString();
            StringBuilder sb = new StringBuilder();
            for(int i=forward.Length-1; i>=0;i--)
            {
                sb.Append(forward[i]);
            }
            return forward == sb.ToString();
        }
        public static int LengthOfLastWord(string s)
        {
           s = s.Trim();
            var length = s.Length;
            var lst = s.LastIndexOf(" ");
            return s.Length-1- lst;
    }
        public int MyAtoi(string s)
        {
            s = s.Trim();
            HashSet<char> set = new HashSet<char>(){'0','1','2','3','4'
                , '5', '6', '7', '8', '9' };
            bool signFound = false;
            int mult = 1;
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if (!signFound)
                {
                    signFound = true;
                    if (c == '-')
                    {
                        mult = -1;
                    }
                    else if (c == '+')
                    {
                        mult = 1;
                    }
                }
                if (!set.Contains(c))
                {
                    break;
                }
                else
                {
                    sb.Append(c);
                }

            }
            if (sb.Length == 0) return 0;
            int result;
            if (Int32.TryParse(sb.ToString(), out result))
            { return result * mult; }
            else if (mult == -1)
            {
                return Int32.MinValue;
            }
            return Int32.MaxValue;
        }
        public static int Reverse(int x)
        {
            string s = x.ToString();
            StringBuilder sb = new StringBuilder();
            int  mult = 1;
            int finishIndex = 0;
            if (s[0]=='-')
            {
                mult = -1;
                finishIndex =1;
            }
            for(int i = (s.Length-1);i>=0+finishIndex;i--)
            {
                sb.Append(s[i]);
            }
            int result;
            if(Int32.TryParse(sb.ToString(),out result))
            {
                return result*mult;
            }
            return 0;
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
