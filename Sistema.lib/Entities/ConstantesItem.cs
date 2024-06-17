using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.lib.Entities
{
    public class ConstantesItem
    {
        public ConstantesItem() { }

        public ConstantesItem(string value, string text)
        {
            Value = value;
            Text = text;
        }

        public string Value { get; set; }
        public string Text { get; set; }
    }
}
