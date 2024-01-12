﻿/*
Given the roots of two binary trees p and q, write a function to check if they are the same or not.

Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.



Example 1:


Input: p = [1,2,3], q = [1,2,3]
Output: true
Example 2:


Input: p = [1,2], q = [1,null,2]
Output: false
Example 3:


Input: p = [1,2,1], q = [1,1,2]
Output: false


Constraints:

The number of nodes in both trees is in the range [0, 100].
-104 <= Node.val <= 104
*/


 // Definition for a binary tree node.

Console.WriteLine(IsSameTree(new TreeNode(1, new TreeNode(2,null,null), new TreeNode(1,null,null)),
                                new TreeNode(1, new TreeNode(1, null,null), new TreeNode(2, null,null))));


bool IsSameTree(TreeNode p, TreeNode q)
{
    Queue<(TreeNode,TreeNode)> queue = new Queue<(TreeNode,TreeNode)>();
    (TreeNode,TreeNode) roots = (p,q);
    queue.Enqueue(roots);
    while (queue.Count != 0)
    {
        (TreeNode v, TreeNode q) temp = queue.Dequeue();
        
        if(temp.v is null && temp.q is null) continue;
        
        
        if ((temp.v is null && temp.q is not null) ||
            (temp.v is not null && temp.q is null) ||
            temp.v.val != temp.q.val)
        {
            return false;
        }
        
        queue.Enqueue((temp.v.left , temp.q.left));
        queue.Enqueue((temp.v.right, temp.q.right));
    }
    
    return true;
} 

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