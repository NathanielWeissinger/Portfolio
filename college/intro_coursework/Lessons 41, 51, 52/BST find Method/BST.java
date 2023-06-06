//I got the loops to go through once, but it just won't go through a second time.


public class BST //with find method
{
    public BST(int i)
    {
        rootNode = new BstNode(i);
    }
    BstNode rootNode;
    
    public void addNode(int i)
    {
        BstNode currentNode = rootNode; //50 from BstNode
        boolean finished = false;
        do
        {
            BstNode curLeftNode = currentNode.leftNode;
            BstNode curRightNode = currentNode.rightNode;
            int curIntData = currentNode.intData;
            if(i > curIntData) //look down the right branch
            {
                if(curRightNode == null)
                { //create a new node referenced with currentNode.rightNode
                    currentNode.rightNode = new BstNode(i);
                    finished = true;
                }
                else //keep looking by assigning a new current node one level down
                {
                    currentNode = currentNode.rightNode;
                }
            }
            else //look down the left branch
            {
                if(curLeftNode == null)
                { //create a new node referenced with currentNode.leftNode
                    currentNode.leftNode = new BstNode(i);
                    finished = true;
                }
                else
                { //keep looking by assigning a new current node one level down
                    currentNode = currentNode.leftNode;
                }
            }
        }
        while(!finished);
    }
    
    public boolean find(int i)
    {
        BstNode currentNode = rootNode; //50 from BstNode
        boolean finished = false;
        boolean found = false;
        while(!finished)
        {
            BstNode curLeftNode = currentNode.leftNode;
            BstNode curRightNode = currentNode.rightNode;
            int curIntData = currentNode.intData;
            if(i > curIntData) //look down the right branch
            {
                if(curIntData == i)
                { //create a new node referenced with currentNode.rightNode
                    finished = true;
                    found = true;
                    break;
                }
                else //keep looking by assigning a new current node one level down
                {
                    currentNode = currentNode.rightNode;
                }
            }
            else if(curIntData == i)
            {
                finished = true;
                found = true;
                break;
            }
            else//look down the left branch
            {
                if(curIntData == i)
                { //create a new node referenced with currentNode.leftNode
                    finished = true;
                    found = true;
                    break;
                }
                else
                { //keep looking by assigning a new current node one level down
                    currentNode = currentNode.leftNode;
                }
            }
        }
        finished = false;
        return found;
    }
}