using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

string test = "The quick brown fox jumps over the lazy dog";
// check for pangram in a string 
 bool IsPangram(string str)
{
    
    string alpha = "abcdefghiklmnopqrstvxyz";
    for (int i = 0; i < alpha.Length; i++)
    {
        var check = str.ToLower().Contains(alpha[i]);
        if (!check) return false;
    }
    return true;

}


// [0,1,0] find th occurance of odd number in an array
int find_it(int[] seq)
{
    for (int i = 0;i < seq.Length; i++)
    {
        int counter = 0;
        int c = seq[i];
        for(int j = 0; j<seq.Length; j++)
        {
            if(seq[j] == c)
                counter++;
        } 
        if (counter % 2 != 0) return c;
        counter = 0;
    }
    return -1;
}

//find the odd/even number in a string
 static int Find(params int[] integers)
{

    int odd = 0, even = 0, res = 0, resOdd = 0;
    for (int i = 0; i<integers.Length; i++)
    {
        if (integers[i] % 2 == 0)
        {
            even++;
            res = integers[i];
        }
        else
        {
            odd++;
            resOdd = integers[i];
        }

    }
    if (even >= 2) return resOdd; else return res;

}


// every a turns to t and vice versa 
static string MakeComplement(string dna)
{
    string res = "";
    
    foreach (var s in dna)
    { 
        switch (char.ToLower(s))
        {
            case 'a': res += "T"; break;
            case 't': res += "A"; break;
            case 'c': res += "G"; break;
            case 'g': res += "C"; break;

        }
    }
    return res;
}


//can this inputs turns into a trinagle
 static bool IsTriangle(int a, int b, int c)
{
    if(a>0 && b>0 && c>0)
    {
        if (b < a + c && c < a + b && a < b + c) return true;
        else return false;
    }  
    return false;
}


//spin the words with 5 or more chars
static string SpinWords(string sentence)
{
    
    List<string> res = new List<string>();
   foreach(var word in sentence.Split(" "))
    {
        if(word.Length >= 5)
        {
            res.Add(String.Join("", word.Reverse()));
        }else res.Add(word);
    }
    return string.Join(" ", res); 
}



// tribonacci series 
 double[] Tribonacci(int n ,double[] signature )
{   double[] res = new double[n] ;
    if (n == 0) return res;
    Array.Copy(signature,res,Math.Min(3,n));
    for(int i = 3; i < n; i++)
    {
        res[i] = signature[i-1] + signature[i-2] + signature[i-3]; 
    }
    return res;
}

//coverts numbers into roman eqvlent
static int solution(string roman)
{
  var chars = roman.ToCharArray();
    var result = 0;
    

    foreach (char c in chars)
    {
        switch (c)
        {
            case 'I':result += 1; break;
            case 'V': result += 5; break;
            case 'X': result += 10; break;
            case 'L': result += 50; break;
            case 'C': result += 100; break;
            case 'D': result += 500; break;
            case 'M': result += 1000; break; 
        }
    }
    if (roman.Contains("IV") || roman.Contains("IX")) result -= 2;
    if (roman.Contains("XL") || roman.Contains("XC")) result -= 20;
    if (roman.Contains("CD") || roman.Contains("CM")) result -= 200;



    return result; 

}


//returns the letter position in the alphabet
static string AlphabetPosition(string text)
{
    List<char> chars = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 
     'i', 'j', 'k', 'l' ,'m' , 'n','o','p','q','r','s','t','u','v','w','x','y','z'} ;
    string result="";
    int i = 0; 
   
        foreach(char c in text.ToLower())
        {
            if (chars.Contains(c)) {
            i = chars.IndexOf(c) + 1;
            result += i.ToString()+" ";
            }
        }
    return result.Trim(); 

   
}


//splits an array to pair of 2s 
static string[]SplitString(string str)
{
    if (str.Length % 2 != 0)
        str += " ";
    
    List<string> result = new List<string>();
    for (int i = 0; i < str.Length; i += 2)
    {
        if (str.Substring(i, 2).Trim().Length < 2) result.Add(str.Substring(i,2).Trim() + "_");    
        else result.Add(str.Substring(i,2));
    }
    return result.ToArray();
}


//find if two arrays is the same but raised to a power of 2 or not 
static Boolean same(int[] arr1 ,int[] arr2)
{
                      
    Dictionary<int, int> counter1=new Dictionary<int, int> { };
    Dictionary<int, int> counter2=new Dictionary<int, int> { };
    foreach (int i in arr1) if (counter1.ContainsKey(i)) counter1[i]++; else counter1.Add(i,1);
    foreach (int i in arr2) if (counter2.ContainsKey(i)) counter2[i]++; else counter2.Add(i,1);
    foreach (KeyValuePair<int, int> i in counter1)
    {
        if (!counter2.ContainsKey(Convert.ToInt32(Math.Pow(i.Key, 2)))) return false;
        if (counter1[i.Key]!= counter2[Convert.ToInt32(Math.Pow(i.Key,2))]) return false;
    }
     
    
    return true;
}
//find if its an anagram or not 
Boolean anagram(string inp1 , string inp2)
{
    Dictionary<char, int> counter1 = new Dictionary<char, int> { };
    Dictionary<char, int> counter2 = new Dictionary<char, int> { };
    foreach (char c in inp1) {
        if (c == ' ') continue;
        else if (counter1.ContainsKey(Char.ToLower(c))) counter1[Char.ToLower(c)]++;
        else counter1.Add(Char.ToLower(c), 1);
    };
    foreach (char c in inp2) { 
        if (c == ' ') continue; 
        else if (counter2.ContainsKey(Char.ToLower(c))) counter2[Char.ToLower(c)]++; 
        else counter2.Add(Char.ToLower(c), 1); };
    foreach(KeyValuePair<char,int> i in counter1)
    {
        if(!counter2.ContainsKey(i.Key)) return false;
        if(counter1[i.Key]!= counter2[i.Key]) return false;
    }
    return true;
}

// binary search
int Search(int[] nums, int target)
{
    int start = 0;
    int end = nums.Length - 1;

    while (start <= end)
    {
        int middle = (start + end) / 2;
        if (nums[middle] == target) return ++middle;
        if (target < nums[middle]) end = middle - 1;
        else start = middle ;
        return ++middle;

    }
    return -1;

}

 int SearchInsert(int[] nums, int target)
{
    int start = 0;
    int end = nums.Length-1;
  
    while(start < end)
    {
        int mid = start + (end - start) / 2;
        if(nums[mid] == target) return mid;
        if (target > nums[mid])
        
            start = mid + 1; // mid is excluded
        
        else
        
            end = mid; // mid is included
        
    }
  
        if (nums[start] < target) return end + 1; else return start;
        
}


int[] arr = { -11, 3, 4, 5, 7, 9 };
//square ints in array and then sort them 
int[] SortedSquares(int[] nums)
{
    int l = 0; int r = nums.Length - 1;
    int[] result = new int[nums.Length];
    for (int i = nums.Length-1; i >= 0; i--)
    {
        if (Convert.ToInt32(Math.Pow(nums[l],2)) > Convert.ToInt32(Math.Pow(nums[r], 2)))
             result[i] = Convert.ToInt32(Math.Pow(nums[l++], 2));
        else result[i] = Convert.ToInt32(Math.Pow(nums[r--], 2));
    }
    return result;
}

 // rotate arra with a shift of k
 void Rotate(int[] nums, int k)
{
    k %= nums.Length; // set the mirror point of the array 
    reverse(nums, 0, nums.Length - 1); // reverse the whole array 
    reverse(nums, 0, k - 1); // reverse the fisrt half of the array
    reverse(nums, k, nums.Length - 1); // reverse the second half 
}

 void reverse(int[] nums, int start, int end)
{
    while (start < end)
    {
        int temp = nums[start];
        nums[start] = nums[end];
        nums[end] = temp;
        start++;
        end--;
    }
}


