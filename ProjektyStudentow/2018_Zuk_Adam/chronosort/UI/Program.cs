using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Models;
using UI.Presenters;

namespace UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Collection of models
            var items = new ItemsCollection();

            // View
            var view = new MainView();

            // Presenter
            var presenter = new MainViewPresenter(items, view);

            Application.Run(view);
        }
    }
}
