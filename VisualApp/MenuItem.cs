using System;
using System.Collections.Generic;
using System.Text;

namespace VisualApp
{
    public delegate void MenuItemAction(object sender, object contextObject);
    public class MenuItem
    {
        public char ShortcutChar { get; set; }
        public String Text { get; set; }
        public MenuItemAction ActionToExecute { get; set;}
        public object ContextObject { get; set; }
    }
}
