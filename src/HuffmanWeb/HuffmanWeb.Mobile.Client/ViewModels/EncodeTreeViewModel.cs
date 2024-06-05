using HuffmanWeb.Common.DTOs.Responses;
using Microsoft.Maui.Graphics;
using System.ComponentModel;

namespace HuffmanWeb.Mobile.Client.ViewModels
{
    public class EncodeTreeViewModel : INotifyPropertyChanged
    {
        private int treeWidth = 2000;
        private int treeHeight = 2000;
        private int nodeWidth = 40;
        private int nodeHeight = 20;
        private Color nodeColor;
        private Color textColor;
        private Color lineColor;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int TreeWidth
        {
            get
            {
                return treeWidth;
            }
            set
            {
                treeWidth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TreeWidth)));
            }
        }
        public int TreeHeight
        {
            get
            {
                return treeHeight;
            }
            set
            {
                treeHeight = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TreeHeight)));
            }
        }
        public int NodeWidth
        {
            get
            {
                return nodeWidth;
            }
            set
            {
                nodeWidth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NodeWidth)));
            }
        }
        public int NodeHeight
        {
            get
            {
                return nodeHeight;
            }
            set
            {
                nodeHeight = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NodeHeight)));
            }
        }
        public Color NodeColor
        {
            get
            {
                return nodeColor;
            }
            set
            {
                nodeColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NodeColor)));
            }
        }
        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextColor)));
            }
        }
        public Color Linecolor
        {
            get
            {
                return lineColor;
            }
            set
            {
                lineColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Linecolor)));
            }
        }
    }
}
