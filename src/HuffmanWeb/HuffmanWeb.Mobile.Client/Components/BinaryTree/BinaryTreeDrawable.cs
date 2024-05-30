
using HuffmanWeb.Common.DTOs;
namespace HuffmanWeb.Mobile.Client.Components.BinaryTree
{
    public class BinaryTreeDrawable : GraphicsView, IDrawable
    {
        public static readonly BindableProperty GraphProperty = BindableProperty.Create(nameof(Graph), typeof(WeightedGraph), typeof(BinaryTreeDrawable));
        public WeightedGraph Graph
        {
            get => (WeightedGraph)GetValue(GraphProperty);
            set => SetValue(GraphProperty, value);
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
            

            var parentGraphicNode = DrawRootNode(canvas, dirtyRect, $"{Graph.Root?.Character}:{Graph.Root?.NbOccurence}");
            var linksFromRoot = Graph.Links.Where(l => l.Parent?.Identifier == Graph.Root?.Identifier).ToList();
            DrawChildrenNode(canvas,dirtyRect,linksFromRoot,parentGraphicNode,0);

        }
        public void DrawChildrenNode (ICanvas canvas, RectF dirtyRect, List<Link<HuffmanNode>> links, GraphicNode parentGraphicNode, int descendantsCount)
        {
            if(links.Count == 0) return;
            int nbLeafs = Graph.Links.Where(l => l.Child == null).Count();
            if (links.Count == 2)
            {
                var leftNode = Graph.AllNodes.FirstOrDefault(n => n.Identifier == links[0].Child?.Identifier);
                var leftLabel = $"{leftNode?.Character}:{leftNode?.NbOccurence}";
                var leftGraphicNode = DrawLeftChildNode(canvas, dirtyRect, leftLabel, links[0].Weight.ToString(), leftNode.DescendantsCount, parentGraphicNode);
                var leftLinks = Graph.Links.Where(l => l.Parent?.Identifier == leftNode?.Identifier).ToList();
                DrawChildrenNode(canvas, dirtyRect, leftLinks, leftGraphicNode, leftNode.DescendantsCount);


                var rightNode = Graph.AllNodes.FirstOrDefault(n => n.Identifier == links[1].Child?.Identifier);
                var rightLabel = $"{rightNode?.Character}:{rightNode?.NbOccurence}";
                var rightGraphicNode = DrawRightChildNode(canvas, dirtyRect, rightLabel, links[1].Weight.ToString(), rightNode.DescendantsCount, parentGraphicNode);
                var rightLinks = Graph.Links.Where(l => l.Parent?.Identifier == rightNode?.Identifier).ToList();
                DrawChildrenNode(canvas, dirtyRect, rightLinks, rightGraphicNode, rightNode.DescendantsCount);

            }
            if (links.Count == 1)
            {
                var leftNode = Graph.AllNodes.FirstOrDefault(n => n.Identifier == links[0].Child?.Identifier);
                var leftLabel = $"{leftNode?.Character} : {leftNode?.NbOccurence}";
                var leftGraphicNode = DrawLeftChildNode(canvas, dirtyRect, leftLabel, links[0].Weight.ToString(), leftNode.DescendantsCount, parentGraphicNode);
                var leftLinks = Graph.Links.Where(l => l.Parent?.Identifier == leftNode?.Identifier).ToList();
                DrawChildrenNode(canvas, dirtyRect, leftLinks, leftGraphicNode, leftNode.DescendantsCount);
            }
        }
        private GraphicNode DrawRootNode(ICanvas canvas, RectF dirtyRect, string label)
        {
            GraphicNode node = new((int)(dirtyRect.Width / 2)-25, 30,50, 20);
            DrawNode(canvas, node, label);
            return node;
        }
        private GraphicNode DrawLeftChildNode(ICanvas canvas, RectF dirtyRect, string label, string weight, int descendantsCount,GraphicNode parentGraphicNode)
        {
            GraphicNode node = new((int)(parentGraphicNode.X - (parentGraphicNode.Width*2* descendantsCount)), (int)(parentGraphicNode.Y + parentGraphicNode.Height), parentGraphicNode.Width, parentGraphicNode.Height);
            DrawNode(canvas, node, label);
            DrawLeftLink(canvas, parentGraphicNode, descendantsCount, node, weight);
            return node;
        }
        private GraphicNode DrawRightChildNode(ICanvas canvas, RectF dirtyRect, string label, string weight, int descendantsCount, GraphicNode parentGraphicNode)
        {
            GraphicNode node = new((int)(parentGraphicNode.X + (parentGraphicNode.Width * 2 * descendantsCount)), (int)(parentGraphicNode.Y + parentGraphicNode.Height), parentGraphicNode.Width, parentGraphicNode.Height);
            DrawNode(canvas, node, label);
            DrawRightLink(canvas, parentGraphicNode, descendantsCount, node, weight);
            return node;
        }
        private void DrawNode(ICanvas canvas, GraphicNode node, string label)
        {
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 4;
            canvas.DrawEllipse(node.X, node.Y, node.Width, node.Height);
            canvas.StrokeColor = Colors.Black;
            canvas.Font = Microsoft.Maui.Graphics.Font.DefaultBold;
            canvas.DrawString(label, node.X, node.Y, node.Width, node.Height, HorizontalAlignment.Center, VerticalAlignment.Center);

        }
        private void DrawRightLink(ICanvas canvas, GraphicNode parentGraphicNode, int nbChildren,GraphicNode childGraphicNode, string weight)
        {
            Point startHorizontalLinePoint = new Point(parentGraphicNode.X + parentGraphicNode.Width, (int)(parentGraphicNode.Y + parentGraphicNode.Height / 2));
            Point endHorizontalLinePoint = new Point((int)(childGraphicNode.X + childGraphicNode.Width / 2), (int)(parentGraphicNode.Y + parentGraphicNode.Height / 2));
            Point endVerticalLinePoint = new Point((int)(childGraphicNode.X + childGraphicNode.Width  / 2), childGraphicNode.Y);
            canvas.DrawLine(startHorizontalLinePoint, endHorizontalLinePoint);
            canvas.DrawLine(endHorizontalLinePoint, endVerticalLinePoint);
            int textWidth = (int)(childGraphicNode.Width / 4);
            int textHeight = (int)((endVerticalLinePoint.Y - endHorizontalLinePoint.Y) / 4);
            int textX = (int)(endVerticalLinePoint.X );
            int textY = (int)(endHorizontalLinePoint.Y + ((endVerticalLinePoint.Y - endHorizontalLinePoint.Y) / 2));
            
            canvas.DrawString(weight,textX,textY, textWidth, textHeight, HorizontalAlignment.Center, VerticalAlignment.Center);
        }
        private void DrawLeftLink(ICanvas canvas, GraphicNode parentGraphicNode, int nbChildren, GraphicNode childGraphicNode, string weight)
        {
            Point startHorizontalLinePoint = new Point(parentGraphicNode.X, (int)(parentGraphicNode.Y + parentGraphicNode.Height / 2));
            Point endHorizontalLinePoint = new Point((int)(childGraphicNode.X + (childGraphicNode.Width / 2)), (int)(parentGraphicNode.Y + parentGraphicNode.Height / 2));
            Point endVerticalLinePoint = new Point((int)(childGraphicNode.X +( childGraphicNode.Width / 2)), childGraphicNode.Y);
            canvas.DrawLine(startHorizontalLinePoint, endHorizontalLinePoint);
            canvas.DrawLine(endHorizontalLinePoint, endVerticalLinePoint);
            int textWidth = (int)(childGraphicNode.Width / 4);
            int textHeight = (int)((endVerticalLinePoint.Y - endHorizontalLinePoint.Y) / 4);
            int textX = (int)(endVerticalLinePoint.X - textWidth);
            int textY = (int)(endHorizontalLinePoint.Y + ((endVerticalLinePoint.Y - endHorizontalLinePoint.Y) / 2));
            canvas.DrawString(weight, textX, textY , textWidth, textHeight, HorizontalAlignment.Center, VerticalAlignment.Center);
        }
    }
}
