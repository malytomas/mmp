
namespace mmp
{
    public class TriTreeView : System.Windows.Forms.TreeView
    {
        public class CheckedCounter
        {
            public int Checked;
            public int Total;

            public CheckedCounter(int check = 0, int total = 0)
            {
                Checked = check;
                Total = total;
            }

            public static CheckedCounter operator +(CheckedCounter l, CheckedCounter r)
            {
                return new CheckedCounter(l.Checked + r.Checked, l.Total + r.Total);
            }
        }

        public enum CheckedState : int { UnInitialised = -1, UnChecked, Checked, Mixed };

        public TriTreeView(): base()
        {
            StateImageList = new System.Windows.Forms.ImageList();
            for (int i = 0; i < 3; i++)
            {
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(16, 16);
                System.Drawing.Graphics chkGraphics = System.Drawing.Graphics.FromImage(bmp);
                switch (i)
                {
                    case 0:
                        System.Windows.Forms.CheckBoxRenderer.DrawCheckBox(chkGraphics, new System.Drawing.Point(0, 1), System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
                        break;
                    case 1:
                        System.Windows.Forms.CheckBoxRenderer.DrawCheckBox(chkGraphics, new System.Drawing.Point(0, 1), System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal);
                        break;
                    case 2:
                        System.Windows.Forms.CheckBoxRenderer.DrawCheckBox(chkGraphics, new System.Drawing.Point(0, 1), System.Windows.Forms.VisualStyles.CheckBoxState.MixedNormal);
                        break;
                }
                StateImageList.Images.Add(bmp);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            CheckBoxes = false;
        }

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode != System.Windows.Forms.Keys.Space)
                return;
            ToggleNodeState(SelectedNode);
        }

        protected override void OnNodeMouseClick(System.Windows.Forms.TreeNodeMouseClickEventArgs e)
        {
            base.OnNodeMouseClick(e);
            System.Windows.Forms.TreeViewHitTestInfo info = HitTest(e.X, e.Y);
            if (info == null || info.Location != System.Windows.Forms.TreeViewHitTestLocations.StateImage)
                return;
            ToggleNodeState(e.Node);
        }

        private void UpdateParentState(System.Windows.Forms.TreeNode tn)
        {
            if (tn == null)
                return;

            int OrigStateImageIndex = tn.StateImageIndex;
            CheckedCounter cnt = new CheckedCounter();
            foreach (System.Windows.Forms.TreeNode tnChild in tn.Nodes)
                cnt = cnt + (tnChild.Tag as CheckedCounter);

            if (cnt.Checked == cnt.Total)
                tn.StateImageIndex = (int)CheckedState.Checked;
            else if (cnt.Checked == 0)
                tn.StateImageIndex = (int)CheckedState.UnChecked;
            else
                tn.StateImageIndex = (int)CheckedState.Mixed;

            tn.Tag = cnt;
            UpdateParentState(tn.Parent);
        }

        private void UpdateChildState(System.Windows.Forms.TreeNode tn, int value)
        {
            if (tn.Nodes.Count == 0)
            {
                tn.StateImageIndex = value;
                CheckedCounter cnt = tn.Tag as CheckedCounter;
                cnt.Checked = value == (int)CheckedState.Checked ? 1 : 0;
                UpdateParentState(tn.Parent);
            }
            else
            {
                foreach (System.Windows.Forms.TreeNode tnChild in tn.Nodes)
                    UpdateChildState(tnChild, value);
            }
        }

        public void ToggleNodeState(System.Windows.Forms.TreeNode tn)
        {
            if (tn == null)
                return;
            UpdateChildState(tn, tn.StateImageIndex == (int)CheckedState.Checked ? (int)CheckedState.UnChecked : (int)CheckedState.Checked);
        }

        private CheckedCounter PrepareNodeCounterOne(System.Windows.Forms.TreeNodeCollection nodes)
        {
            CheckedCounter cnt = new CheckedCounter();
            foreach (System.Windows.Forms.TreeNode node in nodes)
            {
                node.StateImageIndex = (int)CheckedState.UnChecked;
                CheckedCounter tmp;
                if (node.Nodes.Count == 0)
                    tmp = new CheckedCounter(node.StateImageIndex == (int)CheckedState.Checked ? 1 : 0, 1);
                else
                    tmp = PrepareNodeCounterOne(node.Nodes);
                node.Tag = tmp;
                cnt = cnt + tmp;
            }
            return cnt;
        }

        public void PrepareNodeCounters()
        {
            PrepareNodeCounterOne(Nodes);
        }
    }
}
