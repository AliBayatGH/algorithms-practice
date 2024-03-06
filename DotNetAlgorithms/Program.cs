using System.Text;


// Binary Search
int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
int target = 6;
Console.WriteLine($"Binary Search: Index of {target} in array: {BinarySearch(arr, target)}");

// Largest and Smallest Number in an Array
int[] arr2 = { 4, 2, 7, 1, 9, 3 };
int min, max;
FindMinMax(arr2, out min, out max);
Console.WriteLine($"Largest number in array: {max}, Smallest number in array: {min}");

// Pairs with Sum
int[] arr3 = { 1, 2, 3, 4, 5, 6 };
int sum = 7;
List<(int, int)> pairs = FindPairsWithSum(arr3, sum);
Console.WriteLine($"Pairs with sum {sum}: ");
foreach (var pair in pairs)
{
    Console.WriteLine($"({pair.Item1}, {pair.Item2})");
}

// Middle Element of a Singly Linked List
ListNode head = new ListNode(1);
head.next = new ListNode(2);
head.next.next = new ListNode(3);
head.next.next.next = new ListNode(4);
head.next.next.next.next = new ListNode(5);
Console.WriteLine($"Middle Element of a Singly Linked List: {FindMiddle(head).val}");

// Reverse a Linked List
ListNode reversed = ReverseLinkedList(head);
Console.Write("Reversed Linked List: ");
while (reversed != null)
{
    Console.Write($"{reversed.val} ");
    reversed = reversed.next;
}
Console.WriteLine();

// Cycle Detection in a Linked List
ListNode headWithCycle = new ListNode(1);
headWithCycle.next = new ListNode(2);
headWithCycle.next.next = new ListNode(3);
headWithCycle.next.next.next = headWithCycle.next; // Create cycle
Console.WriteLine($"Does the Linked List contain a cycle? {HasCycle(headWithCycle)}");
ListNode startNode = FindCycleStart(headWithCycle);
Console.WriteLine($"Starting node of the cycle: {(startNode != null ? startNode.val.ToString() : "No cycle")}");

// Anagrams of Strings
string s1 = "listen";
string s2 = "silent";
Console.WriteLine($"Are '{s1}' and '{s2}' anagrams? {AreAnagrams(s1, s2)}");

// Palindrome Check
string palindrome = "racecar";
Console.WriteLine($"Is '{palindrome}' a palindrome? {IsPalindrome(palindrome)}");

// Remove Duplicates from an Array
int[] arr4 = { 1, 2, 3, 2, 4, 5, 6, 1 };
RemoveDuplicates(arr4);
Console.Write("Array after removing duplicates: ");
foreach (var item in arr4)
{
    Console.Write($"{item} ");
}
Console.WriteLine();

// Preorder Traversal in a Binary Tree
TreeNode root = new TreeNode(1);
root.left = new TreeNode(2);
root.right = new TreeNode(3);
List<int> preorder = new List<int>();
PreorderTraversal(root, preorder);
Console.Write("Preorder Traversal: ");
foreach (var item in preorder)
{
    Console.Write($"{item} ");
}
Console.WriteLine();

// Inorder Traversal in a Binary Tree
List<int> inorder = new List<int>();
InorderTraversal(root, inorder);
Console.Write("Inorder Traversal: ");
foreach (var item in inorder)
{
    Console.Write($"{item} ");
}
Console.WriteLine();

// Binary Search Tree Implementation
BinarySearchTree bst = new BinarySearchTree();
bst.Insert(5);
bst.Insert(3);
bst.Insert(7);
Console.WriteLine($"Does Binary Search Tree contain 3? {bst.Search(3)}");

// Reverse Words in a Sentence
string sentence = "Hello World";
Console.WriteLine($"Reversed sentence: {ReverseWords(sentence)}");

// Duplicate Characters in a String
string s = "hello world";
Console.WriteLine($"Duplicate characters in '{s}': {PrintDuplicateCharacters(s)}");

// Insertion Sort
int[] arr5 = { 5, 2, 4, 6, 1, 3 };
InsertionSort(arr5);
Console.Write("Array after Insertion Sort: ");
foreach (var item in arr5)
{
    Console.Write($"{item} ");
}
Console.WriteLine();

// Count Character Occurrence
string str = "hello";
char targetChar = 'l';
Console.WriteLine($"Occurrence of '{targetChar}' in '{str}': {CountOccurrences(str, targetChar)}");

// Find Character Occurrence
string str2 = "hello";
char targetChar2 = 'l';
Console.WriteLine($"First occurrence index of '{targetChar2}' in '{str2}': {FindCharacterOccurrence(str2, targetChar2)}");

// Remove Duplicates from an Array
int[] arr6 = { 1, 2, 3, 2, 4, 5, 6, 1 };
RemoveDuplicates(arr6);
Console.Write("Array after removing duplicates: ");
foreach (var item in arr6)
{
    Console.Write($"{item} ");
}
Console.WriteLine();

// Missing Number in an Integer Array
int[] arr7 = { 1, 2, 3, 4, 6, 7, 8, 9, 10 }; // Missing 5
Console.WriteLine($"Missing number in array: {FindMissingNumber(arr7)}");

// How do you perform a binary search in a given array?
// Binary search works on sorted arrays. It repeatedly divides the search interval in half.
// Time Complexity: O(log n)
// Space Complexity: O(1)
// Algorithmic runtime: Logarithmic
int BinarySearch(int[] arr, int target)
{
    int low = 0;
    int high = arr.Length - 1;

    while (low <= high)
    {
        int mid = low + (high - low) / 2;

        if (arr[mid] == target)
            return mid;
        else if (arr[mid] < target)
            low = mid + 1;
        else
            high = mid - 1;
    }

    return -1; // Element not found
}

// How do you find the largest and smallest number in an unsorted integer array?
// Iterate through the array, keeping track of the current minimum and maximum values.
// Time Complexity: O(n)
// Space Complexity: O(1)
// Algorithmic runtime: Linear
void FindMinMax(int[] arr, out int min, out int max)
{
    min = max = arr[0];

    foreach (int num in arr)
    {
        if (num < min)
            min = num;
        else if (num > max)
            max = num;
    }
}

// How do you find all pairs of an integer array whose sum is equal to a given number?
// Use a HashSet to store elements as we traverse the array. For each element, check if its complement (target - current element) exists in the HashSet.
// Time Complexity: O(n)
// Space Complexity: O(n)
// Algorithmic runtime: Linear
List<(int, int)> FindPairsWithSum(int[] arr, int target)
{
    List<(int, int)> pairs = new List<(int, int)>();
    HashSet<int> complements = new HashSet<int>();

    foreach (int num in arr)
    {
        int complement = target - num;
        if (complements.Contains(complement))
            pairs.Add((num, complement));
        complements.Add(num);
    }

    return pairs;
}

// How do you find the middle element of a singly linked list in one pass?
// Use two pointers - a slow pointer and a fast pointer. The slow pointer moves one node at a time while the fast pointer moves two nodes at a time.
// When the fast pointer reaches the end of the list, the slow pointer will be at the middle node.
// Time Complexity: O(n)
// Space Complexity: O(1)
// Algorithmic runtime: Linear
ListNode FindMiddle(ListNode head)
{
    ListNode slow = head;
    ListNode fast = head;

    while (fast != null && fast.next != null)
    {
        slow = slow.next;
        fast = fast.next.next;
    }

    return slow;
}

// How do you reverse a linked list?
// Iterate through the list, reversing the pointers of each node to point to the previous node instead of the next node.
// Time Complexity: O(n)
// Space Complexity: O(1)
// Algorithmic runtime: Linear
ListNode ReverseLinkedList(ListNode head)
{
    ListNode prev = null;
    ListNode current = head;

    while (current != null)
    {
        ListNode nextNode = current.next;
        current.next = prev;
        prev = current;
        current = nextNode;
    }

    return prev; // New head of the reversed list
}

// How do you check if a given linked list contains a cycle? How do you find the starting node of the cycle?
// Use Floyd's Tortoise and Hare algorithm. Move one pointer (slow) by one step and another pointer (fast) by two steps.
// If they meet, there is a cycle. To find the starting node of the cycle, reset one pointer to the head and move both pointers at the same speed until they meet again.
// Time Complexity: O(n)
// Space Complexity: O(1)
bool HasCycle(ListNode head)
{
    ListNode slow = head;
    ListNode fast = head;

    while (fast != null && fast.next != null)
    {
        slow = slow.next;
        fast = fast.next.next;

        if (slow == fast)
            return true;
    }

    return false;
}

ListNode FindCycleStart(ListNode head)
{
    ListNode slow = head;
    ListNode fast = head;

    while (fast != null && fast.next != null)
    {
        slow = slow.next;
        fast = fast.next.next;

        if (slow == fast)
        {
            slow = head;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return slow; // Starting node of the cycle
        }
    }

    return null; // No cycle
}

// How do you check if two strings are anagrams of each other?
// Sort both strings and compare them.
// Time Complexity: O(n log n) for sorting
// Space Complexity: O(n)
bool AreAnagrams(string s1, string s2)
{
    if (s1.Length != s2.Length)
        return false;

    char[] chars1 = s1.ToCharArray();
    char[] chars2 = s2.ToCharArray();

    Array.Sort(chars1);
    Array.Sort(chars2);

    return new string(chars1) == new string(chars2);
}

// How do you check if a given string is a palindrome?
// Use two pointers, one starting from the beginning and the other starting from the end.
// Compare characters at each position until they meet or cross each other.
// Time Complexity: O(n)
// Space Complexity: O(1)
bool IsPalindrome(string s)
{
    int left = 0;
    int right = s.Length - 1;

    while (left < right)
    {
        if (s[left] != s[right])
            return false;
        left++;
        right--;
    }

    return true;
}

// How do you remove duplicates from an array in place?
// Use two pointers - one for iterating through the array and another for storing the next available position to place unique elements.
// Time Complexity: O(n)
// Space Complexity: O(1)
void RemoveDuplicates(int[] arr)
{
    if (arr.Length == 0)
        return;

    int index = 1;

    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] != arr[index - 1])
        {
            arr[index] = arr[i];
            index++;
        }
    }
}

// How do you perform preorder traversal in a given binary tree?
// Recursively visit the root node, then the left subtree, and finally the right subtree.
// Time Complexity: O(n)
// Space Complexity: O(h), where h is the height of the tree
void PreorderTraversal(TreeNode root, List<int> result)
{
    if (root == null)
        return;

    result.Add(root.val); // Visit root node
    PreorderTraversal(root.left, result); // Visit left subtree
    PreorderTraversal(root.right, result); // Visit right subtree
}

// How do you perform an inorder traversal in a given binary tree?
// Recursively visit the left subtree, then the root node, and finally the right subtree.
// Time Complexity: O(n)
// Space Complexity: O(h), where h is the height of the tree
void InorderTraversal(TreeNode root, List<int> result)
{
    if (root == null)
        return;

    InorderTraversal(root.left, result); // Visit left subtree
    result.Add(root.val); // Visit root node
    InorderTraversal(root.right, result); // Visit right subtree
}



// How do you reverse words in a given sentence without using any library method?
// Reverse the entire sentence, then reverse each word individually.
// Time Complexity: O(n)
// Space Complexity: O(1)
string ReverseWords(string s)
{
    char[] chars = s.ToCharArray();
    int start = 0;

    // Reverse the entire string
    Reverse(chars, 0, chars.Length - 1);

    // Reverse each word individually
    for (int end = 0; end < chars.Length; end++)
    {
        if (chars[end] == ' ')
        {
            Reverse(chars, start, end - 1);
            start = end + 1;
        }
    }

    // Reverse the last word
    Reverse(chars, start, chars.Length - 1);

    return new string(chars);
}

void Reverse(char[] chars, int start, int end)
{
    while (start < end)
    {
        char temp = chars[start];
        chars[start] = chars[end];
        chars[end] = temp;
        start++;
        end--;
    }
}

// How do you print duplicate characters from a string?
// Use a HashSet to store characters that have been encountered, and a StringBuilder to build the result.
// Time Complexity: O(n)
// Space Complexity: O(n)
string PrintDuplicateCharacters(string s)
{
    HashSet<char> seen = new HashSet<char>();
    StringBuilder duplicates = new StringBuilder();

    foreach (char c in s)
    {
        if (!seen.Contains(c))
            seen.Add(c);
        else if (!duplicates.ToString().Contains(c.ToString()))
            duplicates.Append(c);
    }

    return duplicates.ToString();
}

// How do you implement an insertion sort algorithm?
// Insertion sort iterates, consuming one input element each repetition, and growing a sorted output list.
// Time Complexity: O(n^2)
// Space Complexity: O(1)
void InsertionSort(int[] arr)
{
    for (int i = 1; i < arr.Length; i++)
    {
        int key = arr[i];
        int j = i - 1;

        // Move elements of arr[0..i-1], that are greater than key, to one position ahead of their current position
        while (j >= 0 && arr[j] > key)
        {
            arr[j + 1] = arr[j];
            j--;
        }

        arr[j + 1] = key;
    }
}

// How do you count the occurrence of a given character in a string?
// Iterate through the string and count occurrences of the given character.
// Time Complexity: O(n)
// Space Complexity: O(1)
int CountOccurrences(string s, char target)
{
    int count = 0;

    foreach (char c in s)
    {
        if (c == target)
            count++;
    }

    return count;
}

// How do you find the occurrence of a given character in a string?
// Iterate through the string and return the index of the first occurrence of the character.
// Time Complexity: O(n)
// Space Complexity: O(1)
int FindCharacterOccurrence(string s, char target)
{
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] == target)
            return i;
    }
    return -1; // Character not found
}


// How do you find the missing number in a given integer array of 1 to 100?
// Calculate the sum of all numbers from 1 to 100 and subtract the sum of the given array from it.
// Time Complexity: O(n)
// Space Complexity: O(1)
int FindMissingNumber(int[] arr)
{
    int n = 100;
    int totalSum = n * (n + 1) / 2;
    int arrSum = 0;

    foreach (int num in arr)
        arrSum += num;

    return totalSum - arrSum;
}


// How do you implement a binary search tree?
// A binary search tree (BST) is a binary tree where nodes are arranged in a specific order. 
// Each node has a value, and for every node, all values in the left subtree are less than the node's value, 
// and all values in the right subtree are greater than the node's value.
// Time Complexity for insert, search, and delete operations: O(log n) on average, O(n) in worst case
// Space Complexity: O(n)
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class BinarySearchTree
{
    private TreeNode root;

    public void Insert(int value)
    {
        root = InsertRecursive(root, value);
    }

    private TreeNode InsertRecursive(TreeNode root, int value)
    {
        if (root == null)
        {
            root = new TreeNode(value);
            return root;
        }

        if (value < root.val)
            root.left = InsertRecursive(root.left, value);
        else if (value > root.val)
            root.right = InsertRecursive(root.right, value);

        return root;
    }

    public bool Search(int value)
    {
        return SearchRecursive(root, value);
    }

    private bool SearchRecursive(TreeNode root, int value)
    {
        if (root == null)
            return false;

        if (root.val == value)
            return true;

        if (value < root.val)
            return SearchRecursive(root.left, value);
        else
            return SearchRecursive(root.right, value);
    }
}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}
