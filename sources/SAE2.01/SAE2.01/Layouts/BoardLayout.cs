using Microsoft.Maui.Layouts;

namespace SAE2._01.Layouts
{
    public class BoardLayout : Layout
    {
        protected override ILayoutManager CreateLayoutManager()
        {
            return new BoardLayoutManager(this);
        }

        public static readonly BindableProperty NbColumnsProperty
        = BindableProperty.Create(nameof(NbColumns),
                                  typeof(int),
                                  typeof(BoardLayout),
                                  7);
        public int NbColumns
        {
            get { return (int)GetValue(NbColumnsProperty); }
            set { SetValue(NbColumnsProperty, value); }
        }

        public static readonly BindableProperty NbRowsProperty
        = BindableProperty.Create(nameof(NbRows),
                                  typeof(int),
                                  typeof(BoardLayout),
                                  9);
        public int NbRows
        {
            get { return (int)GetValue(NbRowsProperty); }
            set { SetValue(NbRowsProperty, value); }
        }

        public static readonly BindableProperty HorizontalSpacingProperty
    = BindableProperty.Create(nameof(HorizontalSpacing),
                              typeof(double),
                              typeof(BoardLayout),
                              0.0);

        public double HorizontalSpacing
        {
            get { return (double)GetValue(HorizontalSpacingProperty); }
            set { SetValue(HorizontalSpacingProperty, value); }
        }

        public static readonly BindableProperty VerticalSpacingProperty
            = BindableProperty.Create(nameof(VerticalSpacing),
                                      typeof(double),
                                      typeof(BoardLayout),
                                      0.0);

        public double VerticalSpacing
        {
            get { return (double)GetValue(VerticalSpacingProperty); }
            set { SetValue(VerticalSpacingProperty, value); }
        }
    }
}
