using Ioana.RealEstate.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ioana.RealEstate.Models.Editors
{
    public class DropDownModel<TKey>
    {
        public TKey Id { get; set; }

        public SelectListItem[] Items { get; protected set; }

        public string OptionLabel { get; set; }
    }

    public class DropDownModel<TItems, TKey> : DropDownModel<TKey>
    {
        public void SetItems(IEnumerable<TItems> items, Func<TItems, object> textSelector, Func<TItems, TKey> valueSelector, Func<TItems, object> groupNameSelector = null)
        {
            TypedSelectItemsProvider<TItems, TKey> selectItemsProvider = new TypedSelectItemsProvider<TItems, TKey>();

            this.Items = selectItemsProvider.GetSelectItems(items, textSelector, valueSelector, groupNameSelector);
        }
    }
}