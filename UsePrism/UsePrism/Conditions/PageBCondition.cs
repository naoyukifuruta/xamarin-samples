using System;
using System.Collections.Generic;
using System.Text;

namespace UsePrism.Conditions
{
    internal sealed class PageBCondition
    {
        public string Title { get; }

        public string LabelG { get; }

        public PageBCondition(string title)
        {
            Title = title;
        }

        public PageBCondition(string title, string label)
        {
            Title = title;
            LabelG = label;
        }
    }
}
