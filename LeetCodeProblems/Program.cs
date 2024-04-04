﻿using System;
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
             //MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
             MaxArea(new int[] { 2, 3, 4, 5, 18, 17, 6 });
            // IsIsomorphic("badc", "baba");
            /* Insert(new int[][] { 
                 new int[] { 1, 3 },
                 new int[] { 6, 8 },
                 new int[] { 9, 9 },
             }, new int[] { 7, 8 });
            */
        }

        public void deneme()
        {
            webControls dropDown = new webControls();
            EbaControls detailsGrid = new EbaControls();
            webControls dropDown2 = new webControls();
            EbaControls detailsGrid2 = new EbaControls();
            webControls dropDown3 = new webControls();
            EbaControls detailsGrid3 = new EbaControls();
            webControls dropDown4 = new webControls();
            EbaControls detailsGrid4 = new EbaControls();
            List<Controls> list= new List<Controls>() { detailsGrid,detailsGrid2,detailsGrid3,dropDown,dropDown2};
            foreach(var item in list)
            {
                var name =item.Name;
               ( (EbaControls)item).enabled = true;
            }
            Controls control = new Controls();
            Controls wb = new webControls();
            var vs =((webControls)wb).visible;

            dropDown.getId();
        }

        public static int MaxArea(int[] height)
        {
            int maxArea = 0;
            int len = height.Length-1;
            for (int i = 0; i <= len; i++)
            {
                int low = 0;
                int high = 0;
                for (int j = 0; j <= len;j++)
                {

                    if (i > j )
                    {
                        if (height[i] <= height[j])
                        {
                            low = i-j;
                        }
                    }
                    if (i < len-j )
                    {
                        if (height[i] <= height[len- j])
                        {
                            high = len - j - i;
                        }
                    }
                    if(low!=0 &&low> len - j - i)
                    {
                        if (maxArea < height[i] * low)
                        {
                            maxArea = height[i] * low;
                        }
                        break;
                    }
                    else if(high != 0 && high >i-j)
                    {
                        if (maxArea < height[i] * high)
                        {
                            maxArea = height[i] * high;
                        }
                        break;
                    }
                    //j++;

                    if ((i <= j || low!=0) && (i >= len - j || high!=0))
                    {
                        if (maxArea < height[i] * low)
                        {
                            maxArea = height[i] * low;
                        }
                        if (maxArea < height[i] * high)
                        {
                            maxArea = height[i] * high;
                        }
                        break;
                    }
                }
            }
            return maxArea;
        }
        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> result = new List<int[]>();
            int[] mergedİnterval = new int[2] { -1, -1 };
            int index =-1;
            bool added = false;
            foreach (int[] arr in intervals)
            {
                if (!added)
                {
                    index++;
                merged:
                    if (mergedİnterval[0] != -1)
                    {
                        if (arr[0] <= newInterval[1] && arr[1] >= newInterval[1])//end of new interval within existed one so end of merge is existed
                        {
                            mergedİnterval[1] = arr[1];
                            result.Add(new int[] { mergedİnterval[0], mergedİnterval[1] });
                            mergedİnterval[0] = -1;
                            added = true;
                        }
                        else if (arr[0] > newInterval[1])//before existed new one is ended so merged end is new one.
                        {
                            mergedİnterval[1] = newInterval[1];
                            result.Add(new int[] { mergedİnterval[0], mergedİnterval[1] });
                            mergedİnterval[0] = -1;
                            result.Add(arr);
                            added = true;

                        }
                        else if (index == intervals.Length - 1)
                        {
                            if (arr[1] <= newInterval[1])
                            {
                                mergedİnterval[1] = newInterval[1];
                                result.Add(new int[] { mergedİnterval[0], mergedİnterval[1] });
                            }
                            else
                            {
                                mergedİnterval[1] = arr[1];
                                result.Add(new int[] { mergedİnterval[0], mergedİnterval[1] });
                            }
                        }
                    }
                    else if (arr[0] < newInterval[0] && arr[1] > newInterval[1])
                    {
                        return intervals;//the new one is subinterval of one of them so intervals wont change.
                    }
                    else if (arr[0] <= newInterval[0] && arr[1] > newInterval[0] && arr[1] <= newInterval[1])//the  start of new one btw existed but end is not merge needed
                    {
                        mergedİnterval[0] = arr[0];
                        goto merged;
                    }
                    else if (arr[0] < newInterval[0] && arr[1] >= newInterval[0] && arr[1] <= newInterval[1])//the  start of new one btw existed but end is not merge needed
                    {
                        mergedİnterval[0] = arr[0];
                        goto merged;
                    }
                    else if (arr[0] > newInterval[0] && arr[1] < newInterval[1])
                    {
                        mergedİnterval[0] = newInterval[0];
                        goto merged;
                    }
                    else if (arr[1] < newInterval[0])
                    {
                        result.Add(arr);


                        if (index == intervals.Length - 1)
                        {
                            result.Add(newInterval);
                            added = true;
                        }
                    }
                    else if (arr[0] > newInterval[1])
                    {
                        result.Add(newInterval);
                        result.Add(arr);
                        added = true;
                    }
                    else if (arr[0] >= newInterval[0] && arr[1] >= newInterval[1] && arr[0] <= newInterval[1])
                    {
                        mergedİnterval[0] = newInterval[0];
                        goto merged;
                    }
                }
                else
                {
                    result.Add(arr);
                }
            }
            if (result.Count() == 0)
                result.Add(newInterval);
            return result.ToArray();

        }

        public IList<IList<string>> Partition(string s)
        {
            IList<IList<string>> result = new List<IList<string>>();
            IList<string> current = new List<string>();
            PartitionHelper(s, 0, current, result);
            return result;
        }

        private void PartitionHelper(string s, int start, IList<string> current, IList<IList<string>> result)
        {
            if (start == s.Length)
            {
                result.Add(new List<string>(current));
                return;
            }

            for (int end = start; end < s.Length; end++)
            {
                if (IsPalindrome(s, start, end))
                {
                    current.Add(s.Substring(start, end - start + 1));
                    PartitionHelper(s, end + 1, current, result);
                    current.RemoveAt(current.Count - 1);
                }
            }
        }
        private bool IsPalindrome(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        public static bool IsIsomorphic(string s, string t)
        {
            Dictionary<char,char> pairs = new Dictionary<char,char>();
            Dictionary<char,char> pairs2 = new Dictionary<char,char>();
            for (int i = 0;i<s.Length;i++)
            {
                if (pairs.ContainsKey(s[i]))
                {
                    if (pairs[s[i]] != t[i])
                        return false;
                }
                else
                {
                    pairs[s[i]] = t[i];
                }

                if (pairs2.ContainsKey(t[i]))
                {
                    if (pairs2[t[i]] != s[i])
                        return false;
                }
                else
                {
                    pairs2[t[i]] = s[i];
                }
            }
            return true;
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
