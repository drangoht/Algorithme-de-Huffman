
using HuffmanWeb.Common.DTOs;
namespace HuffmanWeb.Mobile.Client.Components.BinaryTree
{
    public class BinaryTreeDrawable : GraphicsView, IDrawable
    {
        #region Properties
        private ICanvas? _canvas;
        public static readonly BindableProperty GraphProperty = BindableProperty.Create(nameof(Graph), typeof(WeightedGraph), typeof(BinaryTreeDrawable));
        public static readonly BindableProperty NodeHeightProperty = BindableProperty.Create(nameof(NodeHeight), typeof(int), typeof(BinaryTreeDrawable));
        public static readonly BindableProperty NodeWidthProperty = BindableProperty.Create(nameof(NodeWidth), typeof(int), typeof(BinaryTreeDrawable));
        public static readonly BindableProperty NodeColorProperty = BindableProperty.Create(nameof(NodeColor), typeof(Color), typeof(BinaryTreeDrawable), Colors.Silver);
        public static readonly BindableProperty ShadowColorProperty = BindableProperty.Create(nameof(ShadowColor), typeof(Color), typeof(BinaryTreeDrawable), Colors.Grey);
        public static readonly BindableProperty LineColorProperty = BindableProperty.Create(nameof(LineColor), typeof(Color), typeof(BinaryTreeDrawable), Colors.Black);
        public static readonly BindableProperty LineTextColorProperty = BindableProperty.Create(nameof(LineTextColor), typeof(Color), typeof(BinaryTreeDrawable), Colors.Black);
        public static readonly BindableProperty NodeTextColorProperty = BindableProperty.Create(nameof(NodeTextColor), typeof(Color), typeof(BinaryTreeDrawable), Colors.Black);

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
        public Color NodeColor
        {
            get => (Color)GetValue(NodeColorProperty);
            set => SetValue(NodeColorProperty, value);
        }
        public Color LineColor
        {
            get => (Color)GetValue(LineColorProperty);
            set => SetValue(LineColorProperty, value);
        }
        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }
        public Color LineTextColor
        {
            get => (Color)GetValue(LineTextColorProperty);
            set => SetValue(LineTextColorProperty, value);
        }

        public Color NodeTextColor
        {
            get => (Color)GetValue(NodeTextColorProperty);
            set => SetValue(NodeTextColorProperty, value);
        }
        #endregion

        #region ctor & Bind
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
        #endregion

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (Graph.AllNodes.Count == 0) return;
            _canvas = canvas;
            var startPosition = DefineStartPosition(dirtyRect);
            var rootGraphicNode = DrawRootNode(startPosition, $"{Graph.Root?.NbOccurence}", Graph.Root!.DescendantsCount);
            var linksFromRoot = Graph.Links.Where(l => l.Parent?.Identifier == Graph.Root?.Identifier).ToList();
            DrawChildrenNode(linksFromRoot, rootGraphicNode);

        }

        private Point DefineStartPosition(RectF directRect) =>
                new((int)(directRect.Width / 2) - NodeWidth + NodeWidth / 2, 2 * NodeHeight);

        public void DrawChildrenNode(List<Link<HuffmanNode>> links, GraphicNode parentGraphicNode)
        {
            if (links.Count == 0) return;

            if (links.Count == 2)
            {
                var leftNode = Graph.AllNodes.FirstOrDefault(n => n.Identifier == links[0].Child?.Identifier);
                string leftLabel = string.Empty;
                if (leftNode?.Character != char.MinValue)
                    leftLabel = $"{leftNode?.Character}";
                else
                    leftLabel = $"{leftNode?.NbOccurence}";


                var leftGraphicNode = DrawLeftChildNode(leftLabel, links[0].Weight.ToString(), GetRightDescendantsCount(leftNode), parentGraphicNode);
                var leftLinks = Graph.Links.Where(l => l.Parent?.Identifier == leftNode?.Identifier).ToList();
                DrawChildrenNode(leftLinks, leftGraphicNode);


                var rightNode = Graph.AllNodes.FirstOrDefault(n => n.Identifier == links[1].Child?.Identifier);
                string rightLabel = string.Empty;
                if (rightNode?.Character != char.MinValue)
                    rightLabel = $"{rightNode?.Character}";
                else
                    rightLabel = $"{rightNode?.NbOccurence}";

                var rightGraphicNode = DrawRightChildNode(rightLabel, links[1].Weight.ToString(), GetLeftDescendantsCount(rightNode), parentGraphicNode);
                var rightLinks = Graph.Links.Where(l => l.Parent?.Identifier == rightNode?.Identifier).ToList();
                DrawChildrenNode(rightLinks, rightGraphicNode);

            }
            if (links.Count == 1)
            {
                var leftNode = Graph.AllNodes.FirstOrDefault(n => n.Identifier == links[0].Child?.Identifier);
                string leftLabel = string.Empty;
                if (leftNode?.Character != char.MinValue)
                    leftLabel = $"{leftNode?.Character}";
                else
                    leftLabel = $"{leftNode?.NbOccurence}";


                var leftGraphicNode = DrawLeftChildNode(leftLabel, links[0].Weight.ToString(), GetRightDescendantsCount(leftNode), parentGraphicNode);
                var leftLinks = Graph.Links.Where(l => l.Parent?.Identifier == leftNode?.Identifier).ToList();
                DrawChildrenNode(leftLinks, leftGraphicNode);
            }
        }

        private int GetLeftDescendantsCount(HuffmanNode? parentNode)
        {
            if (parentNode is not null && Graph.Links.Where(l => l.Parent!.Identifier == parentNode.Identifier).Count() == 0)
                return 1;

            var node = Graph.Links.Where(l => l.Parent!.Identifier == parentNode!.Identifier).ToList()[0].Child;
            return node!.DescendantsCount + 2; // 2 = last link + last node
        }
        private int GetRightDescendantsCount(HuffmanNode? parentNode)
        {
            if (parentNode is not null && ((Graph.Links.Where(l => l.Parent!.Identifier == parentNode.Identifier).Count() == 0) ||
               (Graph.Links.Where(l => l.Parent!.Identifier == parentNode.Identifier).Count() != 2)))
                return 1;
            var node = Graph.Links.Where(l => l.Parent!.Identifier == parentNode!.Identifier).ToList()[1].Child;
            return node!.DescendantsCount + 2; // 2 = last link + last node
        }

        private GraphicNode DrawRootNode(Point startPosition, string label, int descendantsCount)
        {
            GraphicNode node = new(
                x: (int)startPosition.X,
                y: (int)startPosition.Y,
                width: NodeWidth,
                height: NodeHeight
                );
            DrawNode(node, label);
            return node;
        }
        private GraphicNode DrawLeftChildNode(string label, string weight, int descendantsCount, GraphicNode parentGraphicNode)
        {
            int linkMargin = 5;
            int linkSpacing = NodeWidth + linkMargin;
            descendantsCount = descendantsCount == 0 ? 1 : descendantsCount;
            GraphicNode node = new(parentGraphicNode.X - (linkSpacing * descendantsCount), parentGraphicNode.Y + NodeHeight + 20, NodeWidth, NodeHeight);
            DrawNode(node, label);
            DrawLeftLink(parentGraphicNode, node, weight);
            return node;
        }
        private GraphicNode DrawRightChildNode(string label, string weight, int descendantsCount, GraphicNode parentGraphicNode)
        {

            int linkMargin = 5;
            int linkSpacing = NodeWidth + linkMargin;
            descendantsCount = descendantsCount == 0 ? 1 : descendantsCount;
            GraphicNode node = new(parentGraphicNode.X + (linkSpacing * descendantsCount), parentGraphicNode.Y + NodeHeight + 20, NodeWidth, NodeHeight);
            DrawNode(node, label);
            DrawRightLink(parentGraphicNode, node, weight);
            return node;
        }
        private void DrawNode(GraphicNode node, string label)
        {
            _canvas!.StrokeColor = Colors.Red;
            _canvas.StrokeSize = 2;

            SolidPaint solidPaint = new SolidPaint(NodeColor);
            RectF paintRectangle = new RectF(node.X, node.Y, node.Width, node.Height);
            _canvas.SetFillPaint(solidPaint, paintRectangle);
            _canvas.SetShadow(new SizeF(10, 10), 10, ShadowColor);
            _canvas.FillEllipse(paintRectangle);

            _canvas.FontColor = NodeTextColor;
            _canvas.Font = Microsoft.Maui.Graphics.Font.DefaultBold;
            _canvas.DrawString(label, paintRectangle, HorizontalAlignment.Center, VerticalAlignment.Center);

        }
        private void DrawRightLink(GraphicNode parentGraphicNode, GraphicNode childGraphicNode, string weight)
        {
            Point startHorizontalLinePoint = new Point(parentGraphicNode.X + NodeWidth, parentGraphicNode.Y + NodeHeight / 2);
            Point endHorizontalLinePoint = new Point(childGraphicNode.X + NodeWidth / 2, parentGraphicNode.Y + NodeHeight / 2);
            Point endVerticalLinePoint = new Point(childGraphicNode.X + NodeWidth / 2, childGraphicNode.Y);
            _canvas!.StrokeColor = LineColor;
            _canvas.DrawLine(startHorizontalLinePoint, endHorizontalLinePoint);
            _canvas.DrawLine(endHorizontalLinePoint, endVerticalLinePoint);
            int textMargin = 10;
            int textX = (int)endVerticalLinePoint.X + textMargin;
            int textY = (int)(endHorizontalLinePoint.Y + ((endVerticalLinePoint.Y - endHorizontalLinePoint.Y) / 2));
            DrawWeight(weight, new Point(textX, textY), HorizontalAlignment.Left);
        }
        private void DrawLeftLink(GraphicNode parentGraphicNode, GraphicNode childGraphicNode, string weight)
        {
            Point startHorizontalLinePoint = new Point(parentGraphicNode.X, parentGraphicNode.Y + NodeHeight / 2);
            Point endHorizontalLinePoint = new Point(childGraphicNode.X + NodeWidth / 2, parentGraphicNode.Y + NodeHeight / 2);
            Point endVerticalLinePoint = new Point(childGraphicNode.X + NodeWidth / 2, childGraphicNode.Y);
            _canvas!.StrokeColor = LineColor;
            _canvas.DrawLine(startHorizontalLinePoint, endHorizontalLinePoint);
            _canvas.DrawLine(endHorizontalLinePoint, endVerticalLinePoint);
            int textMargin = 5;
            int textX = (int)endVerticalLinePoint.X - NodeWidth - textMargin;
            int textY = (int)(endHorizontalLinePoint.Y + ((endVerticalLinePoint.Y - endHorizontalLinePoint.Y) / 2));
            DrawWeight(weight, new Point(textX, textY), HorizontalAlignment.Right);
        }

        private void DrawWeight(string weight, Point weightPosition, HorizontalAlignment hAlignment)
        {
            int textHeight = 5;
            _canvas!.FontColor = LineTextColor;
            _canvas!.DrawString(weight, (int)weightPosition.X, (int)weightPosition.Y, NodeWidth, textHeight, hAlignment, VerticalAlignment.Top);
        }
    }
}
