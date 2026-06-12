using HuffmanWeb.Common.DTOs;

namespace HuffmanWeb.Mobile.Client.Components.BinaryTree
{
    /// <summary>
    /// Draws a Huffman tree on a GraphicsView. Every leaf gets its own horizontal
    /// slot and every parent is centered above its children, so nodes can never
    /// overlap whatever the tree shape. The control sizes itself to the laid-out
    /// tree; the surrounding ScrollView provides panning.
    /// </summary>
    public class BinaryTreeDrawable : GraphicsView, IDrawable
    {
        private const float HorizontalGap = 16f;
        private const float VerticalGap = 44f;
        private const float ContentPadding = 24f;

        #region Bindable properties
        public static readonly BindableProperty GraphProperty = BindableProperty.Create(
            nameof(Graph), typeof(WeightedGraph), typeof(BinaryTreeDrawable),
            propertyChanged: OnLayoutChanged);
        public static readonly BindableProperty NodeWidthProperty = BindableProperty.Create(
            nameof(NodeWidth), typeof(int), typeof(BinaryTreeDrawable), 48,
            propertyChanged: OnLayoutChanged);
        public static readonly BindableProperty NodeHeightProperty = BindableProperty.Create(
            nameof(NodeHeight), typeof(int), typeof(BinaryTreeDrawable), 36,
            propertyChanged: OnLayoutChanged);
        public static readonly BindableProperty NodeColorProperty = BindableProperty.Create(
            nameof(NodeColor), typeof(Color), typeof(BinaryTreeDrawable), Colors.Silver,
            propertyChanged: OnAppearanceChanged);
        public static readonly BindableProperty ShadowColorProperty = BindableProperty.Create(
            nameof(ShadowColor), typeof(Color), typeof(BinaryTreeDrawable), Colors.Grey,
            propertyChanged: OnAppearanceChanged);
        public static readonly BindableProperty LineColorProperty = BindableProperty.Create(
            nameof(LineColor), typeof(Color), typeof(BinaryTreeDrawable), Colors.Black,
            propertyChanged: OnAppearanceChanged);
        public static readonly BindableProperty LineTextColorProperty = BindableProperty.Create(
            nameof(LineTextColor), typeof(Color), typeof(BinaryTreeDrawable), Colors.Gray,
            propertyChanged: OnAppearanceChanged);
        public static readonly BindableProperty NodeTextColorProperty = BindableProperty.Create(
            nameof(NodeTextColor), typeof(Color), typeof(BinaryTreeDrawable), Colors.Black,
            propertyChanged: OnAppearanceChanged);

        public WeightedGraph? Graph
        {
            get => (WeightedGraph?)GetValue(GraphProperty);
            set => SetValue(GraphProperty, value);
        }
        public int NodeWidth
        {
            get => (int)GetValue(NodeWidthProperty);
            set => SetValue(NodeWidthProperty, value);
        }
        public int NodeHeight
        {
            get => (int)GetValue(NodeHeightProperty);
            set => SetValue(NodeHeightProperty, value);
        }
        public Color NodeColor
        {
            get => (Color)GetValue(NodeColorProperty);
            set => SetValue(NodeColorProperty, value);
        }
        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }
        public Color LineColor
        {
            get => (Color)GetValue(LineColorProperty);
            set => SetValue(LineColorProperty, value);
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

        private sealed class PlacedNode
        {
            public required HuffmanNode Node { get; init; }
            public required bool IsLeaf { get; init; }
            public required int Depth { get; init; }
            public float Slot { get; set; }
            public PointF Center { get; set; }
        }

        private sealed class PlacedLink
        {
            public required PlacedNode Parent { get; init; }
            public required PlacedNode Child { get; init; }
            public required string Bit { get; init; }
        }

        private readonly List<PlacedNode> _placedNodes = new();
        private readonly List<PlacedLink> _placedLinks = new();

        public BinaryTreeDrawable()
        {
            Drawable = this;
        }

        private static void OnLayoutChanged(BindableObject bindable, object oldValue, object newValue) =>
            ((BinaryTreeDrawable)bindable).Relayout();

        private static void OnAppearanceChanged(BindableObject bindable, object oldValue, object newValue) =>
            ((BinaryTreeDrawable)bindable).Invalidate();

        /// <summary>
        /// Assigns each leaf the next free horizontal slot (in-order) and centers
        /// each parent over its children, then converts slots/depths to pixels and
        /// resizes the control to fit the whole tree.
        /// </summary>
        private void Relayout()
        {
            _placedNodes.Clear();
            _placedLinks.Clear();

            var graph = Graph;
            float contentWidth = 0f;
            float contentHeight = 0f;

            if (graph?.Root is not null)
            {
                var childrenOf = graph.Links
                    .Where(l => l.Parent is not null && l.Child is not null)
                    .GroupBy(l => l.Parent!.Identifier)
                    .ToDictionary(g => g.Key, g => g.ToList());

                // Guards against a malformed graph containing a cycle.
                var visited = new HashSet<Guid>();
                int nextLeafSlot = 0;
                int maxDepth = 0;

                PlacedNode Place(HuffmanNode node, int depth)
                {
                    maxDepth = Math.Max(maxDepth, depth);
                    List<Link<HuffmanNode>>? links = null;
                    if (visited.Add(node.Identifier))
                        childrenOf.TryGetValue(node.Identifier, out links);

                    var placed = new PlacedNode
                    {
                        Node = node,
                        IsLeaf = links is null || links.Count == 0,
                        Depth = depth,
                    };

                    if (placed.IsLeaf)
                    {
                        placed.Slot = nextLeafSlot++;
                    }
                    else
                    {
                        var children = new List<PlacedNode>(links!.Count);
                        foreach (var link in links)
                        {
                            var child = Place(link.Child!, depth + 1);
                            children.Add(child);
                            _placedLinks.Add(new PlacedLink
                            {
                                Parent = placed,
                                Child = child,
                                Bit = link.Weight.ToString(),
                            });
                        }
                        placed.Slot = (children[0].Slot + children[^1].Slot) / 2f;
                    }

                    _placedNodes.Add(placed);
                    return placed;
                }

                Place(graph.Root, 0);

                float slotWidth = NodeWidth + HorizontalGap;
                float levelHeight = NodeHeight + VerticalGap;
                contentWidth = ContentPadding * 2 + nextLeafSlot * slotWidth - HorizontalGap;
                contentHeight = ContentPadding * 2 + NodeHeight + maxDepth * levelHeight;

                foreach (var placed in _placedNodes)
                {
                    placed.Center = new PointF(
                        ContentPadding + NodeWidth / 2f + placed.Slot * slotWidth,
                        ContentPadding + NodeHeight / 2f + placed.Depth * levelHeight);
                }
            }

            WidthRequest = Math.Max(contentWidth, 1);
            HeightRequest = Math.Max(contentHeight, 1);
            Invalidate();
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (_placedNodes.Count == 0) return;

            canvas.StrokeColor = LineColor;
            canvas.StrokeSize = 2;
            foreach (var link in _placedLinks)
                canvas.DrawLine(link.Parent.Center, link.Child.Center);

            canvas.FontColor = LineTextColor;
            canvas.FontSize = 12;
            canvas.Font = Microsoft.Maui.Graphics.Font.Default;
            foreach (var link in _placedLinks)
            {
                var midX = (link.Parent.Center.X + link.Child.Center.X) / 2f;
                var midY = (link.Parent.Center.Y + link.Child.Center.Y) / 2f;
                bool isLeftChild = link.Child.Center.X < link.Parent.Center.X;
                canvas.DrawString(
                    link.Bit,
                    midX + (isLeftChild ? -6f : 6f),
                    midY - 4f,
                    isLeftChild ? HorizontalAlignment.Right : HorizontalAlignment.Left);
            }

            foreach (var placed in _placedNodes)
            {
                var bounds = new RectF(
                    placed.Center.X - NodeWidth / 2f,
                    placed.Center.Y - NodeHeight / 2f,
                    NodeWidth,
                    NodeHeight);

                canvas.SaveState();
                canvas.SetShadow(new SizeF(2, 2), 4, ShadowColor);
                canvas.SetFillPaint(new SolidPaint(NodeColor), bounds);
                canvas.FillEllipse(bounds);
                canvas.RestoreState();

                canvas.FontColor = NodeTextColor;
                canvas.FontSize = 14;
                canvas.Font = Microsoft.Maui.Graphics.Font.DefaultBold;
                canvas.DrawString(NodeLabel(placed), bounds, HorizontalAlignment.Center, VerticalAlignment.Center);
            }
        }

        private static string NodeLabel(PlacedNode placed) =>
            placed.IsLeaf
                ? placed.Node.Character switch
                {
                    ' ' => "␣",
                    '\n' => "\\n",
                    '\r' => "\\r",
                    '\t' => "\\t",
                    // A root that is also a leaf (single distinct character) has no character.
                    char.MinValue => placed.Node.NbOccurence.ToString(),
                    _ => placed.Node.Character.ToString(),
                }
                : placed.Node.NbOccurence.ToString();
    }
}
