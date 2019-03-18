using System;
using System.Collections.Generic;
using Foundation;
using MyReview.Core.Models;
using MyReview.Core.ViewModels;
using UIKit;

namespace MyReview.Views.Home.Targets
{
    public class TargetsTableSource : UITableViewSource
    {
        public List<TargetModel> DataSource { get; set; }
        private const string CellIdentifier = "TargetCell";

        public TargetsViewModel ViewModel { get; set; }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier) ?? new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            var targetItem = DataSource[indexPath.Row];
            
            cell.TextLabel.Text = targetItem.Name;
            cell.Accessory = targetItem.IsMarked ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return DataSource?.Count ?? 0;
        }

        public override UISwipeActionsConfiguration GetTrailingSwipeActionsConfiguration(UITableView tableView, NSIndexPath indexPath)
        {
            var action = GetAction(tableView, indexPath);

            var leadingSwipe = UISwipeActionsConfiguration.FromActions(new[] { action });

            leadingSwipe.PerformsFirstActionWithFullSwipe = true;

            return leadingSwipe;
        }

        private UIContextualAction GetAction(UITableView tableView, NSIndexPath indexPath)
        {
            var item = DataSource[indexPath.Row];
            var action = UIContextualAction.FromContextualActionStyle
            (
                UIContextualActionStyle.Normal,
                item.IsMarked ? "UnMarkTarget" : "MarkTarget",
                (markTarget, view, success) =>
                {
                    DataSource[indexPath.Row].IsMarked = !item.IsMarked;
                    ViewModel.UpdateMarking(item.IsMarked, item.Id, item.Date);
                    tableView.ReloadRows(new[] {indexPath}, UITableViewRowAnimation.None);
                    success(true);
                });

            action.BackgroundColor = UIColor.Blue;

            return action;
        }
    }
}