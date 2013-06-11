using System;

namespace ProductsManagementApp
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FormatAttribute : Attribute
    {
        private readonly bool _isVisible = true;
        private readonly int _order;

        public FormatAttribute(bool isVisible, int order)
        {
            _isVisible = isVisible;
            _order = order;
        }

        public bool IsVisible
        {
            get { return _isVisible; }
        }

        public int Order
        {
            get { return _order; }
        }
    }
}