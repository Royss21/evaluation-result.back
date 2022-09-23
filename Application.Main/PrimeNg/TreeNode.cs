using System.Collections.Generic;

namespace Application.Main.PrimeNg
{
    public class TreeNode
    {
        public TreeNode()
        {
            Children = new List<TreeNode>();
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public int Order { get; set; }
        public string Icon { get; set; }
        public ICollection<TreeNode> Children { get; set; }
    }
}
