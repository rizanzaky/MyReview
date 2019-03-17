using System;
using System.Collections.Generic;
using Foundation;
using MyReview.Core.Models;
using UIKit;

namespace MyReview.Views.Home.Targets
{
    public class TargetsTableSource : UITableViewSource
    {
        public List<TargetModel> DataSource { get; set; }
        private const string CellIdentifier = "TargetCell";

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier) ?? new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            var targetItem = DataSource[indexPath.Row];
            
            cell.TextLabel.Text = targetItem.Name;
            cell.Accessory = UITableViewCellAccessory.Checkmark;

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
            var cell = tableView.CellAt(indexPath);
            var action = UIContextualAction.FromContextualActionStyle
            (
                UIContextualActionStyle.Normal,
                cell.Accessory == UITableViewCellAccessory.Checkmark ? "UnMarkTarget" : "MarkTarget",
                (markTarget, view, success) =>
                {
                    cell.Accessory = cell.Accessory == UITableViewCellAccessory.Checkmark
                        ? UITableViewCellAccessory.None : UITableViewCellAccessory.Checkmark;
                    success(true);
                });

            action.BackgroundColor = UIColor.Blue;

            return action;
        }
    }
}