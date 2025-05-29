using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace osrs_toolbox
{
    public class NineSlicePanel : FrameworkElement
    {
        public static string[] SliceNames =
        {
            "top_left", "top", "top_right",
            "left", "center", "right",
            "bottom_left", "bottom", "bottom_right"
        };
        public ImageSource[] Slices = new ImageSource[9];
        public int BorderSize { get; set; } = 16;
        protected override void OnRender(DrawingContext dc)
        {
            if (Slices.Length != 9)
                return;
            foreach (ImageSource Slice in Slices)
            {
                if (Slice == null) return;
            }

            double width = ActualWidth;
            double height = ActualHeight;
            double b = BorderSize;

            Rect[] targets = 
            {
                new(0, 0, b, b),                     // TopLeft
                new(b, 0, width - 2 * b, b),         // Top
                new(width - b, 0, b, b),             // TopRight
                new(0, b, b, height - 2 * b),        // Left
                new(b, b, width - 2 * b, height - 2 * b), // Center
                new(width - b, b, b, height - 2 * b),     // Right
                new(0, height - b, b, b),            // BottomLeft
                new(b, height - b, width - 2 * b, b),// Bottom
                new(width - b, height - b, b, b)     // BottomRight
            };

            for (int i = 0; i < 9; i++)
            {
                if (Slices[i] != null)
                    dc.DrawImage(Slices[i], targets[i]);
            }
        }
    }
}
