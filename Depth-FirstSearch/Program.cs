
 // Leetcode: 113
 // Definition for a binary tree node.

 using System.Diagnostics;

 IList<IList<int>> PathSum(TreeNode root, int targetSum)
 {
     Stack<(TreeNode,List<int>)> stack = new Stack<(TreeNode,List<int>)>();
     List<int> tempList = new List<int>();
     IList<IList<int>> targetLists = new List<IList<int>>();
     Dictionary<TreeNode, bool> isDiscovered = new Dictionary<TreeNode, bool>();
     int sum = 0;
     if(root != null) {
         stack.Push((root,new List<int>() {}));
     }
     else {
         return targetLists;
     }
     
     while (stack.Count > 0)
     {
         (TreeNode node, List<int> intList) tuple = stack.Pop();
         tempList = tuple.intList;
         isDiscovered.TryAdd(tuple.node, false);
         
         if(tuple.node.right != null) isDiscovered.TryAdd(tuple.node.right, false);
         if(tuple.node.left != null) isDiscovered.TryAdd(tuple.node.left, false);

         Console.WriteLine("\n" +"Element - " + tuple.node.val + " ");
         
         if (!isDiscovered[tuple.node])
         {
             isDiscovered[tuple.node] = true;

             List<int> list = new List<int>(tempList);
             
             if(tuple.node.right != null && !isDiscovered[tuple.node.right])
             {
                 list.Add(tuple.node.val);
                 stack.Push((tuple.node.right,list));
             }

             list = new List<int>(tempList);
             
             if(tuple.node.left != null && !isDiscovered[tuple.node.left]) 
             {
                 list.Add(tuple.node.val);
                 stack.Push((tuple.node.left,list));
             }
             Console.WriteLine("Sum - " + (tuple.intList.Sum() + tuple.node.val));

             if (tuple.intList.Sum() + tuple.node.val == targetSum )
             {
                 tuple.intList.Add(tuple.node.val);
                 if (tuple.node.left == null && tuple.node.right == null)
                 {
                     targetLists.Add(tuple.intList);
                     Console.WriteLine("Solution => ");
                 }
                 
                 tuple.intList.ForEach(i => Console.Write(i + " "));
             }
             else
             {
                 tuple.intList.Add(tuple.node.val);
                 tuple.intList.ForEach(i => Console.Write(i + " "));
             }
         }
     }

     return targetLists;
 }

 // PathSum(new TreeNode(5,
 //     new TreeNode(4, new TreeNode(11, new TreeNode(7, null, null), new TreeNode(2, null, null)), null),
 //     new TreeNode(8, new TreeNode(13, null, null),
 //         new TreeNode(4, new TreeNode(5, null, null), new TreeNode(1, null, null)))),22);
 PathSum(new TreeNode(1, new TreeNode(2, null, null), null), 1);
 public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}