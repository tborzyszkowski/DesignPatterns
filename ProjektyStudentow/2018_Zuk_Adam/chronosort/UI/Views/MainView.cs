using System;
using System.Windows.Forms;
using UI.Presenters;

namespace UI
{
    public partial class MainView : Form
    {
        public MainViewPresenter Presenter { get; set; }

        public MainView()
        {
            InitializeComponent();
        }

        private void butChangeDirectory_Click(object sender, EventArgs e)
        {
            this.Presenter.OnChangeDirectoryClick(lstDirectoryFiles, lblDirectoryPathValue);
        }

        private void butChangeNewOrderDirectory_Click(object sender, EventArgs e)
        {
            this.Presenter.OnChangeDirectoryClick(lstNewOrder, lblNewOrderDirectoryPathValue);
        }

        private void lstDirectoryFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Presenter.OnPictureFileSelect(lstDirectoryFiles);
        }

        private void lstNewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Presenter.OnPictureFileSelect(lstNewOrder);
        }

        private void butAddSelectedFiles_Click(object sender, EventArgs e)
        {
            this.Presenter.OnFilesAddButtonClick();
        }

        private void butRemoveSelectedFiles_Click(object sender, EventArgs e)
        {
            this.Presenter.OnRemoveFilesButtonClick();
        }

        private void butNewOrderUp_Click(object sender, EventArgs e)
        {
            this.Presenter.OnArrowButtonClick(-1);
        }

        private void butNewOrderDown_Click(object sender, EventArgs e)
        {
            this.Presenter.OnArrowButtonClick(1);
        }

        private void butBeginSort_Click(object sender, EventArgs e)
        {
            this.Presenter.OnBeginButtonClick();
        }
    }
}
