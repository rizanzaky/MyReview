using MyReview.Extensions;
using UIKit;

namespace MyReview.Views.Home
{
    public class HomeView : UIView
    {
        private DatePanelView _datePanel;

        public HomeView()
        {
            BuildView();
        }

        private void BuildView()
        {
            // create
            _datePanel = new DatePanelView();

            // styles
            BackgroundColor = UIColor.White;

            // hierarchy
            Add(_datePanel);

            // constraints
            _datePanel.AlignLeftAnchor(LeftAnchor, 5f);
            _datePanel.AlignTopAnchor(this, 20f);
            _datePanel.AlignRightAnchor(RightAnchor, 5f);
        }
    }
}