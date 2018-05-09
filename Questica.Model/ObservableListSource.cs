using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;

namespace Questica.Model
{
    public class ObservableListSource<T> : ObservableCollection<T>, IListSource where T : class
    {
        // Fields
        private IBindingList _bindingList;

        // Methods
        IList IListSource.GetList() =>
            (this._bindingList ?? (this._bindingList = this.ToBindingList<T>()));

        // Properties
        bool IListSource.ContainsListCollection =>
            false;
    }
}