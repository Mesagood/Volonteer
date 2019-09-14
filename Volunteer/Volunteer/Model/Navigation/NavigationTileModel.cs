using Xamarin.Forms.Internals;

namespace Volunteer.Models.Navigation
{
    /// <summary>
    /// Model for the Navigation list with tiles page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class NavigationTileModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of an item.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the description of an item.
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// Gets or sets the image of an item.
        /// </summary>
        public string Skills { get; set; }

        /// <summary>
        /// Gets or sets the average rating of an item.
        /// </summary>

        #endregion
    }
}