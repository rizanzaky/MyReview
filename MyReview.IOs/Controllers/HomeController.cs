using System;
using Foundation;
using MyReview.Core.ViewModels;
using MyReview.Views.Home;
using MyReview.Views.Home.Targets;
using UIKit;

namespace MyReview.Controllers
{
    public class HomeController : UIViewController
    {
        private readonly HomeView _homeView;
        private readonly TargetsViewModel _homeViewModel;
        private readonly TargetsTableSource _targetsTableSource;
        private NSObject _keyboardDownObserver;

        private NSObject _keyboardUpObserver;
        private DateTime _panelDate;

        public HomeController()
        {
            _homeView = new HomeView();
            _homeViewModel = new TargetsViewModel();
            _targetsTableSource = new TargetsTableSource {ViewModel = _homeViewModel};
        }

        private DateTime PanelDate
        {
            get => _panelDate;
            set
            {
                _panelDate = value;
                _homeView.DatePanel.DateLabel.Text = $"{value:ddd, dd-MMM-yyyy}";
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

        private void OnKeyboardShown(NSNotification obj)
        {
            obj.UserInfo.TryGetValue(UIKeyboard.FrameEndUserInfoKey, out var keyboardFrameInfo);
            var keyboardFrame = keyboardFrameInfo as NSValue;
            _homeView.TargetViewBottomAnchor.Constant = -keyboardFrame?.CGRectValue.Height ?? -280;
        }

        private void OnTargetSaved(object sender, EventArgs e)
        {
            _homeView.AddTarget.NewTargetInput.ResignFirstResponder();
        }

        private void OnKeyboardHidden(NSNotification obj)
        {
            _homeView.TargetViewBottomAnchor.Constant = 0;
            _homeView.AddTarget.NewTargetInput.Text = string.Empty;
        }

        private void RegisterEvents()
        {
            _homeView.DatePanel.LeftButton.TouchUpInside += OnLeftButtonClicked;
            _homeView.DatePanel.RightButton.TouchUpInside += OnRightButtonClicked;
            _keyboardUpObserver =
                NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidShowNotification, OnKeyboardShown);
            _homeView.AddTarget.CancelTargetButton.TouchUpInside += OnTargetSaved;
            _keyboardDownObserver =
                NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, OnKeyboardHidden);
        }

        private void UnregisterEvents()
        {
            _homeView.DatePanel.LeftButton.TouchUpInside -= OnLeftButtonClicked;
            _homeView.DatePanel.RightButton.TouchUpInside -= OnRightButtonClicked;
            NSNotificationCenter.DefaultCenter.RemoveObserver(_keyboardUpObserver);
            _homeView.AddTarget.CancelTargetButton.TouchUpInside -= OnTargetSaved;
            NSNotificationCenter.DefaultCenter.RemoveObserver(_keyboardDownObserver);
        }
    }
}