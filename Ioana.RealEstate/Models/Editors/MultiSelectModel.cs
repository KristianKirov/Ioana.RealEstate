using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ioana.RealEstate.Models.Editors
{
    public class MultiSelectModelBase
    {
        public string Placeholder { get; set; }

        public SelectListItem[] Items { get; protected set; }
    }

    public class MultiSelectModel<TKey> : MultiSelectModelBase
    {
        public virtual TKey[] SelectedIds { get; set; }
    }

    //public class MultiSelectModelRequired<TKey> : MultiSelectModelBase
    //{
    //    [MinLength(1)]
    //    [Required]
    //    public TKey[] SelectedIds { get; set; }
    //}

    public class MultiSelectModel<TItems, TKey> : MultiSelectModel<TKey>
    {
        public void SetItems(IEnumerable<TItems> items, Func<TItems, object> textSelector, Func<TItems, TKey> valueSelector, Func<TItems, object> groupNameSelector = null)
        {
            TypedSelectItemsProvider<TItems, TKey> selectItemsProvider = new TypedSelectItemsProvider<TItems, TKey>();
            this.Items = selectItemsProvider.GetSelectItems(items, textSelector, valueSelector, groupNameSelector);
        }
    }

    public class MultiSelectModelRequired<TItems, TKey> : MultiSelectModel<TItems, TKey>
    {
        [MinLength(1)]
        [Required]
        public override TKey[] SelectedIds
        {
            get
            {
                return base.SelectedIds;
            }
            set
            {
                base.SelectedIds = value;
            }
        }
    }

    public class TypedSelectItemsProvider<TItems, TKey>
    {
        private Dictionary<string, SelectListGroup> selectGroups;

        private SelectListGroup GetSelectGroup(string groupName)
        {
            if (selectGroups == null)
            {
                selectGroups = new Dictionary<string, SelectListGroup>();
            }

            SelectListGroup foundGroup;
            if (this.selectGroups.TryGetValue(groupName, out foundGroup))
            {
                return foundGroup;
            }

            foundGroup = new SelectListGroup()
            {
                Name = groupName
            };

            this.selectGroups.Add(groupName, foundGroup);

            return foundGroup;
        }

        public SelectListItem[] GetSelectItems(IEnumerable<TItems> items, Func<TItems, object> textSelector, Func<TItems, TKey> valueSelector, Func<TItems, object> groupNameSelector)
        {
            SelectListItem[] selectItems = items.Select(i =>
            {
                SelectListItem selectItem = new SelectListItem()
                {
                    Text = textSelector(i).ToString(),
                    Value = valueSelector(i).ToString()
                };

                if (groupNameSelector != null)
                {
                    selectItem.Group = this.GetSelectGroup(groupNameSelector(i).ToString());
                }

                return selectItem;
            }).ToArray();

            return selectItems;
        }
    }
}