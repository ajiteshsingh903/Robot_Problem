using System;
using System.Collections.Generic;
using System.Linq;


namespace Assignment_1_2021
//My First Assignment in C#
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the Moves of Robot:");
            string moves = Console.ReadLine(); //storing the input in moves
            var p = new Program();

            bool pos = p.JudgeCircle(moves); //Calling the function
            if (pos)
            {
                Console.WriteLine("The Robot return’s to initial Position (0,0)");
            }
            else
            {
                Console.WriteLine("The Robot doesn’t return to the Initial Postion (0,0)");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s = Console.ReadLine(); //reading the string for input
            bool flag = p.CheckIfPangram(s); //Calling the function
            if (flag) //checking both conditions 
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:

            int[] arr = { 1, 2, 3, 1, 1, 3 }; // using pre-defined input 
            int gp = p.NumIdenticalPairs(arr); //Calling the function
            Console.WriteLine("Q3:");
            Console.WriteLine("The number of IdenticalPairs in the array are {0}:", gp); //displaying the output 

            //Question 4:
            int[] arr1 = { 3, 1, 4, 1, 5 }; // using pre-defined input 
            Console.WriteLine("Q4:");
            int pivot = p.PivotIndex(arr1); //Calling the function

            if (pivot > 0) //checking both conditions for pivot index
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            String merged = MergeAlternately(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);

            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();
        }

        public bool JudgeCircle(string moves)
        {

            int L_R = 0, U_D = 0;
            foreach (char i in moves)
            {
                if (i == 'L')
                    L_R++;
                else if (i == 'R')
                    L_R--;
                else if (i == 'U')
                    U_D++;
                else if (i == 'D')
                    U_D--;
            }
            return (L_R == 0 && U_D == 0);


        }


        public bool CheckIfPangram(string sentence)
        {
            if (sentence.Length < 26) return false;

            for (var i = 1; i <= 26; i++)
                if (sentence.IndexOf((char)(i + 96)) < 0)
                    return false;

            return true;
        }
        public int NumIdenticalPairs(int[] nums)
        {


            var res = 0;
            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        res++;
                    }
                }
            }
            return res;

        }


        public int PivotIndex(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            int leftSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i != 0)
                    leftSum += nums[i - 1];
                if (sum - nums[i] - leftSum == leftSum)
                    return i;
            }
            return -1;
        }



        private static string MergeAlternately(string word1, string word2)
        {
            int i = 0, j = i + 1, k = 0;
            char[] c = new char[word1.Length + word2.Length];


            while (i < c.Length)
            {
                if (i < word1.Length)
                {
                    c[k] = word1[i];
                }
                else
                {
                    break;
                }

                if (i < word2.Length)
                {
                    c[k + 1] = word2[i];
                }
                else
                {
                    break;
                }
                i++;
                k += 2;
            }

            for (; i < word1.Length; i++)
            {
                c[k++] = word1[i];
            }

            for (; i < word2.Length; i++)
            {
                c[k++] = word2[i];
            }


            return new string(c);
        }
        private static string ToGoatLatin(string sentence)
        {
            string wordCount = "maa";
            string vowels = "aeiouAEIUO";
            string answer = "";
            int space;
            sentence = sentence.Insert(0, " ");

            //Increment to the next space location after processing the previous word
            for (int x = sentence.IndexOf(" "); x > -1; x = sentence.IndexOf(" ", x + 1))
            {
                space = sentence.IndexOf(" ", x + 1); //Get index of next space
                if (vowels.IndexOf(sentence[x + 1]) != -1)
                { // Is a vowel
                    answer += $"{sentence.Substring(x + 1, space != -1 ? space - x - 1 : sentence.Length - x - 1)}{wordCount} ";
                }
                else
                { //Is a consonant
                    answer += $"{sentence.Substring(x + 2, space != -1 ? space - x - 2 : sentence.Length - x - 2)}{sentence[x + 1]}{wordCount} ";
                }
                wordCount += "a";
            }
            return answer.TrimEnd();
        }
    }
}








