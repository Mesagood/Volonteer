using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Volunteer.Models.Navigation;
using System.Net;
using System.IO;
using Volunteer.Commands;
using System.Linq;

namespace Volunteer.ViewModels.Navigation
{
    /// <summary>
    /// Viewmodel for the Navigation list with tile page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class NavigationTileViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="NavigationTileViewModel"/> class.
        /// </summary>
        public NavigationTileViewModel()
        {
            this.ItemSelectedCommand = new Command<object>(this.NavigateToNextPage);
           
        }
       
        
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemSelectedCommand { get; set; }

        /// <summary>
        /// Gets or sets a collection of values to be displayed in the Navigation list page.
        /// </summary>
        public ObservableCollection<NavigationTileModel> NavigationList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the Navigation list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        #endregion
    }
}