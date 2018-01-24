using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using UI.Models;

namespace UI.Presenters
{
    public class MainViewPresenter
    {
        private ItemsCollection _items;

        private MainView _view;

        public MainViewPresenter(ItemsCollection items, MainView view)
        {
            this._items = items;
            this._view = view;

            this._view.Presenter = this;
        }

        public void OnChangeDirectoryClick(ListBox listBox, Label directoryValueLabel)
        {
            using (var directoryDialog = new FolderBrowserDialog())
            {
                var result = directoryDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(directoryDialog.SelectedPath))
                {
                    directoryValueLabel.Text = directoryDialog.SelectedPath;

                    var files = Directory.GetFiles(directoryDialog.SelectedPath);

                    if (listBox == this._view.lstDirectoryFiles)
                    {
                        listBox.Items.Clear();

                        foreach (var file in files)
                        {
                            listBox.Items.Add(file);
                        }
                    }
                }
            }
        }

        public void OnPictureFileSelect(ListBox sender)
        {
            if (sender.SelectedItem == null)
            {
                return;
            }
            this._view.picPreview.ImageLocation = sender.SelectedItem.ToString();
        }

        public void OnFilesAddButtonClick()
        {
            foreach (var item in this._view.lstDirectoryFiles.SelectedItems)
            {
                this._view.lstNewOrder.Items.Add(item.ToString());
            }
        }

        public void OnRemoveFilesButtonClick()
        {
            var selItems = new List<string>();

            foreach (var item in this._view.lstNewOrder.SelectedItems)
            {
                selItems.Add(item.ToString());
            }

            foreach (var item in selItems)
            {
                this._view.lstNewOrder.Items.Remove(item);
            }
        }

        public void OnArrowButtonClick(int direction)
        {
            if (this._view.lstNewOrder.SelectedItem == null || this._view.lstNewOrder.SelectedIndex < 0)
            {
                return;
            }

            int newIndex = this._view.lstNewOrder.SelectedIndex + direction;

            if (newIndex < 0 || newIndex >= this._view.lstNewOrder.Items.Count)
            {
                return;
            }

            var selected = this._view.lstNewOrder.SelectedItem;

            this._view.lstNewOrder.Items.Remove(selected);
            this._view.lstNewOrder.Items.Insert(newIndex, selected);
            this._view.lstNewOrder.SetSelected(newIndex, true);
        }

        public void OnBeginButtonClick()
        {
            var newOrderPath = this._view.lblNewOrderDirectoryPathValue.Text;

            if (!Directory.Exists(newOrderPath))
            {
                MessageBox.Show("Please select output directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this._view.lstNewOrder.Items.Count == 0)
            {
                MessageBox.Show("Please add files to new order list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var item in this._view.lstNewOrder.Items)
            {
                this._items.ItemList.Add(new Item(item.ToString(), newOrderPath));
            }

            var ser = new XmlSerializer(typeof(ItemsCollection));

            using (FileStream fs = new FileStream(Application.StartupPath + @"\config.xml", FileMode.Create))
            {
                ser.Serialize(fs, this._items);
            }

            Process.Start("ChronoSortCore.exe", string.Format("-source {0}", Application.StartupPath + @"\config.xml"));
        }
    }
}
