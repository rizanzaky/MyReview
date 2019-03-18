using System;
using MyReview.Core.ViewModels;
using MyReview.Views.Home;
using MyReview.Views.Home.Targets;
using UIKit;

namespace MyReview.Controllers
{
    public class HomeController : UIViewController
    {
        private readonly HomeView _homeView;
        private DateTime _panelDate;
        private readonly TargetsTableSource _targetsTableSource;
        private readonly TargetsViewModel _homeViewModel;

        public HomeController()
        {
            _homeView = new HomeView();
            _targetsTableSource = new TargetsTableSource();
            _homeViewModel = new TargetsViewModel();
        }

        private DateTime PanelDate
        {
            get => _panelDate;
            set
            {
                _panelDate = value;
                _homeView.DatePanel.DateLabel.Text = value.ToShortDateString();
            }
        }

        public override void LoadView()
        {
            View = _homeView;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            PanelDate = DateTime.Now;
            _targetsTableSource.DataSource = _homeViewModel.Targets;
            _homeView.TargetsTable.Source = _targetsTableSource;

            RegisterEvents();
        }

        public override void WillMoveToParentViewController(UIViewController parent)
        {
            base.WillMoveToParentViewController(parent);

            if (parent != null) UnregisterEvents();
        }

        private void OnRightButtonClicked(object sender, EventArgs args)
        {
            PanelDate = PanelDate.AddDays(1);
            _homeViewModel.MergeMarkingsIntoTargets(PanelDate);
            _targetsTableSource.DataSource = _homeViewModel.Targets;
            _homeView.TargetsTable.ReloadData();
        }

        private void OnLeftButtonClicked(object sender, EventArgs args)
        {
            PanelDate = PanelDate.AddDays(-1);
            _homeViewModel.MergeMarkingsIntoTargets(PanelDate);
            _targetsTableSource.DataSource = _homeViewModel.Targets;
            _homeView.TargetsTable.ReloadData();
        }

        private void RegisterEvents()
        {
            _homeView.DatePanel.LeftButton.TouchUpInside += OnLeftButtonClicked;
            _homeView.DatePanel.RightButton.TouchUpInside += OnRightButtonClicked;

        }

        private void UnregisterEvents()
        {
            _homeView.DatePanel.LeftButton.TouchUpInside -= OnLeftButtonClicked;
            _homeView.DatePanel.RightButton.TouchUpInside -= OnRightButtonClicked;
        }
    }
}