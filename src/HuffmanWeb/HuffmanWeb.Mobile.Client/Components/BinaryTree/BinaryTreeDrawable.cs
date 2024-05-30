
using HuffmanWeb.Common.DTOs;
using Microsoft.Maui.Graphics;
namespace HuffmanWeb.Mobile.Client.Components.BinaryTree
{
    public class BinaryTreeDrawable : GraphicsView, IDrawable
    {

        public static readonly BindableProperty GraphProperty = BindableProperty.Create(nameof(Graph), typeof(WeightedGraph), typeof(BinaryTreeDrawable));
        public static readonly BindableProperty NodeHeightProperty = BindableProperty.Create(nameof(NodeHeight), typeof(int), typeof(BinaryTreeDrawable));
        public static readonly BindableProperty NodeWidthProperty = BindableProperty.Create(nameof(NodeWidth), typeof(int), typeof(BinaryTreeDrawable));

        public WeightedGraph Graph
        {
            get => (WeightedGraph)GetValue(GraphProperty);
            set => SetValue(GraphProperty, value);
        }

        public int NodeHeight
        {
            get => (int)GetValue(NodeHeightProperty);
            set => SetValue(NodeHeightProperty, value);
        }
        public int NodeWidth
        {
            get => (int)GetValue(NodeWidthProperty);
            set => SetValue(NodeWidthProperty, value);
        }
        public BinaryTreeDrawable()
        {
            Drawable = this;
        }

        private static void RequestInvalidate(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is GraphicsView)
            {
                ((GraphicsView)bindable).Invalidate();
            }
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if(Graph.AllNodes.Count == 0) return;
            WidthRequest = (int)Graph.Root?.DescendantsCount * NodeWidth * 2;
            HeightRequest = (int)Graph.Root?.DescendantsCount * NodeHeight * 2;
            var rootGraphicNode = DrawRootNode(canvas, dirtyRect, $"{Graph.Root?.NbOccurence}", Graph.Root.DescendantsCount);
            var linksFromRoot = Graph.Links.Where(l => l.Parent?.Identifier == Graph.Root?.Identifier).ToList();
            DrawChildrenNode(canvas,dirtyRect,linksFromRoot,rootGraphicNode,Graph.Root.DescendantsCount);

        }
        public void DrawChildrenNode (ICanvas canvas, RectF dirtyRect, List<Link<HuffmanNode>> links, GraphicNode parentGraphicNode, int descendantsCount)
        {
            if(links.Count == 0) return;
            int nbLeafs = Graph.Links.Where(l => l.Child == null).Count();
            
            if (links.Count == 2)
            {
                var leftNode = Graph.AllNodes.FirstOrDefault(n => n.Identifier == links[0].Child?.Identifier);
                string leftLabel = string.Empty;
                if (leftNode?.Character != char.MinValue)
                    leftLabel = $"{leftNode?.Character}";
                else
                    leftLabel = $"{leftNode?.NbOccurence}";
                
                var leftGraphicNode = DrawLeftChildNode(canvas, dirtyRect, leftLabel, links[0].Weight.ToString(), leftNode.DescendantsCount, parentGraphicNode);
                var leftLinks = Graph.Links.Where(l => l.Parent?.Identifier == leftNode?.Identifier).ToList();
                DrawChildrenNode(canvas, dirtyRect, leftLinks, leftGraphicNode, leftNode.DescendantsCount);


                var rightNode = Graph.AllNodes.FirstOrDefault(n => n.Identifier == links[1].Child?.Identifier);
                string rightLabel = string.Empty;
                if (rightNode?.Character != char.MinValue)
                    rightLabel = $"{rightNode?.Character}";
                else
                    rightLabel = $"{rightNode?.NbOccurence}";

                var rightGraphicNode = DrawRightChildNode(canvas, dirtyRect, rightLabel, links[1].Weight.ToString(), rightNode.DescendantsCount, parentGraphicNode);
                var rightLinks = Graph.Links.Where(l => l.Parent?.Identifier == rightNode?.Identifier).ToList();
                DrawChildrenNode(canvas, dirtyRect, rightLinks, rightGraphicNode, rightNode.DescendantsCount);

            }
            if (links.Count == 1)
            {
                var leftNode = Graph.AllNodes.FirstOrDefault(n => n.Identifier == links[0].Child?.Identifier);
                string leftLabel = string.Empty;
                if (leftNode?.Character != char.MinValue)
                    leftLabel = $"{leftNode?.Character}";
                else
                    leftLabel = $"{leftNode?.NbOccurence}";
                
                var leftGraphicNode = DrawLeftChildNode(canvas, dirtyRect, leftLabel, links[0].Weight.ToString(), leftNode.DescendantsCount, parentGraphicNode);
                var leftLinks = Graph.Links.Where(l => l.Parent?.Identifier == leftNode?.Identifier).ToList();
                DrawChildrenNode(canvas, dirtyRect, leftLinks, leftGraphicNode, leftNode.DescendantsCount);
            }
        }
        private GraphicNode DrawRootNode(ICanvas canvas, RectF dirtyRect, string label,int descendantsCount)
        {
            int xRoot = ((int)(dirtyRect.Width/2)-NodeWidth);
            int yRoot = 2 * NodeHeight;
            //int nodeWidth = (int)(dirtyRect.Width / descendantsCount);
            //int nodeHeight = (int)(dirtyRect.Height / 32);
            GraphicNode node = new(
                x: xRoot + NodeWidth / 2,
                y: yRoot,
                width: NodeWidth,
                height: NodeHeight
                );
            DrawNode(canvas, node, label);
            return node;
        }
        private GraphicNode DrawLeftChildNode(ICanvas canvas, RectF dirtyRect, string label, string weight, int descendantsCount,GraphicNode parentGraphicNode)
        {
            int linkSpacing = parentGraphicNode.Width ;
            descendantsCount = descendantsCount == 0 ? 1 : descendantsCount;
            GraphicNode node = new(parentGraphicNode.X - (linkSpacing * descendantsCount), parentGraphicNode.Y + parentGraphicNode.Height * 2, parentGraphicNode.Width, parentGraphicNode.Height);
            DrawNode(canvas, node, label);
            DrawLeftLink(canvas, parentGraphicNode, descendantsCount, node, weight);
            return node;
        }
        private GraphicNode DrawRightChildNode(ICanvas canvas, RectF dirtyRect, string label, string weight, int descendantsCount, GraphicNode parentGraphicNode)
        {
            int linkSpacing = parentGraphicNode.Width ;
            descendantsCount = descendantsCount == 0 ? 1 : descendantsCount;
            GraphicNode node = new(parentGraphicNode.X + (linkSpacing * descendantsCount), parentGraphicNode.Y + parentGraphicNode.Height * 2, parentGraphicNode.Width, parentGraphicNode.Height);
            DrawNode(canvas, node, label);
            DrawRightLink(canvas, parentGraphicNode, descendantsCount, node, weight);
            return node;
        }
        private void DrawNode(ICanvas canvas, GraphicNode node, string label)
        {
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 1;
            canvas.DrawEllipse(node.X, node.Y, node.Width, node.Height);
            canvas.StrokeColor = Colors.Black;
            canvas.Font = Microsoft.Maui.Graphics.Font.DefaultBold;
            canvas.DrawString(label, node.X, node.Y, node.Width, node.Height, HorizontalAlignment.Center, VerticalAlignment.Center);

        }
        private void DrawRightLink(ICanvas canvas, GraphicNode parentGraphicNode, int nbChildren,GraphicNode childGraphicNode, string weight)
        {
            Point startHorizontalLinePoint = new Point(parentGraphicNode.X + parentGraphicNode.Width, parentGraphicNode.Y + parentGraphicNode.Height / 2);
            Point endHorizontalLinePoint = new Point(childGraphicNode.X + childGraphicNode.Width / 2, parentGraphicNode.Y + parentGraphicNode.Height / 2);
            Point endVerticalLinePoint = new Point(childGraphicNode.X + childGraphicNode.Width / 2, childGraphicNode.Y);
            canvas.DrawLine(startHorizontalLinePoint, endHorizontalLinePoint);
            canvas.DrawLine(endHorizontalLinePoint, endVerticalLinePoint);
            int textWidth = childGraphicNode.Width;
            int textMargin = 5;
            int textHeight = (int)((endVerticalLinePoint.Y - endHorizontalLinePoint.Y) / 4);
            int textX = (int)endVerticalLinePoint.X + textMargin;
            int textY = (int)(endHorizontalLinePoint.Y + ((endVerticalLinePoint.Y - endHorizontalLinePoint.Y) / 2));
            
            canvas.DrawString(weight, textX,textY, textWidth, textHeight, HorizontalAlignment.Left, VerticalAlignment.Top);
        }
        private void DrawLeftLink(ICanvas canvas, GraphicNode parentGraphicNode, int nbChildren, GraphicNode childGraphicNode, string weight)
        {
            Point startHorizontalLinePoint = new Point(parentGraphicNode.X, parentGraphicNode.Y + parentGraphicNode.Height / 2);
            Point endHorizontalLinePoint = new Point(childGraphicNode.X + (childGraphicNode.Width / 2),parentGraphicNode.Y + parentGraphicNode.Height / 2);
            Point endVerticalLinePoint = new Point(childGraphicNode.X + (childGraphicNode.Width / 2), childGraphicNode.Y);
            canvas.DrawLine(startHorizontalLinePoint, endHorizontalLinePoint);
            canvas.DrawLine(endHorizontalLinePoint, endVerticalLinePoint);
            int textWidth = childGraphicNode.Width;
            int textMargin = 5;
            int textHeight = (int)((endVerticalLinePoint.Y - endHorizontalLinePoint.Y) / 4);
            int textX = (int)endVerticalLinePoint.X - textWidth - textMargin;
            int textY = (int)(endHorizontalLinePoint.Y + ((endVerticalLinePoint.Y - endHorizontalLinePoint.Y) / 2));
            canvas.DrawString(weight, textX, textY , textWidth, textHeight, HorizontalAlignment.Right, VerticalAlignment.Top);
        }
    }
}
