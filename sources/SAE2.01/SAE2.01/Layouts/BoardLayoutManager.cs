using Microsoft.Maui.Layouts;

namespace SAE2._01.Layouts
{
    public class BoardLayoutManager : ILayoutManager
    {
        BoardLayout? BoardLayout { get; set; }
        double MaxCellWidth { get; set; }
        double MaxCellHeight { get; set; }
        double LayoutWidth { get; set; }
        double LayoutHeight { get; set; }

        public BoardLayoutManager(BoardLayout boardLayout)
        {
            BoardLayout = boardLayout;
        }
        public Size ArrangeChildren(Rect bounds)
        {
            if (BoardLayout == null)
                return new Size(LayoutWidth, LayoutHeight);

            var padding = BoardLayout.Padding;
            var horizontalSpacing = BoardLayout.HorizontalSpacing;
            var verticalSpacing = BoardLayout.VerticalSpacing;
            int nbColumns = BoardLayout.NbColumns;
            double top = padding.Top + bounds.Top;
            double left = padding.Left + bounds.Left;

            for (int cellId = 0; cellId < BoardLayout.Count; cellId++)
            {
                var cell = BoardLayout[cellId];
                int numRow = cellId / nbColumns;
                int numColumn = cellId - numRow * nbColumns; // ??

                double leftSide = left + numColumn * (MaxCellWidth + horizontalSpacing);
                double topSide = top + numRow * (MaxCellHeight + verticalSpacing);

                var destination = new Rect(leftSide, topSide, MaxCellWidth, MaxCellHeight);
                cell.Arrange(destination);
            }

            return new Size(LayoutWidth, LayoutHeight);
        }

        public Size Measure(double widthConstraint, double heightConstraint)
        {
            if (BoardLayout == null)
                return new Size(widthConstraint, heightConstraint);

            int nbRows = BoardLayout.NbRows;
            int nbColumns = BoardLayout.NbColumns;

            var padding = BoardLayout.Padding;
            var horizontalSpacing = BoardLayout.HorizontalSpacing;
            var verticalSpacing = BoardLayout.VerticalSpacing;

            MaxCellWidth = (widthConstraint - padding.HorizontalThickness - (nbColumns - 1) * horizontalSpacing) / nbColumns;
            MaxCellHeight = (heightConstraint - padding.VerticalThickness - (nbRows - 1) * verticalSpacing) / nbRows;

            double minDim = Math.Min(MaxCellHeight, MaxCellWidth);
            MaxCellHeight = minDim;  // ??
            MaxCellWidth = minDim;   // ??

            LayoutWidth = MaxCellWidth * nbColumns + (nbColumns - 1) * horizontalSpacing + padding.HorizontalThickness;
            LayoutHeight = MaxCellHeight * nbRows + (nbRows - 1) * verticalSpacing + padding.VerticalThickness;
            return new Size(LayoutWidth, LayoutHeight);
        }
    }
}
