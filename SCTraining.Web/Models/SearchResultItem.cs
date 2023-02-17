using Sitecore.Configuration;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Converters;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SCTraining.Web.Models
{
    public abstract class SearchResultItem
    {
        private Item _item;

        public virtual Item Item
        {
            get { return _item ?? (_item = GetItem()); }
            set { _item = value; }
        }

        [IndexField(Sitecore.ContentSearch.BuiltinFields.Group)]
        [TypeConverter(typeof(IndexFieldIDValueConverter))]
        public virtual ID ItemId
        {
            get; set;
        }

        [IndexField(Sitecore.ContentSearch.BuiltinFields.UniqueId)]
        [TypeConverter(typeof(IndexFieldItemUriValueConverter))]
        public virtual ItemUri ItemUri
        {
            get; set;
        }

        [IndexField(Sitecore.ContentSearch.BuiltinFields.Language)]
        public virtual string Language
        {
            get; set;
        }

        [IndexField(Sitecore.ContentSearch.BuiltinFields.LatestVersion)]
        public bool IsLatestVersion
        {
            get; set;
        }

        [IndexField(Sitecore.ContentSearch.BuiltinFields.Path)]
        [TypeConverter(typeof(IndexFieldEnumerableConverter))]
        public virtual IEnumerable<ID> ItemAncestorsAndSelf
        {
            get; set;
        }

        [IndexField(Sitecore.ContentSearch.BuiltinFields.SmallUpdatedDate)]
        public DateTime Updated
        {
            get; set;
        }

        [IndexField(Sitecore.ContentSearch.BuiltinFields.AllTemplates)]
        [TypeConverter(typeof(IndexFieldEnumerableConverter))]
        public virtual IEnumerable<ID> ItemBaseTemplates
        {
            get; set;
        }

        private Item GetItem()
        {
            Assert.IsNotNull(ItemUri, "ItemUri is null.");
            return Factory.GetDatabase(ItemUri.DatabaseName).GetItem(ItemUri.ItemID, ItemUri.Language, ItemUri.Version);
        }
    }
}