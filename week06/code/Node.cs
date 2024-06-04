public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data)
        {
            return true; // Found the value
        }
        else if (value < Data && Left != null)
        {
            // Search in the left subtree
            return Left.Contains(value);
        }
        else if (value > Data && Right != null)
        {
            // Search in the right subtree
            return Right.Contains(value);
        }

        return false; // Value not found
    }

public int GetHeight()
{
    // if null height = 0
    if (this == null)
    {
        return 0;
    }

    // calculate left and right branch height starting from the leaves
    int leftHeight = (Left != null) ? Left.GetHeight() : 0;
    int rightHeight = (Right != null) ? Right.GetHeight() : 0;

    // max heights and current node (missed that before)
    return Math.Max(leftHeight, rightHeight) + 1;
}

}