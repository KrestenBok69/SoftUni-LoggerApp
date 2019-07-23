namespace LoggerApp.Layouts
{
    /// <summary>
    /// Takes outside information to create a layout
    /// </summary>
    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string type)
        {
            ILayout layout = null;

            if (type == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                layout = new XmlLayout();
            }

            return layout;
        }
    }
}
